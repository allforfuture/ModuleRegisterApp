using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using ThoughtWorks.QRCode.Codec;
using System.Data;

namespace ModuleRegisterApp
{
     public class InfoPrint
    {
        string m_PageTitle;
        RecordInfo rInfo=new RecordInfo();
        DataTable dt;
        //定义打印机对象
        protected  PrintDocument m_print = null;

        public InfoPrint()
        {

        }

        public InfoPrint(RecordInfo info)
        {
            rInfo = info;
        }

        public void Print()
        {
            if (m_print == null)
            {
                m_print = new PrintDocument();
                PrintDialog printDialog1 = new PrintDialog();
                printDialog1.Document = m_print;
                if (DialogResult.OK == printDialog1.ShowDialog())
                {
                    m_print.PrintPage += new PrintPageEventHandler(one_PrintPage);
                    m_print.Print();
                }
            }
        }

        public void Print(ref DataTable dt)
        {
            if (m_print == null)
            {
                this.dt = dt;
                m_print = new PrintDocument();
                System.Windows.Forms.PrintDialog printDialog1 = new System.Windows.Forms.PrintDialog();
                printDialog1.Document = m_print;
                if (DialogResult.OK == printDialog1.ShowDialog())
                {
                    //m_print.DefaultPageSettings.PaperSize = ps;
                    m_print.PrintPage += new PrintPageEventHandler(Carton_PrintPage);
                    m_print.Print();
                }
            }
        }

        private void m_print_PrintPage(object send,PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            //g.TranslateTransform((float)0.6, (float)0.6);

            //画线
            Pen blackPen = new Pen(Color.Black, (float)1);
            
            //IntPtr hdc = e.Graphics.GetHdc();
            try
            {
                //g.DrawString(tital, f1, b1, new PointF((e.PageBounds.Width - g.MeasureString(rInfo.holder_dept, f1).Width) / 2, 20));
                //横线
                g.DrawLine(blackPen, new Point(5,35), new Point(605, 35));
                g.DrawLine(blackPen, new Point(5, 65), new Point(605, 65));
                g.DrawLine(blackPen, new Point(5, 95), new Point(605, 95));
                g.DrawLine(blackPen, new Point(5, 125), new Point(605, 125));

                //竖线
                g.DrawLine(blackPen, new Point(5, 35), new Point(5, 125));
                g.DrawLine(blackPen, new Point(155, 35), new Point(155, 95));
                g.DrawLine(blackPen, new Point(305, 35), new Point(305, 95));
                g.DrawLine(blackPen, new Point(455, 35), new Point(455, 95));
                g.DrawLine(blackPen, new Point(605, 35), new Point(605, 125));

                Font f1 = new Font("宋体", 16);
                Brush b1 = new SolidBrush(Color.Black);
                string tital = m_PageTitle;
                g.DrawString(tital, f1, b1, new PointF(305, 12));


                Font f2 = new Font("宋体", 10);
                Brush b2 = new SolidBrush(Color.Black);
                string tmp = "NO:";
                g.DrawString(tmp, f2, b2, new PointF(5, 20));
                g.DrawString(rInfo.record_id, f2, b2, new PointF(25,20));
                
                Font bFont = new Font("宋体", 9);
                Font nFont = new Font("宋体", 12);
                tmp = "登记日期:";
                g.DrawString(tmp, bFont, b1, new PointF(6, 40));
                g.DrawString(rInfo.register_date.ToString("yyyy-MM-dd"), nFont, b1, new PointF(60, 40));
                tmp = "部门:";
                g.DrawString(tmp, bFont, b1, new PointF(156, 40));
                g.DrawString(rInfo.holder_dept, nFont, b1, new PointF(186, 40));
                tmp = "工号:";
                g.DrawString(tmp, bFont, b1, new PointF(306, 40));
                g.DrawString(rInfo.holder_emp, nFont, b1, new Point(336, 40));
                tmp = "姓名:";
                g.DrawString(tmp, bFont, b1, new PointF(456, 40));
                g.DrawString(rInfo.holder_name, nFont, b1, new Point(486, 40));

                tmp = "登记者:";
                g.DrawString(tmp, bFont, b1, new PointF(6, 66));
                g.DrawString(rInfo.register_name, nFont, b1, new Point(60, 66));
                tmp = "Site:";
                g.DrawString(tmp, bFont, b1, new PointF(156, 66));
                g.DrawString(rInfo.site, nFont, b1, new Point(186, 66));
                tmp = "机种:";
                g.DrawString(tmp, bFont, b1, new PointF(306, 66));
                g.DrawString(rInfo.serials[0].model, nFont, b1, new Point(336, 66));
                tmp = "数量:";
                g.DrawString(tmp, bFont, b1, new PointF(456, 66));
                g.DrawString(rInfo.serials.Count.ToString(), nFont, b1, new Point(486, 66));

                tmp = "原因:";
                g.DrawString(tmp, bFont, b1, new PointF(6, 96));
                g.DrawString(rInfo.reason, nFont, b1, new Point(36, 96));

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Print failed." + System.Environment.NewLine + ex.Message,
                   "Print Result", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
            }
            finally
            {
               // blackPen.Dispose();
                //g.Dispose();
            }
        }

        private void one_PrintPage(object send,PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int r1=2, r2=62, r3=142,r4=190,r5=200;
            int c1 = 3, c2 = 43, c3 = 83,c4=123,c5=163,c6=203;

            try
            {
                Font f1 = new Font("宋体", 12);
                Brush brush1 = new SolidBrush(Color.Black);
                string tmpStr;

                tmpStr = "ID:";
                g.DrawString(tmpStr, f1, brush1, new Point(r1, c1));
                g.DrawString(rInfo.record_id, f1, brush1, new Point(r2, c1));
                Image img = ImgCreate(rInfo.record_id);
                g.DrawImage(img, new Point(r5, c1));

                tmpStr = "Date:";
                g.DrawString(tmpStr, f1, brush1, new Point(r1, c2));
                g.DrawString(rInfo.register_date.ToString("yyyy/MM/dd"), f1, brush1, new Point(r2, c2));

                tmpStr = "Type:";
                g.DrawString(tmpStr, f1, brush1, new Point(r1, c3));
                g.DrawString(rInfo.type_desc, f1, brush1, new Point(r2, c3));

                tmpStr = "Model:";
                g.DrawString(tmpStr, f1, brush1, new Point(r3, c3));
                g.DrawString(rInfo.serials[0].model, f1, brush1, new Point(r4, c3));

                tmpStr = "Owner:";
                g.DrawString(tmpStr, f1, brush1, new Point(r1, c4));
                g.DrawString(rInfo.register_name, f1, brush1, new Point(r2, c4));

                tmpStr = "Qty:";
                g.DrawString(tmpStr, f1, brush1, new Point(r1, c5));
                g.DrawString(rInfo.serials.Count.ToString(), f1, brush1, new Point(r2, c5));

                if(rInfo.reason!="")
                {
                    tmpStr = "Reason:";
                    g.DrawString(tmpStr, f1, brush1, new Point(r1, c6));
                    Rectangle rec1 = new Rectangle(r2, c6, 200, 90);
                    g.DrawString(rInfo.reason, f1, brush1, rec1);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Print failed." + System.Environment.NewLine + ex.Message,
                   "Print Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Carton_PrintPage(object send, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int r1 = 2, r2 = 62, r3 = 122, r4 = 182, r5 = 200;
            int c1 = 3, c2 = 43, c3 = 83, c4 = 123, c5 = 163;

            try
            {
                Font f1 = new Font("宋体", 12);
                Brush brush1 = new SolidBrush(Color.Black);
                string tmpStr;


				//tmpStr = "测试:";
				//new Point(左上角X方向,左上角Y方向)
				//g.DrawString(tmpStr, f1, brush1, new Point(r1, c1));
				//g.DrawString("OK", f1, brush1, new Point(100, c1));

				tmpStr = "ID:";
				g.DrawString(tmpStr, f1, brush1, new Point(r1, c1));
				g.DrawString(dt.Rows[0]["carton_id"].ToString(), f1, brush1, new Point(r2, c1));
				Image img = ImgCreate(dt.Rows[0]["carton_id"].ToString());
				g.DrawImage(img, new Point(r5, c1));

				tmpStr = "Date:";
				g.DrawString(tmpStr, f1, brush1, new Point(r1, c2));
				g.DrawString(dt.Rows[0]["date"].ToString(), f1, brush1, new Point(r2, c2));

				tmpStr = "Type:";
				g.DrawString(tmpStr, f1, brush1, new Point(r1, c3));
				g.DrawString(dt.Rows[0]["type"].ToString(), f1, brush1, new Point(r2, c3));

				tmpStr = "Model:";
				g.DrawString(tmpStr, f1, brush1, new Point(r3, c3));
				g.DrawString(dt.Rows[0]["model"].ToString(), f1, brush1, new Point(r4, c3));

				tmpStr = "Owner:";
				g.DrawString(tmpStr, f1, brush1, new Point(r1, c4));
				g.DrawString(dt.Rows[0]["owner"].ToString(), f1, brush1, new Point(r2, c4));

				tmpStr = "Qty:";
				g.DrawString(tmpStr, f1, brush1, new Point(r1, c5));
				g.DrawString(dt.Rows[0]["qty"].ToString(), f1, brush1, new Point(r2, c5));


			}
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Print failed." + System.Environment.NewLine + ex.Message,
                   "Print Result", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
            }
        }

        public  Image ImgCreate(string text)
        {
            QRCodeEncoder coder = new QRCodeEncoder();
            coder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            coder.QRCodeScale = 1;
            coder.QRCodeVersion = 7;
            return coder.Encode(text);
        }
    }
}
