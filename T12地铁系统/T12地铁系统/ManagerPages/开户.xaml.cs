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
    /// 开户.xaml 的交互逻辑
    /// </summary>
    public partial class 开户 : Page
    {
        private bool a = false;
        private bool b = false;
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        public 开户()
        {
            InitializeComponent();
            open_time.Text = d.ToString("yyyy-MM-dd hh:mm:ss");
            open_time.IsReadOnly = true;
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += Timer_Tick;
            image1.Visibility = Visibility.Hidden;
            image2.Visibility = Visibility.Hidden;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {

            if (username.Text == "" || username.Text == null)
            {

                if (image1.Visibility != Visibility.Visible)
                {
                    image1.Visibility = Visibility.Visible;
                }
                else
                {
                    image1.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                image1.Visibility = Visibility.Hidden;
                username.BorderBrush = Brushes.Black;
            }

            if (pwd.Password == "" || pwd.Password == null)
            {
                if (image2.Visibility != Visibility.Visible)
                {
                    image2.Visibility = Visibility.Visible;
                }
                else
                {
                    image2.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                image2.Visibility = Visibility.Hidden;
                pwd.BorderBrush = Brushes.Black;
            }
        }

        DateTime d = DateTime.Now;
        private void add_Click(object sender, RoutedEventArgs e)
        {
            string s1 = username.Text;
            string s2 = pwd.Password;
            //添加用户信息到数据库
            if (s1 == "" || s1 == null)
            {
                username.BorderBrush = Brushes.Red;
                timer.Start();
            }
            else
            {
                username.BorderBrush = Brushes.Black;
                image1.Visibility = Visibility.Hidden;
            }

            if (s2 == "" || s2 == null)
            {
                pwd.BorderBrush = Brushes.Red;
                timer.Start();
            }
            else
            {
                pwd.BorderBrush = Brushes.Black;
                image2.Visibility = Visibility.Hidden;
            }

            if (s1 != null && !s1.Equals("") && s2 != null && !s2.Equals(""))
            {
                a = true;

            }

            if (ID.Text.Length != 18)
            {
                ID.BorderBrush = Brushes.Red;
                ID_Error.Content = "输入18位身份证号";
            }
            else
            {
                if (a)
                {
                    string s4 = ID.Text;
                    using (var context = new MyDbEntities())
                    {
                        User user = new User()
                        {
                            UserName = s1,
                            PassWord = s2,
                            OpenTime = d,
                            ID = s4,
                            Money = 0
                        };

                        try
                        {
                            context.User.Add(user);
                            context.SaveChanges();
                            MessageBox.Show("添加成功!!" , "信息", MessageBoxButton.OK, MessageBoxImage.Information);
                            timer.Stop();
                            Clear();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("添加失败!" + ex.Message);
                        }
                        context.Dispose();
                    }
                }
            }
        }
        private void Clear()
        {
            username.Text = "";
            pwd.Password = "";
            ID.Text = "";
        }
    }
}
