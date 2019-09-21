using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuleRegisterApp3
{
     public class DataGridSource
    {
        string recordID=string.Empty;
        string site=string.Empty;
        int qty = 0;
        DateTime register;

        public string RecordID
        {
            get
            {
                return recordID;
            }

            set
            {
                recordID = value;
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

        public DateTime Register
        {
            get
            {
                return register;
            }

            set
            {
                register = value;
            }
        }
    }
}
