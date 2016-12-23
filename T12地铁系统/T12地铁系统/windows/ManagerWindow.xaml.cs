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

namespace T12地铁系统.windows
{
    /// <summary>
    /// ManagerWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ManagerWindow : Window
    {
        public ManagerWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.SourceInitialized += ManagerWindow_SourceInitialized;
           
            n1.IsSelected = true;
        }

        private void ManagerWindow_SourceInitialized(object sender, EventArgs e)
        {
            Login_manager login = new Login_manager();
            login.ShowDialog();
            this.Title = "你好:" + login.UserName;
            if (Login_manager.logSuccess == false)
            {
                this.Close();
            }
        }

        private void TreeViewItem_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = e.Source as TreeViewItem;
            string path = string.Format("/ManagerPages/{0}.xaml", item.Header);
            Uri source = new Uri(path, UriKind.Relative);
            object obj = null;
            try
            {
                obj = Application.LoadComponent(source);
            }
            catch
            {
                MessageBox.Show("未找到" + source.OriginalString);
                return;
            }
            Page p = obj as Page;
            if (p != null)
            {
                frame1.NavigationService.RemoveBackEntry();
                frame1.Source = source;
                return;
            }
            Window w = obj as Window;
            if (w != null)
            {
                w.Owner = this;
                w.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;
                w.ShowDialog();
            }
        }
    }
}
