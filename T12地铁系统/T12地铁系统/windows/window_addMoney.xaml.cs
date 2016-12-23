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
    /// window_addMoney.xaml 的交互逻辑
    /// </summary>
    public partial class window_addMoney : Window
    {
        public window_addMoney()
        {
            InitializeComponent();
            MainWindow.is_addmoney = true;
            this.Closing += Window_addMoney_Closing;
        }

        private void Window_addMoney_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow.is_addmoney = false;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string str_user = MainWindow.userName;
            int money = 0;
            if(int.TryParse(textBox.Text,out money))
            {
                try
                {
                    var content = MainWindow.context_main;
                    {
                        if (content == null)
                        {
                            content = new MyDbEntities();
                            
                        }
                        var q = from t in content.User
                                where t.UserName == str_user
                                select t;
                        int rest = 0;
                        foreach (var v in q)
                        {
                            v.Money += money;
                            rest = (int)v.Money;
                        }
                        content.Configuration.ValidateOnSaveEnabled = false;
                        content.SaveChanges();
                        content.Configuration.ValidateOnSaveEnabled = true;
                        MessageBox.Show("充值成功!!!!!余额为："+ rest , "信息", MessageBoxButton.OK, MessageBoxImage.Information);
                        textBox.Text = "";
                    }

                }
                catch (Exception ee)
                {

                    MessageBox.Show("充值失败！！！！");
                }
                   
                
               
            }else
            {
                MessageBox.Show("请输入正确的金额！");
            }

        }
    }
}
