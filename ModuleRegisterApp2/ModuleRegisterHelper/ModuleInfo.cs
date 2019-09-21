using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModuleRegisterApp2
{
    public class ModuleInfo
    {
        #region MyRegion
        private string record_id = string.Empty;
        private string serial_cd = string.Empty;
        private string model = string.Empty;

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
        public string Serial_cd
        {
            get
            {
                return serial_cd;
            }

            set
            {
                serial_cd = value;
            }
        }
        public string Model
        {
            get
            {
                return model;
            }

            set
            {
                model = value;
            }
        }
        #endregion

        #region The construtor method
        public ModuleInfo(string record_id, string serial_cd, string model)
        {
            this.record_id = record_id;
            this.serial_cd = serial_cd;
            this.model = model;
        }

        public ModuleInfo()
        {

        }
        #endregion
    }
}
