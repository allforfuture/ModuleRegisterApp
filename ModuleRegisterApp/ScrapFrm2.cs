using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuleRegisterApp
{
    public partial class ScrapFrm2 : Form
    {
        DBFactory dbFac = new DBFactory();
        #region Initialize class object
        UserInfo uInfo = new UserInfo();
        DBFactory dbFaci = new DBFactory();
        RecordInfo rInfo = new RecordInfo();
        ComMethod comMethod = new ComMethod();
        //DataTable dtModule = new DataTable();
        #endregion

        public ScrapFrm2()
        {
            InitializeComponent();            
        }

        public ScrapFrm2(UserInfo u)
        {
            InitializeComponent();
            this.uInfo = u;
            uInfo.LoadModelData(ref model_cbx);

            //dtModule.Columns.Add("sn");
            //dtModule.Columns.Add("model");
            //dtModule.Columns.Add("cheak");

            string sqlStr = "select * from t_category where type=2 and department='QA'";
            DataTable dt = new DataTable();
            dbFac.ExecuteDataTable(sqlStr, ref dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    cbx_reason.Items.Add(dt.Rows[i]["category_cd"].ToString().Trim());
                }
                cbx_reason.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 提交内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submit_btn_Click(object sender, EventArgs e)
        {
            if(model_cbx.SelectedItem.ToString() == "") return;
            if(rInfo.serials.Count<=0)
            {
                result_lbl.Text = "No data for upload";
                return;
            }
            rInfo.record_id = uInfo.r_user;
            rInfo.site = site_txt.Text;
            rInfo.holder_dept =string.Empty;
            rInfo.holder_emp = string.Empty;
            rInfo.holder_name = string.Empty;
            rInfo.register_emp = uInfo.r_user;
            rInfo.register_date = DateTime.Now;
            rInfo.register_name = uInfo.r_username;
            rInfo.type = 2;
            //rInfo.statue = "N";

            switch (cbx_reason.SelectedItem.ToString())
            {
                case "正常生产报废":
					rInfo.statue = "G";
                    break;
                case "半成品报废":
                    rInfo.statue = "H";
                    break;
                case "客户返品报废":
                    rInfo.statue = "C";
                    break;
                case "培训小组报废":
                    rInfo.statue = "E";
                    break;
                case "制造报废前扫描":
                    rInfo.statue = "B";
                    break;
				case "实验品保存":
					rInfo.statue = "Q";
					break;
                case "外观不良报废":
                    rInfo.statue = "A";
                    break;
            }


            rInfo.reason = cbx_reason.SelectedItem.ToString();
           
            MessageFrm mesFrm = new MessageFrm();
            mesFrm.label1.Text = "是否确认报废处理！";
            mesFrm.ShowDialog();
            DialogResult = mesFrm.DialogResult;
            bool flag=false;
            if (DialogResult==DialogResult.Yes)
            {
                flag = dbFaci.ExecuteObject(ref rInfo);
            }
            else
            {
                return;
            }
            if (flag == false)
            {
                MessageBox.Show("提交失败！请检查数据是否有误");
                return;
            }
            else
            {
                DialogResult = MessageBox.Show("成功提交！是否打印标签？", "信息提示", MessageBoxButtons.YesNo);
                if(DialogResult==DialogResult.Yes)
                {
                    InfoPrint iPrint = new InfoPrint(rInfo);
                    iPrint.Print();
                }
                rInfo = null;
                this.Close();
            }
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

            CheckAPI APIcheck = new CheckAPI();
            string category = APIcheck.modelCategory(barcode_txt.Text, model_cbx.SelectedItem.ToString());

            if (IsExists(barcode_txt.Text.ToUpper()) == false)
            {
                result_lbl.Text = "重复Error";
                return;
           }
            
          //  if (IsOkReturn(barcode_txt.Text.ToUpper(), model_cbx.SelectedItem.ToString()) == false)
          //  {
         //       result_lbl.Text = "Error";
         //       return;
         //   }

            serial se = new serial();
            se.serial_cd = barcode_txt.Text.ToUpper();
            se.model = model_cbx.SelectedItem.ToString();
			se.category = category;
            rInfo.serials.Add(se);
            updateGridView();
            barcode_txt.Text = "";
            barcode_txt.SelectAll();
        }
        
        /// <summary>
        /// 判断马达是否有重复
        /// </summary>
        /// <param name="serial_cd"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        private bool IsExists(string serial_cd)
        {
            if (rInfo != null)
            {
                foreach (serial ce in rInfo.serials)
                {
                    if (ce.serial_cd == serial_cd)
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
        /// <returns>true表示允许报废，false表示不允许</returns>
        private bool IsOkReturn(string serial_cd, string model)
        {
            DataTable t = new DataTable();
            string sql = "select m.record_id,m.serial_cd,m.model,r.register_date,r.type,r.statue," +
                        " row_number() over(partition by serial_cd, model order by serial_cd, r.record_id desc) as num " +
                        " from t_module m,t_record r where m.record_id = r.record_id and substring(serial_cd,1,17) = '" + serial_cd.Substring(0,17) + "' limit 1";
            dbFaci.ExecuteDataTable(sql, ref t);
            if (t.Rows.Count > 0)
            {
                if (t.Rows[0]["type"].ToString().Trim() == "2")
                {
                    return true;
                }
            }
            t = new DataTable();
            switch (model)
            {
                case "KK06":
                    //sql = "select  faci.serial_cd from t_faci_kk06 faci,m_process m " +
                //" where faci.proc_uuid = m.proc_uuid and serial_cd = '" + serial_cd.Substring(0,17) + "' and m.process_cd = 'AE-16_08MH' limit 1";
                    return true;
                    //break;
                case "KK07":
                    //sql = "select  faci.serial_cd from t_faci_kk07 faci,m_process m " +
                //" where faci.proc_uuid = m.proc_uuid and serial_cd = '" + serial_cd.Substring(0,17) + "' and m.process_cd = 'AE-16_08MH' limit 1";
                    return true;
                    //break;
                case "KK04":
                    return true;
            }
            dbFaci.ExcuteDataTableAOI(model, sql, ref t);
            if (t.Rows.Count > 0)
            {
                return true;
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
            t1 = comMethod.ConverToDataTable<serial>(rInfo.serials);
            moduleList_dgv.DataSource = t1;

            moduleList_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            qty_txt.Text =moduleList_dgv.Rows.Count.ToString();
        }
        
        /// <summary>
        /// 提交后初始化Form界面
        /// </summary>
        private void From_Initilzer()
        {
            rInfo = new RecordInfo();
          
            barcode_txt.Text = "";
            moduleList_dgv.DataSource = null;
        }
        
        /// <summary>
        /// 删除datagridview行的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void moduleList_dgv_UserDeletingRow(object sender,DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.Index < 0) return;
            string sn = moduleList_dgv.Rows[e.Row.Index].Cells[0].Value.ToString();
            DialogResult result= MessageBox.Show("确定删除[" + sn +"]马达 ?", "提示!", MessageBoxButtons.OKCancel);
            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
                return;
            }
            for(int i=0;i<rInfo.serials.Count;i++)
            {
                if(rInfo.serials[i].serial_cd==sn)
                {
                    rInfo.serials.RemoveAt(i);
                }
            }
            qty_txt.Text = rInfo.serials.Count.ToString();
        }

		private void cbx_reason_SelectedIndexChanged(object sender, EventArgs e)
		{
			barcode_txt.Text = qty_txt.Text = null;
			rInfo.serials.Clear();
			moduleList_dgv.Columns.Clear();
		}
	}
}
