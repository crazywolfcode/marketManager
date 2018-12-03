using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows;
using System.Windows.Markup;
using System.Threading.Tasks;

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
    }
}
