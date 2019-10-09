namespace ModuleRegisterApp
{
    partial class ScrapBigCartonFrm
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
            this.btnBigCarton = new System.Windows.Forms.Button();
            this.txtCartonBig = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCarton = new System.Windows.Forms.TextBox();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.qty_lbl = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lblErr = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBigCarton
            // 
            this.btnBigCarton.Location = new System.Drawing.Point(470, 33);
            this.btnBigCarton.Name = "btnBigCarton";
            this.btnBigCarton.Size = new System.Drawing.Size(120, 43);
            this.btnBigCarton.TabIndex = 0;
            this.btnBigCarton.Text = "New BigCarton";
            this.btnBigCarton.UseVisualStyleBackColor = true;
            this.btnBigCarton.Click += new System.EventHandler(this.BtnBigCarton_Click);
            // 
            // txtCartonBig
            // 
            this.txtCartonBig.BackColor = System.Drawing.SystemColors.Window;
            this.txtCartonBig.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCartonBig.Location = new System.Drawing.Point(103, 40);
            this.txtCartonBig.Name = "txtCartonBig";
            this.txtCartonBig.Size = new System.Drawing.Size(210, 29);
            this.txtCartonBig.TabIndex = 1;
            this.txtCartonBig.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Carton_txt_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(5, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "BigCarton ID:";
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.BackgroundColor = System.Drawing.Color.SkyBlue;
            this.dgv.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(13, 157);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(718, 430);
            this.dgv.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(16, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Carton ID:";
            // 
            // txtCarton
            // 
            this.txtCarton.Enabled = false;
            this.txtCarton.Font = new System.Drawing.Font("宋体", 14.25F);
            this.txtCarton.Location = new System.Drawing.Point(103, 99);
            this.txtCarton.Name = "txtCarton";
            this.txtCarton.Size = new System.Drawing.Size(210, 29);
            this.txtCarton.TabIndex = 5;
            this.txtCarton.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtCarton_KeyDown);
            // 
            // txtQty
            // 
            this.txtQty.BackColor = System.Drawing.SystemColors.Desktop;
            this.txtQty.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtQty.ForeColor = System.Drawing.SystemColors.Window;
            this.txtQty.Location = new System.Drawing.Point(560, 99);
            this.txtQty.Name = "txtQty";
            this.txtQty.ReadOnly = true;
            this.txtQty.Size = new System.Drawing.Size(94, 29);
            this.txtQty.TabIndex = 6;
            // 
            // qty_lbl
            // 
            this.qty_lbl.AutoSize = true;
            this.qty_lbl.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.qty_lbl.Location = new System.Drawing.Point(521, 108);
            this.qty_lbl.Name = "qty_lbl";
            this.qty_lbl.Size = new System.Drawing.Size(33, 12);
            this.qty_lbl.TabIndex = 7;
            this.qty_lbl.Text = "Qty:";
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.Location = new System.Drawing.Point(616, 34);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(94, 42);
            this.btnPrint.TabIndex = 8;
            this.btnPrint.Text = "Print Label";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.BtnPrint_Click);
            // 
            // lblErr
            // 
            this.lblErr.AutoSize = true;
            this.lblErr.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblErr.ForeColor = System.Drawing.Color.Red;
            this.lblErr.Location = new System.Drawing.Point(98, 78);
            this.lblErr.Name = "lblErr";
            this.lblErr.Size = new System.Drawing.Size(0, 14);
            this.lblErr.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(344, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "Model:";
            // 
            // txtModel
            // 
            this.txtModel.BackColor = System.Drawing.SystemColors.Desktop;
            this.txtModel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtModel.ForeColor = System.Drawing.SystemColors.Window;
            this.txtModel.Location = new System.Drawing.Point(387, 39);
            this.txtModel.Name = "txtModel";
            this.txtModel.ReadOnly = true;
            this.txtModel.Size = new System.Drawing.Size(67, 29);
            this.txtModel.TabIndex = 11;
            // 
            // ScrapPalletFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 592);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblErr);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.qty_lbl);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.txtCarton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCartonBig);
            this.Controls.Add(this.btnBigCarton);
            this.Name = "ScrapPalletFrm";
            this.Text = "ScrapBigCartonFrm";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBigCarton;
        private System.Windows.Forms.TextBox txtCartonBig;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCarton;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label qty_lbl;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label lblErr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtModel;
    }
}