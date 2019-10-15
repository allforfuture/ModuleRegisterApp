using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ThoughtWorks.QRCode.Codec;

namespace ModuleRegisterApp
{
    public partial class Reprint : Form
    {
        
        public Reprint()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgv.RowCount <= 0)
                return;
            if (DialogResult.OK == new PrintDialog().ShowDialog())
            {
                printDocument1.Print();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string sql="";
            if (rbtnP.Checked)
            {
                sql =
$@"SELECT b.carton_id AS ID,
b.record_id,
TO_CHAR(b.create_date,'YYYY/MM/DD')AS register_date,
CASE
	WHEN a.type = 0 THEN '借出'
	WHEN a.type = 1 THEN '还入'
	WHEN a.type = 2 THEN '报废'
	WHEN a.type = 3 THEN '厂外借出'
	WHEN a.type = 4 THEN '保留品'		  
END AS type,
c.model,
d.user_name,
COUNT(DISTINCT c.serial_cd),
a.category_cd
FROM t_record AS a
JOIN t_carton AS b ON a.record_id = b.record_id
JOIN t_module AS c ON a.record_id = c.record_id
JOIN t_user AS d ON b.create_user = d.user_id
WHERE b.carton_id in (SELECT carton_id FROM t_carton WHERE record_id = '{txtID.Text}')
GROUP BY b.carton_id,b.record_id,b.create_date,a.type,a.category_cd,c.model,d.user_name";
            }
            else if (rbtnL.Checked)
            {
                sql =
$@"SELECT b.carton_big_id AS ID,
b.carton_id,
TO_CHAR(b.create_date,'YYYY/MM/DD')AS register_date,
CASE
	WHEN c.type = 0 THEN '借出'
	WHEN c.type = 1 THEN '还入'
	WHEN c.type = 2 THEN '报废'
	WHEN c.type = 3 THEN '厂外借出'
	WHEN c.type = 4 THEN '保留品'		  
END AS type,
d.model,
e.user_name,
COUNT(DISTINCT d.serial_cd),
c.category_cd
FROM t_carton AS a
JOIN t_carton_big AS b ON a.carton_id = b.carton_id
JOIN t_record AS c ON a.record_id = c.record_id
JOIN t_module AS d ON c.record_id=d.record_id
JOIN t_user AS e ON b.create_user = e.user_id
WHERE b.carton_big_id in (SELECT carton_big_id FROM t_carton_big WHERE carton_id='{txtID.Text}')
GROUP BY b.carton_big_id,b.carton_id,b.create_date,c.type,c.category_cd,d.model,e.user_name";
            }

            new DBFactory().ExecuteDataTable(sql, ref dt);
            dgv.DataSource = dt;
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int r1 = 2, r2 = 62, r3 = 142, r4 = 190, r5 = 200;
            int c1 = 3, c2 = 43, c3 = 83, c4 = 123, c5 = 163, c6 = 203;

            string ID= dgv.Rows[0].Cells["ID"].Value.ToString();
            string Date= dgv.Rows[0].Cells["register_date"].Value.ToString();
            string Type= dgv.Rows[0].Cells["type"].Value.ToString();
            string Model= dgv.Rows[0].Cells["model"].Value.ToString();
            string Owner= dgv.Rows[0].Cells["user_name"].Value.ToString();
            int Qty=0;
            foreach (DataGridViewRow dr in dgv.Rows)
            {
                Qty += Convert.ToInt16(dr.Cells["count"].Value);
            }
            string Reason= dgv.Rows[0].Cells["category_cd"].Value.ToString();

            

            try
            {
                Font f1 = new Font("宋体", 12);
                Brush brush1 = new SolidBrush(Color.Black);
                string tmpStr;

                tmpStr = "ID:";
                g.DrawString(tmpStr, f1, brush1, new Point(r1, c1));
                g.DrawString(ID, f1, brush1, new Point(r2, c1));
                Image img = ImgCreate(ID);
                g.DrawImage(img, new Point(r5, c1));

                tmpStr = "Date:";
                g.DrawString(tmpStr, f1, brush1, new Point(r1, c2));
                g.DrawString(Date, f1, brush1, new Point(r2, c2));

                tmpStr = "Type:";
                g.DrawString(tmpStr, f1, brush1, new Point(r1, c3));
                g.DrawString(Type, f1, brush1, new Point(r2, c3));

                tmpStr = "Model:";
                g.DrawString(tmpStr, f1, brush1, new Point(r3, c3));
                g.DrawString(Model, f1, brush1, new Point(r4, c3));

                tmpStr = "Owner:";
                g.DrawString(tmpStr, f1, brush1, new Point(r1, c4));
                g.DrawString(Owner, f1, brush1, new Point(r2, c4));

                tmpStr = "Qty:";
                g.DrawString(tmpStr, f1, brush1, new Point(r1, c5));
                g.DrawString(Qty.ToString(), f1, brush1, new Point(r2, c5));

                if (ID.Substring(8, 1) == "P")
                {
                    tmpStr = "Reason:";
                    g.DrawString(tmpStr, f1, brush1, new Point(r1, c6));
                    Rectangle rec1 = new Rectangle(r2, c6, 200, 90);
                    g.DrawString(Reason, f1, brush1, rec1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Print failed." + System.Environment.NewLine + ex.Message,
                   "Print Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public Image ImgCreate(string text)
        {
            QRCodeEncoder coder = new QRCodeEncoder();
            coder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            coder.QRCodeScale = 1;
            coder.QRCodeVersion = 7;
            return coder.Encode(text);
        }
    }
}
