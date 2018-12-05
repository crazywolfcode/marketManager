using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManage
{
  public  interface ApiBase
    {
       Boolean isConn(String addres);

        List<EcmStore> GetStoreList();

        List<EcmGcategory> GetGCateList(int storeId, int parentid =0);

        List<EcmGoods> GetGoodsList(int cateid,int storeId);

        List<EcmGoodsSpec> GoodsSpecList(int goodsId);
      
    }
}
