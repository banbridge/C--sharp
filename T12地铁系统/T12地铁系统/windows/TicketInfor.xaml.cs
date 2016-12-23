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
using System.Windows.Threading;

namespace T12地铁系统.windows
{
    /// <summary>
    /// TicketInfor.xaml 的交互逻辑
    /// </summary>
    public partial class TicketInfor : Window
    {
        public int money = 0;
        DispatcherTimer timer = new DispatcherTimer();
        public TicketInfor()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.Loaded += TicketInfor_Loaded;
            timer.Tick += Timer_Tick;
            MainWindow.is_tickInfo = true;
            timer.Interval = TimeSpan.FromMilliseconds(500);
            this.Closed += TicketInfor_Closed;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (noMoney.Text != "" && noMoney.Text != null)
            {
                noMoney.Text = "";
            }else
            {
                noMoney.Text = "余额不足！！！请充值";
            }
        }

        private void TicketInfor_Closed(object sender, EventArgs e)
        {
            MainWindow.is_tickInfo = false;
        }

        private void TicketInfor_Loaded(object sender, RoutedEventArgs e)
        {
            int style = MainWindow.ticket_style;
            
            Infor_numberOfTicket.Content = MainWindow.textbox_nums.Text;
            int nums = int.Parse(Infor_numberOfTicket.Content.ToString());
            int danjia;
            if (style == 1)
            {
                Infor_startPos.Content = MainWindow.textbox_start.Text;
                Infor_endPos.Content = MainWindow.textbox_end.Text;
                Infor_moneyOfOne.Content = MainWindow.label_money.Content;
                Infor_style.Content = "普通票";
                danjia = int.Parse(Infor_moneyOfOne.Content.ToString());
              
            }
            else 
            {
                Infor_startPos.Content = "当前位置";
                if (style == 6)
                {
                    Infor_style.Content = "6元通票";
                    Infor_endPos.Content = "任意位置";
                }
                else
                {
                    Infor_style.Content =style+ "元快速票";
                    Infor_endPos.Content = style * 3 + "站以内任意位置";
                }
                
                Infor_moneyOfOne.Content = style;
                danjia = style;
            }
            money = danjia * nums;
            Infor_totalPayMoney.Content = money + "";
            restMon.Text = "你的余额为：" + MainWindow.restmoney;
        }

        private void btn_payMoney_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.Is_UserLogin == false)
            {
                MessageBoxResult result = MessageBox.Show("你没有登录,要登陆吗？", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK&&MainWindow.is_log==false)
                {
                    (new Login_User()).ShowDialog();
                }
            }
            else
            {
                string user = MainWindow.userName;
                try
                {
                    var content = MainWindow.context_main;
                    {
                        if (MainWindow.is_payok == false)
                        {
                            if (content == null)
                            {
                                content = new MyDbEntities();

                            }
                            int rest = 0;
                            bool F = false;
                            var q = from t in content.User
                                    where t.UserName == user
                                    select t;
                            foreach (var v in q)
                            {
                                if (v.Money >= money)
                                {
                                    F = true;
                                }
                                
                            }
                            if (F) {
                                foreach (var v in q)
                                {
                                    v.Money -= money;
                                    rest = (int)v.Money;
                                }
                                Ticket t1 = new Ticket()
                                {
                                    UserName = MainWindow.userName,
                                    Begin = Infor_startPos.Content.ToString(),
                                    End = Infor_endPos.Content.ToString(),
                                    BuyDate = DateTime.Now,
                                    Count=int.Parse(MainWindow.textbox_nums.Text.ToString())
                                };
                                content.Ticket.Add(t1);
                                (new PayOk(rest, this)).ShowDialog();
                                content.Configuration.ValidateOnSaveEnabled = false;
                                content.SaveChanges();
                                content.Configuration.ValidateOnSaveEnabled = true;
                            }
                            else {
                                noMoney.Visibility = Visibility.Visible;
                                timer.Start();
                                return;
                            }

                           
                        }
                        
                    }
                }
                catch (Exception ee)
                {

                    MessageBox.Show(ee.Message);
                }
                
            }
        }
    }
}
