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
    public partial class input : Form
    {
        public input(calu owner)
        {
            InitializeComponent();
            this.Owner = owner;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            string name = text_box_drug_name.Text;
            if (name == null || name.Equals(""))
            {
                MessageBox.Show("请输入药品名称.", "Drug", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }

            ((calu)this.Owner).addDrugByName(name);
            this.Close();
        }
    }
}
