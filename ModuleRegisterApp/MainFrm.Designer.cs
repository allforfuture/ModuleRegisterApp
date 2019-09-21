namespace ModuleRegisterApp
{
    partial class MainFrm
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
			this.meno_cbx = new System.Windows.Forms.CheckBox();
			this.Memo_txt = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.carton_chb = new System.Windows.Forms.CheckBox();
			this.carton_txt = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.RecordID_chb = new System.Windows.Forms.CheckBox();
			this.RecordID_txt = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.dateShift_cbx = new System.Windows.Forms.CheckBox();
			this.module_cbx = new System.Windows.Forms.CheckBox();
			this.dept_cbx = new System.Windows.Forms.CheckBox();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.module_txt = new System.Windows.Forms.TextBox();
			this.dept_combo = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.search_btn = new System.Windows.Forms.Button();
			this.Sumary_dgv = new System.Windows.Forms.DataGridView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.BerrowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ReturnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ProduceScrapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.ScrapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ScrapCartonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.qAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.报废ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.dept_rbt = new System.Windows.Forms.RadioButton();
			this.dateShift_rbt = new System.Windows.Forms.RadioButton();
			this.module_rbt = new System.Windows.Forms.RadioButton();
			this.carton_rbt = new System.Windows.Forms.RadioButton();
			this.RecordID_rbt = new System.Windows.Forms.RadioButton();
			this.meno_rbt = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Sumary_dgv)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.meno_rbt);
			this.groupBox1.Controls.Add(this.meno_cbx);
			this.groupBox1.Controls.Add(this.RecordID_rbt);
			this.groupBox1.Controls.Add(this.Memo_txt);
			this.groupBox1.Controls.Add(this.carton_rbt);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.module_rbt);
			this.groupBox1.Controls.Add(this.carton_chb);
			this.groupBox1.Controls.Add(this.dateShift_rbt);
			this.groupBox1.Controls.Add(this.carton_txt);
			this.groupBox1.Controls.Add(this.dept_rbt);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.RecordID_chb);
			this.groupBox1.Controls.Add(this.RecordID_txt);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.dateShift_cbx);
			this.groupBox1.Controls.Add(this.module_cbx);
			this.groupBox1.Controls.Add(this.dept_cbx);
			this.groupBox1.Controls.Add(this.dateTimePicker2);
			this.groupBox1.Controls.Add(this.dateTimePicker1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.module_txt);
			this.groupBox1.Controls.Add(this.dept_combo);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.search_btn);
			this.groupBox1.Location = new System.Drawing.Point(12, 36);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(818, 147);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "操作区";
			// 
			// meno_cbx
			// 
			this.meno_cbx.AutoSize = true;
			this.meno_cbx.Location = new System.Drawing.Point(682, 109);
			this.meno_cbx.Name = "meno_cbx";
			this.meno_cbx.Size = new System.Drawing.Size(15, 14);
			this.meno_cbx.TabIndex = 21;
			this.meno_cbx.UseVisualStyleBackColor = true;
			this.meno_cbx.Visible = false;
			// 
			// Memo_txt
			// 
			this.Memo_txt.Location = new System.Drawing.Point(397, 105);
			this.Memo_txt.Name = "Memo_txt";
			this.Memo_txt.Size = new System.Drawing.Size(161, 21);
			this.Memo_txt.TabIndex = 20;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(354, 112);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(35, 12);
			this.label7.TabIndex = 19;
			this.label7.Text = "Memo:";
			// 
			// carton_chb
			// 
			this.carton_chb.AutoSize = true;
			this.carton_chb.Location = new System.Drawing.Point(682, 72);
			this.carton_chb.Name = "carton_chb";
			this.carton_chb.Size = new System.Drawing.Size(15, 14);
			this.carton_chb.TabIndex = 18;
			this.carton_chb.UseVisualStyleBackColor = true;
			this.carton_chb.Visible = false;
			// 
			// carton_txt
			// 
			this.carton_txt.Location = new System.Drawing.Point(397, 69);
			this.carton_txt.Name = "carton_txt";
			this.carton_txt.Size = new System.Drawing.Size(161, 21);
			this.carton_txt.TabIndex = 17;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(324, 74);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(65, 12);
			this.label6.TabIndex = 16;
			this.label6.Text = "Carton ID:";
			// 
			// RecordID_chb
			// 
			this.RecordID_chb.AutoSize = true;
			this.RecordID_chb.Location = new System.Drawing.Point(252, 113);
			this.RecordID_chb.Name = "RecordID_chb";
			this.RecordID_chb.Size = new System.Drawing.Size(15, 14);
			this.RecordID_chb.TabIndex = 15;
			this.RecordID_chb.UseVisualStyleBackColor = true;
			this.RecordID_chb.Visible = false;
			// 
			// RecordID_txt
			// 
			this.RecordID_txt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.RecordID_txt.Location = new System.Drawing.Point(86, 109);
			this.RecordID_txt.Name = "RecordID_txt";
			this.RecordID_txt.Size = new System.Drawing.Size(149, 23);
			this.RecordID_txt.TabIndex = 14;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(15, 112);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(65, 12);
			this.label5.TabIndex = 13;
			this.label5.Text = "Record ID:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(524, 35);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(17, 12);
			this.label4.TabIndex = 12;
			this.label4.Text = "to";
			// 
			// dateShift_cbx
			// 
			this.dateShift_cbx.AutoSize = true;
			this.dateShift_cbx.Location = new System.Drawing.Point(682, 34);
			this.dateShift_cbx.Name = "dateShift_cbx";
			this.dateShift_cbx.Size = new System.Drawing.Size(15, 14);
			this.dateShift_cbx.TabIndex = 11;
			this.dateShift_cbx.UseVisualStyleBackColor = true;
			this.dateShift_cbx.Visible = false;
			// 
			// module_cbx
			// 
			this.module_cbx.AutoSize = true;
			this.module_cbx.Location = new System.Drawing.Point(252, 70);
			this.module_cbx.Name = "module_cbx";
			this.module_cbx.Size = new System.Drawing.Size(15, 14);
			this.module_cbx.TabIndex = 10;
			this.module_cbx.UseVisualStyleBackColor = true;
			this.module_cbx.Visible = false;
			// 
			// dept_cbx
			// 
			this.dept_cbx.AutoSize = true;
			this.dept_cbx.Location = new System.Drawing.Point(252, 34);
			this.dept_cbx.Name = "dept_cbx";
			this.dept_cbx.Size = new System.Drawing.Size(15, 14);
			this.dept_cbx.TabIndex = 9;
			this.dept_cbx.UseVisualStyleBackColor = true;
			this.dept_cbx.Visible = false;
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.Location = new System.Drawing.Point(548, 32);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(117, 21);
			this.dateTimePicker2.TabIndex = 7;
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(397, 32);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(121, 21);
			this.dateTimePicker1.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(324, 35);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 12);
			this.label3.TabIndex = 5;
			this.label3.Text = "DateShift:";
			// 
			// module_txt
			// 
			this.module_txt.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.module_txt.Location = new System.Drawing.Point(86, 67);
			this.module_txt.Name = "module_txt";
			this.module_txt.Size = new System.Drawing.Size(149, 23);
			this.module_txt.TabIndex = 4;
			// 
			// dept_combo
			// 
			this.dept_combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.dept_combo.FormattingEnabled = true;
			this.dept_combo.Location = new System.Drawing.Point(86, 31);
			this.dept_combo.Name = "dept_combo";
			this.dept_combo.Size = new System.Drawing.Size(149, 20);
			this.dept_combo.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(32, 73);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 12);
			this.label2.TabIndex = 2;
			this.label2.Text = "Module:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(45, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "Dept:";
			// 
			// search_btn
			// 
			this.search_btn.Location = new System.Drawing.Point(725, 109);
			this.search_btn.Name = "search_btn";
			this.search_btn.Size = new System.Drawing.Size(75, 29);
			this.search_btn.TabIndex = 0;
			this.search_btn.Text = "Search";
			this.search_btn.UseVisualStyleBackColor = true;
			this.search_btn.Click += new System.EventHandler(this.search_btn_Click);
			// 
			// Sumary_dgv
			// 
			this.Sumary_dgv.AllowUserToAddRows = false;
			this.Sumary_dgv.AllowUserToDeleteRows = false;
			this.Sumary_dgv.BackgroundColor = System.Drawing.Color.LightSalmon;
			this.Sumary_dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.Sumary_dgv.Location = new System.Drawing.Point(13, 189);
			this.Sumary_dgv.Name = "Sumary_dgv";
			this.Sumary_dgv.RowTemplate.Height = 23;
			this.Sumary_dgv.Size = new System.Drawing.Size(818, 391);
			this.Sumary_dgv.TabIndex = 1;
			this.Sumary_dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Sumary_dgv_CellContentClick);
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.SystemColors.Info;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.ToolStripMenuItem3,
            this.qAToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(849, 25);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BerrowToolStripMenuItem,
            this.ReturnToolStripMenuItem,
            this.ProduceScrapToolStripMenuItem});
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
			this.toolStripMenuItem1.Text = "制造";
			// 
			// BerrowToolStripMenuItem
			// 
			this.BerrowToolStripMenuItem.Name = "BerrowToolStripMenuItem";
			this.BerrowToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.B)));
			this.BerrowToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.BerrowToolStripMenuItem.Text = "借出";
			this.BerrowToolStripMenuItem.Click += new System.EventHandler(this.BerrowToolStripMenuItem_Click);
			// 
			// ReturnToolStripMenuItem
			// 
			this.ReturnToolStripMenuItem.Name = "ReturnToolStripMenuItem";
			this.ReturnToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
			this.ReturnToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.ReturnToolStripMenuItem.Text = "还入";
			this.ReturnToolStripMenuItem.Click += new System.EventHandler(this.ReturnToolStripMenuItem_Click);
			// 
			// ProduceScrapToolStripMenuItem
			// 
			this.ProduceScrapToolStripMenuItem.Name = "ProduceScrapToolStripMenuItem";
			this.ProduceScrapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.P)));
			this.ProduceScrapToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
			this.ProduceScrapToolStripMenuItem.Text = "报废前扫描";
			this.ProduceScrapToolStripMenuItem.Click += new System.EventHandler(this.ProduceScrapToolStripMenuItem_Click);
			// 
			// ToolStripMenuItem3
			// 
			this.ToolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ScrapToolStripMenuItem,
            this.ScrapCartonToolStripMenuItem});
			this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
			this.ToolStripMenuItem3.Size = new System.Drawing.Size(44, 21);
			this.ToolStripMenuItem3.Text = "仓库";
			// 
			// ScrapToolStripMenuItem
			// 
			this.ScrapToolStripMenuItem.Name = "ScrapToolStripMenuItem";
			this.ScrapToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
			this.ScrapToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.ScrapToolStripMenuItem.Text = "报废";
			this.ScrapToolStripMenuItem.Click += new System.EventHandler(this.ScrapToolStripMenuItem_Click);
			// 
			// ScrapCartonToolStripMenuItem
			// 
			this.ScrapCartonToolStripMenuItem.Name = "ScrapCartonToolStripMenuItem";
			this.ScrapCartonToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.C)));
			this.ScrapCartonToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
			this.ScrapCartonToolStripMenuItem.Text = "报废|装箱";
			this.ScrapCartonToolStripMenuItem.Click += new System.EventHandler(this.ScrapCartonToolStripMenuItem_Click);
			// 
			// qAToolStripMenuItem
			// 
			this.qAToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.报废ToolStripMenuItem});
			this.qAToolStripMenuItem.Name = "qAToolStripMenuItem";
			this.qAToolStripMenuItem.Size = new System.Drawing.Size(38, 21);
			this.qAToolStripMenuItem.Text = "QA";
			// 
			// 报废ToolStripMenuItem
			// 
			this.报废ToolStripMenuItem.Name = "报废ToolStripMenuItem";
			this.报废ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Q)));
			this.报废ToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.报废ToolStripMenuItem.Text = "实验品保存";
			this.报废ToolStripMenuItem.Click += new System.EventHandler(this.报废ToolStripMenuItem_Click);
			// 
			// dept_rbt
			// 
			this.dept_rbt.AutoSize = true;
			this.dept_rbt.Location = new System.Drawing.Point(252, 34);
			this.dept_rbt.Name = "dept_rbt";
			this.dept_rbt.Size = new System.Drawing.Size(14, 13);
			this.dept_rbt.TabIndex = 22;
			this.dept_rbt.UseVisualStyleBackColor = true;
			// 
			// dateShift_rbt
			// 
			this.dateShift_rbt.AutoSize = true;
			this.dateShift_rbt.Checked = true;
			this.dateShift_rbt.Location = new System.Drawing.Point(682, 34);
			this.dateShift_rbt.Name = "dateShift_rbt";
			this.dateShift_rbt.Size = new System.Drawing.Size(14, 13);
			this.dateShift_rbt.TabIndex = 23;
			this.dateShift_rbt.TabStop = true;
			this.dateShift_rbt.UseVisualStyleBackColor = true;
			// 
			// module_rbt
			// 
			this.module_rbt.AutoSize = true;
			this.module_rbt.Location = new System.Drawing.Point(252, 70);
			this.module_rbt.Name = "module_rbt";
			this.module_rbt.Size = new System.Drawing.Size(14, 13);
			this.module_rbt.TabIndex = 24;
			this.module_rbt.UseVisualStyleBackColor = true;
			// 
			// carton_rbt
			// 
			this.carton_rbt.AutoSize = true;
			this.carton_rbt.Location = new System.Drawing.Point(682, 72);
			this.carton_rbt.Name = "carton_rbt";
			this.carton_rbt.Size = new System.Drawing.Size(14, 13);
			this.carton_rbt.TabIndex = 25;
			this.carton_rbt.UseVisualStyleBackColor = true;
			// 
			// RecordID_rbt
			// 
			this.RecordID_rbt.AutoSize = true;
			this.RecordID_rbt.Location = new System.Drawing.Point(252, 113);
			this.RecordID_rbt.Name = "RecordID_rbt";
			this.RecordID_rbt.Size = new System.Drawing.Size(14, 13);
			this.RecordID_rbt.TabIndex = 26;
			this.RecordID_rbt.UseVisualStyleBackColor = true;
			// 
			// meno_rbt
			// 
			this.meno_rbt.AutoSize = true;
			this.meno_rbt.Location = new System.Drawing.Point(682, 109);
			this.meno_rbt.Name = "meno_rbt";
			this.meno_rbt.Size = new System.Drawing.Size(14, 13);
			this.meno_rbt.TabIndex = 27;
			this.meno_rbt.UseVisualStyleBackColor = true;
			// 
			// MainFrm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(849, 592);
			this.Controls.Add(this.Sumary_dgv);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainFrm";
			this.Text = "主窗口";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Sumary_dgv)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox module_txt;
        private System.Windows.Forms.ComboBox dept_combo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button search_btn;
        private System.Windows.Forms.DataGridView Sumary_dgv;
        private System.Windows.Forms.CheckBox dateShift_cbx;
        private System.Windows.Forms.CheckBox module_cbx;
        private System.Windows.Forms.CheckBox dept_cbx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem3;
        private System.Windows.Forms.CheckBox RecordID_chb;
        private System.Windows.Forms.TextBox RecordID_txt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem BerrowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReturnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ScrapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ScrapCartonToolStripMenuItem;
        private System.Windows.Forms.CheckBox carton_chb;
        private System.Windows.Forms.TextBox carton_txt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox meno_cbx;
        private System.Windows.Forms.TextBox Memo_txt;
        private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ToolStripMenuItem ProduceScrapToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem qAToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 报废ToolStripMenuItem;
		private System.Windows.Forms.RadioButton dept_rbt;
		private System.Windows.Forms.RadioButton dateShift_rbt;
		private System.Windows.Forms.RadioButton module_rbt;
		private System.Windows.Forms.RadioButton carton_rbt;
		private System.Windows.Forms.RadioButton RecordID_rbt;
		private System.Windows.Forms.RadioButton meno_rbt;
	}
}