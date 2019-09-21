using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ModuleRegisterApp
{
    public partial class InfoFrm : Form
    {
        RecordInfo rInfo = new RecordInfo();
        DataTable dtModule = null;

        public InfoFrm(RecordInfo recodeInfo)
        {
            InitializeComponent();
            rInfo = recodeInfo;
            dtModule_Initilzer();
            #region
            dept_cbx.Text = recodeInfo.holder_dept;
            model_cbx.Text = recodeInfo.serials[0].model;
            qty_txt.Text = recodeInfo.serials.Count.ToString();
            id_txt.Text = recodeInfo.holder_emp;
            name_txt.Text = recodeInfo.holder_name;
            site_txt.Text = recodeInfo.site;
            reason_txt.Text = recodeInfo.reason;
            register_txt.Text = recodeInfo.register_name;
            switch (recodeInfo.type)
            {
                case 0:
                    type_txt.Text = "借出";
                    break;
                case 1:
                    type_txt.Text = "还入";
                    break;
                case 2:
                    type_txt.Text = "报废";
                    break;
                case 3:
                    type_txt.Text = "借出Site";
                    break;
                case 4:
                    type_txt.Text = "保留品";
                    break;
            }
            foreach (serial se in recodeInfo.serials)
            {
                DataRow dr = dtModule.NewRow();
                dr["serial_cd"] = se.serial_cd;
                dr["model"] = se.model;
                dtModule.Rows.Add(dr);
            }
            moduleList_dgv.DataSource = dtModule;
            //moduleList_dgv.AutoResizeColumns();
            moduleList_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            #endregion
        }

        private void dtModule_Initilzer()
        {
            dtModule = new DataTable();
            dtModule.Columns.Add("serial_cd", typeof(string));
            dtModule.Columns.Add("model", typeof(string));
        }

        /// <summary>
        /// 更新dataGridView
        /// </summary>
        /// <param name="dt"></param>
        private void updateGridView(DataTable dt)
        {
            moduleList_dgv.DataSource = null;
            moduleList_dgv.DataSource = dt;
            moduleList_dgv.AutoResizeColumns();
            //moduleList_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            qty_txt.Text = dtModule.Rows.Count.ToString();

        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            InfoPrint iPrint = new InfoPrint(rInfo);
            iPrint.Print();
        }
    }
}
