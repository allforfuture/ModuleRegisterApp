using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModuleRegisterApp2
{
    public partial class LoginFrm : Form
    {

        public LoginFrm()
        {
            InitializeComponent();
            UserInfo uInfo = new UserInfo();
            dep_cbx.DataSource =uInfo.GetAllDept();

            this.user_txt.KeyDown += (object sender, KeyEventArgs e) =>
            {
                Err_lbl.Text = "";
                if(e.KeyCode==Keys.Enter)
                {
                    pw_txt.Select();
                }
            };
            this.pw_txt.KeyDown += (object sender, KeyEventArgs e) =>
            {
                Err_lbl.Text = "";
                if(e.KeyCode==Keys.Enter)
                {
                    Login();
                }
            };
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            if(dep_cbx.SelectedItem.ToString()=="")
            {
                Err_lbl.Text = "选择部门";
                return;
            }
            if(user_txt.Text=="" || pw_txt.Text=="")
            {
                Err_lbl.Text = "用户或密码不能为空！";
                return;
            }
            UserInfo uInfo = new UserInfo(user_txt.Text, pw_txt.Text,  dep_cbx.SelectedItem.ToString());
            if(uInfo.User_name==string.Empty)
            {
                //用户名或密码错误
                Err_lbl.Text = "用户或密码错误!";
                return;
            }
            MainFrm mFrm = new MainFrm(uInfo);
            mFrm.Show();
        }

        private void Login()
        {
            if (dep_cbx.SelectedItem.ToString() == "")
            {
                Err_lbl.Text = "选择部门";
                return;
            }
            if (user_txt.Text == "" || pw_txt.Text == "")
            {
                Err_lbl.Text = "用户或密码不能为空！";
                return;
            }
            UserInfo uInfo = new UserInfo(user_txt.Text, pw_txt.Text, dep_cbx.SelectedItem.ToString());
            if (uInfo.User_name == string.Empty)
            {
                //用户名或密码错误
                Err_lbl.Text = "用户或密码错误!";
                return;
            }
            MainFrm mFrm = new MainFrm(uInfo);
            mFrm.Show();
        }
    }
}
