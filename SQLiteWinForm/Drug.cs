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
            DataGridViewCheckBoxColumn column = new DataGridViewCheckBoxColumn();
            {
                column.HeaderText = "ѡ��";
                column.Name = "select";
                column.FlatStyle = FlatStyle.System;
                column.CellTemplate.ReadOnly = false;
                column.CellTemplate.Style.BackColor = System.Drawing.Color.Beige;
            }

            dataGridViewDrug.Columns.Insert(0, column);
         
            RefreshTable();
            InitTable();
        }

        private void setReadOnlyOfRows(bool state)
        {
            int count = dataGridViewDrug.Columns.Count;
            for (int i = 2; i < count; i++)
            {
                dataGridViewDrug.Columns[i].ReadOnly = state;
            }
        }

        private void InitTable()
        {
            dataGridViewDrug.AllowUserToAddRows = false;
            dataGridViewDrug.Columns[1].HeaderText = "���";
            dataGridViewDrug.Columns[1].ReadOnly = true;
            dataGridViewDrug.Columns[2].HeaderText = "����";
            dataGridViewDrug.Columns[3].HeaderText = "����";
            dataGridViewDrug.Columns[4].HeaderText = "����";
            dataGridViewDrug.Columns[5].HeaderText = "����";
            dataGridViewDrug.Columns[6].HeaderText = "������Ϣ";

            int count = dataGridViewDrug.RowCount;
            for (int i = 0; i < count; i++)
            {
                dataGridViewDrug.Rows[i].Cells[1].Value = i + 1;       
            }
            setReadOnlyOfRows(true);
        }

        //ˢ������Դ
        private void RefreshTable()
        {
            dataGridViewDrug.DataSource = dba.ReadTable(table_name);
        }
        //��������Դ
        private void UpdateTable(DataTable dt)
        {
            setReadOnlyOfRows(true);
            if (dt != null)
            {
                if (dba.UpdateTable(dt, "drug"))
                {
                    RefreshTable();
                    MessageBox.Show("�����ɹ�!", "Drug", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("����ʧ��!", "Drug", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }
        //���
        private void button_load_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }
        
        //�������޸�
        private void button_save_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dataGridViewDrug.DataSource as DataTable;
            dataGridViewDrug.AllowUserToAddRows = false;
            UpdateTable(dt);
            button_edit.Enabled = true;
        }
        
        //ɾ��
        private void button_delete_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dataGridViewDrug.DataSource as DataTable;
            if (this.dataGridViewDrug.CurrentRow == null)
            {
                MessageBox.Show("��ѡ��Ҫɾ����ҩ��.", "Drug", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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
                MessageBox.Show("������ҩƷ����.", "Drug", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            dataGridViewDrug.DataSource = dba.ReadTableByNameFuzzy(table_name, textBox_search.Text);
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> drug_names = new List<string>();

            for (int i = 0; i < dataGridViewDrug.Rows.Count; i++)
            {
                if ((bool)dataGridViewDrug.Rows[i].Cells[0].EditedFormattedValue == true)
                {

                    drug_names.Add(dataGridViewDrug.Rows[i].Cells[2].Value.ToString());
                }
            }

            if (drug_names.Count <= 0)
            {
                MessageBox.Show("������ѡ��һ��ҩƷ.", "Drug", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            calu c = new calu(drug_names);
            c.Show();
        }
    }
}