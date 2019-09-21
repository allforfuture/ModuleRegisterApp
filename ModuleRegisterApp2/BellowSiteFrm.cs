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
    public partial class BellowSiteFrm : Form
    {
        /// <summary>
        /// Design a delegate to refresh dataGridView of mainfrm,when user click sumbit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void frmRefreshHandler(DataTable dt);
        public frmRefreshHandler frmRefreshEvent;

        public BellowSiteFrm(UserInfo uInfo)
        {
            InitializeComponent();
            
        }
    }
}
