using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using System.IO.Ports;
namespace MarketManage
{

    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        #region varivable area
        private DispatcherTimer   mDateTime;
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
            CheckReaderLinkStatus();
        }

        #region  时间 定时器
        private void StartDateTimeTime() {
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
            if (api.isConn( null))
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
                    new GoodsManageWindow().ShowDialog();
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
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (mDateTime != null)
            {
                mDateTime.Stop();
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
