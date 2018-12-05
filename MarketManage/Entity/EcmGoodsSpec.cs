using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

 namespace MarketManage
{

	 /// <summary>
	 /// 数据条数:17331
	 /// 数据大小:1.93MB
	 /// </summary>


	  public  class EcmGoodsSpec
	 {

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public UInt32 specId{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public UInt32 goodsId{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String specOne{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String specTwo{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 //public String colorRgb{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0.00
	 /// </summary>

	 public Decimal price{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int32 stock{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	// public String sku{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String colorImageUrl{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String colorThumbnail{ get; set; }

        /// <summary>
        /// 标签数 默认0
        /// 
        /// </summary>

        public Int32 tagCount{ get; set; }

	 }
}
