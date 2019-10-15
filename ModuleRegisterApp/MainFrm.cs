using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Configuration;

namespace ModuleRegisterApp
{
    public partial class MainFrm : Form
    {
        #region Initializ class object
        public string r_user;
        public string r_dept;
        public UserInfo uInfo = new UserInfo();
        DBFactory dbFac = new DBFactory();
        RecordInfo rInfo = new RecordInfo();
        #endregion

        //定义ButtonColumn
        DataGridViewButtonColumn openTray;

        public MainFrm(UserInfo u)
        {
            InitializeComponent();
            Text = Text + "_" + Application.ProductVersion.ToString();
            uInfo = u;
            //uInfo.LoadDeptData(ref cboDept);
            cboDept.Items.AddRange(LoginFrm.deptArr);
            if (u.r_dept=="MFG")
            {
                ToolStripMenuItem3.Enabled = false;
            }
			if (u.r_dept == "PC")
			{
				//ToolStripMenuItem2.Enabled = false;
				toolStripMenuItem1.Enabled = false;
			}

            cboDept.SelectedIndex = 0;
            cboType.SelectedIndex = 0;

            uInfo.LoadModelData(ref cboModel);
        }

        /// <summary>
        /// 点击查找的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void search_btn_Click(object sender, EventArgs e)
        {
            Sumary_dgv.Columns.Clear();
			bool IsQuery = false;
            DataTable t1 = new DataTable();
            StringBuilder sql = new StringBuilder();
            sql.AppendLine("select rr.record_id,rr.site,rr.register_date,rr.holder_dept,rr.holder_name,rr.type,");
            sql.AppendLine("count(mm.serial_cd) as qty,rr.category_cd,mm.model");
            sql.AppendLine("from t_record as rr");
            sql.AppendLine("left join t_module as mm on rr.record_id = mm.record_id");
            sql.AppendLine("left join t_carton as cc on mm.record_id=cc.record_id");


            if (chkDept.Checked)
            {
                if (IsQuery)
                    sql.AppendLine("and");
                else
                    sql.AppendLine("where");
                sql.AppendLine(string.Format("rr.holder_dept = '{0}'", cboDept.Text));
                IsQuery = true;
            }

            if (chkModule.Checked)
            {
                if (IsQuery)
                    sql.AppendLine("and");
                else
                    sql.AppendLine("where");
                //sql.AppendLine(string.Format("mm.serial_cd = '{0}'", module_txt.Text));
                sql.AppendLine($"rr.record_id in(SELECT record_id FROM t_module where serial_cd='{module_txt.Text}')");
                IsQuery = true;
            }
            if (chkRecordID.Checked)
            {
                if (IsQuery)
                    sql.AppendLine("and");
                else
                    sql.AppendLine("where");
                sql.AppendLine(string.Format("rr.record_id='{0}'", RecordID_txt.Text));
                IsQuery = true;
            }

            if (chkDateShift.Checked)
            {
                if (IsQuery)
                    sql.AppendLine("and");
                else
                    sql.AppendLine("where");
                sql.AppendLine(string.Format("rr.register_date >= '{0}' and rr.register_date<'{1}'"
                    , dateTimePicker1.Value.ToString("yyyy-MM-dd"), dateTimePicker2.Value.AddDays(1).ToString("yyyy-MM-dd")));
                IsQuery = true;
            }

            if (chkCartonID.Checked)
            {
                if (IsQuery)
                    sql.AppendLine("and");
                else
                    sql.AppendLine("where");
                sql.AppendLine(string.Format("cc.carton_id='{0}'", carton_txt.Text));
                IsQuery = true;
            }


            if (chkMemo.Checked)
            {
                if (IsQuery)
                    sql.AppendLine("and");
                else
                    sql.AppendLine("where");
                sql.AppendLine(string.Format("rr.category_cd like '%{0}%'", Memo_txt.Text));
                IsQuery = true;
            }

            if (chkType.Checked)
            {
                if (IsQuery)
                    sql.AppendLine("and");
                else
                    sql.AppendLine("where");
                sql.AppendLine(string.Format("rr.type = '{0}'", cboType.Text.Substring(0,1)));
                IsQuery = true;
            }
            if (chkModel.Checked)
            {
                if (IsQuery)
                    sql.AppendLine("and");
                else
                    sql.AppendLine("where");
                sql.AppendLine(string.Format("mm.model = '{0}'", cboModel.Text));
                IsQuery = true;
            }

            if (IsQuery == true)
            {                
                sql.AppendLine("group by rr.record_id,rr.site,rr.register_date,rr.holder_dept,rr.holder_name,rr.type,rr.category_cd,mm.model");
                dbFac.ExecuteDataTable(sql.ToString(), ref t1);
            }
            if (t1 == null || t1.Rows.Count <= 0) return;
            LoadDataGridview(t1);
        }

        /// <summary>
        /// 加载dataGridView数据
        /// </summary>
        /// <param name="dt"></param>
        private void LoadDataGridview(DataTable dt)
        {
            Sumary_dgv.Columns.Clear();
            
            Sumary_dgv.DataSource = dt;
            dt.DefaultView.Sort = "register_date desc";
            this.Sumary_dgv.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(Sumary_dgv_cellFormating);
            Sumary_dgv.Columns[0].DataPropertyName = "record_id";
            Sumary_dgv.Columns[1].DataPropertyName = "site";
            Sumary_dgv.Columns[2].DataPropertyName = "register_date";
            Sumary_dgv.Columns[3].DataPropertyName = "holder_dept";
            Sumary_dgv.Columns[4].DataPropertyName = "holder_name";
            Sumary_dgv.Columns[5].DataPropertyName = "type";
            Sumary_dgv.Columns[6].DataPropertyName = "qty";
            addButtonsToDataGridView(Sumary_dgv);
            Sumary_dgv.AutoResizeColumns();
            Sumary_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            
            //this.Sumary_dgv.CellFormatting -= new System.Windows.Forms.DataGridViewCellFormattingEventHandler(Sumary_dgv_cellFormating);
        }

        /// <summary>
        /// 点击dataGridView控件的Open按键的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sumary_dgv_cellFormating(object sender,DataGridViewCellFormattingEventArgs e)
        {
            if(e.ColumnIndex>0)
            {
                if(Sumary_dgv.Columns[e.ColumnIndex].Name.Equals("type"))
                {
                    switch (e.Value.ToString())
                    {
                        case "0":
                            e.Value = "借出";
                            break;
                        case "1":
                            e.Value = "还入";
                            break;
                        case "2":
                            e.Value = "报废";
                            break;
                        case "3":
                            e.Value = "借出Site";
                            break;
                        case "4":
                            e.Value = "保留品";
                            break;
                    }
                }
            }
        }

        private void Sumary_dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int currentRow = int.Parse(e.RowIndex.ToString());

            if (Sumary_dgv.Columns[e.ColumnIndex] == openTray && currentRow >= 0)
            {
                rInfo = new RecordInfo();
                foreach (Form buff in Application.OpenForms)
                {
                    if (buff.Name == "InfoFrm")
                        {
                        MessageBox.Show("Please close the currently open form.", "Notice",
                        MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                        return;
                    }
                }

                rInfo.record_id = Sumary_dgv["record_id", currentRow].Value.ToString();
                DataTable t1 = new DataTable();
                string sql = "select * from t_record left join t_user on  t_record.register_emp=t_user.user_id where  record_id='" + rInfo.record_id + "'";
                dbFac.ExecuteDataTable(sql, ref t1);
                if (t1.Rows.Count > 0)
                {
                    rInfo.site = t1.Rows[0]["site"].ToString();
                    rInfo.holder_dept = t1.Rows[0]["holder_dept"].ToString();
                    rInfo.holder_emp = t1.Rows[0]["holder_emp"].ToString();
                    rInfo.holder_name = t1.Rows[0]["holder_name"].ToString();
                    rInfo.type = int.Parse(t1.Rows[0]["type"].ToString());
                    rInfo.statue = t1.Rows[0]["category_id"].ToString();
                    rInfo.register_date = DateTime.Parse(t1.Rows[0]["register_date"].ToString());
                    rInfo.register_emp = t1.Rows[0]["register_emp"].ToString();
                    rInfo.register_name = t1.Rows[0]["user_name"].ToString();
                    rInfo.reason = t1.Rows[0]["category_cd"].ToString();
                }
                
                t1 = new DataTable();
                sql = "select serial_cd,model from t_module where record_id='"+ rInfo.record_id + "'";
                dbFac.ExecuteDataTable(sql, ref t1);
                if(t1.Rows.Count>0)
                {
                    for(int i=0;i<t1.Rows.Count;i++)
                    {
                        serial se = new serial();
                        se.serial_cd = t1.Rows[i]["serial_cd"].ToString().Trim();
                        se.model = t1.Rows[i]["model"].ToString().Trim();
                        rInfo.serials.Add(se);
                    }
                }

                InfoFrm iFrm = new InfoFrm(rInfo);
                iFrm.Show();
            }
        }

        private void addButtonsToDataGridView(DataGridView dgv)
        {
            openTray = new DataGridViewButtonColumn();
            openTray.HeaderText = string.Empty;
            openTray.Text = "Open";
            openTray.UseColumnTextForButtonValue = true;
            openTray.Width = 80;
            dgv.Columns.Add(openTray);
        }

        /// <summary>
        /// 打开【还入登记】窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach(Form f in Application.OpenForms)
            {
                if(f.Name=="ReturnModuleFrm")
                {
                    isOpen = true;
                }
            }
            if (!isOpen)
            {
                ReturnModuleFrm rFrm = new ReturnModuleFrm(uInfo);
                rFrm.Show();
            }
        }

        /// <summary>
        /// 打开【借出登记】窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BerrowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "RegisterFrm")
                {
                    isOpen = true;
                }
            }
            if (!isOpen)
            {
                RegisterFrm rFrm = new RegisterFrm(uInfo);
                rFrm.Show();
            }
        }

        /// <summary>
        /// 打开报废窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "ScrapFrm")
                {
                    isOpen = true;
                }
            }
            if (!isOpen)
            {
                ScrapFrm sFrm = new ScrapFrm(uInfo);
                sFrm.Show();
            }
        }

        /// <summary>
        /// 打开报废装箱界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScrapCartonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "ScrapCartonFrm")
                {
                    isOpen = true;
                }
            }
            if (!isOpen)
            {
                ScrapCartonFrm scFrom = new ScrapCartonFrm(uInfo);
                scFrom.Show();
            }
        }

		/// <summary>
		/// 打开借出厂外界面
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void outToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool isOpen = false;
			foreach (Form f in Application.OpenForms)
			{
				if (f.Name == "OutSiteRegister")
				{
					isOpen = true;
				}
			}
			if (!isOpen)
			{
				OutSiteRegister scFrom = new OutSiteRegister(uInfo);
				scFrom.Show();
			}
		}

		private void ProduceScrapToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool isOpen = false;
			foreach (Form f in Application.OpenForms)
			{
				if (f.Name == "ScrapFrm1")
				{
					isOpen = true;
				}
			}
			if (!isOpen)
			{
				ScrapFrm1 sFrm1 = new ScrapFrm1(uInfo);
				sFrm1.Show();
			}
		}

		private void 报废ToolStripMenuItem_Click(object sender, EventArgs e)
		{
			bool isOpen = false;
			foreach (Form f in Application.OpenForms)
			{
				if (f.Name == "ScrapFrm2")
				{
					isOpen = true;
				}
			}
			if (!isOpen)
			{
				ScrapFrm2 sFrm2 = new ScrapFrm2(uInfo);
				sFrm2.Show();
			}
		}

        private void ScrapPalletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "ScrapPalletFrm")
                {
                    isOpen = true;
                }
            }
            if (!isOpen)
            {
                ScrapBigCartonFrm scFrom = new ScrapBigCartonFrm(uInfo);
                scFrom.Show();
            }
        }

        private void 保留品登记ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "ReservationIn")
                {
                    isOpen = true;
                }
            }
            if (!isOpen)
            {
                ReservationIn form = new ReservationIn(uInfo);
                form.Show();
            }
        }

        private void 保留品取出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "ReservationOut")
                {
                    isOpen = true;
                }
            }
            if (!isOpen)
            {
                ReservationOut form = new ReservationOut(uInfo);
                form.Show();
            }
        }

        private void 保留品装箱ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "ReservationCartonFrm")
                {
                    isOpen = true;
                }
            }
            if (!isOpen)
            {
                ReservationCartonFrm form = new ReservationCartonFrm(uInfo);
                form.Show();
            }
        }

        private void 保留品装大箱ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "ReservationBigCartonFrm")
                {
                    isOpen = true;
                }
            }
            if (!isOpen)
            {
                ReservationBigCartonFrm form = new ReservationBigCartonFrm(uInfo);
                form.Show();
            }
        }

        private void 重新打印ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Reprint")
                {
                    isOpen = true;
                }
            }
            if (!isOpen)
            {
                new Reprint().Show();
            }
        }
    }
}
