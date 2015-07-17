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
            this.delteDrug = new System.Windows.Forms.ToolStripMenuItem();
            this.addDrug = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelTotalCost = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFormulaView)).BeginInit();
            this.contextMenuStripCalu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridFormulaView
            // 
            this.dataGridFormulaView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridFormulaView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridFormulaView.Location = new System.Drawing.Point(12, 38);
            this.dataGridFormulaView.Name = "dataGridFormulaView";
            this.dataGridFormulaView.RowTemplate.Height = 23;
            this.dataGridFormulaView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridFormulaView.Size = new System.Drawing.Size(409, 237);
            this.dataGridFormulaView.TabIndex = 5;
            this.dataGridFormulaView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDrug_CellValueChanged);
            this.dataGridFormulaView.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridViewDrug_CurrentCellDirtyStateChanged);
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
            this.delteDrug,
            this.addDrug,
            this.PrintToolStripMenuItem});
            this.contextMenuStripCalu.Name = "contextMenuStripCalu";
            this.contextMenuStripCalu.Size = new System.Drawing.Size(101, 70);
            // 
            // delteDrug
            // 
            this.delteDrug.Name = "delteDrug";
            this.delteDrug.Size = new System.Drawing.Size(100, 22);
            this.delteDrug.Text = "删除";
            this.delteDrug.Click += new System.EventHandler(this.delteDrug_Click);
            // 
            // addDrug
            // 
            this.addDrug.Name = "addDrug";
            this.addDrug.Size = new System.Drawing.Size(100, 22);
            this.addDrug.Text = "添加";
            this.addDrug.Click += new System.EventHandler(this.addDrug_Click);
            // 
            // PrintToolStripMenuItem
            // 
            this.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem";
            this.PrintToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.PrintToolStripMenuItem.Text = "打印";
            this.PrintToolStripMenuItem.Click += new System.EventHandler(this.PrintToolStripMenuItem_Click);
            // 
            // labelTotalCost
            // 
            this.labelTotalCost.AutoSize = true;
            this.labelTotalCost.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelTotalCost.ForeColor = System.Drawing.Color.Red;
            this.labelTotalCost.Location = new System.Drawing.Point(52, 299);
            this.labelTotalCost.Name = "labelTotalCost";
            this.labelTotalCost.Size = new System.Drawing.Size(76, 19);
            this.labelTotalCost.TabIndex = 7;
            this.labelTotalCost.Text = "总价：0";
            // 
            // calu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 335);
            this.ContextMenuStrip = this.contextMenuStripCalu;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridFormulaView);
            this.Controls.Add(this.labelTotalCost);
            this.Name = "calu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "计算总价";
            this.Load += new System.EventHandler(this.calu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridFormulaView)).EndInit();
            this.contextMenuStripCalu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridFormulaView;
        private System.Windows.Forms.Label label1;
        private string table_name = "drug";
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCalu;
        private System.Windows.Forms.ToolStripMenuItem delteDrug;
        private System.Windows.Forms.ToolStripMenuItem addDrug;
        private System.Windows.Forms.ToolStripMenuItem PrintToolStripMenuItem;
        private System.Windows.Forms.Label labelTotalCost;
    }
}