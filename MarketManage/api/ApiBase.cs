﻿using System;
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

        List<EcmGoodsTag> getTagList(int goodsId,int specId);

        Boolean existGoodsSpecTag(int goodsId, int specId, String epc);

        EcmGoodsTag getTagByTag(String epc);

        EcmGoods getGoodsByid(int goodsId);

        EcmGoodsSpec getGoodsSpecByid(int specId);
    }
}
