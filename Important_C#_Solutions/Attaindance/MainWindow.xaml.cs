using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Attaindance
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public InOutRep repo;
        bool IsLogin ;
        private Timer MainTimer;


        public MainWindow()
        {
            InitializeComponent();
            repo = new InOutRep();
            IsLogin = repo.IsLogin;
          
            MainTimer = new Timer();
            MainTimer.Tick += new EventHandler(mainTimer_Tick);
            MainTimer.Interval = 500; // in miliseconds
            MainTimer.Start();
        }

        private void Logout_name_Click(object sender, RoutedEventArgs e)
        {
            repo.Logout(DateTime.Now);
        }

        private void Login_name_Click(object sender, RoutedEventArgs e)
        {
            IsLogin = true;
            repo.LogIn(DateTime.Now);
            DisplayRemainTime();
        }

        public void DisplayRemainTime()
        {
            if(!IsLogin)
            {
                txt_time.Text = "Login First ...";
            }        
            else
            {
                DateTime? loginTime = repo.GetLoginTime();
                if (loginTime.HasValue)
                {
                    TimeSpan? span =   DateTime.Now - loginTime;
                    var remainSeconds = 28800- span.Value.TotalSeconds;
                    TimeSpan t = TimeSpan.FromSeconds(remainSeconds);

                    txt_time.Text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                                    t.Hours,
                                    t.Minutes,
                                    t.Seconds,
                                    t.Milliseconds);

                }

                  
                else
                    txt_time.Text = "Error Occured ";
            }
        }

        public void mainTimer_Tick(object sender , EventArgs e)
        {
            DisplayRemainTime();
        }


    }
}
