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
    public partial class ReturnModuleFrm : Form
    {
        UserInfo uInfo=new UserInfo();
        RecordInfo rInfo = new RecordInfo();
        DBFactory dbFaci = new DBFactory();
        ComMethod comMethod = new ComMethod();

        public ReturnModuleFrm()
        {
            InitializeComponent();
        }

        public ReturnModuleFrm(UserInfo uInfo)
        {
            InitializeComponent();
            this.uInfo = uInfo;
            uInfo.LoadModelData(ref model_cbx);
            model_cbx.SelectedIndex = 1;
        }

        /// <summary>
        /// 输入条码时响应的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barcode_txt_Enter(object sender, KeyEventArgs e)
        {
            if (barcode_txt.Text == "")
                return;
            
            result_lbl.Text = "";
            if (e.KeyCode != Keys.Enter) return;
            int strLength = barcode_txt.Text.Length;
            if (strLength < Check.minLength || strLength > Check.maxLength)
            {
                MessageBox.Show(string.Format("号码必须最少{0}位，最多{1}位", Check.minLength, Check.maxLength));
                return;
            }
            if (model_cbx.SelectedItem.ToString() == "")
            {
                result_lbl.Text = "Error";
                return;
            }

            //if (barcode_txt.Text.Length < 24)
            //{
            //    result_lbl.Text = "Error";
            //    return;
            //}
            //barcode_txt.Text = barcode_txt.Text.Substring(0, 24);

            if (IsExists(barcode_txt.Text.ToUpper()) == false)
            {
                result_lbl.Text = "重复Error";
               return;
            }

			//   if (IsOkReturn(barcode_txt.Text.ToUpper(), model_cbx.SelectedItem.ToString()) == false) return;

			serial se = new serial();
			se.serial_cd = barcode_txt.Text.ToUpper();
			se.model = model_cbx.SelectedItem.ToString();
			rInfo.serials.Add(se);
			updateGridView();
            barcode_txt.Text = "";
            barcode_txt.SelectAll();
		}

        /// <summary>
        /// 点击提交操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submit_btn_Click(object sender, EventArgs e)
        {
            if (rInfo.serials.Count <= 0)
            {
                result_lbl.Text = "No data for upload";
                return;
            }

            if ( model_cbx.SelectedItem.ToString()=="") return;

            rInfo.record_id = uInfo.r_user;
            rInfo.site = site_txt.Text;
            rInfo.holder_dept =string.Empty;
            rInfo.holder_emp =string.Empty;
            rInfo.holder_name =string.Empty;
            rInfo.register_emp = uInfo.r_user;
            //rInfo.register_date = DateTime.Now;
            rInfo.register_name = uInfo.r_username;
            rInfo.type = 1;
            rInfo.statue = "N";
            rInfo.reason = reason_txt.Text;

            bool flag = dbFaci.ExecuteObject(ref rInfo);
            if (flag == false)
            {
                MessageBox.Show("提交失败！请检查数据是否有误");
                return;
            }
            else
            {
                MessageBox.Show("成功提交!");
                From_Initilzer();
                return;
            }
            
        }

        /// <summary>
        /// 判断马达是否有重复
        /// </summary>
        /// <param name="serial_cd"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        private bool IsExists(string serial_cd)
        {
            if (rInfo!=null)
            {
                foreach (serial ce in rInfo.serials)
                {
                    if (ce.serial_cd  == serial_cd)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// 判断马达是否是借出状态和AOI是否存在
        /// </summary>
        /// <param name="serial_cd"></param>
        /// <param name="dt"></param>
        /// <returns>true表示允许还，false表示不允许</returns>
        private bool IsOkReturn(string serial_cd,string model)
        {
            DataTable t = new DataTable();
            string sql = "select m.record_id,m.serial_cd,m.model,r.register_date,r.type,r.statue,"+
                        " row_number() over(partition by serial_cd, model order by serial_cd, r.record_id desc) as num "+
                        " from t_module m,t_record r where m.record_id = r.record_id and substring(serial_cd,1,17) = '"+ serial_cd.Substring(0,17) + "' limit 1";
            dbFaci.ExecuteDataTable(sql, ref t);
            if (t.Rows.Count > 0)
            {
                if(t.Rows[0]["type"].ToString().Trim()=="0")
                { 
                    return true;
                }
            }
            return true;
        }

        /// <summary>
        /// 更新dataGridView
        /// </summary>
        /// <param name="dt"></param>
        private void updateGridView()
        {
            moduleList_dgv.DataSource = null;

            if (rInfo == null) return;
            DataTable t1 = new DataTable("t1");



            //t1 = comMethod.ConverToDataTable<serial>(rInfo.serials);
            t1.Columns.Add("serial_cd");
            t1.Columns.Add("model");
            foreach(serial se in rInfo.serials)
            {
                DataRow dr = t1.NewRow();
                dr["serial_cd"] = se.serial_cd;
                dr["model"] = se.model;
                t1.Rows.Add(dr);
            }
                
            moduleList_dgv.DataSource = t1;
            moduleList_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            qty_txt.Text = t1.Rows.Count.ToString();
        }

        /// <summary>
        /// 提交后初始化Form界面
        /// </summary>
        private void From_Initilzer()
        {
            rInfo = new RecordInfo();
            reason_txt.Text = "";
            barcode_txt.Text = "";
            moduleList_dgv.DataSource = null;
        }
    }
}
