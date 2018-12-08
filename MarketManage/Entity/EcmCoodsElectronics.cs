using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

 namespace MarketManage
{

	 /// <summary>
	 /// 数据条数:0
	 /// 数据大小:16KB
	 /// </summary>


	  public  class EcmGoodsElectronics
	 {

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public UInt32 id{ get; set; }

	 /// <summary>
	 /// 注释:电子标签识别码
	 /// 可空:YES
	 /// </summary>

	 public String epc{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public UInt32 specId{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public UInt32 storeId{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public UInt32 goodsId{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public String goodsName{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public String specName{ get; set; }
        /// <summary>
        ///   是否售出 0 未 1 售出
        ///  默认 0
        /// </summary>
        public Int32 isSellOut { get; set; }
        
    }
}
