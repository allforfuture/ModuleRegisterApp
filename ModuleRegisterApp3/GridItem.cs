using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuleRegisterApp3
{
    public class GridItem
    {
        public string RecordID { get; set; }
        public string Site { get; set; }
        public int Qty { get; set; }
        public DateTime Register_date { get; set; }
        public string Holder_name { get; set; }
        public string Holder_dept { get; set; }
    }
}
