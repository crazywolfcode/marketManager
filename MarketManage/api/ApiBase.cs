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
    }
}
