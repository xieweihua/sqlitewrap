namespace SQLiteView
{
    partial class Drug
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridViewDrug = new System.Windows.Forms.DataGridView();
            this.button_load = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.button_delete = new System.Windows.Forms.Button();
            this.button_edit = new System.Windows.Forms.Button();
            this.button_add = new System.Windows.Forms.Button();
            this.button_search = new System.Windows.Forms.Button();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.contextMenuStripDrug = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDrug)).BeginInit();
            this.contextMenuStripDrug.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewDrug
            // 
            this.dataGridViewDrug.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridViewDrug.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders;
            this.dataGridViewDrug.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridViewDrug.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDrug.Location = new System.Drawing.Point(12, 32);
            this.dataGridViewDrug.Name = "dataGridViewDrug";
            this.dataGridViewDrug.RowTemplate.Height = 23;
            this.dataGridViewDrug.ShowEditingIcon = false;
            this.dataGridViewDrug.Size = new System.Drawing.Size(443, 279);
            this.dataGridViewDrug.TabIndex = 0;
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(484, 157);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(75, 23);
            this.button_load.TabIndex = 1;
            this.button_load.Text = "刷新";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button_load_Click);
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(484, 70);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 2;
            this.button_save.Text = "保存";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_delete
            // 
            this.button_delete.Location = new System.Drawing.Point(484, 128);
            this.button_delete.Name = "button_delete";
            this.button_delete.Size = new System.Drawing.Size(75, 23);
            this.button_delete.TabIndex = 3;
            this.button_delete.Text = "删除";
            this.button_delete.UseVisualStyleBackColor = true;
            this.button_delete.Click += new System.EventHandler(this.button_delete_Click);
            // 
            // button_edit
            // 
            this.button_edit.Location = new System.Drawing.Point(484, 99);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(75, 23);
            this.button_edit.TabIndex = 5;
            this.button_edit.Text = "编辑";
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // button_add
            // 
            this.button_add.Location = new System.Drawing.Point(484, 41);
            this.button_add.Name = "button_add";
            this.button_add.Size = new System.Drawing.Size(75, 23);
            this.button_add.TabIndex = 6;
            this.button_add.Text = "增加";
            this.button_add.UseVisualStyleBackColor = true;
            this.button_add.Click += new System.EventHandler(this.button_add_Click);
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(484, 186);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(75, 23);
            this.button_search.TabIndex = 8;
            this.button_search.Text = "查找";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // textBox_search
            // 
            this.textBox_search.Location = new System.Drawing.Point(484, 227);
            this.textBox_search.Multiline = true;
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(75, 30);
            this.textBox_search.TabIndex = 9;
            // 
            // contextMenuStripDrug
            // 
            this.contextMenuStripDrug.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem});
            this.contextMenuStripDrug.Name = "contextMenuStripDrug";
            this.contextMenuStripDrug.Size = new System.Drawing.Size(125, 26);
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ToolStripMenuItem.Text = "计算总价";
            this.ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // Drug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 347);
            this.ContextMenuStrip = this.contextMenuStripDrug;
            this.Controls.Add(this.textBox_search);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.button_add);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.button_delete);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.dataGridViewDrug);
            this.IsMdiContainer = true;
            this.Name = "Drug";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Drug";
            this.Load += new System.EventHandler(this.Drug_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDrug)).EndInit();
            this.contextMenuStripDrug.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewDrug;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_delete;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.TextBox textBox_search;
        private string table_name = "drug";
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDrug;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
    }
}

