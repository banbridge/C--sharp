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
    /// Path2.xaml 的交互逻辑
    /// </summary>
    public partial class Path2 : Page
    {
        
        public Path2()
        {
            InitializeComponent();
        }
        private void ellipse_click(object sender, MouseEventArgs e)
        {
            Ellipse ep = sender as Ellipse;
            Solve.getResult(ep);
        }
    }
}
