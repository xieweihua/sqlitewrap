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
            this.textBox_weight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_drug = new System.Windows.Forms.Label();
            this.label_cost = new System.Windows.Forms.Label();
            this.button_calu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_weight
            // 
            this.textBox_weight.Location = new System.Drawing.Point(88, 85);
            this.textBox_weight.Name = "textBox_weight";
            this.textBox_weight.Size = new System.Drawing.Size(100, 21);
            this.textBox_weight.TabIndex = 0;
            this.textBox_weight.TextChanged += new System.EventHandler(this.textBox_weight_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "请输入重量：";
            // 
            // label_drug
            // 
            this.label_drug.AutoSize = true;
            this.label_drug.Font = new System.Drawing.Font("SimSun", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_drug.Location = new System.Drawing.Point(48, 24);
            this.label_drug.Name = "label_drug";
            this.label_drug.Size = new System.Drawing.Size(0, 19);
            this.label_drug.TabIndex = 2;
            // 
            // label_cost
            // 
            this.label_cost.AutoSize = true;
            this.label_cost.Font = new System.Drawing.Font("SimSun", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_cost.ForeColor = System.Drawing.Color.Red;
            this.label_cost.Location = new System.Drawing.Point(57, 156);
            this.label_cost.Name = "label_cost";
            this.label_cost.Size = new System.Drawing.Size(0, 20);
            this.label_cost.TabIndex = 3;
            // 
            // button_calu
            // 
            this.button_calu.Location = new System.Drawing.Point(194, 83);
            this.button_calu.Name = "button_calu";
            this.button_calu.Size = new System.Drawing.Size(75, 23);
            this.button_calu.TabIndex = 4;
            this.button_calu.Text = "计算";
            this.button_calu.UseVisualStyleBackColor = true;
            this.button_calu.Click += new System.EventHandler(this.button_calu_Click);
            // 
            // calu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 262);
            this.Controls.Add(this.button_calu);
            this.Controls.Add(this.label_cost);
            this.Controls.Add(this.label_drug);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_weight);
            this.Name = "calu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "计算总价";
            this.Load += new System.EventHandler(this.calu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_weight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_drug;
        private System.Windows.Forms.Label label_cost;
        private System.Windows.Forms.Button button_calu;
    }
}