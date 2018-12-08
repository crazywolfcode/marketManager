using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.IO.Ports;
using System.Collections.Generic;

namespace MarketManage
{

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class GoodsElectTagWindow : Window
    {

        #region varivable area
        private EcmGoodsSpec mEcmGoodsSpec;
        private EcmGoods mEcmGoods;
        private List<EcmGoodsTag> mEcmGoodsTagList;

        #endregion
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

        public GoodsElectTagWindow(EcmGoodsSpec spec, EcmGoods goods = null)
        {
            InitializeComponent();
            mEcmGoodsSpec = spec;
            mEcmGoods = goods;
            if (mEcmGoodsSpec == null)
            {
                this.Close();
            }
            new WindowBehavior(this).RepairWindowDefaultBehavior();
        }

        private void Window_Activated(object sender, EventArgs e)
        {

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.img.Source = CommonFunction.getImageSource(mEcmGoods.defaultImage);
            this.thumbImg.Source = CommonFunction.getImageSource(mEcmGoodsSpec.colorThumbnail);
            this.goodsNmaeTb.Text = mEcmGoods.goodsName;
            this.specTb.Text = mEcmGoodsSpec.specOne + "    " + mEcmGoodsSpec.specTwo + "      ￥" + mEcmGoodsSpec.price;
            this.StockCounTb.Text = mEcmGoodsSpec.stock.ToString();
            this.TagCounTb.Text = mEcmGoodsSpec.tagCount.ToString();
            //reader = new Reader.ReaderMethod();
            //string err;
            //reader.OpenCom(MyHelper.ConfigurationHelper.GetConfig("Com"), Convert.ToInt32(MyHelper.ConfigurationHelper.GetConfig("BaudRate")), out err);
            //Console.WriteLine("=========" + err);
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            FillTagData();

            //注册事件
            CallBackHelper.RegisteReadeTagCallBack(mReadeTagCallBack);
            CallBackHelper.RegisteWriteTagCallBack(mWriteTagCallBack);
            CallBackHelper.RegisteInventoryRealTagCallBack(mInventoryRealTagCallBack);
        }

        private void FillTagData()
        {
            mEcmGoodsTagList = new DaoApi().getTagList((int)mEcmGoods.goodsId, (int)mEcmGoodsSpec.specId);
            tag_lv.ItemsSource = mEcmGoodsTagList;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //消毁事件
            CallBackHelper.UnRegisteReadeTagCallBack(mReadeTagCallBack);
            CallBackHelper.UnRegisteWriteTagCallBack(mWriteTagCallBack);
            CallBackHelper.UnRegisteInventoryRealTagCallBack(mInventoryRealTagCallBack);
        }

        private void deleteETag_Click(object sender, RoutedEventArgs e)
        {

        }
        #region 状态栏

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

        #region 注册事件
        App.ReadeTagCallBack mReadeTagCallBack = new App.ReadeTagCallBack(readeTagCallBack);
        private static void readeTagCallBack(Reader.MessageTran tran)
        {
            //Todo
            Console.WriteLine("===:TODO");
        }

        App.WriteTagCallBack mWriteTagCallBack = new App.WriteTagCallBack(writeTagCallBack);
        private static void writeTagCallBack(Reader.MessageTran tran)
        {
            //Todo
            Console.WriteLine("===:TODO");
        }

        App.InventoryRealTagCallBack mInventoryRealTagCallBack = new App.InventoryRealTagCallBack(inventoryRealTagCallBack);
      
        private static void inventoryRealTagCallBack(Reader.MessageTran tran)
        {
            //Todo
            Console.WriteLine("===:TODO");
        }
        #endregion


        /// <summary>
        /// 保存标签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveTagBtn_Click(object sender, RoutedEventArgs e)
        {
            String epc = EPCTB.Text.Trim();
            if (String.IsNullOrWhiteSpace(epc))
            {
                Console.WriteLine("EPC 不能为空");
                return;
            }

            EcmGoodsTag goodsTag = new EcmGoodsTag
            {
                goodsId =(int) mEcmGoods.goodsId,
                specId = (int)mEcmGoodsSpec.specId,
                goodsName = mEcmGoods.goodsName,
                isSellOut = 0,
                storeId = (int)App.mEcmStore.storeId,
                storeName = App.mEcmStore.storeName,
                tag = epc,
            };

            EcmGoodsElectronics electronics = new EcmGoodsElectronics();
            electronics.storeId = App.mEcmStore.storeId;
            electronics.goodsId = mEcmGoods.goodsId;
            electronics.goodsName = mEcmGoods.goodsName;
            electronics.specId = mEcmGoodsSpec.specId;
            electronics.specName = mEcmGoodsSpec.specOne + mEcmGoodsSpec.specTwo;
            electronics.epc = epc;
            electronics.isSellOut = 0;

            //1.判断是否已经和商品存在
            bool exist = new DaoApi().existGoodsSpecTag((int)mEcmGoods.goodsId, (int)mEcmGoodsSpec.specId, epc);
            //2.事务
            if (exist)
            {
                MessageBox.Show("已经存在");
            }
            else
            {
                mEcmGoodsSpec.tagCount = mEcmGoodsSpec.tagCount + 1;
               // String updateSql = DatabaseOPtionHelper.GetInstance().getUpdateSql(mEcmGoodsSpec);
                String intsertTagSql = DatabaseOPtionHelper.GetInstance().getInsertSql(goodsTag);
                String intsertElctSql = DatabaseOPtionHelper.GetInstance().getInsertSql(electronics);
                String[] sqls = new string[] { intsertTagSql, intsertElctSql };
                int res = DatabaseOPtionHelper.GetInstance().TransactionExecute(sqls);

                if (res > 0)
                {
                    MessageBox.Show("保存成功！");
                    RefreshData();
                }
                else
                {
                    MessageBox.Show("保存失败！");
                }
            }
        }
        /// <summary>
        /// 刷新数据
        /// </summary>
        private void RefreshData()
        {
            this.TagCounTb.Text = mEcmGoodsSpec.tagCount.ToString();
            FillTagData();
        }
        /// <summary>
        /// 读取标签
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
                byte btWordCnt = 0x00;

                btWordAdd = Convert.ToByte(0);

                btWordCnt = Convert.ToByte(8);


                //  reader.ReceiveCallback = new Reader.ReciveDataCallback(callaback);
                App.reader.AnalyCallback = new Reader.AnalyDataCallback(anayCallback);
                String err = String.Empty;


                //用天线1 去读
                App.reader.ReadTag(0x01, btMemBank, btWordAdd, btWordCnt);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// ReceiveData call back
        /// </summary>
        /// <param name="btAryReceiveData"></param>
        private void callaback(byte[] btAryReceiveData)
        {

            string strLog = CommonFunction.ByteArrayToString(btAryReceiveData, 0, btAryReceiveData.Length);

            Console.WriteLine("=========== ReceiveData:" + strLog);

            MessageBox.Show(" ReceiveData:" + strLog);
        }

        private void anayCallback(Reader.MessageTran messageTran) {
            if (messageTran.PacketType != 0xA0)
            {
                MessageBox.Show("anayCallback:" + messageTran.Cmd);
                return;
            }
            Console.WriteLine(" anayCallback:Cmd:" + messageTran.Cmd);
            switch (messageTran.Cmd)
            {
                
                case 0x81:
                    ProcessReadTag(messageTran);
                    break;
                case 0x82:
                   // ProcessWriteTag(msgTran);
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
            }
            else
            {
                TagInfoObj tagInfo = new TagInfoObj(msgTran.AryData);
                this.Dispatcher.Invoke(new Action (delegate {
                    this.EPCTB.Text = tagInfo.EPC.Trim();
                }));
            }
        }
    }
}
