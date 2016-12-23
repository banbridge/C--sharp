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
    /// Interaction logic for Login_User.xaml
    /// </summary>
    public partial class Login_User : Window
    {
        Random r = new Random();
        public Login_User()
        {
            InitializeComponent();
            MainWindow.is_log = true;
            btn.Content = r.Next(1000, 9999).ToString();
            this.Closing += Login_User_Closing;
        }

        private void Login_User_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.is_log = false;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            
            btn.Content= r.Next(1000, 9999).ToString();
        }

        private void cancel_Login_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Ok_Login_Click(object sender, RoutedEventArgs e)
        {
            bool f_passwrd = false, f_user = false, f_yanzhengma = false;
            string user = textboxUser.Text.ToString();
            string password = textboxPassword.Password.ToString();
            if (user == "" || user == null)
            {
                textboxUser.BorderBrush = Brushes.Red;
                user_label.Content = "用户名为空";
            }
            else
            {
                try
                {
                    var content = MainWindow.context_main;
                    {
                        var q = from t in content.User
                                where t.UserName.ToString() == user
                                select new
                                {
                                    用户名 = t.UserName,
                                    密码 = t.PassWord.ToString(),
                                    余额 = t.Money,
                                    身份证 = t.ID,
                                    开户时间 = t.OpenTime
                                };
                        String s = "";
                        foreach (var v in q)
                        {
                           
                            s += v.密码;
                            MainWindow.restmoney = (int)v.余额;
                        }
                       
                        if (s != ""&&s!=null)
                        {
                            s = s.Substring(0, s.IndexOf(" "));
                            f_user = true;
                            textboxUser.BorderBrush = Brushes.Black;
                            user_label.Content = "";

                            if (s == password)
                            {
                                f_passwrd = true;
                                textboxPassword.BorderBrush = Brushes.Black;
                                password_label.Content = "";
                            }
                            else
                            {
                               // MessageBox.Show(s.Length + ":l:" + s + ":ps:" + password);
                                textboxPassword.BorderBrush = Brushes.Red;
                                password_label.Content = "密码不正确";
                            }

                        }
                        else
                        {
                            textboxUser.BorderBrush = Brushes.Red;
                            user_label.Content = "用户名不存在";
                        }

                    }
            }
                catch (Exception e1)
            {

                MessageBox.Show(e1.Message + "，打开失败");
            }
        }
            if (password == "" || password == null)
            {
                textboxPassword.BorderBrush = Brushes.Red;
                password_label.Content = "密码为空";
            }
            if (Yanzhengma.Text.ToString() != btn.Content.ToString())
            {
                Yanzhengma.BorderBrush = Brushes.Red;
                yanzhengma_label.Content = "验证码错误";
                btn.Content = r.Next(1000, 9999).ToString();
            }
            else
            {
                f_yanzhengma = true;
                Yanzhengma.BorderBrush = Brushes.Black;
                yanzhengma_label.Content = "";
            }

            if (f_passwrd == true && f_user == true && f_yanzhengma == true)
            {
                MessageBox.Show("登录成功!!", "信息", MessageBoxButton.OK, MessageBoxImage.Information);
                MainWindow.Is_UserLogin = true;
                MainWindow.label_userInfo.Text = "欢迎你，" + user;
                MainWindow.userName = user;
                MainWindow.label_userInfo.Visibility = Visibility.Visible;
                MainWindow.btn_logIn.Visibility = Visibility.Hidden;
                this.Close();
            }

        }
           
        
    }
}
