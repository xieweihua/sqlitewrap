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
        public calu(DataGridViewRow data)
        {
            InitializeComponent();
            this.data = data;
            label_drug.Text = "名称：" + data.Cells[1].Value + "\n";
            label_drug.Text += "单价：" + data.Cells[2].Value;
        }

        private void calu_Load(object sender, EventArgs e)
        {

        }

        private DataGridViewRow data;

        private void textBox_weight_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_calu_Click(object sender, EventArgs e)
        {
            double weight = 0.0;
            double price = 0.0;
            try
            {
                price = double.Parse(data.Cells[2].Value.ToString());
                weight = double.Parse(textBox_weight.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Drug", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            label_cost.Text = "总价：";
            label_cost.Text += (price * weight).ToString();
        }
    }
}
