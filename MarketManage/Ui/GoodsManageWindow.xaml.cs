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
    public partial class GoodsManageWindow : Window
    {

        #region varivable area
        private List<EcmGcategory> GCateList;
        private EcmStore mStore;
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

        public GoodsManageWindow(EcmStore store)
        {
            InitializeComponent();
            this.mStore = store;
            if (mStore == null) {
                this.Close();
            }
            new WindowBehavior(this).RepairWindowDefaultBehavior();
        }

        private void Window_Activated(object sender, EventArgs e)
        {

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.LeftScrollViewer.Height = RootView.ActualHeight;   
        }

        private void FillData() {
            MyCustomControlLibrary.MMessageBox.GetInstance().ShowLoading(
                  MyCustomControlLibrary.MMessageBox.LoadType.Foure,
                  "Loading...",
                 new Point(0, 0),
                  new Size(200,120),
                  "&#xe752;",
                  Orientation.Vertical,
                  "#ffffff",
                  5);
            getCateList();

            if (GCateList.Count > 0) {
                this.cateListPanel.Children.Clear();
                for (int i = 0; i < GCateList.Count; i++)
                {
                    Expander expander = new Expander();
                    expander.Style = FindResource(ResourceName.BaseDataExpenderStyle.ToString()) as Style;
                    expander.Header = GCateList[i].cateName;
                    expander.Tag = GCateList[i];
                    expander.Expanded += Expander_Expanded;            
                    List<EcmGcategory> templist = getSubCateList((int)GCateList[i].cateId);
                    if (templist.Count > 0) {
                        ListView listView = new ListView();
                        listView.Style = FindResource(ResourceName.BaseDataListViewStyle.ToString()) as Style;
                        listView.ItemsSource = templist;
                        listView.ItemContainerStyle = FindResource(ResourceName.ListViewItemCateStyle.ToString()) as Style;
                        listView.SelectionChanged += ListView_SelectionChanged;
                        expander.Content = listView;
                    }                   
                    this.cateListPanel.Children.Add(expander);
                }
            }
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            Expander expander = sender as Expander;
            if (expander.Tag is EcmGcategory gcategory)
            {
                MessageBox.Show(gcategory.cateName);
            }
            if (expander.HasContent == false) {
              //TODO
            }
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv.SelectedIndex == -1)
            {
                return;
            }
            MessageBox.Show(((EcmGcategory)lv.SelectedItem).cateName);
        }
        private void getCateList()
        {
            GCateList = new DaoApi().GetGCateList((Int32)mStore.storeId);
        }
        private List<EcmGcategory> getSubCateList(int parentid)
        {
          return new DaoApi().GetGCateList((Int32)mStore.storeId,parentid);
        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            FillData();
        }

        private void BindingCateItem()
        {
            if (GCateList.Count <= 0)
            {
                //Alert("获取商下的分类失败;");
                return;
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

    }
}
