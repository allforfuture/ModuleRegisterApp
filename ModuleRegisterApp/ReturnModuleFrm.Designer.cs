﻿namespace ModuleRegisterApp
{
    partial class ReturnModuleFrm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.result_lbl = new System.Windows.Forms.Label();
            this.site_txt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.reason_txt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.model_cbx = new System.Windows.Forms.ComboBox();
            this.submit_btn = new System.Windows.Forms.Button();
            this.qty_txt = new System.Windows.Forms.TextBox();
            this.barcode_txt = new System.Windows.Forms.TextBox();
            this.moduleList_dgv = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moduleList_dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.result_lbl);
            this.groupBox1.Controls.Add(this.site_txt);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.reason_txt);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.model_cbx);
            this.groupBox1.Controls.Add(this.submit_btn);
            this.groupBox1.Controls.Add(this.qty_txt);
            this.groupBox1.Controls.Add(this.barcode_txt);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(852, 174);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "信息登记";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(438, 135);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "数量:";
            // 
            // result_lbl
            // 
            this.result_lbl.AutoSize = true;
            this.result_lbl.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.result_lbl.ForeColor = System.Drawing.Color.Red;
            this.result_lbl.Location = new System.Drawing.Point(348, 136);
            this.result_lbl.Name = "result_lbl";
            this.result_lbl.Size = new System.Drawing.Size(0, 14);
            this.result_lbl.TabIndex = 16;
            // 
            // site_txt
            // 
            this.site_txt.Location = new System.Drawing.Point(361, 21);
            this.site_txt.Name = "site_txt";
            this.site_txt.Size = new System.Drawing.Size(100, 21);
            this.site_txt.TabIndex = 15;
            this.site_txt.Text = "M-1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(317, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "位置:";
            // 
            // reason_txt
            // 
            this.reason_txt.Enabled = false;
            this.reason_txt.Location = new System.Drawing.Point(68, 63);
            this.reason_txt.Multiline = true;
            this.reason_txt.Name = "reason_txt";
            this.reason_txt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.reason_txt.Size = new System.Drawing.Size(663, 55);
            this.reason_txt.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "原因:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "马达ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "机种:";
            // 
            // model_cbx
            // 
            this.model_cbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.model_cbx.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.model_cbx.FormattingEnabled = true;
            this.model_cbx.Location = new System.Drawing.Point(68, 20);
            this.model_cbx.Name = "model_cbx";
            this.model_cbx.Size = new System.Drawing.Size(121, 24);
            this.model_cbx.TabIndex = 8;
            // 
            // submit_btn
            // 
            this.submit_btn.Location = new System.Drawing.Point(656, 127);
            this.submit_btn.Name = "submit_btn";
            this.submit_btn.Size = new System.Drawing.Size(75, 41);
            this.submit_btn.TabIndex = 3;
            this.submit_btn.Text = "提交";
            this.submit_btn.UseVisualStyleBackColor = true;
            this.submit_btn.Click += new System.EventHandler(this.submit_btn_Click);
            // 
            // qty_txt
            // 
            this.qty_txt.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.qty_txt.Enabled = false;
            this.qty_txt.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.qty_txt.ForeColor = System.Drawing.Color.OrangeRed;
            this.qty_txt.Location = new System.Drawing.Point(479, 128);
            this.qty_txt.Name = "qty_txt";
            this.qty_txt.Size = new System.Drawing.Size(65, 26);
            this.qty_txt.TabIndex = 2;
            // 
            // barcode_txt
            // 
            this.barcode_txt.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.barcode_txt.Location = new System.Drawing.Point(68, 129);
            this.barcode_txt.Name = "barcode_txt";
            this.barcode_txt.Size = new System.Drawing.Size(273, 26);
            this.barcode_txt.TabIndex = 2;
            this.barcode_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.barcode_txt_Enter);
            // 
            // moduleList_dgv
            // 
            this.moduleList_dgv.AllowUserToAddRows = false;
            this.moduleList_dgv.AllowUserToDeleteRows = false;
            this.moduleList_dgv.BackgroundColor = System.Drawing.Color.SkyBlue;
            this.moduleList_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.moduleList_dgv.Location = new System.Drawing.Point(12, 192);
            this.moduleList_dgv.Name = "moduleList_dgv";
            this.moduleList_dgv.RowTemplate.Height = 23;
            this.moduleList_dgv.Size = new System.Drawing.Size(856, 387);
            this.moduleList_dgv.TabIndex = 2;
            // 
            // ReturnModuleFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 591);
            this.Controls.Add(this.moduleList_dgv);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReturnModuleFrm";
            this.Text = "还入登记";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.moduleList_dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox site_txt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox reason_txt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox model_cbx;
        private System.Windows.Forms.Button submit_btn;
        private System.Windows.Forms.TextBox qty_txt;
        private System.Windows.Forms.TextBox barcode_txt;
        private System.Windows.Forms.DataGridView moduleList_dgv;
        private System.Windows.Forms.Label result_lbl;
        private System.Windows.Forms.Label label8;
    }
}