using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ModuleRegisterApp2
{
     public class CartonInfo
    {
        string carton_id = string.Empty;
        string create_user = string.Empty;
        DateTime update_date = DateTime.Parse("2000-01-01 00:00:00");
        DateTime create_date = DateTime.Now;
        int qty = 0;
        int status = 0;
        List<RecordInfo> records = new List<RecordInfo>();

        public string Carton_id
        {
            get
            {
                return carton_id;
            }

            set
            {
                carton_id = value;
            }
        }

        public List<RecordInfo> Records
        {
            get
            {
                return records;
            }

            set
            {
                records = value;
            }
        }

        public string Create_user
        {
            get
            {
                return create_user;
            }

            set
            {
                create_user = value;
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

        public DateTime Create_date
        {
            get
            {
                return create_date;
            }

            set
            {
                create_date = value;
            }
        }

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public int Qty
        {
            get
            {
                return qty;
            }

            set
            {
                qty = value;
            }
        }

        #region The public method
        public void SetCartonInfo(string cartonID)
        {
            
            string sql = "select *,(select count(serial_cd) from t_module where record_id=t_carton.record_id) as qty from t_carton where  carton_id='" + cartonID + "' order by create_date desc limit 1";
            DataTable dt = new DataTable();
            DBHelper.ExecuteRefDT(sql, ref dt);
            if (dt.Rows.Count > 0)
            {
                cartonID = dt.Rows[0]["caron_id"].ToString();
                create_date = DateTime.Parse(dt.Rows[0]["create_date"].ToString());
                create_user = dt.Rows[0]["create_user"].ToString();
                qty = int.Parse(dt.Rows[0]["qty"].ToString());
            }
        }

        public bool WriteDB()
        {
            string[] tmpArray=new string[records.Count];
            int i = 0;
            foreach(RecordInfo rInfo in records)
            {
                tmpArray[i] = "INSERT INTO public.t_carton(carton_id, record_id, create_user, update_date, create_date, status) "+
                 " VALUES('"+ carton_id +"', '"+ rInfo.Record_id + "', '" + create_user + "', '" + update_date + "', '" + create_date+ "', 0)";
                i++;
            }
            if (!DBHelper.WriteRecord(tmpArray))
                return false;
            return true;
        }
        #endregion
    }
}
