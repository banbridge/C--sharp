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
using T12地铁系统.windows;


namespace T12地铁系统
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public static bool is_log = false, is_tickInfo = false,is_payok=false,is_addmoney=false;
        public static MyDbEntities context_main = new MyDbEntities();
        public static string userName="";
        public static bool Is_UserLogin ;
        public static int ticket_style,restmoney=-1;
        public static Frame mainFrame;
        public static TextBox textbox_start, textbox_end,textbox_nums;
        public static Label label_money;
        public static TextBlock label_userInfo;
        public static Button btn_logIn;
        DispatcherTimer timer;
        public static Ellipse e1_start = new Ellipse(), e2_end = new Ellipse();
        public MainWindow()
        {
            Is_UserLogin = false;
            ticket_style = 1;
            InitializeComponent();
            InitLanguages();
            mainFrame = main_frame;
            textbox_start = textBox_start;
            textbox_end = textBox_end;
            label_money = label_oneOfMoney;
            label_userInfo = label_user;
            textbox_nums= textbox_ticketCnt;
            btn_logIn = btn_login;
            this.Loaded += MainWindow_Loaded;
        }

        Thickness tn = new Thickness();

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            tn.Right = -label1.Width;
            label1.Margin = tn;
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Start();
            //context_main.Dispose();
            this.WindowState = WindowState.Maximized;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            main_frame.Source = new Uri("/Paths/AllPage.xaml", UriKind.Relative);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (tn.Right >= stack1.Width)
            {
                tn.Right = -label1.Width;
            }
            else
            {
                tn.Right += 1;
                label1.Margin = tn;
            }

            DateTime dt = DateTime.Now;
           string s1= string.Format("{0:D2}:{1:D2} {2}", dt.Hour, dt.Minute, dt.ToString("dddd")); 
            label_year.Content =string.Format("{0} ", dt.ToString("MM-dd-yyyy"))+s1;
        }

        

        private void ButtonButtom_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            if (btn != null)
            {
                string str = btn.Name.ToString();
                switch (str)
                {
                    case "btn_changeEnglish":
                        string selectedLanguageName = (e.Source as Button).Tag.ToString();
                        //MessageBox.Show(selectedLanguageName);//测试
                        foreach (var v in languages)
                        {
                            string languageName = this.FindResource(v).ToString();
                           
                            if (languageName == selectedLanguageName)
                            {
                                ResourceDictionary currentDict = new ResourceDictionary()
                                {
                                    Source = new Uri(pfx + currentLanguage + ".xaml", UriKind.Relative)
                                };
                                this.Resources.MergedDictionaries.Remove(currentDict);
                                currentDict.Source = new Uri(pfx + v + ".xaml", UriKind.Relative);
                                this.Resources.MergedDictionaries.Add(currentDict);
                                currentLanguage = v;
                                break;
                            }
                        }
                        break;
                    case "btn_shutdown":App.Current.Shutdown(); break;
                    case "btn_back":
                        
                        this.Close();
                        break;
                    case "btn_ok":
                        if (textbox_start.Text == "")
                        {
                            MessageBox.Show("请选择起始地点!","提示",MessageBoxButton.OK,MessageBoxImage.Warning);
                        }
                        else if (textbox_end.Text == "")
                        {
                            MessageBox.Show("请选择目的地!", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        else
                        {
                            if (is_tickInfo == false)
                            {
                                if (Is_UserLogin == false)
                                {

                                    MessageBoxResult result = MessageBox.Show("你没有登录,要登录吗？", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                                    if (result == MessageBoxResult.OK && MainWindow.is_log == false)
                                    {
                                        (new Login_User()).ShowDialog();
                                    }

                                }
                                else
                                {
                                    TicketInfor p = new TicketInfor();
                                    p.ShowDialog();
                                }
                                    
                            }
                            
                        }
                      
                         break;
                    case "btn_addMoney":
                        if (Is_UserLogin == false)
                        {
                            MessageBoxResult result= MessageBox.Show("你没有登录,要登陆吗？","提示",MessageBoxButton.OKCancel,MessageBoxImage.Question);
                            if (result == MessageBoxResult.OK)
                            {
                                (new Login_User()).ShowDialog();
                            }
                        }
                        else
                        {
                            if (is_addmoney == false) {  (new window_addMoney()).ShowDialog(); }
                              
                        }
                        break;
                }
            }
        }

        private void ButtonPathchoice_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            if (btn != null)
            {
                
                string str = btn.Tag.ToString();
                RadialGradientBrush brush = new RadialGradientBrush();
                brush.GradientStops.Add(new GradientStop(color: Color.FromArgb(0xFF, 0xff, 0xd7, 0x00), offset: 0.25));
                brush.GradientStops.Add(new GradientStop(color: Color.FromArgb(0xFF, 0xff, 0x00, 0x00), offset: 0.50));
                brush.GradientStops.Add(new GradientStop(color: Color.FromArgb(0xff, 0x80, 0x00, 0x80), offset: 1));
                e1_start.Fill = brush;
                e1_start = new Ellipse();
                textBox_start.Text = "";
                e2_end.Fill = brush;
                e2_end = new Ellipse();
                textBox_end.Text = "";
                main_frame.Source = new Uri("/Paths/" + btn.Tag, UriKind.Relative);
            }
        }

        private void ButtonChangeTick_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            int count = 0;
            if (btn != null&&int.TryParse(textbox_ticketCnt.Text,out count))
            {
                if (btn.Name.ToString() == "btn_addTicket")
                {
                    if (count < 30) { count++; }
                    textbox_ticketCnt.Text = count + "";
                }
                else if (btn.Name.ToString() == "btn_subTicket")
                {
                    if (count > 1) count--; textbox_ticketCnt.Text = count + "";
                }
                else
                {
                    textbox_ticketCnt.Text = btn.Tag.ToString();
                }
            }
            
        }

        private void ButtonClrear_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            string str = btn.Tag.ToString();
            RadialGradientBrush brush = new RadialGradientBrush();
            brush.GradientStops.Add(new GradientStop(color: Color.FromArgb(0xFF, 0xff, 0xd7, 0x00), offset: 0.25));
            brush.GradientStops.Add(new GradientStop(color: Color.FromArgb(0xFF, 0xff, 0x00, 0x00), offset: 0.50));
            brush.GradientStops.Add(new GradientStop(color: Color.FromArgb(0xff, 0x80, 0x00, 0x80), offset: 1));
            switch (str)
            {
                case "pos_start":
                    e1_start.Fill = brush;
                    e1_start = new Ellipse(); 
                    textBox_start.Text = "";
                    break;
                case "pos_end":
                    e2_end.Fill = brush;
                    e2_end = new Ellipse();
                    textBox_end.Text = "";
                    break;
            }
            if(textBox_end.Text==""||textBox_start.Text=="")
            {
                label_money.Content = "";
            }
        }
        //中英文转换
        private string currentLanguage = "zh-CN";

        private void Button_TicketStyle_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            if (btn != null)
            {
                if (is_tickInfo == false) {     if (Is_UserLogin == false)
                {

                    MessageBoxResult result = MessageBox.Show("你没有登录,要登录吗？", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                    if (result == MessageBoxResult.OK && MainWindow.is_log == false)
                    {
                        (new Login_User()).ShowDialog();
                    }

                }
                else
                {
                    ticket_style = int.Parse(btn.Tag.ToString());
                    (new TicketInfor()).ShowDialog();
                }}
                
               
            }
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            (new Login_User()).ShowDialog();
        }

        private string pfx = "/XamlResources/";
        private List<string> languages = new List<string>();
        private void InitLanguages()
        {
            
            foreach (var v in this.Resources.MergedDictionaries)
            {
                
                if (v.Source.OriginalString == pfx + "Languages.xaml")
                {
                    
                    foreach (var language in v.Keys)
                    {
                        languages.Add(language.ToString());
                    }
                }
            }
        }

    }
}
