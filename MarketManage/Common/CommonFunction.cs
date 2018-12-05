using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows;
using System.Windows.Markup;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace MarketManage
{
    class CommonFunction
    {
        public static FrameworkElement getFrameworkElementFromXaml(string path)
        {
            XmlTextReader reader = new XmlTextReader(path);
            FrameworkElement element = XamlReader.Load(reader) as FrameworkElement;
            return element;
        }

        public static BitmapImage getImageSource(String uri)
        {

            BitmapImage bmp = new BitmapImage();
            try
            {
                bmp.BeginInit();//初始化
                bmp.UriSource = new Uri(App.demianurl + uri);//设置图片路径
                bmp.EndInit();//结束初始化
            }
            catch {

            }
            return bmp;
        }
    }
}
