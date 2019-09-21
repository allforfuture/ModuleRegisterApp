using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ModuleRegisterApp2
{
    public class RecordInfo
    {
        #region MyRegion
        private string record_id = string.Empty;
        private string site = string.Empty;
        private string holder_dept = string.Empty;
        private string holder_emp = string.Empty;
        private string holder_name = string.Empty;
        private string register_emp = string.Empty;
        private DateTime register_date = DateTime.Now;
        private string register_name = string.Empty;
        private DateTime update_date = DateTime.Now;
        private int type = 0;
        private string type_desc = string.Empty;
        private char statue = 'N';
        private string reason = string.Empty;
        private List<ModuleInfo> serials = new List<ModuleInfo>();

        public string Record_id
        {
            get
            {
                return record_id;
            }

            set
            {
                record_id = value;
            }
        }

        public string Site
        {
            get
            {
                return site;
            }

            set
            {
                site = value;
            }
        }

        public string Holder_dept
        {
            get
            {
                return holder_dept;
            }

            set
            {
                holder_dept = value;
            }
        }

        public string Holder_emp
        {
            get
            {
                return holder_emp;
            }

            set
            {
                holder_emp = value;
            }
        }

        public string Holder_name
        {
            get
            {
                return holder_name;
            }

            set
            {
                holder_name = value;
            }
        }

        public string Register_emp
        {
            get
            {
                return register_emp;
            }

            set
            {
                register_emp = value;
            }
        }

        public DateTime Register_date
        {
            get
            {
                return register_date;
            }

            set
            {
                register_date = value;
            }
        }

        public DateTime Update_date
        {
            get
            {
                return update_date;
            }

            set
            {
                update_date = value;
            }
        }

        public int Type
        {
            get
            {
                return type;
            }

            set
            {
                type = value;
            }
        }

        public char Statue
        {
            get
            {
                return statue;
            }

            set
            {
                statue = value;
            }
        }

        public string Reason
        {
            get
            {
                return reason;
            }

            set
            {
                reason = value;
            }
        }

        public List<ModuleInfo> Serials
        {
            get
            {
                return serials;
            }

            set
            {
                serials = value;
            }
        }

        public string Type_desc
        {
            get
            {
                switch(type)
                {
                    case 0:
                        type_desc = "借出";
                        return type_desc;
                    case 1:
                        type_desc = "还入";
                        return type_desc;
                    case 2:
                        type_desc = "报废";
                        return type_desc;
                    case 3:
                        type_desc = "借出Site";
                        return type_desc;
                    default:
                        type_desc = "";
                        return type_desc;
                }
            }

            set
            {
                type_desc = value;
            }
        }

        public string Register_name
        {
            get
            {
                return register_name;
            }

            set
            {
                register_name = value;
            }
        }
        #endregion

        #region The construtor method
        public RecordInfo()
        {

        }

        public RecordInfo(string recordID)
        {
            SetRecordInfo(recordID);
        }
        #endregion

        #region public method
        public void GetRecordInfo(string t,ref DataTable dt)
        {

        }

        public void SetRecordInfo(string recordID)
        {
            string sql = "select * from t_record left join t_user on  t_record.register_emp=t_user.user_id where  record_id='" + recordID + "'";
            DataTable dt = new DataTable();
            DBHelper.ExecuteRefDT(sql, ref dt);
            if(dt.Rows.Count>0)
            {
                record_id = dt.Rows[0]["record_id"].ToString();
                site = dt.Rows[0]["site"].ToString();
                holder_dept = dt.Rows[0]["holder_dept"].ToString();
                holder_emp = dt.Rows[0]["holder_emp"].ToString();
                holder_name = dt.Rows[0]["holder_name"].ToString();
                type = int.Parse(dt.Rows[0]["type"].ToString());
                statue = char.Parse(dt.Rows[0]["statue"].ToString());
                register_date = DateTime.Parse(dt.Rows[0]["register_date"].ToString());
                register_emp = dt.Rows[0]["register_emp"].ToString();
                register_name = dt.Rows[0]["user_name"].ToString();
                reason = dt.Rows[0]["reason"].ToString();
            }
            sql = "select record_id,serial_cd,model from t_module where record_id='" + recordID + "'";
            dt = new DataTable();
            DBHelper.ExecuteRefDT(sql, ref dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ModuleInfo se = new ModuleInfo();
                    se.Record_id = dt.Rows[i]["record_id"].ToString();
                    se.Serial_cd  = dt.Rows[i]["serial_cd"].ToString().Trim();
                    se.Model = dt.Rows[i]["model"].ToString().Trim();
                    serials.Add(se);
                }
            }
        }

        public bool WriteDB(int serialsNum)
        {
            string[] sqlArray = new string[serialsNum+1];
            string newRecordID = DBHelper.GetNewRecordId();
            
            sqlArray[0] = "INSERT INTO public.t_record( " +
                        " record_id, site, holder_dept, holder_emp, holder_name, register_emp, " +
                        " register_date, update_date, type, statue, reason) " +
                        " VALUES('" + newRecordID + "', '" + site + "', '" + holder_dept + "', '" + holder_emp + "', '" + holder_name + "', '" + register_emp + "', " +
                        " '" + register_date + "', '" + update_date + "', '" + type + "', '" + statue + "', '" + reason + "'); ";
            for (int i=0;i<serialsNum;i++)
            {
                sqlArray[i + 1] = "INSERT INTO public.t_module(record_id, serial_cd, model) " +
                            " VALUES('" + newRecordID + "', '" + Serials[i].Serial_cd + "', '" + Serials[i].Model + "'); ";
            }
            if (DBHelper.WriteRecord(sqlArray))
            {
                record_id = newRecordID;
                return true;
            }
            return false;
        }

        
        #endregion
    }
}
