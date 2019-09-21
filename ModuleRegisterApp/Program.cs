using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ModuleRegisterApp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginFrm lFrm = new LoginFrm();
            IsUpdateEnable isupdate = new IsUpdateEnable();
            if (isupdate.bFlag)
            {
                System.Diagnostics.Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AutoUpdater_Simple.exe"));
                Application.Exit();
            }
            else
            {
                MainFrm mFrm;
                DialogResult dr = lFrm.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    mFrm = new MainFrm(lFrm.uInfo);
                    Application.Run(mFrm);
                }
            }
        }
    }
}
