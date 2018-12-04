using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

 namespace MarketManage
{

	 /// <summary>
	 /// 数据条数:39
	 /// 数据大小:19.08KB
	 /// </summary>


	  public  class EcmStore
	 {

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int32 storeId{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String storeName{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String ownerName{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String ownerCard{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public Int32 regionId{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public String regionName{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String address{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String zipcode{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String tel{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int16 sgrade{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String applyRemark{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int32 creditValue{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:5.0
	 /// </summary>

	 public Decimal evaluationDesc{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:5.0
	 /// </summary>

	 public Decimal evaluationService{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:5.0
	 /// </summary>

	 public Decimal evaluationSpeed{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0.00
	 /// </summary>

	 public Decimal praiseRate{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public String domain{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String topDomain{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int16 state{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String closeReason{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public Int32 addTime{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int32 endTime{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public String certification{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int16 sortOrder{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int16 recommended{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String theme{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public String storeBanner{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public String storeLogo{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public String description{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String image1{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String image2{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String image3{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String imQq{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String imWw{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String imMsn{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String hotSearch{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String businessScope{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String onlineService{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String hotline{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String picSlides{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int16 enableGroupbuy{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:1
	 /// </summary>

	 public Int16 enableRadar{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String waptheme{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String picSlidesWap{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public Decimal lng{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public Decimal lat{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public Int32 zoom{ get; set; }

	 /// <summary>
	 /// 注释:营业开始时间
	 /// 可空:YES
	 /// </summary>

	 public Int16 serviceBegin{ get; set; }

	 /// <summary>
	 /// 注释:营业结束时间
	 /// 可空:YES
	 /// </summary>

	 public Int16 serviceEnd{ get; set; }

	 /// <summary>
	 /// 注释:到达时间
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int32 serviceArrive{ get; set; }

	 /// <summary>
	 /// 注释:人均消费
	 /// 可空:NO
	 ///默认值:0.00
	 /// </summary>

	 public Decimal serviceConsumption{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public Decimal amountForFreeFee{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public Int32 acountForFreeFee{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String preConnects{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String afterConnects{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int16 isOpenShua{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public Int32 cityId{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public String cityName{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public String storeRealName{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public String storeIdCard{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int16 authenticationState{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public String sendAddress{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public String secretKey{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public String appkey{ get; set; }

	 /// <summary>
	 /// 注释:�Ƿ�����˵���ʵ����֤
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int16 ifStoreAuthentication{ get; set; }

	 /// <summary>
	 /// 注释:��ҵ��������
	 /// 可空:NO
	 /// </summary>

	 public String storeLegalPerson{ get; set; }

	 /// <summary>
	 /// 注释:��ҵӪҵִ�պ�
	 /// 可空:NO
	 /// </summary>

	 public String storeLicenseNumber{ get; set; }

	 /// <summary>
	 /// 注释:��ҵӪҵִ��������
	 /// 可空:NO
	 /// </summary>

	 public String storeLicensePic{ get; set; }

	 /// <summary>
	 /// 注释:һ�����ڶ����Ƿ��Ͷ�������
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int16 stateRemind{ get; set; }

	 /// <summary>
	 /// 注释:��������
	 /// 可空:NO
	 ///默认值:0
	 /// </summary>

	 public Int16 storeType{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String storeCode{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public String storeHotImages{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public String storeNewImages{ get; set; }

	 /// <summary>
	 /// 可空:YES
	 /// </summary>

	 public String storeRecommendImages{ get; set; }

	 /// <summary>
	 /// 可空:NO
	 /// </summary>

	 public String wximages{ get; set; }

	 }
}
