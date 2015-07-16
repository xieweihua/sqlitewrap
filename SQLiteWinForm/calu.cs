using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SQLiteView
{
    public partial class calu : Form
    {
        DataAccess dba;
        public calu(List<string> names)
        {
            InitializeComponent();
            dataGridFormulaView.AllowUserToAddRows = false;   
            dba = new DataAccess();
            drug_names = names;
            initTable();
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            dataGridFormulaView.Columns[0].HeaderText = "名称";
            dataGridFormulaView.Columns[1].HeaderText = "单价";
            column.HeaderText = "重量";
            column.DefaultCellStyle.NullValue = "0";
            dataGridFormulaView.Columns.Add(column);
            setReadOnlyOfRows();
        }

        private void setReadOnlyOfRows()
        {
            dataGridFormulaView.Columns[0].ReadOnly = true;
            dataGridFormulaView.Columns[1].ReadOnly = true;
            dataGridFormulaView.Columns[2].ReadOnly = false;
        }

        public void addDrugByName(string drugName)
        {
            DataTable dt = dba.ReadTableByName(table_name, drugName);
            if (drug_names.Contains(drugName))
            {
                MessageBox.Show("已经存在药品：" + drugName, "Drug", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("找不到药品：" + drugName, "Drug", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            drug_names.Add(drugName);
            initTable();
        }

        private void initTable()
        {
            string name_list = "(";
            string last = drug_names[drug_names.Count - 1];
            foreach (string name in drug_names)
            {
                if (name != last)
                    name_list += ("'" + name + "',");
                else
                    name_list += ("'" +  name + "')");
            }
            dataGridFormulaView.DataSource = dba.ReadFormula(table_name, name_list);
        }

        private void calu_Load(object sender, EventArgs e)
        { 
        }

        private List<string> drug_names;

        private void caluToatalCost_Click(object sender, EventArgs e)
        {
            double total = 0.0;
            for (int i = 0; i < dataGridFormulaView.Rows.Count; i++)
            {
                if (dataGridFormulaView.Rows[i].Cells[0].Value != null)
                    total += (double)dataGridFormulaView.Rows[i].Cells[2].Value * double.Parse(dataGridFormulaView.Rows[i].Cells[0].Value.ToString());
            }
            MessageBox.Show("总价：" + total.ToString(), "Drug", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void delteDrug_Click(object sender, EventArgs e)
        {
            DataTable dt = this.dataGridFormulaView.DataSource as DataTable;
            if (this.dataGridFormulaView.CurrentRow == null)
            {
                MessageBox.Show("请选择要删除的药物.", "Drug", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            drug_names.Remove(this.dataGridFormulaView.CurrentRow.Cells[1].Value.ToString());
            DataRowView rowview = this.dataGridFormulaView.CurrentRow.DataBoundItem as DataRowView;
            if (rowview != null)
            {
                rowview.Row.Delete();
            }
        }

        private void addDrug_Click(object sender, EventArgs e)
        {
            input c = new input(this);
            c.Show();
        }
    }
}
