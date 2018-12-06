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
    /// xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public const bool DEBUG = true;
        public const string demianurl = "http://www.byam.cn/";
        public static EcmStore mEcmStore;

        public delegate void WriteTagCallBack(Reader.MessageTran msgTran);
        public delegate void ReadeTagCallBack(Reader.MessageTran msgTran);
        public delegate void InventoryRealTagCallBack(Reader.MessageTran msgTran);
        public static List<WriteTagCallBack> WriteTagCallBackList = new List<WriteTagCallBack>();
        public static List<ReadeTagCallBack> readeTagCallBackList = new List<ReadeTagCallBack>();
        public static List<InventoryRealTagCallBack> inventoryRealTagCallBackList = new List<InventoryRealTagCallBack>();
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //  new MainWindow().Show();
            new StoreManageWindow().Show();
        }


    }
}
