using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ModuleRegisterApp2
{
     public class UserInfo
    {
        #region prepety

        private string user_id = string.Empty;
        private string user_name = string.Empty;
        private string user_dept = string.Empty;
        private string user_password = string.Empty;
        private string user_role = string.Empty;

        public string User_id
        {
            get
            {
                return user_id;
            }

            set
            {
                user_id = value;
            }
        }

        public string User_name
        {
            get
            {
                return user_name;
            }

            set
            {
                user_name = value;
            }
        }

        public string User_dept
        {
            get
            {
                return user_dept;
            }

            set
            {
                user_dept = value;
            }
        }

        public string User_role
        {
            get
            {
                return user_role;
            }

            set
            {
                user_role = value;
            }
        }

        public string User_password
        {
            get
            {
                return user_password;
            }

            set
            {
                user_password = value;
            }
        }

        #endregion

        #region The constructor method
        public UserInfo()
        {

        }

        public UserInfo(string user_id,string password,string user_dept)
        {
            DataTable dt = new DataTable();
            string sql = "select user_id,user_name,pass,dept,u_role from t_user" +
                " where user_id='"+ user_id +"' and pass='"+ password+"' and dept='"+ user_dept +"'";
            DBHelper.ExecuteRefDT(sql, ref dt);
            if(dt.Rows.Count>0)
            {
                this.user_id = dt.Rows[0]["user_id"].ToString();
                this.user_name = dt.Rows[0]["user_name"].ToString();
                this.User_password = dt.Rows[0]["pass"].ToString();
                this.user_dept = dt.Rows[0]["dept"].ToString();
                this.user_role = dt.Rows[0]["u_role"].ToString();
            }
        }

        public string[] GetAllDept()
        {
            string[] tmp = null;
            string sql = "select distinct(dept) as dept from t_user ";
            DataTable dt = new DataTable();
            DBHelper.ExecuteRefDT(sql, ref dt);
            if(dt.Rows.Count>0)
            {
                tmp = new string[dt.Rows.Count];
                int i = 0;
                foreach(DataRow  dr in dt.Rows)
                {
                    tmp[i] = dr["dept"].ToString();
                    i++;
                }
                return tmp;
            }
            else
            {
                return tmp;
            }
        }


        #endregion
    }
}
