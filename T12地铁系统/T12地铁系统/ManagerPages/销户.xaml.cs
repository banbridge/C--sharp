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
    /// 销户.xaml 的交互逻辑
    /// </summary>
    public partial class 销户 : Page
    {
        public 销户()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = "";
            String str = del_username.Text;
            if (str==""||str==null)
            {
                label.Content = "用户名为空！！！！";
                del_username.BorderBrush = Brushes.Red;

            }
            else
            {
                label.Content = "";
                del_username.BorderBrush = Brushes.Black;
                //删除数据库中改用户
                using (var context = new MyDbEntities())
                {
                    var q = from t in context.User
                            where t.UserName == str
                            select t;
                    try
                    {
                        foreach (var v in q)
                        {
                            s += v.UserName;

                        }
                        if (s == "")
                        {
                            label.Content = "用户名不存在！！！！";
                            del_username.BorderBrush = Brushes.Red;

                            return;
                        }
                        else
                        {
                            foreach (var v in q)
                            {
                                s += v.UserName;
                                context.User.Remove(v);
                            }

                            MessageBox.Show("删除成功!","信息",MessageBoxButton.OK,MessageBoxImage.Information);
                        }
                        context.SaveChanges();
                    }
                    catch (Exception ee)
                    {
                        MessageBox.Show("删除失败：" + ee.Message);
                    }
                    context.Dispose();
                }
                del_username.Text = "";
            }
        }
           
    }
}
