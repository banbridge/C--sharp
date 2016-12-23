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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace T12地铁系统.Paths
{
    /// <summary>
    /// AllPage.xaml 的交互逻辑
    /// </summary>
    public partial class AllPage : Page
    {
       
        public AllPage()
        {
            InitializeComponent();
        }
        private void Path_MouseEnter(object sender, MouseEventArgs e)
        {
            Path p1 = e.Source as Path;
            p1.Stroke = Brushes.Black;
        }
        private void Path_MouseLeave(object sender, MouseEventArgs e)
        {
            Path p1 = e.Source as Path;
            switch (p1.Name)
            {
                case "Path1":
                    p1.Stroke = new SolidColorBrush(Color.FromRgb(0xF7, 0x38, 0x09));
                    break;
                case "Path2":
                    p1.Stroke = new SolidColorBrush(Color.FromRgb(0x90, 0x2C, 0x2C));
                    break;
                case "Path3":
                    p1.Stroke = new SolidColorBrush(Color.FromRgb(0x11, 0xFF, 0x41));
                    break;
                case "Path4":
                    p1.Stroke = new SolidColorBrush(Color.FromRgb(0xE9, 0xC6, 0x39));
                    break;
                case "Path5":
                    p1.Stroke = new SolidColorBrush(Color.FromRgb(0x2A, 0xA5, 0xF8));
                    break;
                case "Path6":
                    p1.Stroke = new SolidColorBrush(Color.FromRgb(0x53, 0x2A, 0xF8));
                    break;
            }
        }
        private void path_Click(object sender, MouseEventArgs e)
        {
            Path p1 = e.Source as Path;
            if (p1 != null)
            {
                string path = string.Format("/Paths/{0}.xaml", p1.Name);
                Uri source = new Uri(path, UriKind.Relative);
                Object obj = null;
                try
                {
                    obj = Application.LoadComponent(source);
                }
                catch (Exception)
                {
                    MessageBox.Show("未找到");
                    return;
                }
                Page p = obj as Page;

                if (p != null)
                {
                   
                   //MainWindow.mainFrame.Source = source;
                    MainWindow.mainFrame.Source = source;
                    return;
                }
            }

            
        }
    }
}
