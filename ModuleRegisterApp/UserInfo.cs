using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Configuration;

namespace ModuleRegisterApp
{
    public class UserInfo
    {
		//下面三个无引用，注释掉
        //public string m_userId;
        //public string m_userName;
        //public string m_dept;
        public string r_user;
        public string r_dept;
        public string r_username;

        public void LoadDeptData(ref ComboBox obj)
        {
            obj.Items.Add("PI");
            obj.Items.Add("PE");
            obj.Items.Add("QA");
            obj.Items.Add("PD");
        }

        public void LoadModelData(ref ComboBox obj)
        {
			string[] modelType = ConfigurationManager.AppSettings["modelType"].ToString().Split(';');
			obj.Items.AddRange(modelType);
            obj.Text = ConfigurationManager.AppSettings["modelTypeDefault"];
            //obj.Items.Add("KK04");
            //obj.Items.Add("KK06");
            //obj.Items.Add("KK07");
            //obj.Items.Add("KK08");
            //obj.Items.Add("KK09");
        }
    }
}