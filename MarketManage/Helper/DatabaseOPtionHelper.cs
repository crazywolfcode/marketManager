using MyHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDao;
namespace MarketManage
{
  public  class DatabaseOPtionHelper
    {

        private static DbHelper Instance;
     

        public static DbHelper GetInstance()
        {
            if (Instance == null)
            {
                string conn = ConfigurationHelper.GetConnectionConfig(ConfigItemName.mysqlConn.ToString());
                    Instance = new SqlDao.MySqlHelper(conn);              
            }
            return Instance;
        }
    }
}
