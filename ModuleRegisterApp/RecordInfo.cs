using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuleRegisterApp
{
    public class RecordInfo
    {
        public string record_id;
        public string site;
        public string holder_dept;
        public string holder_emp;
        public string holder_name;
        public string register_emp;
        public string register_dept;
        public string register_name;
        public DateTime register_date;
        public int type;
        public string type_desc
        {
            get
            {
                switch (type)
                {
                    case 0:
                        return "借出";
                    case 1:
                        return "还入";
                    case 2:
                        return "报废";
                    case 3:
                        return "借出Site";
                }
                return "";
            }
        }
        public string statue;
        public string reason;
        public List<serial> serials=new List<serial>();
    }
    public class serial
    {
        public string serial_cd { get; set; }
		public string model { get; set; }
		public string category { get; set; }
	}
}
