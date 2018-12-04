using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

 namespace MarketManage
{

	 /// <summary>
	 /// 数据条数:1076
	 /// 数据大小:31.38KB
	 /// </summary>


	  public  class EcmGcategory
	 {

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public UInt32 cateId{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public UInt32 storeId{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String cateName{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public UInt32 parentId{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:255
	 /// </summary>

	 public Int16 sortOrder{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:1
	 /// </summary>

	 public Int16 ifShow{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String cateLogo{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String cateImages{ get; set; }

	 }
}
