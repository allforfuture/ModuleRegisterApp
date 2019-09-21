namespace ModuleRegisterApp2
{
    partial class ScrapCartonFrm
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
            this.model_txt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Print_btn = new System.Windows.Forms.Button();
            this.qty_lbl = new System.Windows.Forms.Label();
            this.Qty_txt = new System.Windows.Forms.TextBox();
            this.Record_txt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Carton_txt = new System.Windows.Forms.TextBox();
            this.NewCarton_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // model_txt
            // 
            this.model_txt.BackColor = System.Drawing.SystemColors.Desktop;
            this.model_txt.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.model_txt.ForeColor = System.Drawing.SystemColors.Window;
            this.model_txt.Location = new System.Drawing.Point(391, 25);
            this.model_txt.Name = "model_txt";
            this.model_txt.ReadOnly = true;
            this.model_txt.Size = new System.Drawing.Size(67, 29);
            this.model_txt.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "Model:";
            // 
            // Print_btn
            // 
            this.Print_btn.Enabled = false;
            this.Print_btn.Location = new System.Drawing.Point(620, 20);
            this.Print_btn.Name = "Print_btn";
            this.Print_btn.Size = new System.Drawing.Size(94, 42);
            this.Print_btn.TabIndex = 20;
            this.Print_btn.Text = "Print Label";
            this.Print_btn.UseVisualStyleBackColor = true;
            this.Print_btn.Click += new System.EventHandler(this.Print_btn_Click);
            // 
            // qty_lbl
            // 
            this.qty_lbl.AutoSize = true;
            this.qty_lbl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.qty_lbl.Location = new System.Drawing.Point(525, 94);
            this.qty_lbl.Name = "qty_lbl";
            this.qty_lbl.Size = new System.Drawing.Size(33, 12);
            this.qty_lbl.TabIndex = 19;
            this.qty_lbl.Text = "Qty:";
            // 
            // Qty_txt
            // 
            this.Qty_txt.BackColor = System.Drawing.SystemColors.Desktop;
            this.Qty_txt.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Qty_txt.ForeColor = System.Drawing.SystemColors.Window;
            this.Qty_txt.Location = new System.Drawing.Point(564, 85);
            this.Qty_txt.Name = "Qty_txt";
            this.Qty_txt.ReadOnly = true;
            this.Qty_txt.Size = new System.Drawing.Size(94, 29);
            this.Qty_txt.TabIndex = 18;
            // 
            // Record_txt
            // 
            this.Record_txt.Enabled = false;
            this.Record_txt.Font = new System.Drawing.Font("宋体", 14.25F);
            this.Record_txt.Location = new System.Drawing.Point(99, 85);
            this.Record_txt.Name = "Record_txt";
            this.Record_txt.Size = new System.Drawing.Size(210, 29);
            this.Record_txt.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(34, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 12);
            this.label2.TabIndex = 16;
            this.label2.Text = "Pack ID:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.SkyBlue;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 143);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(718, 430);
            this.dataGridView1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(21, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "Carton ID:";
            // 
            // Carton_txt
            // 
            this.Carton_txt.BackColor = System.Drawing.SystemColors.Window;
            this.Carton_txt.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Carton_txt.Location = new System.Drawing.Point(99, 26);
            this.Carton_txt.Name = "Carton_txt";
            this.Carton_txt.Size = new System.Drawing.Size(210, 29);
            this.Carton_txt.TabIndex = 13;
            // 
            // NewCarton_btn
            // 
            this.NewCarton_btn.Location = new System.Drawing.Point(474, 19);
            this.NewCarton_btn.Name = "NewCarton_btn";
            this.NewCarton_btn.Size = new System.Drawing.Size(120, 43);
            this.NewCarton_btn.TabIndex = 12;
            this.NewCarton_btn.Text = "New Carton";
            this.NewCarton_btn.UseVisualStyleBackColor = true;
            this.NewCarton_btn.Click += new System.EventHandler(this.NewCarton_btn_Click);
            // 
            // ScrapCartonFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 592);
            this.Controls.Add(this.model_txt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Print_btn);
            this.Controls.Add(this.qty_lbl);
            this.Controls.Add(this.Qty_txt);
            this.Controls.Add(this.Record_txt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Carton_txt);
            this.Controls.Add(this.NewCarton_btn);
            this.Name = "ScrapCartonFrm";
            this.Text = "ScrapCartonFrm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox model_txt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Print_btn;
        private System.Windows.Forms.Label qty_lbl;
        private System.Windows.Forms.TextBox Qty_txt;
        private System.Windows.Forms.TextBox Record_txt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Carton_txt;
        private System.Windows.Forms.Button NewCarton_btn;
    }
}