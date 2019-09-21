namespace ModuleRegisterApp
{
    partial class LoginFrm
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dep_cbx = new System.Windows.Forms.ComboBox();
            this.user_txt = new System.Windows.Forms.TextBox();
            this.pw_txt = new System.Windows.Forms.TextBox();
            this.Login_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "部门:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "用户:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "密码:";
            // 
            // dep_cbx
            // 
            this.dep_cbx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dep_cbx.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dep_cbx.FormattingEnabled = true;
            this.dep_cbx.Location = new System.Drawing.Point(101, 53);
            this.dep_cbx.Name = "dep_cbx";
            this.dep_cbx.Size = new System.Drawing.Size(121, 20);
            this.dep_cbx.TabIndex = 3;
            this.dep_cbx.SelectedIndexChanged += new System.EventHandler(this.dep_cbx_SelectedIndexChanged);
            // 
            // user_txt
            // 
            this.user_txt.Location = new System.Drawing.Point(101, 98);
            this.user_txt.Name = "user_txt";
            this.user_txt.Size = new System.Drawing.Size(121, 21);
            this.user_txt.TabIndex = 4;
            // 
            // pw_txt
            // 
            this.pw_txt.Location = new System.Drawing.Point(101, 141);
            this.pw_txt.Name = "pw_txt";
            this.pw_txt.PasswordChar = '*';
            this.pw_txt.Size = new System.Drawing.Size(121, 21);
            this.pw_txt.TabIndex = 5;
            this.pw_txt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Pw_txt_KeyDown);
            // 
            // Login_btn
            // 
            this.Login_btn.Location = new System.Drawing.Point(101, 188);
            this.Login_btn.Name = "Login_btn";
            this.Login_btn.Size = new System.Drawing.Size(75, 23);
            this.Login_btn.TabIndex = 6;
            this.Login_btn.Text = "登入";
            this.Login_btn.UseVisualStyleBackColor = true;
            this.Login_btn.Click += new System.EventHandler(this.Login_btn_Click);
            // 
            // LoginFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 281);
            this.Controls.Add(this.Login_btn);
            this.Controls.Add(this.pw_txt);
            this.Controls.Add(this.user_txt);
            this.Controls.Add(this.dep_cbx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登陆";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox dep_cbx;
        private System.Windows.Forms.TextBox user_txt;
        private System.Windows.Forms.TextBox pw_txt;
        private System.Windows.Forms.Button Login_btn;
    }
}

