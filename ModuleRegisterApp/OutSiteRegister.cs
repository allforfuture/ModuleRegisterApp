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
    public partial class OutSiteRegister : Form
    {
        #region Initialzi calss object
        UserInfo uInfo = new UserInfo();
        DBFactory dbFaci = new DBFactory();
        RecordInfo rInfo = new RecordInfo();
        ComMethod comMethod = new ComMethod();
        InfoPrint iPrint;
        #endregion

        public OutSiteRegister(UserInfo u)
        {
            InitializeComponent();
            uInfo = u;
            uInfo.LoadDeptData(ref dept_cbx);
            uInfo.LoadModelData(ref model_cbx);
            dept_cbx.SelectedItem = 0;
            model_cbx.SelectedIndex = 1;
        }

        /// <summary>
        /// 提交内容
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

            if (id_txt.Text == "" || name_txt.Text == "" || dept_cbx.SelectedItem.ToString() == "" || reason_txt.Text == "") return;
            rInfo.record_id = uInfo.r_user;
            rInfo.site = site_txt.Text;
            rInfo.holder_dept = dept_cbx.SelectedItem.ToString();
            rInfo.holder_emp = id_txt.Text.ToUpper();
            rInfo.holder_name = name_txt.Text;
            rInfo.register_emp = uInfo.r_user;
            rInfo.register_date = DateTime.Now;
            rInfo.register_name = uInfo.r_username;
            rInfo.type = 3;
            rInfo.statue = "N";
            rInfo.reason = reason_txt.Text;

            bool flag = dbFaci.ExecuteObject(ref rInfo);
            if (flag == false)
            {
                MessageBox.Show("提交失败！请检查数据是否有误");
                return;
            }
            
            MessageBox.Show("提交成功!", "提示!", MessageBoxButtons.OK);
            rInfo = null;
            this.Close();
        }

        /// <summary>
        /// 输入条码时响应的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barcode_txt_Enter(object sender, KeyEventArgs e)
        {
            result_lbl.Text = "";
            if (e.KeyCode != Keys.Enter) return;

            if (model_cbx.SelectedItem.ToString() == "")
            {
                result_lbl.Text = "Error";
                return;
            }
            if (barcode_txt.Text.Length < 24)
            {
                result_lbl.Text = "Error";
                return;
            }
            barcode_txt.Text = barcode_txt.Text.Substring(0, 24);

            if (IsExists(barcode_txt.Text.ToUpper()) == false)
            {
                result_lbl.Text = "Error";
                return;
            }

            if (IsOkReturn(barcode_txt.Text.ToUpper(), model_cbx.SelectedItem.ToString()) == false)
            {
                result_lbl.Text = "Error";
                return;
            }

            serial se = new serial();
            se.serial_cd = barcode_txt.Text.ToUpper();
            se.model = model_cbx.SelectedItem.ToString();
            rInfo.serials.Add(se);
            updateGridView();
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

                foreach (serial se in rInfo.serials)
                {
                    if (se.serial_cd == serial_cd)
                    {
                        return false;
                    }
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
            DataTable t1 = new DataTable("t1");
            t1 = comMethod.ConverToDataTable<serial>(rInfo.serials);

            moduleList_dgv.DataSource = t1;
            moduleList_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            qty_txt.Text = rInfo.serials.Count().ToString();

        }

        /// <summary>
        /// 判断马达是否是借出状态和AOI是否存在
        /// </summary>
        /// <param name="serial_cd"></param>
        /// <param name="dt"></param>
        /// <returns>true表示允许借，false表示不允许</returns>
        private bool IsOkReturn(string serial_cd, string model)
        {
            DataTable t = new DataTable();
            string sql = "select m.record_id,m.serial_cd,m.model,r.register_date,r.type,r.statue," +
                        " row_number() over(partition by serial_cd, model order by serial_cd, r.record_id desc) as num " +
                        " from t_module m,t_record r where m.record_id = r.record_id and substring(serial_cd,1,17) = '" + serial_cd.Substring(0, 17) + "' limit 1";
            dbFaci.ExecuteDataTable(sql, ref t);
            if (t.Rows.Count > 0)
            {
                if (t.Rows[0]["type"].ToString().Trim() == "1" || t.Rows[0]["type"].ToString().Trim() == "2")
                {
                    return false;
                }
            }
            t = new DataTable();
            switch (model)
            {
                case "KK06":
                    return true;
                    //sql = "select  faci.serial_cd from t_faci_kk06 faci,m_process m " +
                //" where faci.proc_uuid = m.proc_uuid and serial_cd = '" + serial_cd.Substring(0, 17) + "' and m.process_cd = 'AE-16_17BL' limit 1";
                    //break;
                case "KK07":
                    return true;
                    //sql = "select  faci.serial_cd from t_faci_kk07 faci,m_process m " +
                //" where faci.proc_uuid = m.proc_uuid and serial_cd = '" + serial_cd.Substring(0, 17) + "' and m.process_cd = 'AE-16_17BL' limit 1";
                    //break;
                case "KK04":
                    return true;
            }
            dbFaci.ExcuteDataTableAOI(model, sql, ref t);
            if (t.Rows.Count > 0)
            {

                return true;
            }
            return false;
        }

        /// <summary>
        /// 点击打印操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Print_Click(object sender, EventArgs e)
        {
            iPrint = new InfoPrint(rInfo);
            iPrint.Print("借出登记");
        }

    }
}
