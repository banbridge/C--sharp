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
    /// Login_manager.xaml 的交互逻辑
    /// </summary>
    public partial class Login_manager : Window
    {
        public static bool logSuccess=false;
        public string UserName { get; set; }
        private string PassWord { get; set; }
        private static int i = 0;
        private bool j = false;
        public static int num = 0;
        System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
        public Login_manager()
        {
            logSuccess = false;
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            userName.Focus();
            image_error.Visibility = Visibility.Hidden;
            timer.Interval = TimeSpan.FromMilliseconds(200);
            timer.Tick += Timer_Tick;
            comboBox.IsReadOnly = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Action();
            num++;
        }
        private void Action()
        {
            if (num == 10)
            {
                timer.Stop();
                num = 1;
            }
            if (j == false)
            {
                image_error.Visibility = Visibility.Hidden;
                j = true;
            }
            else
            {
                image_error.Visibility = Visibility.Visible;
                j = false;
            }
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            string n = comboBox.Text;
            if (!userName.Text.Equals("") && !userName.Text.Equals(null))
            {
                if (passWord.Password.Equals("123") && userName.Text.Equals("Admin"))
                {
                    logSuccess = true;
                    UserError_label.Content = "";
                    PasswordError_label.Content = "";
                   this.Close();
                }else
                {
                    if (passWord.Password.Equals("") || passWord.Password.Equals(null))
                    {
                        passWord.BorderBrush = Brushes.Red;
                        PasswordError_label.Content = "密码不能为空!";
                    }else if (passWord.Password != "123"){
                        passWord.BorderBrush = Brushes.Red;
                        PasswordError_label.Content = "密码错误";
                        j = true;
                        timer.Start();
                        passWord.Password = "";
                    }else if(passWord.Password == "123")
                    {
                        PasswordError_label.Content = "";
                        passWord.BorderBrush = Brushes.Black;
                    }
                    //else
                    //{
                    //    j = true;
                    //    timer.Start();
                    //    passWord.Password = "";
                    //}
                    if (!userName.Text.Equals("Admin"))
                    {
                        userName.BorderBrush = Brushes.Red;
                        UserError_label.Content = "用户名不正确，默认为Admin";
                    }else if (userName.Text.Equals("Admin"))
                    {
                        UserError_label.Content = "";
                        userName.BorderBrush = Brushes.Black;
                    }
                    //else
                    //{
                    //    j = true;
                    //    timer.Start();
                    //    passWord.Password = "";
                    //}
                }
                
            }
            else
            {
                MessageBox.Show("请输入用户名");
            }
            UserName = userName.Text;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (userName.Text.Equals("") || userName.Equals(null) || passWord.Password == "" || passWord.Password == null|| logSuccess == false)
            {
                //this.Close();
            }
        }
    }
}
