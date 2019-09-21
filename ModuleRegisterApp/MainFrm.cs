using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            uInfo = u;
            uInfo.LoadDeptData(ref dept_combo);
            if(u.r_dept=="MFG")
            {
                ToolStripMenuItem3.Enabled = false;
            }
			if (u.r_dept == "PC")
			{
				//ToolStripMenuItem2.Enabled = false;
				toolStripMenuItem1.Enabled = false;
			}
		}

        /// <summary>
        /// 点击查找的操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void search_btn_Click(object sender, EventArgs e)
        {
			//	刚刚改了改t_record表里的字段出现的问题
			//1查询				OK
			//2查询之后的open	ok
			//优化：
			//sql语句变成总(选择字段)分（条件筛选）机构

			Sumary_dgv.Columns.Clear();
			bool IsQuery = false;
			string sql= "select record_id,site,register_date,holder_dept,holder_name,type,(select count(serial_cd) from t_module where record_id=t_record.record_id) as qty,category_cd";
			DataTable t1 = new DataTable();
			if (dept_rbt.Checked==true)
			{
				sql += " from t_record where holder_dept = '" + dept_combo.SelectedItem.ToString() + "'";
				IsQuery = true;
			}
			else if (dateShift_rbt.Checked==true)
			{
				sql += " from t_record where register_date >= '" + dateTimePicker1.Value.ToString("yyyy-MM-dd 00:00:00") + "' and register_date<= '" + dateTimePicker2.Value.ToString("yyyy-MM-dd 23:59:00") + "'";
				IsQuery = true;
			}
			else if(module_rbt.Checked==true)
            {
                sql +=" from t_record where record_id in(select record_id from t_module where substring(serial_cd,1,17) = '" + module_txt.Text.Substring(0,17) + "' )";
				IsQuery = true;
			}
			else if (carton_rbt.Checked == true)
			{
				//特殊：要对比t_record r,t_carton c两个表sql语句和其他不相同
				sql = "select r.record_id,r.site,r.register_date,r.holder_dept,r.holder_name,r.type,(select count(serial_cd) from t_module where record_id=r.record_id) as qty,category_cd" +
				" from t_record r,t_carton c where r.record_id=c.record_id and c.carton_id='" + carton_txt.Text + "'";
				IsQuery = true;
			}
			else if(RecordID_rbt.Checked==true)
            {
                sql +=" from t_record where record_id='" + RecordID_txt.Text + "'";
				IsQuery = true;
			}
			else if (meno_rbt.Checked==true)
            {
				sql+= " from t_record where category_cd='" + Memo_txt.Text + "'";
				IsQuery = true;
			}
			if (IsQuery == true)
			{
				sql += " and category_id!='B'";
				dbFac.ExecuteDataTable(sql, ref t1);
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
				if (f.Name == "ScrapFrm")
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
	}
}
