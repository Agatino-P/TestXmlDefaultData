using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace TestXmlDefaultData
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(@"c:\cam3d\default\cerchio.xml");
            string jsonText = JsonConvert.SerializeXmlNode(doc);
            var obj = JsonConvert.DeserializeObject(jsonText);

            StringBuilder sb = new StringBuilder();
            foreach (var size in ((Newtonsoft.Json.Linq.JObject)obj)["root"]["Size"].ToList())
            {
                sb.Append($"X:{size["DimX"]} Y:{size["DimY"]} Z:{size["DimZ"]}\n");
            }
            MessageBox.Show(sb.ToString(),((Newtonsoft.Json.Linq.JObject)obj)["root"]["Size"].ToList().Count.ToString());
        }
    }
}
