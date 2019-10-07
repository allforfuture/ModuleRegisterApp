using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;


namespace ModuleRegisterApp
{
    public partial class LoginFrm : Form
    {
        DBFactory dbFac = new DBFactory();
        public UserInfo uInfo = new UserInfo();
        public static string[] deptArr;

        public LoginFrm()
        {
            InitializeComponent();
            LoadCombo();
            user_txt.SelectAll();
            dep_cbx.Text = "PD";
        }

        private void LoadCombo()
        {
            List<string> dept=new List<string>();
            DataTable t1 = new DataTable();
            dbFac.ExecuteDataTable("select distinct(dept) from t_user order by dept desc", ref t1);
            if(t1.Rows.Count>0)
            {
                for(int i=0;i<t1.Rows.Count;i++)
                {
                    //dep_cbx.Items.Add();
                    dept.Add(t1.Rows[i]["dept"].ToString().Trim());
                }
                deptArr = dept.ToArray();
                dep_cbx.Items.AddRange(deptArr);
                //dep_cbx.SelectedIndex = 1;
                dep_cbx.Text = "PD";
            }
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
            if (dep_cbx.SelectedItem == null || user_txt.Text == "" || pw_txt.Text == "") return;
            string sql = "select user_id,dept,user_name from t_user where user_id='"+ user_txt.Text +"' and pass='"+ pw_txt.Text +"' and dept='"+ dep_cbx.SelectedItem.ToString()+"'";
            DataTable t1 = new DataTable();
            dbFac.ExecuteDataTable(sql,ref t1);
            if (t1.Rows.Count>0)
            {
                //登陆成功
                uInfo.r_dept = t1.Rows[0]["dept"].ToString();
                uInfo.r_user = t1.Rows[0]["user_id"].ToString();
                uInfo.r_username = t1.Rows[0]["user_name"].ToString().Trim();
                DialogResult = DialogResult.OK;
            }
            else
            {
                //登陆失败
                MessageBox.Show("用户名或密码错误!");
            }
        }

        private void Pw_txt_KeyDown(object sender,KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            if (dep_cbx.SelectedItem == null || user_txt.Text == "" || pw_txt.Text == "") return;
            string sql = "select user_id,dept,user_name from t_user where user_id='" + user_txt.Text + "' and pass='" + pw_txt.Text + "' and dept='" + dep_cbx.SelectedItem.ToString() + "'";
            DataTable t1 = new DataTable();
            dbFac.ExecuteDataTable(sql, ref t1);
            if (t1.Rows.Count > 0)
            {
                //登陆成功
                uInfo.r_dept = t1.Rows[0]["dept"].ToString();
                uInfo.r_user = t1.Rows[0]["user_id"].ToString();
                uInfo.r_username = t1.Rows[0]["user_name"].ToString().Trim();
                DialogResult = DialogResult.OK;
            }
            else
            {
                //登陆失败
                MessageBox.Show("用户名或密码错误!");
            }
        }

        private void dep_cbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            //pw_txt.Text = "";
            user_txt.Select();
        }
    }
}
