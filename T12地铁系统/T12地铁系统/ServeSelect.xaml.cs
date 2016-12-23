using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using T12地铁系统.windows;


namespace T12地铁系统
{
    /// <summary>
    /// ServeSelect.xaml 的交互逻辑
    /// </summary>
    public partial class ServeSelect : Window
    {
        public ServeSelect()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            if (btn != null)
            {
                string str = btn.Name;
                switch (str)
                {
                    case "MetroItem":
                        (new MainWindow()).Show(); break;
                    case "ManagerItem":
                        (new ManagerWindow()).Show();
                        break;
                }
            }
        }
    }
}
