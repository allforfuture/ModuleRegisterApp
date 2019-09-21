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
    public partial class MainFrm : Form
    {
        UserInfo uInfo = new UserInfo();
        DataGridViewButtonColumn dgvBtnCol  =new DataGridViewButtonColumn();

        public MainFrm(UserInfo uInfo)
        {
            InitializeComponent();
            this.uInfo = uInfo;
            dept_combo.DataSource = DeptInfo.partList;
            Sumary_dgv.CellClick += new DataGridViewCellEventHandler(Sumary_dgv_CellClick);
            
        }

        private void search_btn_Click(object sender, EventArgs e)
        {

            //((DataTable)Sumary_dgv.DataSource).Clear();
            Sumary_dgv.Columns.Clear();

            //Setting dataGridViewButtonColumn
            dgvBtnCol.HeaderText = "Event";
            dgvBtnCol.Text = "Open";
            dgvBtnCol.UseColumnTextForButtonValue = true;
            dgvBtnCol.Width = 80;

            #region This SQL of search  

            string sql = "SELECT record_id, site,  register_date, type,(select count(serial_cd) from t_module where record_id=t_record.record_id) as qty,holder_dept,holder_name " +
                " FROM public.t_record where 1=1  ";
            if (dept_cbx.Checked == true && dept_combo.SelectedItem.ToString()!="")
                sql =sql+ "and holder_dept='"+ dept_combo.SelectedItem.ToString() + "'";
                
            if (module_cbx.Checked == true && module_txt.Text!="")
                sql = sql + " and record_id in (select record_id from t_module where serial_cd='"+ module_txt.Text+"'";

            if (dateShift_cbx.Checked == true && (DateTime.Parse(dateTimePicker1.Text) <= DateTime.Parse(dateTimePicker2.Text)))
                sql =sql+ " and register_date>='"+ DateTime.Parse(dateTimePicker1.Text).ToString("yyyy-MM-dd 00:00:00") + "' and register_date<='" + DateTime.Parse(dateTimePicker2.Text).ToString("yyyy-MM-dd 23:59:59") + "'";

            if (carton_chb.Checked == true && carton_txt.Text!="")
                sql = " and t_record in (select record_ id from t_carton where carton_id='"+ carton_txt.Text+"'";

            if (meno_cbx.Checked == true && Memo_txt.Text != "")
                sql = sql+ " and reason='"+ Memo_txt.Text +"'";

            if (RecordID_chb.Checked == true && RecordID_txt.Text!="")
                sql = sql + " and record_id='"+ RecordID_txt.Text +"'";
            sql = sql + " order by register_date desc limit 200 ";
            #endregion

            DataTable dt = new DataTable();
            DBHelper.ExecuteRefDT(sql, ref dt);

            if(dt.Rows.Count<0) ((DataTable)Sumary_dgv.DataSource).Clear();
            //Delegate cellFormatting to Sumary_dgv_CellFormating method
            Sumary_dgv.CellFormatting += new DataGridViewCellFormattingEventHandler(Sumary_dgv_CellFormating);

            Sumary_dgv.DataSource = dt;
            Sumary_dgv.Columns.Add(dgvBtnCol);

            //Auto  resize dataGridView columns
            Sumary_dgv.AutoResizeColumns();
            Sumary_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        /// <summary>
        /// Design user click dataGridView cell ,open "infoFrm" form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sumary_dgv_CellClick(object sender,DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 7)
                return;
            if (e.RowIndex < 0)
                return;
            string recordID = Sumary_dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (recordID != "")
            {
                InfoFrm iFrm = new InfoFrm(recordID);
                iFrm.Show();
            }
        }

        /// <summary>
        ///Disign conver integer to string by Use dataGridViewCellFormating 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sumary_dgv_CellFormating(object sender,DataGridViewCellFormattingEventArgs e)
        {
            //if (e.RowIndex <= 0)
            //    return;
            if(Sumary_dgv.Columns[e.ColumnIndex].Name=="type")
            {
                if (e.Value == null)
                    return;
                switch(e.Value.ToString())
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

        private void BellowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach(Form m in Application.OpenForms)
            {
                if (m.Name == "BellowFrm")
                    return;
            }
            BellowFrm bFrm = new BellowFrm(uInfo);
            bFrm.frmRefreshEvent += delegate (DataTable dt)
            {
                ReLoadDataGridView(dt);
            };
            bFrm.Show();
        }

        private void ReturnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form m in Application.OpenForms)
            {
                if (m.Name == "ReturnFrm")
                    return;
            }
            ReturnFrm rFrm = new ReturnFrm(uInfo);
            rFrm.frmRefreshEvent += delegate (DataTable dt)
            {
                ReLoadDataGridView(dt);
            };
            rFrm.Show();
        }

        private void BellowSiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form m in Application.OpenForms)
            {
                if (m.Name == "BellowSiteFrm")
                    return;
            }
            BellowSiteFrm bsFrm = new BellowSiteFrm(uInfo);
            bsFrm.frmRefreshEvent += delegate (DataTable dt)
            {
                ReLoadDataGridView(dt);
            };
            bsFrm.Show();
        }

        private void ScrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form m in Application.OpenForms)
            {
                if (m.Name == "ScrapFrm")
                    return;
            }
            ScrapFrm sFrm = new ScrapFrm(uInfo);
            sFrm.frmRefreshEvent += delegate (DataTable dt)
            {
                ReLoadDataGridView(dt);
            };
            sFrm.Show();
        }

        private void ScrapCartonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form m in Application.OpenForms)
            {
                if (m.Name == "ScrapCartonFrm")
                    return;
            }
            ScrapCartonFrm scFrm = new ScrapCartonFrm(uInfo);
            scFrm.Show();
        }

        private void ReLoadDataGridView(DataTable dt)
        {
            Sumary_dgv.Columns.Clear();

            //Setting dataGridViewButtonColumn
            dgvBtnCol.HeaderText = "Event";
            dgvBtnCol.Text = "Open";
            dgvBtnCol.UseColumnTextForButtonValue = true;
            dgvBtnCol.Width = 80;
            
            Sumary_dgv.DataSource = dt;
            Sumary_dgv.Columns.Add(dgvBtnCol);
            Sumary_dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
	}
}
