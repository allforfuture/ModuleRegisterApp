using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ModuleRegisterApp3
{
    /// <summary>
    /// Window1.xaml 的交互逻辑
    /// </summary>
    public partial class Window1 : Window
    {
        List<DataGridSource> listDataSource = new List<ModuleRegisterApp3.DataGridSource>();

        public Window1()
        {
            InitializeComponent();

            MainWindow mainWin = new MainWindow();
            mainWin.ShowDialog();
            if(!mainWin.DialogResult.HasValue || mainWin.DialogResult.Value==false)
            {
                Application.Current.Shutdown();
            }
        }

        private void Submit_btn_Click(object sender, RoutedEventArgs e)
        {
            DataGridSource dgs = new ModuleRegisterApp3.DataGridSource();
            dgs.RecordID = "20180124P001";
            dgs.Site = "A-1";
            dgs.Qty = 100;
            dgs.Register = DateTime.Now;
            listDataSource.Add(dgs);

            GridItem gItem = new GridItem();
            gItem.RecordID = "";
            gItem.Site = "A-1";
            gItem.Qty = 100;
            gItem.Register_date = DateTime.Now;
            gItem.Holder_dept = "PI";
            gItem.Holder_name = "张三";
            ListGridItem lGridItem = new ListGridItem();
            lGridItem.listGridItem.Add(gItem);
            resultDockPanel.Resources = lGridItem;
        }
    }
}
