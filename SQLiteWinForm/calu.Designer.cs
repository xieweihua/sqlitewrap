namespace SQLiteView
{
    partial class calu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridFormulaView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStripCalu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.caluToatalCost = new System.Windows.Forms.ToolStripMenuItem();
            this.delteDrug = new System.Windows.Forms.ToolStripMenuItem();
            this.addDrug = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFormulaView)).BeginInit();
            this.contextMenuStripCalu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridFormulaView
            // 
            this.dataGridFormulaView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFormulaView.Location = new System.Drawing.Point(12, 38);
            this.dataGridFormulaView.Name = "dataGridFormulaView";
            this.dataGridFormulaView.RowTemplate.Height = 23;
            this.dataGridFormulaView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridFormulaView.Size = new System.Drawing.Size(371, 239);
            this.dataGridFormulaView.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "已选中的药品:";
            // 
            // contextMenuStripCalu
            // 
            this.contextMenuStripCalu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.caluToatalCost,
            this.delteDrug,
            this.addDrug});
            this.contextMenuStripCalu.Name = "contextMenuStripCalu";
            this.contextMenuStripCalu.Size = new System.Drawing.Size(153, 92);
            // 
            // caluToatalCost
            // 
            this.caluToatalCost.Name = "caluToatalCost";
            this.caluToatalCost.Size = new System.Drawing.Size(152, 22);
            this.caluToatalCost.Text = "计算总价";
            this.caluToatalCost.Click += new System.EventHandler(this.caluToatalCost_Click);
            // 
            // delteDrug
            // 
            this.delteDrug.Name = "delteDrug";
            this.delteDrug.Size = new System.Drawing.Size(152, 22);
            this.delteDrug.Text = "删除";
            this.delteDrug.Click += new System.EventHandler(this.delteDrug_Click);
            // 
            // addDrug
            // 
            this.addDrug.Name = "addDrug";
            this.addDrug.Size = new System.Drawing.Size(152, 22);
            this.addDrug.Text = "添加";
            this.addDrug.Click += new System.EventHandler(this.addDrug_Click);
            // 
            // calu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 311);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridFormulaView);
            this.Name = "calu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "计算总价";
            this.Load += new System.EventHandler(this.calu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFormulaView)).EndInit();
            this.contextMenuStripCalu.ResumeLayout(false);
            this.ContextMenuStrip = this.contextMenuStripCalu;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridFormulaView;
        private System.Windows.Forms.Label label1;
        private string table_name = "drug";
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCalu;
        private System.Windows.Forms.ToolStripMenuItem caluToatalCost;
        private System.Windows.Forms.ToolStripMenuItem delteDrug;
        private System.Windows.Forms.ToolStripMenuItem addDrug;
    }
}