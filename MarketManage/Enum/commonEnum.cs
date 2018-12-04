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
    }

}
