using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace T12地铁系统
{
    class Solve
    {
        public static void getResult(Ellipse ep)
        {
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
                int i2 = int.Parse(MainWindow.e2_end.Tag.ToString());
                MainWindow.label_money.Content = Math.Abs(i2 - i1) / 3 + 1 + "";
            }
            else
            {
                MainWindow.label_money.Content = "";
            }
        }
    }
}
