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
    /// 查询.xaml 的交互逻辑
    /// </summary>
    public partial class 查询 : Page
    {
        public 查询()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = "";
            //string str = c_username.Text;
            string str = c_username.Text;
            if (str == "" || str == null)
            {
                c_username.BorderBrush = Brushes.Red;
                Error.Content = "用户名不能为空";
                return;
            }
            try
            {
                using (var context = new MyDbEntities())
                {
                    var q = from t1 in context.User
                            where t1.UserName == str
                            select new
                            {
                                账户 = t1.UserName,
                                开户时间 = t1.OpenTime,
                                身份证号 = t1.ID,
                                余额 = t1.Money
                            };
                    foreach (var v in q)
                    {
                        s += v.账户;
                    }
                    if (s == "")
                    {
                        c_username.BorderBrush = Brushes.Red;
                        Error.Content = "用户名不存在";

                        return;
                    }
                    dataGrid.ItemsSource = q.ToList();
                }
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message + "，查询出错");
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string str = c_username.Text;
            try
            {
                using (var context = new MyDbEntities())
                {
                    var q = from t in context.Ticket
                                //where t.UserName == str
                            select new
                            {
                                账户 = t.UserName,
                                起始站 = t.Begin,
                                终点站 = t.End,
                                购票数量 = t.Count,
                                购票时间 = t.BuyDate,

                            };
                    dataGrid.ItemsSource = q.ToList();
                    context.Dispose();
                }
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message + "，查询出错");
            }

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            try
            {
                using (var context = new MyDbEntities())
                {

                    var q = from t1 in context.User
                                // where t1.UserName == str

                            select new
                            {
                                账户 = t1.UserName,
                                密码 = t1.PassWord,
                                开户时间 = t1.OpenTime,
                                身份证号 = t1.ID,
                                余额 = t1.Money
                            };

                    dataGrid.ItemsSource = q.ToList();
                }
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message + "，查询出错");
            }

        }
    }
}
