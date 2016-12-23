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

namespace T12地铁系统.ManagerPages
{
    /// <summary>
    /// 充值.xaml 的交互逻辑
    /// </summary>
    public partial class 充值 : Page
    {
        public 充值()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String us = user.Text, mon = money.Text, s = "" ;
            int int_mon = 0;
            bool is_mon = false,is_use=false;

            // 充值
            if (us == "" || us == null)
            {
                label_user.Content = "用户名为空！！！！";
                user.BorderBrush = Brushes.Red;
            }
            else
            {
                label_user.Content = "";
                user.BorderBrush = Brushes.Black;
                is_use = true;
            }
            if (mon == "" || mon == null)
            {
                label_mon.Content = "金额为空！！！";
                money.BorderBrush = Brushes.Red;
            }
            else if (!int.TryParse(mon, out int_mon))
            {
                label_mon.Content = "金额形式不正确！！！";
                money.BorderBrush = Brushes.Red;
            }
            else
            {
                label_mon.Content = "";
                money.BorderBrush = Brushes.Black;
                is_mon = true;
            }
            if (is_use)
            {
                using (var context = new MyDbEntities())
                {
                    var q = from t in context.User
                            where t.UserName == us
                            select t;
                    foreach (var v in q)
                    {
                        s += v.UserName;
                    }
                    if (s == "")
                    {
                        label_user.Content = "用户名不存在！！！！";
                        user.BorderBrush = Brushes.Red;
                    }
                    else if (is_mon == true)
                    {
                        try

                        {
                            int r = 0;
                            foreach (var v in q)
                            {
                                v.Money += int.Parse(mon);
                                r = (int)v.Money;
                            }
                            context.Configuration.ValidateOnSaveEnabled = false;
                            context.SaveChanges();
                           
                            MessageBox.Show("充值成功，余额为：" + r, "信息", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch (Exception ee)
                        {
                            MessageBox.Show("充值失败：" + ee.Message);
                        }
                        context.Dispose();
                    }

                }
            }

            
            
            
            
        }
    }
}
