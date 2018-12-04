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
    public partial class StoreManageWindow : Window
    {

        #region varivable area
        private List<EcmStore> storeList;
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

        public StoreManageWindow()
        {
            InitializeComponent();
            new WindowBehavior(this).RepairWindowDefaultBehavior();
        }

        private void Window_Activated(object sender, EventArgs e)
        {

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            getStoreList();
        }


        private void getStoreList()
        {
            storeList = new DaoApi().GetStoreList();
        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            BindingStoreItem();
        }

        private void BindingStoreItem()
        {
            if (storeList.Count <= 0)
            {
                Alert("获取商城失败;");
                return;
            }
            this.mainBody.Children.Clear();
            string path = string.Empty;
            if (App.DEBUG == true)
            {
                path = MyHelper.FileHelper.GetProjectRootPath() + "/Ui/storeItem.xaml";
            }
            else
            {
                path = MyHelper.FileHelper.GetRunTimeRootPath() + "/storeItem.xaml";
            }
            for (int i = 0; i < storeList.Count; i++)
            {
                Grid element = (Grid)CommonFunction.getFrameworkElementFromXaml(path);              
                element.MouseMove += Element_MouseMove;
                element.MouseLeave += Element_MouseLeave;
                element.Tag = i;
                element.MouseLeftButtonUp += Element_MouseLeftButtonUp;
                TextBlock storeName = element.FindName("storeName") as TextBlock;
                TextBlock storeOwer = element.FindName("storeOwer") as TextBlock;
                TextBlock storeTel = element.FindName("storeTel") as TextBlock;
                TextBlock stroeRegion = element.FindName("stroeRegion") as TextBlock;
                TextBlock stroeAddress = element.FindName("stroeAddress") as TextBlock;
                Image image = element.FindName("storeImg") as Image;

                EcmStore store = storeList[i];
                storeName.Text = store.storeName;
                storeOwer.Text = store.ownerName;
                storeTel.Text = store.tel;
                stroeRegion.Text = store.regionName;
                stroeAddress.Text = store.address;

                if (store.storeLogo != null) {
                  image.Source = CommonFunction.getImageSource(App.demianurl+store.storeLogo);                   
                }
                this.mainBody.Children.Add(element);
            }

        }
        
        private void Element_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Grid grid = sender as Grid;
            int index = Convert.ToInt32(grid.Tag.ToString());
          //TODO
        }

        private void Element_MouseLeave(object sender, MouseEventArgs e)
        {
            Grid grid = sender as Grid;
            Border mainBorder = grid.FindName("main") as Border;
            mainBorder.Background = (Brush)App.Current.Resources["F9"];        
          
        }

        private void Element_MouseMove(object sender, MouseEventArgs e)
        {
            Grid grid = sender as Grid;
            Border mainBorder = grid.FindName("main") as Border;
            mainBorder.Background = Brushes.White;     
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
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
