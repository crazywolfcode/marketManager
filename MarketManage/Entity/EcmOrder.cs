using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

 namespace MarketManage
{

	 /// <summary>
	 /// 数据条数:249
	 /// 数据大小:41.67KB
	 /// </summary>


	  public  class EcmOrder
	 {

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public Int32 orderId{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String orderSn{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:material
	 /// </summary>

	 public String type{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String extension{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int32 sellerId{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public String sellerName{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int32 buyerId{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public String buyerName{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String buyerEmail{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int16 status{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int32 addTime{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public Int32 paymentId{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public String paymentName{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String paymentCode{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String outTradeSn{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public Int32 payTime{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String payMessage{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public Int32 shipTime{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public String invoiceNo{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String expressCompany{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int32 finishedTime{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int32 autoFinishedTime{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0.00
	 /// </summary>

	 public Decimal goodsAmount{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0.00
	 /// </summary>

	 public Decimal discount{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0.00
	 /// </summary>

	 public Decimal orderAmount{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int16 evaluationStatus{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int32 evaluationTime{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int16 sellerEvaluationStatus{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int32 sellerEvaluationTime{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int16 anonymous{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String postscript{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int16 payAlter{ get; set; }

	

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String code{ get; set; }

	 }
}
