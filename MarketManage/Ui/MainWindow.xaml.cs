using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.IO.Ports;
using System.Collections.Generic;
using Reader;

namespace MarketManage
{

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        #region varivable area
        private DispatcherTimer mDateTime;
        public SerialPort mSerialPort;
        
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            new WindowBehavior(this).RepairWindowDefaultBehavior();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
         
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // times
            StartDateTimeTime();
            //api link
            CheckApiLinkStatus();
            //reader link status
         //   CheckReaderLinkStatus();


            App.reader = new ReaderMethod();
            //  reader.ReceiveCallback = new Reader.ReciveDataCallback(callaback);
            App.reader.AnalyCallback = new AnalyDataCallback(AnalyData);
            String err = String.Empty;
         int res = App.reader.OpenCom(MyHelper.ConfigurationHelper.GetConfig("Com"), Convert.ToInt32(MyHelper.ConfigurationHelper.GetConfig("BaudRate")), out err);
         //   int res =   reader.OpenCom("COM3",115200, out err);
            
        }

        private void AnalyData(MessageTran msgTran)
        {
            if (msgTran.PacketType != 0xA0)
            {
                return;
            }
            switch (msgTran.Cmd)
            {
                case 0x81:
                    ProcessReadTag(msgTran);
                    break;
                default:
                    MessageBox.Show("其它操作！");
                    break;
            }
        }

        /// <summary>
        /// 读标签
        /// </summary>
        /// <param name="msgTran"></param>
        private void ProcessReadTag(Reader.MessageTran msgTran)
        {
            string strCmd = "读标签";
            string strErrorCode = string.Empty;

            if (msgTran.AryData.Length == 1)
            {
                strErrorCode = CommonFunction.FormatErrorCode(msgTran.AryData[0]);
                string strLog = strCmd + "失败，失败原因： " + strErrorCode;
                MessageBox.Show(strLog);
            }
            else
            {
                //读取规则可查看r2000通讯协议用户手册_V2.38   
                //data总长度
                int nLen = msgTran.AryData.Length;
                //Read 操作的数据长度。单位是字节 
                int nDataLen = Convert.ToInt32(msgTran.AryData[nLen - 3]);
                //所操作标签的有效数据长度(msgTran.AryData[2])   Epc的长度=有效数据长度-PC-CRC-读取的标签数据   pc和crc各占两字节
                int nEpcLen = Convert.ToInt32(msgTran.AryData[2]) - nDataLen - 4;
                //从数组3开始获取两字节的pc
                string strPC = CommonFunction.ByteArrayToString(msgTran.AryData, 3, 2);               
                string strEPC = CommonFunction.ByteArrayToString(msgTran.AryData, 5, nEpcLen);
                string strCRC = CommonFunction.ByteArrayToString(msgTran.AryData, 5 + nEpcLen, 2);
                string strData = CommonFunction.ByteArrayToString(msgTran.AryData, 7 + nEpcLen, nDataLen);

                byte byTemp = msgTran.AryData[nLen - 2];
                byte byAntId = (byte)((byTemp & 0x03) + 1);
                //读取当前工作的天线   
                string strAntId = byAntId.ToString();

                string strReadCount = msgTran.AryData[nLen - 1].ToString();
                
                Console.WriteLine("EPC:" + strEPC);
               // MessageBox.Show(strEPC);
                Console.WriteLine("strData:" + strData);

       
                Console.WriteLine("strAntId:" + strAntId);


                this.Dispatcher.Invoke(new Action(delegate { getTagInfo(strEPC); }));
              
            }
        }


  


        private delegate void getdata(String epc);

        private void getTagInfo(string epc) {
            this.currTag.Text = epc;
            EcmGoodsTag tag = new DaoApi().getTagByTag(epc);
          
            if (tag == null) {
                this.goodsNmaeTb.Text = "";
                this.thumbImg.Source =null;
                this.specTb.Text = "";
                this.StockCounTb.Text = "";
                this.TagCounTb.Text ="";
                return;
            }
            EcmGoods goods = new DaoApi().getGoodsByid(tag.goodsId);
            if (goods != null)
            {
             
                this.goodsNmaeTb.Text = goods.goodsName;
                this.thumbImg.Source = CommonFunction.getImageSource(goods.defaultImage);
            }
            else {
                MessageBox.Show("获取商品失败");
            }
            EcmGoodsSpec spec = new DaoApi().getGoodsSpecByid(tag.specId);

            if (spec != null)
            {
                this.specTb.Text = spec.specOne + "    " + spec.specTwo + "      ￥" + spec.price;
                this.StockCounTb.Text = spec.stock.ToString();
                this.TagCounTb.Text = spec.tagCount.ToString();
            }
            else
            {
                MessageBox.Show("获取商品构规格失败");
            }
        }

        /// <summary>
        /// 读标签 Btn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReaderTagBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //标签存储区域 0x00 RESERVED 0x01 EPC 0x02 TID 0x03 USER
                byte btMemBank = 0x02;
                //读取数据首地址
                byte btWordAdd = 0x00;
                //读取数据长度
                byte btWordCnt = Convert.ToByte("8");

                App.reader.ReadTag(0x01, btMemBank, btWordAdd, btWordCnt);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #region  时间 定时器
        private void StartDateTimeTime()
        {
            mDateTime = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 1)
            };
            mDateTime.Tick += MDateTime_Tick;
            mDateTime.Start();
        }
        #endregion

        #region api link
        private void CheckApiLinkStatus()
        {
            ChangerApiStatus();
        }

        private void ChangerApiStatus()
        {
            String apiNomalStr = "数据连接正常";
            String apirErrStr = "数据连接异常";
            ApiBase api = new DaoApi();
            if (api.isConn(null))
            {
                apiLinkStatusTb.ToolTip = apiNomalStr;
                apiLinkStatusTb.Foreground = Brushes.Green;
            }
            else
            {
                apiLinkStatusTb.ToolTip = apirErrStr;
                apiLinkStatusTb.Foreground = Brushes.Red;
            }
        }


        #endregion

        #region reader link
        private void CheckReaderLinkStatus()
        {
            InitSerialPort();
            ChangerReaderStatus();
        }
        private void InitSerialPort()
        {
            mSerialPort = new SerialPort
            {
                BaudRate = Convert.ToInt32(MyHelper.ConfigurationHelper.GetConfig("BaudRate")),
                PortName = MyHelper.ConfigurationHelper.GetConfig("com"),
                DataBits = Convert.ToInt32(MyHelper.ConfigurationHelper.GetConfig("DataBits")),
                StopBits = StopBits.One,
                Parity = Parity.None
            };
            if (mSerialPort.IsOpen)
            {
                mSerialPort.Close();
            }
            try
            {
                mSerialPort.Open();
            }
            catch (Exception e)
            {
                Alert(e.Message);
            }
        }
        private void ChangerReaderStatus()
        {
            String readerNomalStr = "标签读写器连接正常";
            String readerErrStr = "标签读写器连接异常";
            if (mSerialPort.IsOpen == true)
            {
                readerLinkStatusTb.ToolTip = readerNomalStr;
                readerLinkStatusTb.Foreground = Brushes.Green;
            }
            else
            {
                readerLinkStatusTb.ToolTip = readerErrStr;
                readerLinkStatusTb.Foreground = Brushes.Red;
            }
        }
        #endregion

        private void MDateTime_Tick(object sender, EventArgs e)
        {
            UpdateTimeDate();
        }

        #region max min close mover
        private void headerBorder_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MaxBtn_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void MinBtn_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        #endregion mover

        #region menu
        private void userHeaderImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.userMenuPopup.IsOpen == false)
            {
                this.userMenuPopup.IsOpen = true;
            }
            else { this.userMenuPopup.IsOpen = false; }
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            //setting update request support about quit
            MenuItem item = sender as MenuItem;
            switch (item.Tag.ToString())
            {
                case "setting":
                    new SettingWindow().ShowDialog();
                    break;
                case "goodsManager":
                    new StoreManageWindow().ShowDialog();
                    break;
                case "quit":
                    this.Close();
                    break;
            }
            this.userMenuPopup.IsOpen = false;
        }
        #endregion

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            //读取器开始工作
        
            //注册事件
            CallBackHelper.RegisteReadeTagCallBack(mReadeTagCallBack);
            CallBackHelper.RegisteWriteTagCallBack(mWriteTagCallBack);
            CallBackHelper.RegisteInventoryRealTagCallBack(mInventoryRealTagCallBack);
        }

        #region 读取器开始工作

        /// <summary>
        /// 发送数据 回调
        /// </summary>
        /// <param name="btArySendData"></param>
        private void SendCallback(byte[] btArySendData)
        {
            MyHelper.ConsoleHelper.writeLine("发送数据: " + CommonFunction.ByteArrayToString(btArySendData, 0, btArySendData.Length));
        }
        /// <summary>
        /// 接受到数据 回调
        /// </summary>
        /// <param name="btAryReceiveData"></param>
        private void ReceiveCallback(byte[] btAryReceiveData)
        {
            MyHelper.ConsoleHelper.writeLine("接受到数据: " + CommonFunction.ByteArrayToString(btAryReceiveData, 0, btAryReceiveData.Length));
        }
        /// <summary>
        /// 回调事件
        /// </summary>
        /// <param name="messageTran"></param>
        private void AnalyCallback(Reader.MessageTran messageTran)
        {
            if (messageTran.PacketType != 0xA0)
            {
                return;
            }
            switch (messageTran.Cmd)
            {                
                case 0x81:
                    //ProcessReadTag(messageTran);
                    if (App.readeTagCallBackList.Count > 0) {
                        for (int i = 0; i < App.readeTagCallBackList.Count; i++)
                        {
                            App.readeTagCallBackList[i]?.Invoke(messageTran);
                        }
                    }
                    break;
                case 0x82:
                    // ProcessWriteTag(messageTran);
                    if (App.WriteTagCallBackList.Count > 0) {
                        for (int i = 0; i < App.WriteTagCallBackList.Count; i++)
                        {
                            App.WriteTagCallBackList[i]?.Invoke(messageTran);
                        }
                    }
                    break;
                case 0x89:
                case 0x8B:
                    // ProcessInventoryReal(messageTran);
                    if (App.inventoryRealTagCallBackList.Count > 0)
                    {
                        for (int i = 0; i < App.inventoryRealTagCallBackList.Count; i++)
                        {
                            App.inventoryRealTagCallBackList[i]?.Invoke(messageTran);
                        }
                    }
                    break;
                case 0xb0:
                    ProcessInventoryISO18000(messageTran);
                    break;
                case 0xb1:
                    ProcessReadTagISO18000(messageTran);
                    break;
                case 0xb2:
                    //ProcessWriteTagISO18000(messageTran);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// 读取标签
        /// </summary>
        /// <param name="messageTran"></param>
        private void ProcessReadTagISO18000(Reader.MessageTran messageTran)
        {
            string strCmd = "读取标签";
            string strErrorCode = string.Empty;

            if (messageTran.AryData.Length == 1)
            {
                strErrorCode = CommonFunction.FormatErrorCode(messageTran.AryData[0]);
                string strLog = strCmd + "失败，失败原因： " + strErrorCode;

                Console.WriteLine(strErrorCode + ":"+ strLog);
            }
            else
            {
                string strAntID = CommonFunction.ByteArrayToString(messageTran.AryData, 0, 1);
                string strData = CommonFunction.ByteArrayToString(messageTran.AryData, 1, messageTran.AryData.Length - 1);
                
                Console.WriteLine(strCmd + ": antID :"+strAntID+" data:"+strData );
            }
        }

        private void ProcessInventoryISO18000(Reader.MessageTran messageTran)
        {
            string strCmd = "盘存标签";
            string strErrorCode = string.Empty;

            if (messageTran.AryData.Length == 1)
            {
                if (messageTran.AryData[0] != 0xFF)
                {
                    strErrorCode = CommonFunction.FormatErrorCode(messageTran.AryData[0]);
                    string strLog = strCmd + "失败，失败原因： " + strErrorCode;

                    Console.WriteLine(strErrorCode + ":" + strLog);
                }
            }
            else if (messageTran.AryData.Length == 9)
            {
                string strAntID = CommonFunction.ByteArrayToString(messageTran.AryData, 0, 1);
                string strUID = CommonFunction.ByteArrayToString(messageTran.AryData, 1, 8);
                string data = CommonFunction.ByteArrayToString(messageTran.AryData, 1, 8);
                string strData = CommonFunction.ByteArrayToString(messageTran.AryData, 1, messageTran.AryData.Length - 1);
            }
            else if (messageTran.AryData.Length == 2)
            {
              //  m_curOperateTagISO18000Buffer.nTagCnt = Convert.ToInt32(messageTran.AryData[1]);


                Console.WriteLine(strErrorCode + ":");
            }
            else
            {
                strErrorCode = "未知错误";
                string strLog = strCmd + "失败，失败原因： " + strErrorCode;

                Console.WriteLine(strErrorCode+":"+strLog);
            }
        }


        //注册事件
        App.ReadeTagCallBack mReadeTagCallBack = new App.ReadeTagCallBack(readeTagCallBack);
        private static void readeTagCallBack(Reader.MessageTran messageTran) {
            //Test            
                string strCmd = "读标签";
                string strErrorCode = string.Empty;

                if (messageTran.AryData.Length == 1)
                {
                    strErrorCode = CommonFunction.FormatErrorCode(messageTran.AryData[0]);
                    string strLog = strCmd + "失败，失败原因： " + strErrorCode;

                    Console.WriteLine(strCmd+":"+strErrorCode + strLog);
                }
                else
                {
                    //读取规则可查看r2000通讯协议用户手册_V2.38   
                    //data总长度
                    int nLen = messageTran.AryData.Length;
                    //Read 操作的数据长度。单位是字节 
                    int nDataLen = Convert.ToInt32(messageTran.AryData[nLen - 3]);
                    //所操作标签的有效数据长度(messageTran.AryData[2])   Epc的长度=有效数据长度-PC-CRC-读取的标签数据   pc和crc各占两字节
                    int nEpcLen = Convert.ToInt32(messageTran.AryData[2]) - nDataLen - 4;
                    //从数组3开始获取两字节的pc
                    string strPC = CommonFunction.ByteArrayToString(messageTran.AryData, 3, 2);
                    //
                    string strEPC = CommonFunction.ByteArrayToString(messageTran.AryData, 5, nEpcLen);
                    //
                    string strCRC = CommonFunction.ByteArrayToString(messageTran.AryData, 5 + nEpcLen, 2);
                    string strData = CommonFunction.ByteArrayToString(messageTran.AryData, 7 + nEpcLen, nDataLen);

                    byte byTemp = messageTran.AryData[nLen - 2];
                    byte byAntId = (byte)((byTemp & 0x03) + 1);
                    //读取当前工作的天线   
                    string strAntId = byAntId.ToString();
                    string strReadCount = messageTran.AryData[nLen - 1].ToString();                

                Console.WriteLine("data总长度:"+nLen+ " 操作的数据长度:"+ nDataLen+ " 有效数据长度:"+ nDataLen);
                Console.WriteLine("Pc:"+strPC+ " epc:"+ strEPC+ " crc:"+ strCRC+" 天线："+strAntId);
            }
           

            Console.WriteLine("===:TODO");
        }

        App.WriteTagCallBack mWriteTagCallBack = new App.WriteTagCallBack(writeTagCallBack);
        private static void writeTagCallBack(Reader.MessageTran tran)
        {
            //Todo
            Console.WriteLine("===:TODO");
        }

        App.InventoryRealTagCallBack mInventoryRealTagCallBack = new App.InventoryRealTagCallBack(inventoryRealTagCallBack);

        public bool InvokeRequired { get; private set; }

        private static void inventoryRealTagCallBack(Reader.MessageTran tran)
        {
            //Todo
            Console.WriteLine("===:TODO");
        }
        #endregion  读取器开始工作
        
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (mDateTime != null)
            {
                mDateTime.Stop();
            }
            try
            {
                App.reader.CloseCom();
            }
            catch {
            }
            
        }

        #region 状态栏
        /// <summary>
        /// 更新时间信息
        /// </summary>
        private void UpdateTimeDate()
        {
            string timeDateString = "";
            DateTime now = DateTime.Now;
            timeDateString = string.Format("{0}年{1}月{2}日 {3}:{4}:{5}",
                now.Year,
                now.Month.ToString("00"),
                now.Day.ToString("00"),
                now.Hour.ToString("00"),
                now.Minute.ToString("00"),
                now.Second.ToString("00"));
            timeDateTextBlock.Text = timeDateString;
        }

        /// <summary>
        /// 警告信息提示（一直提示）
        /// </summary>
        /// <param name="message">提示信息</param>
        private void Alert(string message)
        {
            // #FF68217A
            sb.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x21, 0x2A));
            statusInfoTextBlock.Text = message;
        }

        /// <summary>
        /// 普通状态信息提示
        /// </summary>
        /// <param name="message">提示信息</param>
        private void Information(string message)
        {
            if (true)
            {
                // #FFCA5100
                sb.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0xCA, 0x51, 0x00));
            }
            else
            {
                // #FF007ACC
                sb.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x00, 0x7A, 0xCC));
            }
            statusInfoTextBlock.Text = message;
        }


        #endregion
    }
}
