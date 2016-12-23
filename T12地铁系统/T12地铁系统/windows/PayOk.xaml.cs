using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace T12地铁系统.windows
{
    /// <summary>
    /// PayOk.xaml 的交互逻辑
    /// </summary>
    public partial class PayOk : Window
    {
        private int rest;
        private TicketInfor ticketInfor;

        DispatcherTimer timer = new DispatcherTimer();
        public PayOk()
        {
           
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (cnt > 6)
            {
                chupiao.Text = "出票成功";
                dian.Visibility = Visibility.Hidden;
            }
            else
            {
                if (dian.Text.ToString() == ". . .")
                {
                    dian.Text = ". . ";
                }
                else
                {
                    dian.Text = ". . .";
                }
            }
           
            cnt++;
        }


        public int cnt;
        public PayOk(int rest, TicketInfor ticketInfor) 
        {
            cnt = 0;
            MainWindow.is_payok = true;
            this.rest = rest;
            this.ticketInfor = ticketInfor;
            timer.Tick += Timer_Tick; timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Start();
            InitializeComponent();
            this.Closing += PayOk_Closing;
            yue.Content = "你的余额为：" + rest;
        }

        private void PayOk_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.ticketInfor.Close();
            MainWindow.is_payok = false;
        }
    }
}
