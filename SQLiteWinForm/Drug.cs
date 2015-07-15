using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace SQLiteView
{
    public partial class Drug : Form
    {
        DataAccess dba;
        public Drug()
        {
            InitializeComponent();
            dba = new DataAccess();
            RefreshTable();
        }

        private void setReadOnlyOfRows(bool state)
        {
            int count = dataGridViewDrug.Columns.Count;
            for (int i = 0; i < count; i++)
            {
                dataGridViewDrug.Columns[i].ReadOnly = state;
            }
        }

        //刷新数据源
        private void RefreshTable()
        {
            dataGridViewDrug.DataSource = dba.ReadTable(table_name);
            setReadOnlyOfRows(true);
            dataGridViewDrug.AllowUserToAddRows = false;
            dataGridViewDrug.Columns[0].HeaderText = "序号";
            dataGridViewDrug.Columns[1].HeaderText = "名称";
            dataGridViewDrug.Columns[2].HeaderText = "单价";
            dataGridViewDrug.Columns[3].HeaderText = "产地";
            dataGridViewDrug.Columns[4].HeaderText = "种类";
            dataGridViewDrug.Columns[5].HeaderText = "描述信息";

            int count = dataGridViewDrug.RowCount;
            for (int i = 0; i < count; i++)
            {
                dataGridViewDrug.Rows[i].Cells[0].Value = i + 1;       
            }
        }
        //更新数据源
        private void UpdateTable(DataTable dt)
        {
            setReadOnlyOfRows(true);
            if (dt != null)
            {
                if (dba.UpdateTable(dt, "drug"))
                {
                    RefreshTable();
                    MessageBox.Show("操作成功!", "Drug", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("操作失败!", "Drug", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        //浏览
        private void button_load_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
        
        //新增、修改
        private void button_save_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dataGridViewDrug.DataSource as DataTable;
            dataGridViewDrug.AllowUserToAddRows = false;
            UpdateTable(dt);
            button_edit.Enabled = true;
        }
        
        //删除
        private void button_delete_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dataGridViewDrug.DataSource as DataTable;
            if (this.dataGridViewDrug.CurrentRow == null)
            {
                MessageBox.Show("请选择要删除的药物.", "Drug", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            DataRowView rowview = this.dataGridViewDrug.CurrentRow.DataBoundItem as DataRowView;
            if (rowview != null)
            {
                rowview.Row.Delete();
                UpdateTable(dt);
            }
            
        }

        private void Drug_Load(object sender, EventArgs e)
        {

        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            setReadOnlyOfRows(false);
            button_edit.Enabled = false;
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            dataGridViewDrug.AllowUserToAddRows = true;
            setReadOnlyOfRows(false);
        }

        private void data_error(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Drug", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            return;
        }

        private void button_search_Click(object sender, EventArgs e)
        {
            if (textBox_search.Text == "")
            {
                MessageBox.Show("请输入药品名称.", "Drug", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            dataGridViewDrug.DataSource = dba.ReadTableByName(table_name, textBox_search.Text);
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calu c = new calu(this.dataGridViewDrug.CurrentRow);
            c.Show();
        }
    }
}