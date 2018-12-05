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
            this.RightScrollViewer.Height = RootView.ActualHeight;
            
            this.TitleTb.Text = mStore.storeName;
        }
        private void Window_ContentRendered(object sender, EventArgs e)
        {
            FillData();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
           this.LeftScrollViewer.Height = RootView.ActualHeight;
            this.RightScrollViewer.Height = RootView.ActualHeight;
        }
        private void FillData() {
            MyCustomControlLibrary.MMessageBox.GetInstance().ShowLoading(
                  MyCustomControlLibrary.MMessageBox.LoadType.Foure,
                  "加载...",
                  new Point(0, 0),
                  new Size(200,120),
                  "&#xe752;",
                  Orientation.Vertical,
                  "#ffffff",
                  5);
            getCateList();

            if (GCateList.Count > 0) {
                this.CateListPanel.Children.Clear();
                EcmGcategory ecmGcategory;
                for (int i = 0; i < GCateList.Count; i++)
                {
                    ecmGcategory = GCateList[i];                   
                    this.CateListPanel.Children.Add(BuildUI(ecmGcategory));                                   
                }
            }
            MyCustomControlLibrary.MMessageBox.GetInstance().Close();
        }

     private  UIElement BuildUI(EcmGcategory gcategory) {
            List<EcmGcategory> templist = getSubCateList((int)gcategory.cateId);  
            Expander expander = new Expander();
            expander.Style = FindResource(ResourceName.BaseDataExpenderStyle.ToString()) as Style;
            expander.Header = gcategory.cateName;
            expander.Tag = gcategory;
            expander.Expanded += Expander_Expanded;
            if (templist.Count > 0)
            {
                StackPanel panel = new StackPanel();
                for (int j = 0; j < templist.Count; j++)
                {
                    List<EcmGcategory> dstemplist = getSubCateList((int)templist[j].cateId);                    
                    Expander sexpander = new Expander();
                    sexpander.Style = FindResource(ResourceName.BaseDataExpenderStyle.ToString()) as Style;
                    sexpander.Header ="     "+ templist[j].cateName;
                    sexpander.Tag = templist[j];
                    sexpander.Expanded += Expander_Expanded;
                    if (dstemplist.Count > 0)
                    {                   
                        ListView listView = new ListView();
                        listView.Style = FindResource(ResourceName.BaseDataListViewStyle.ToString()) as Style;
                        listView.ItemsSource = dstemplist;
                        listView.ItemContainerStyle = FindResource(ResourceName.ListViewItemCateStyle.ToString()) as Style;
                        //listView.SelectionChanged += ListView_SelectionChanged;
                        listView.MouseLeftButtonUp += ListView_MouseLeftButtonUp;
                        sexpander.Content = listView;
                    }
                    panel.Children.Add(sexpander);
                }
                expander.Content = panel;
            }
            return expander;
        }

        private void ListView_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ListView_SelectionChanged(sender, null);
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            Expander expander = sender as Expander;
            EcmGcategory gcategory = expander.Tag as EcmGcategory;
            if (gcategory != null)
            {
                if (expander.HasContent == false)
                {
                    FillGoosdsData(gcategory);
                }
            }            
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView lv = sender as ListView;
            if (lv.SelectedIndex == -1)
            {
                return;
            }
            if (lv != null)
            {
                EcmGcategory gcategory = lv.SelectedItem as EcmGcategory;
                if (gcategory != null)
                {
                    FillGoosdsData(gcategory);
                }
            }
        }
        /// <summary>
        /// 显示分类下的商品
        /// </summary>
        /// <param name="gcategory"></param>
        private void  FillGoosdsData(EcmGcategory gcategory) {
            List<EcmGoods> goodsList = GetGoods((int)gcategory.cateId, (int)gcategory.storeId);
            if (goodsList.Count > 0) {
                this.mainBody.Children.Clear();
                string path = string.Empty;
                if (App.DEBUG == true)
                {
                    path = MyHelper.FileHelper.GetProjectRootPath() + "/Ui/goodsItem.xaml";
                }
                else
                {
                    path = MyHelper.FileHelper.GetRunTimeRootPath() + "/goodsItem.xaml";
                }
                for (int i = 0; i < goodsList.Count; i++)
                {
                    Grid element = (Grid)CommonFunction.getFrameworkElementFromXaml(path);
                    element.MouseMove += Element_MouseMove;
                    element.MouseLeave += Element_MouseLeave;
                    element.Tag =goodsList[i];
                    element.MouseLeftButtonUp += Element_MouseLeftButtonUp;
                    TextBlock gName = element.FindName("gName") as TextBlock;
                    TextBlock gsName = element.FindName("gsName") as TextBlock;
                    TextBlock gCate = element.FindName("gCate") as TextBlock;
                    TextBlock gBrand = element.FindName("gBrand") as TextBlock;                 
                    Image image = element.FindName("img") as Image;
                    EcmGoods goods = goodsList[i];
                    gName.Text = goods.goodsName;
                    gsName.Text = goods.goodsSubname;
                    gCate.Text ="分类："+ goods.cateName;
                    gBrand.Text = "品牌：" + goods.brand;    
                    if (goods.defaultImage != null)
                    {
                        image.Source = CommonFunction.getImageSource(goods.defaultImage);
                    }
                    this.mainBody.Children.Add(element);
                }                
            } else {
                //没有商品数据时，显示提示信息
                FillEmptyData(gcategory.cateName);
            }
        }

        /// <summary>
        /// 没有商品数据时，显示提示信息
        /// </summary>
        private void FillEmptyData(String catename) {
            this.mainBody.Children.Clear();
            this.mainBody.Children.Add(new TextBlock() {Text = catename+": 类别下没有商品" ,HorizontalAlignment =HorizontalAlignment.Center,Margin=new Thickness(10.0)});
        }
        #region get data
        private void getCateList()
        {
            GCateList = new DaoApi().GetGCateList((Int32)mStore.storeId);
        }
        private List<EcmGcategory> getSubCateList(int parentid)
        {
          return new DaoApi().GetGCateList((Int32)mStore.storeId,parentid);
        }
        private List<EcmGoods> GetGoods(int cateid,int storeid) {
            return new DaoApi().GetGoodsList(cateid,storeid);
        }
        #endregion get data
        
        private void Element_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Grid grid = sender as Grid;
            if (grid != null) {
                EcmGoods goods = grid.Tag as EcmGoods;
                if (goods != null) {
                    new GoodsDetailWindow(goods).ShowDialog();
                }
            }
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
