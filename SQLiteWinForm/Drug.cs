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
        private List<string> drug_names;
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
            drug_names = new List<string>();
        }

        private void setCheckBoxState()
        {
            int count = dataGridViewDrug.Rows.Count;
            if (drug_names == null)
            {
                return;
            }
            for (int i = 0; i < count; i++)
            {
                DataGridViewRow row = dataGridViewDrug.Rows[i];
                if( drug_names.Contains(row.Cells["name"].Value.ToString()))
                {
                    row.Cells[0].Value = true;
                }
            }
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
            dataGridViewDrug.Columns[4].HeaderText = "������Ϣ";

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
            setCheckBoxState();
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
            setCheckBoxState();
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (drug_names.Count <= 0)
            {
                MessageBox.Show("������ѡ��һ��ҩƷ.", "Drug", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            calu c = new calu(drug_names);
            c.Show();
        }

        private void dataGridViewDrug_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewDrug.IsCurrentCellDirty)
            {
                dataGridViewDrug.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }    
        }

        private void dataGridViewDrug_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != 0)
            {
                return;
            }
            DataGridViewRow row = dataGridViewDrug.Rows[e.RowIndex];
            string name = row.Cells[2].Value.ToString();
            if ((bool)row.Cells[0].EditedFormattedValue == true)
            {
                if (!drug_names.Contains(name))
                {
                    drug_names.Add(name);
                }
            }
            else
            {
                if (drug_names.Contains(name))
                {
                    drug_names.Remove(name);
                }
            }   
        }

        private void ResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = dataGridViewDrug.Rows.Count;
            if (drug_names == null)
            {
                return;
            }
            for (int i = 0; i < count; i++)
            {
                dataGridViewDrug.Rows[i].Cells[0].Value = false;
            }
        }
    }
}