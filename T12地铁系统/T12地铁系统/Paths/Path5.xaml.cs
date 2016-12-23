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
    /// Path5.xaml 的交互逻辑
    /// </summary>
    public partial class Path5 : Page
    {
        
        public Path5()
        {
            InitializeComponent();
        }
        private void ellipse_click(object sender, MouseEventArgs e)
        {
            Ellipse ep = sender as Ellipse;
            TextBox t1 = MainWindow.textbox_start, t2 = MainWindow.textbox_end;

            if (t1.Text == "")
            {
                RadialGradientBrush brush = new RadialGradientBrush();
                brush.GradientStops.Add(new GradientStop(color: Color.FromArgb(0xFF, 0xff, 0xff, 0xff), offset: 0));
                brush.GradientStops.Add(new GradientStop(color: Color.FromArgb(0xFF, 0x00, 0x9c, 0xac), offset: 0.54));
                brush.GradientStops.Add(new GradientStop(color: Color.FromArgb(0xFF, 0x33, 0x59, 0xda), offset: 1));
                ep.Fill = brush;
                t1.Text = ep.ToolTip.ToString();
                MainWindow.e1_start = ep;
            }
            else if (t2.Text == "")
            {
                RadialGradientBrush brush = new RadialGradientBrush();
                brush.GradientStops.Add(new GradientStop(color: Color.FromArgb(0xFF, 0xff, 0xff, 0xff), offset: 0));
                brush.GradientStops.Add(new GradientStop(color: Color.FromArgb(0xFF, 0x00, 0x9c, 0xac), offset: 0.54));
                brush.GradientStops.Add(new GradientStop(color: Color.FromArgb(0xFF, 0x33, 0x59, 0xda), offset: 1));
                ep.Fill = brush;
                t2.Text = ep.ToolTip.ToString();
                MainWindow.e2_end = ep;
            }
            if (t1.Text != "" && t2.Text != "")
            {
                int i1 = int.Parse(MainWindow.e1_start.Tag.ToString());
                int i2 = int.Parse(MainWindow.e2_end.Tag.ToString());int m = Math.Max(i1, i2);
                int sub = 24 - m + i1 + i2 - m;
                
                if (Math.Abs(i2 - i1) <sub)
                {
                    sub = Math.Abs(i2 - i1);
                }
               
                MainWindow.label_money.Content = sub / 3 + 1 + "";
            }
            else
            {
                MainWindow.label_money.Content = "";
            }

        }
    }
}
