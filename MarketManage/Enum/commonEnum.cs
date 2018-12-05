using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManage
{
    public enum Auto {
        yes,no
    }

    public enum ConfigItemName
    {
        //connectionStrings
        appSettings,
        connectionStrings,
        mysqlConn,
        //appSettings
        programVersion,
        coryRight,
        dbType,
    }

    public enum TableName {
        ecm_store,
        ecm_gcategory,
        ecm_goods,
        ecm_goods_spec,
        ecm_goods_tag,
        ecm_goods_electronics
    }

}
