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
    public partial class InfoFrm : Form
    {
        RecordInfo rInfo = null;

        public InfoFrm(string recordID)
        {
            InitializeComponent();
            rInfo = new RecordInfo(recordID);
            reason_txt.Text = rInfo.Record_id;
            model_cbx.Text = rInfo.Serials[0].Model;
            id_txt.Text = rInfo.Holder_emp;
            dept_cbx.Text = rInfo.Holder_dept;
            name_txt.Text = rInfo.Holder_name;
            type_txt.Text = rInfo.Type_desc;
            reason_txt.Text = rInfo.Reason;
            register_txt.Text = rInfo.Register_name;
            moduleList_dgv.DataSource = rInfo.Serials;
            qty_txt.Text = rInfo.Serials.Count.ToString();
        }

        /// <summary>
        /// 打印事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submit_btn_Click(object sender, EventArgs e)
        {
            PrintLabel pLabel = new PrintLabel(rInfo);
            pLabel.Print(type_txt.Text);
        }
    }
}
