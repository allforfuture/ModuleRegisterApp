namespace ModuleRegisterApp2
{
    partial class LoginFrm
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
            this.Login_btn = new System.Windows.Forms.Button();
            this.pw_txt = new System.Windows.Forms.TextBox();
            this.user_txt = new System.Windows.Forms.TextBox();
            this.dep_cbx = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Err_lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Login_btn
            // 
            this.Login_btn.Location = new System.Drawing.Point(100, 185);
            this.Login_btn.Name = "Login_btn";
            this.Login_btn.Size = new System.Drawing.Size(75, 23);
            this.Login_btn.TabIndex = 13;
            this.Login_btn.Text = "登入";
            this.Login_btn.UseVisualStyleBackColor = true;
            this.Login_btn.Click += new System.EventHandler(this.Login_btn_Click);
            // 
            // pw_txt
            // 
            this.pw_txt.Location = new System.Drawing.Point(100, 138);
            this.pw_txt.Name = "pw_txt";
            this.pw_txt.PasswordChar = '*';
            this.pw_txt.Size = new System.Drawing.Size(121, 21);
            this.pw_txt.TabIndex = 12;
            // 
            // user_txt
            // 
            this.user_txt.Location = new System.Drawing.Point(100, 95);
            this.user_txt.Name = "user_txt";
            this.user_txt.Size = new System.Drawing.Size(121, 21);
            this.user_txt.TabIndex = 11;
            
            // 
            // dep_cbx
            // 
            this.dep_cbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dep_cbx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dep_cbx.FormattingEnabled = true;
            this.dep_cbx.Location = new System.Drawing.Point(100, 50);
            this.dep_cbx.Name = "dep_cbx";
            this.dep_cbx.Size = new System.Drawing.Size(121, 20);
            this.dep_cbx.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "密码:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "用户:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "部门:";
            // 
            // Err_lbl
            // 
            this.Err_lbl.AutoSize = true;
            this.Err_lbl.ForeColor = System.Drawing.Color.Red;
            this.Err_lbl.Location = new System.Drawing.Point(100, 21);
            this.Err_lbl.Name = "Err_lbl";
            this.Err_lbl.Size = new System.Drawing.Size(0, 12);
            this.Err_lbl.TabIndex = 14;
            // 
            // LoginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 281);
            this.Controls.Add(this.Err_lbl);
            this.Controls.Add(this.Login_btn);
            this.Controls.Add(this.pw_txt);
            this.Controls.Add(this.user_txt);
            this.Controls.Add(this.dep_cbx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "LoginFrm";
            this.Text = "LoginFrm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Login_btn;
        private System.Windows.Forms.TextBox pw_txt;
        private System.Windows.Forms.TextBox user_txt;
        private System.Windows.Forms.ComboBox dep_cbx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Err_lbl;
    }
}