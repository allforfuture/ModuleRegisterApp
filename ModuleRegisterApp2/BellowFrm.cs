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
    public partial class BellowFrm : Form
    {
        /// <summary>
        /// Design a delegate to refresh dataGridView of mainfrm,when user click sumbit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void frmRefreshHandler(DataTable dt);
        public frmRefreshHandler frmRefreshEvent;

        UserInfo uInfo;
        RecordInfo rInfo;

        #region The construct method
        public BellowFrm(UserInfo uInfo)
        {
            InitializeComponent();
            this.uInfo = new UserInfo();
            this.uInfo = uInfo;
            this.Form_Load();
        }
        #endregion

        public void Form_Load()
        {             
            this.rInfo = new RecordInfo();
            dept_cbx.DataSource = DeptInfo.partList;
            model_cbx.DataSource = ModelInfo.modelList;
            this.barcode_txt.KeyDown += new KeyEventHandler(barcode_txt_KeyDown);
        }

        private void barcode_txt_KeyDown(object sender,KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            if (barcode_txt.Text.Length < 24)
                return;
            if (!sn_Validation(barcode_txt.Text))
                return;
            if (model_cbx.SelectedItem.ToString() == "")
                return;
            ModuleInfo se = new ModuleInfo();
            se.Serial_cd = barcode_txt.Text;
            se.Model = model_cbx.SelectedItem.ToString();
            se.Record_id = string.Empty;
            rInfo.Serials.Add(se);
            qty_txt.Text = rInfo.Serials.Count.ToString();
            this.LoadGridView();
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            if (id_txt.Text=="" || Name =="" || dept_cbx.SelectedItem.ToString()=="")
            {
                //Holder part can't empty
                return;
            }
            if(reason_txt.Text=="")
            {
                //must input the reason for you bellow module
                return;
            }
            if(rInfo.Serials.Count<1)
            {
                //please scan the module what you want to bellow
                return;
            }
            rInfo.Site = site_txt.Text;
            rInfo.Type = 0;
            rInfo.Holder_dept = dept_cbx.SelectedItem.ToString();
            rInfo.Holder_emp = id_txt.Text;
            rInfo.Holder_name = name_txt.Text;
            rInfo.Reason = reason_txt.Text;

            if(rInfo.WriteDB(rInfo.Serials.Count))
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("record_id", typeof(string));
                dt.Columns.Add("site", typeof(string));
                dt.Columns.Add("register_date", typeof(DateTime));
                dt.Columns.Add("type", typeof(int));
                dt.Columns.Add("qty", typeof(int));
                dt.Columns.Add("holder_dept", typeof(string));
                dt.Columns.Add("holder_name", typeof(string));
                DataRow dr = dt.NewRow();
                dr["record_id"] = rInfo.Record_id;
                dr["site"] = rInfo.Site;
                dr["register_date"] = rInfo.Register_date;
                dr["type"] = rInfo.Type;
                dr["qty"] = rInfo.Serials.Count;
                dr["holder_dept"] = rInfo.Holder_dept;
                dr["holder_name"] = rInfo.Holder_name;
                dt.Rows.Add(dr);
                frmRefreshEvent(dt);

                //write to DB is company
                DialogResult result=MessageBox.Show("Write to DB is sucess,do you want register again?", "Infonation", MessageBoxButtons.YesNo);
                if(result==DialogResult.Yes)
                {
                    this.Controls.Clear();
                    InitializeComponent();
                    Form_Load();
                }
                else
                {
                    barcode_txt.Enabled = false;
                    submit_btn.Enabled = false;
                }
            }
            else
            {
                //write to db is discompany,have some error fot check
                return;
            }
        }

        /// <summary>
        /// 判断sn是否可以添加
        /// </summary>
        /// <param name="sn">马达sn</param>
        /// <returns>true可以添加，false不允许添加</returns>
        private bool sn_Validation(string sn)
        {
            if(rInfo!=null)
            {
                foreach(ModuleInfo se in rInfo.Serials)
                {
                    if (se.Serial_cd == sn)
                        return false;
                }
            }

            return true;
        }

        private void LoadGridView()
        {
            //先将控件记录集清空
            moduleList_dgv.Columns.Clear();
            DataTable dt = new DataTable();
            dt = ComMethod.ConverToDataTable<ModuleInfo>(rInfo.Serials);
            moduleList_dgv.DataSource = dt;
            moduleList_dgv.Columns[0].DataPropertyName = "serial_cd";
            moduleList_dgv.Columns[1].DataPropertyName = "model";
            moduleList_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

    }
}
