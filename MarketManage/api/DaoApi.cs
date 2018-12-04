using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlDao;
namespace MarketManage
{
    public class DaoApi : ApiBase
    {
        public List<EcmStore> GetStoreList()
        {
            List<EcmStore> list = new List<EcmStore>();
            String sql = DatabaseOPtionHelper.GetInstance().getSelectSqlNoSoftDeleteCondition(TableName.ecm_store.ToString());
            list=  DatabaseOPtionHelper.GetInstance().select<EcmStore>(sql);
            return list;
        }

        public bool isConn(string addres)
        {
            return DatabaseOPtionHelper.GetInstance().CheckConn(addres);
        }
    }
}
