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
	public partial class ScrapCartonFrm : Form
	{
		UserInfo uInfo = new UserInfo();
		DBFactory dbFaci = new DBFactory();
		DataTable dtRecord;
		DateTime registerDate;
		InfoPrint iPrint = new InfoPrint();

		int todayNum, sumNum;

		public ScrapCartonFrm()
		{
			InitializeComponent();
		}

		public ScrapCartonFrm(UserInfo u)
		{
			InitializeComponent();
			InitializeDataTable();
			Qty_txt.Text = "0/0";
			this.uInfo = u;
		}

		private void InitializeDataTable()
		{
			todayNum = 0;
			sumNum = 0;
			dtRecord = new DataTable("dtRecord");
			dtRecord.Columns.Add("record_id");
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
            if (e.KeyCode != Keys.Enter || Carton_txt.Text.Length != 12) return;
            if (Carton_txt.Text.Substring(8, 1) != "C")
            {
                MessageBox.Show("Wrong format!");
                return;
            }
            string sql = "select carton_id,model,count(serial_cd) as qty from t_carton c,t_record r,t_module m " +
					" where c.record_id = r.record_id and r.record_id = m.record_id and carton_id = '" + Carton_txt.Text + "' and c.status=0  group by carton_id,model";
			DataTable dt = new DataTable();
			dbFaci.ExecuteDataTable(sql, ref dt);

			if (dt != null && dt.Rows.Count > 0)
			{
				Carton_txt.Text = Carton_txt.Text.ToUpper();
				Qty_txt.Text = "0/" + dt.Rows[0]["qty"].ToString();
				model_txt.Text = dt.Rows[0]["model"].ToString();
				sumNum = int.Parse(dt.Rows[0]["qty"].ToString());
				LoadDataGridView();
				Record_txt.Enabled = true;
				Carton_txt.Enabled = false;
				Print_btn.Enabled = true;
				NewCarton_btn.Enabled = false;
				Record_txt.SelectAll();
				registerDate = DateTime.Now;
			}
			else
			{
				MessageBox.Show("Not found the carton info!");
			}
		}

		/// <summary>
		/// 扫描Record时
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Record_txt_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode != Keys.Enter) return;
            lblErr.Text = "";
            if (Record_txt.Text.Length != 12)
			{
				lblErr.Text = "Please check the record length!";
				return;
			}
            if (Record_txt.Text.Substring(8, 1) != "P")
            {
                MessageBox.Show("Wrong format!");
                return;
            }
            string sql = "select r.record_id,r.site,r.register_date,r.type,m.model,count(m.serial_cd) as qty " +
						//在记录表和马达表里查找数据，并左连接（因为先写记录再写马达属性表，所以左查询，即使是事务一起插入的）
						" from t_record r left join t_module m on r.record_id = m.record_id " +
						//以输入的id查询并不能被装过箱
						" where r.record_id not in(select record_id from t_carton where status = 0 ) and m.record_id =  '" + Record_txt.Text.ToUpper().Trim() + "' " +
						//以下面多个字段为一组
						" group by r.record_id,r.site,r.register_date,r.type,m.model";
			DataTable t1 = new DataTable();
			dbFaci.ExecuteDataTable(sql, ref t1);

			if (t1 == null || t1.Rows.Count <= 0)
			{
				lblErr.Text = "Not found the record info!";
				return;
			}
            //是否重复输入
			if (!IsExists(Record_txt.Text.Trim().ToUpper()))
			{
				lblErr.Text = "The record id is had add!";
				return;
			}
			//不是第一次输入且model不相同就返回报错
			if (t1.Rows[0]["model"].ToString() != model_txt.Text && model_txt.Text != string.Empty)
			{
				lblErr.Text = "Can't add different model !";
				return;
			}
			string record_id = Record_txt.Text.Trim().ToUpper();
			string carton_id = Carton_txt.Text.Trim().ToUpper();

			sql = "insert into t_carton(carton_id,record_id,create_user,create_date,status) values('" + carton_id + "','" + record_id + "','" + uInfo.r_user + "','" + registerDate + "',0)";
			if (dbFaci.ExecuteSQL(sql) == 1)
			{
				DataRow dr = dtRecord.NewRow();
				dr["record_id"] = t1.Rows[0]["record_id"].ToString();
				dr["type"] = t1.Rows[0]["type"].ToString();
				dr["model"] = t1.Rows[0]["model"].ToString();
				dr["qty"] = t1.Rows[0]["qty"].ToString();
				if (model_txt.Text == string.Empty) model_txt.Text = t1.Rows[0]["model"].ToString();
				dtRecord.Rows.Add(dr);
				LoadDataGridView();
				todayNum = todayNum + int.Parse(t1.Rows[0]["qty"].ToString());
				sumNum = sumNum + int.Parse(t1.Rows[0]["qty"].ToString());
				Qty_txt.Text = todayNum.ToString() + "/" + sumNum.ToString();
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
		/// <param name="record_id"></param>
		/// <param name="dt"></param>
		/// <returns></returns>
		private bool IsExists(string record_id)
		{
			if (dtRecord != null && dtRecord.Rows.Count > 0)
			{
				foreach (DataRow ce in dtRecord.Rows)
				{
					if (ce["record_id"].ToString() == record_id)
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
		private void NewCarton_btn_Click(object sender, EventArgs e)
		{
            string tmp = dbFaci.GetNewCartonId("carton","C");
			Carton_txt.Text = tmp;
			Carton_txt.Enabled = false;
			Record_txt.Enabled = true;
			Print_btn.Enabled = true;
			Record_txt.SelectAll();
			registerDate = DateTime.Now;
		}

		/// <summary>
		/// 打印标签
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Print_btn_Click(object sender, EventArgs e)
		{
			if (Carton_txt.Text != "" && sumNum != 0)
			{
				DataTable dt = new DataTable();
				dt.Columns.Add("carton_id");
				dt.Columns.Add("date");
				dt.Columns.Add("type");
				dt.Columns.Add("model");
				dt.Columns.Add("owner");
				dt.Columns.Add("qty");
				DataRow dr = dt.NewRow();
				dr["carton_id"] = Carton_txt.Text.ToUpper();
				dr["date"] = registerDate.ToString("yyyy/MM/dd");
				dr["type"] = "报废";
				dr["model"] = model_txt.Text;
				dr["owner"] = uInfo.r_username;
				dr["qty"] = sumNum.ToString();
				dt.Rows.Add(dr);
				iPrint.Print(ref dt);
				Record_txt.Enabled = false;
			}
		}

		/// <summary>
		/// 加载DataGridView控件的数据
		/// </summary>
		private void LoadDataGridView()
		{
			dataGridView1.DataSource = null;
			if (dtRecord != null)
			{
				dataGridView1.DataSource = dtRecord;
                //dataGridView1.Columns[0].DataPropertyName = "record_id";
                //dataGridView1.Columns[1].DataPropertyName = "type";
                //dataGridView1.Columns[2].DataPropertyName = "qty";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
			}
		}
	}
}
