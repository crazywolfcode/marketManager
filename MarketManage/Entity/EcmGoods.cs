using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

 namespace MarketManage
{

	 /// <summary>
	 /// 数据条数:1851
	 /// 数据大小:5.74MB
	 /// </summary>


	  public  class EcmGoods
	 {

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public UInt32 goodsId{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public UInt32 storeId{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:material
	 /// </summary>

	 public String type{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String goodsName{ get; set; }

	 /// <summary>
	 /// 注释:商品副标题
	 /// 可空:NO
	 /// </summary>

	 public String goodsSubname{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public String description{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public UInt32 cateId{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String cateName{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String brand{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int16 specQty{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String specName1{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String specName2{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:1
	 /// </summary>

	// public Int16 ifShow{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 // public Int16 ifColorImage{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	// public Int16 closed{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 //public Int16 ifOpen{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public String closeReason{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public UInt32 addTime{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public UInt32 lastUpdate{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public UInt32 defaultSpec{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String defaultImage{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int16 recommended{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public UInt32 cateId1{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public UInt32 cateId2{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public UInt32 cateId3{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public UInt32 cateId4{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0.00
	 /// </summary>

	 public Decimal price{ get; set; }

	 /// <summary>
	 /// 注释:市场价
	 /// 可空:NO
	 ///默认值:0.00
	 /// </summary>

	 public Decimal marketPrice{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String tags{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public UInt32 integralMaxExchange{ get; set; }

	 /// <summary>
	 /// 注释:商城推荐
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int16 mallRecommended{ get; set; }

	 /// <summary>
	 /// 注释:商城推荐排序
	 /// 可空:NO
	 ///默认值:255
	 /// </summary>

	// public Int16 mallSortOrder{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 //public UInt32 virtualSeles{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public String priceIntervals{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	// public UInt32 deliveryTemplateId{ get; set; }



	 }
}
