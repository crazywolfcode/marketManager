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
        public List<EcmGcategory> GetGCateList(int storeId,int parentid=0)
        {
            List<EcmGcategory> list = new List<EcmGcategory>();
            String condition = "store_id = " + storeId +" and parent_id ="+parentid;
            String sql = DatabaseOPtionHelper.GetInstance().getSelectSqlNoSoftDeleteCondition(TableName.ecm_gcategory.ToString(),null,condition);
            list = DatabaseOPtionHelper.GetInstance().select<EcmGcategory>(sql);
            Console.WriteLine("--- " + sql);
            return list;
        }

        public List<EcmGoods> GetGoodsList(int cateid, int storeId)
        {
            List<EcmGoods> list = new List<EcmGoods>();
            String condition = String.Empty;
            if (storeId > 0)
            {
                 condition = "store_id = " + storeId + " and cate_id =" + cateid;
            }
            else {
                 condition =" cate_id =" + cateid;
            }
            String sql = DatabaseOPtionHelper.GetInstance().getSelectSqlNoSoftDeleteCondition(TableName.ecm_goods.ToString(),null,condition);
            Console.WriteLine("=== " + sql);
            list = DatabaseOPtionHelper.GetInstance().select<EcmGoods>(sql);
            return list;
        }

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
