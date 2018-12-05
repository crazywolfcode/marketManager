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
            if (mEcmGoodsSpec == null) {
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
            this.specTb.Text = mEcmGoodsSpec.specOne + "    " + mEcmGoodsSpec.specTwo + "      ￥" + mEcmGoodsSpec.price + "  库存：" + mEcmGoodsSpec.stock + "    标签数:" + mEcmGoodsSpec.tagCount;
        }
        
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            FillTagData();
        }

        private void FillTagData() {
            mEcmGoodsTagList = new DaoApi().getTagList((int)mEcmGoods.goodsId,(int)mEcmGoodsSpec.specId);           
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

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
    }
}
