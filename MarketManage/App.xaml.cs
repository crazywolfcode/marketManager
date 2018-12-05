using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MarketManage
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public const bool DEBUG = true;
        public const string demianurl = "http://www.byam.cn/";
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //  new MainWindow().Show();
            new StoreManageWindow().Show();
        }
    }
}
