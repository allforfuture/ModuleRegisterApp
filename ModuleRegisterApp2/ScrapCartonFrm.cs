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
    public partial class ScrapCartonFrm : Form
    {
        #region private file
        UserInfo uInfo;
        CartonInfo cInfo;
        PrintLabel pLable;
        int nowNum, allNum;
        #endregion

        public ScrapCartonFrm(UserInfo uInfo)
        {
            InitializeComponent();
            this.uInfo = new UserInfo();
            this.uInfo = uInfo;
            this.Form_Load();
        }

        private void Form_Load()
        {
            nowNum = 0;
            allNum = 0;
            cInfo = new CartonInfo();
            pLable = new PrintLabel();
            Record_txt.Enabled = false;
            Carton_txt.KeyDown += new KeyEventHandler(Carton_txt_KeyDown);
            Record_txt.KeyDown += new KeyEventHandler(Record_txt_KeyDown);
            
        }

        private void Carton_txt_KeyDown(object sender,KeyEventArgs e)
        {
            cInfo.SetCartonInfo(Carton_txt.Text);
            if (cInfo.Qty != 0)
            {
                Carton_txt.Enabled = false;
                NewCarton_btn.Enabled = false;
                Record_txt.Enabled = true;
                allNum = cInfo.Qty;
                Qty_txt.Text = allNum.ToString();
                cInfo.Carton_id = Carton_txt.Text.ToUpper();
            }
        }

        private void Record_txt_KeyDown(object sender,KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;
            if (Record_txt.Text.Length < 13)
                return;
            if (!SN_Validation(Record_txt.Text))
                return;
            allNum = allNum + nowNum;
            Qty_txt.Text = nowNum.ToString()+ "/" + allNum.ToString();
            LoadGridView();
        }

        private void NewCarton_btn_Click(object sender, EventArgs e)
        {
            string newCartonID = DBHelper.GetNewCartonId();
            Carton_txt.Enabled = false;
            NewCarton_btn.Enabled = false;
            Record_txt.Enabled = true;
            cInfo.Carton_id = newCartonID.ToUpper();
            Qty_txt.Text = "0";
        }

        /// <summary>
        /// 加载dataGridView控件
        /// </summary>
        private void LoadGridView()
        {
            dataGridView1.Columns.Clear();

            if (cInfo.Records.Count < 1)
                return;
            dataGridView1.DataSource = ComMethod.ConverToDataTable<RecordInfo>(cInfo.Records);
            dataGridView1.Columns[0].DataPropertyName = "record_id";
            dataGridView1.Columns[1].DataPropertyName = "qty";
            dataGridView1.AutoSize = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        /// <summary>
        /// 提交并打印标签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Print_btn_Click(object sender, EventArgs e)
        {
            if (cInfo.Records.Count < 1)
                return;
            cInfo.Create_date = DateTime.Now;
            cInfo.Create_user = uInfo.User_id;
            cInfo.Status = 0;
            if(!cInfo.WriteDB())
            {
                //have some error once write to db "
                return;
            }
            MessageBox.Show("write to db is sucess", "infonation");
            DataTable dt = new DataTable();
            pLable.Print(ref dt);
        }

        /// <summary>
        /// 判断sn是否可以添加
        /// </summary>
        /// <param name="sn">马达sn</param>
        /// <returns>true可以添加，false不允许添加</returns>
        private bool SN_Validation(string sn)
        {
            if (cInfo != null)
            {
                foreach (RecordInfo se in cInfo.Records)
                {
                    if (se.Record_id == sn)
                        return false;
                }
            }
            RecordInfo rInfo = new RecordInfo();
            rInfo.SetRecordInfo(sn);
            if (rInfo.Serials.Count < 1)
                return false;
            cInfo.Records.Add(rInfo);
            nowNum = nowNum + rInfo.Serials.Count;
            return true;
        }
    }
}
