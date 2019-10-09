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
	public partial class ScrapBigCartonFrm : Form
	{
		UserInfo uInfo = new UserInfo();
		DBFactory dbFaci = new DBFactory();
		DataTable dtRecord;
		DateTime registerDate;
		InfoPrint iPrint = new InfoPrint();

		int todayNum, sumNum;

		public ScrapBigCartonFrm()
		{
			InitializeComponent();
		}

		public ScrapBigCartonFrm(UserInfo u)
		{
			InitializeComponent();
			InitializeDataTable();
			txtQty.Text = "0/0";
			this.uInfo = u;
		}

		private void InitializeDataTable()
		{
			todayNum = 0;
			sumNum = 0;
			dtRecord = new DataTable("dtRecord");
            dtRecord.Columns.Add("carton_id");
            dtRecord.Columns.Add("type");
			dtRecord.Columns.Add("model");
			dtRecord.Columns.Add("qty");
		}

		/// <summary>
		/// 扫描箱号时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Carton_txt_KeyDown(object sender, KeyEventArgs e)
		{
            if (e.KeyCode != Keys.Enter || txtCartonBig.Text.Length != 12) return;
            if (txtCartonBig.Text.Substring(8, 1) != "B")
            {
                MessageBox.Show("Wrong format!");
                return;
            }
            string sql =
$@"SELECT carton_big_id,model,COUNT(serial_cd) AS qty
FROM t_carton_big Big,t_carton Carton,t_record Record,t_module Module
WHERE Big.carton_id=Carton.carton_id
AND Carton.record_id = Record.record_id
AND Record.record_id = Module.record_id
AND Big.carton_big_id = '{txtCartonBig.Text}'
AND Big.status=0
GROUP BY carton_big_id,model";


            DataTable dt = new DataTable();
			dbFaci.ExecuteDataTable(sql, ref dt);

			if (dt != null && dt.Rows.Count > 0)
			{
				txtCartonBig.Text = txtCartonBig.Text.ToUpper();
				txtQty.Text = "0/" + dt.Rows[0]["qty"].ToString();
				txtModel.Text = dt.Rows[0]["model"].ToString();
				sumNum = int.Parse(dt.Rows[0]["qty"].ToString());
				LoadDataGridView();
				txtCarton.Enabled = true;
				txtCartonBig.Enabled = false;
				btnPrint.Enabled = true;
				btnBigCarton.Enabled = false;
				txtCarton.SelectAll();
				registerDate = DateTime.Now;
			}
			else
			{
				MessageBox.Show("Not found the carton_big info!");
			}
		}

		/// <summary>
		/// 扫描Record时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TxtCarton_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Enter) return;
            lblErr.Text = "";
            if (txtCarton.Text.Length != 12)
			{
				lblErr.Text = "Please check the record length!";
				return;
			}
            if (txtCarton.Text.Substring(8, 1) != "C")
            {
                MessageBox.Show("Wrong format!");
                return;
            }

            string sql = 
$@"WITH DataTable
AS (SELECT Carton.carton_id,Pack.type,Module.model
FROM t_carton Carton
LEFT JOIN t_record Pack ON Carton.record_id=Pack.record_id
LEFT JOIN t_module Module ON Pack.record_id=Module.record_id
WHERE Carton.carton_id NOT IN(SELECT carton_id FROM t_carton_big WHERE status = 0 )
AND Carton.carton_id='{txtCarton.Text.ToUpper().Trim()}')
SELECT carton_id,type,model,COUNT(*) AS qty
FROM DataTable
GROUP BY carton_id,type,model";
            DataTable t1 = new DataTable();
			dbFaci.ExecuteDataTable(sql, ref t1);

			if (t1 == null || t1.Rows.Count <= 0)
			{
				lblErr.Text = "Not found the carton info!";
				return;
			}
            //是否重复输入
			if (!IsExists(txtCarton.Text.Trim().ToUpper()))
			{
				lblErr.Text = "The carton id is had add!";
				return;
			}
			//不是第一次输入且model不相同就返回报错
			if (t1.Rows[0]["model"].ToString() != txtModel.Text && txtModel.Text != string.Empty)
			{
				lblErr.Text = "Can't add different model !";
				return;
			}
			string carton_id = txtCarton.Text.Trim().ToUpper();
			string pallet_id = txtCartonBig.Text.Trim().ToUpper();

            sql = $@"INSERT INTO t_carton_big(carton_big_id,carton_id,create_user,create_date,status)VALUES('{pallet_id}','{carton_id}','{uInfo.r_user}','{registerDate}',0)";
            if (dbFaci.ExecuteSQL(sql) == 1)
			{
                DataRow dr = dtRecord.NewRow();
				dr["carton_id"] = t1.Rows[0]["carton_id"].ToString();
				dr["type"] = t1.Rows[0]["type"].ToString();
				dr["model"] = t1.Rows[0]["model"].ToString();
				dr["qty"] = t1.Rows[0]["qty"].ToString();
				if (txtModel.Text == string.Empty) txtModel.Text = t1.Rows[0]["model"].ToString();
				dtRecord.Rows.Add(dr);
				LoadDataGridView();
				todayNum = todayNum + int.Parse(t1.Rows[0]["qty"].ToString());
				sumNum = sumNum + int.Parse(t1.Rows[0]["qty"].ToString());
				txtQty.Text = todayNum.ToString() + "/" + sumNum.ToString();
				return;
			}
			else
			{
				lblErr.Text = "Unload to server!";
				return;
			}
        }

		/// <summary>
		/// 判断记录号是否有重复
		/// </summary>
		/// <param name="carton_id"></param>
		/// <param name="dt"></param>
		/// <returns></returns>
		private bool IsExists(string carton_id)
		{
			if (dtRecord != null && dtRecord.Rows.Count > 0)
			{
				foreach (DataRow ce in dtRecord.Rows)
				{
					if (ce["carton_id"].ToString() == carton_id)
					{
						return false;
					}
				}
			}
			return true;
		}

		/// <summary>
		/// 取新的箱号
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnBigCarton_Click(object sender, EventArgs e)
		{
            string tmp = dbFaci.GetNewCartonId("carton_big","B");
			txtCartonBig.Text = tmp;
			txtCartonBig.Enabled = false;
			txtCarton.Enabled = true;
			btnPrint.Enabled = true;
			txtCarton.SelectAll();
			registerDate = DateTime.Now;
		}

		/// <summary>
		/// 打印标签
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnPrint_Click(object sender, EventArgs e)
		{
			if (txtCartonBig.Text != "" && sumNum != 0)
			{
				DataTable dt = new DataTable();
				dt.Columns.Add("carton_id");
				dt.Columns.Add("date");
				dt.Columns.Add("type");
				dt.Columns.Add("model");
				dt.Columns.Add("owner");
				dt.Columns.Add("qty");
				DataRow dr = dt.NewRow();
				dr["carton_id"] = txtCartonBig.Text.ToUpper();
				dr["date"] = registerDate.ToString("yyyy/MM/dd");
				dr["type"] = "报废";
				dr["model"] = txtModel.Text;
				dr["owner"] = uInfo.r_username;
				dr["qty"] = sumNum.ToString();
				dt.Rows.Add(dr);
				iPrint.Print(ref dt);
				txtCarton.Enabled = false;
			}
		}

		/// <summary>
		/// 加载DataGridView控件的数据
		/// </summary>
		private void LoadDataGridView()
		{
			dgv.DataSource = null;
			if (dtRecord != null)
			{
				dgv.DataSource = dtRecord;
				dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			}
		}
	}
}
