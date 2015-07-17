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
            
            dataGridFormulaView.Columns[0].HeaderText = "名称";
            dataGridFormulaView.Columns[1].HeaderText = "单价";
            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.HeaderText = "剂量";
            column.Name = "weight";
            column.DefaultCellStyle.NullValue = "0";
            dataGridFormulaView.Columns.Add(column);

            DataGridViewTextBoxColumn column_cost = new DataGridViewTextBoxColumn();
            column_cost.HeaderText = "价格";
            column_cost.Name = "cost";
            column_cost.DefaultCellStyle.NullValue = "0";
            dataGridFormulaView.Columns.Add(column_cost);

            setReadOnlyOfRows();
        }

        private void setReadOnlyOfRows()
        {
            dataGridFormulaView.Columns[0].ReadOnly = true;
            dataGridFormulaView.Columns[1].ReadOnly = true;
            dataGridFormulaView.Columns[2].ReadOnly = false;
            dataGridFormulaView.Columns[3].ReadOnly = true;
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

        private DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // 列强制转换
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[count].HeaderText.ToString());
                dt.Columns.Add(dc);
            }

            // 循环行
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    if (dgv.Rows[count].Cells[countsub].Value == null)
                        dr[countsub] = "0";
                    else
                        dr[countsub] = Convert.ToString(dgv.Rows[count].Cells[countsub].Value);
                }
                dt.Rows.Add(dr);
            }
            DataRow drTotal = dt.NewRow();
            drTotal[0] = "总价";
            drTotal[1] = this.caluToatalCost().ToString();
            dt.Rows.Add(drTotal);

            dt.Columns[2].SetOrdinal(0);
            dt.Columns[3].SetOrdinal(1);  
            return dt;
        }

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dt = GetDgvToTable(dataGridFormulaView);
            DataSet dy = new DataSet();
            dy.Tables.Add(dt);
            DLLFullPrint.MyDLL.TakeOver(dy);
        }

        private void dataGridViewDrug_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridFormulaView.IsCurrentCellDirty)
            {
                dataGridFormulaView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridViewDrug_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            DataGridViewCellCollection cells = dataGridFormulaView.Rows[e.RowIndex].Cells;
            cells["cost"].Value = Double.Parse(cells["weight"].Value.ToString()) * Double.Parse(cells["price"].Value.ToString());

            double cost = 0;
            for(int i = 0; i < dataGridFormulaView.Rows.Count; i++) 
            {
                if (dataGridFormulaView.Rows[i].Cells["cost"].Value != null)
                    cost += double.Parse(dataGridFormulaView.Rows[i].Cells["cost"].Value.ToString());
            }
            labelTotalCost.Text = "总价：" + cost.ToString();
        }

        private double caluToatalCost()
        {
            double total = 0.0;
            for (int i = 0; i < dataGridFormulaView.Rows.Count; i++)
            {
                if (dataGridFormulaView.Rows[i].Cells[0].Value != null)
                    total += double.Parse(dataGridFormulaView.Rows[i].Cells[1].Value.ToString());
            }
            return total;
        }
    }
}
