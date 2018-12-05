using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManage
{
   public class CallBackHelper
    {
        #region 注册返回事件
        public static void RegisteWriteTagCallBack(App.WriteTagCallBack callBack)
        {
            App.WriteTagCallBackList.Add(callBack);
        }

        public static void UnRegisteWriteTagCallBack(App.WriteTagCallBack callBack)
        {
            App.WriteTagCallBackList.Remove(callBack);
        }

        public static void RegisteReadeTagCallBack(App.ReadeTagCallBack callBack)
        {
            App.readeTagCallBackList.Add(callBack);
        }

        public static void UnRegisteReadeTagCallBack(App.ReadeTagCallBack callBack)
        {
            App.readeTagCallBackList.Remove(callBack);
        }

        public static void RegisteInventoryRealTagCallBack(App.InventoryRealTagCallBack callBack)
        {
            App.inventoryRealTagCallBackList.Add(callBack);
        }

        public static void UnRegisteInventoryRealTagCallBack(App.InventoryRealTagCallBack callBack)
        {
            App.inventoryRealTagCallBackList.Remove(callBack);
        }
        
        #endregion 注册返回事件
    }
}
