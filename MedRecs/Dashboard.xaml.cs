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
using System.Windows.Shapes;
using LoginPageTest;


namespace MedRecs
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        private HEALTHCARE_PERSONNEL user { set; get; }

<<<<<<< Updated upstream
        //private 

=======
>>>>>>> Stashed changes
        public Dashboard(HEALTHCARE_PERSONNEL user)
        {
            InitializeComponent();
            this.user = user;
            username.Content = this.user.email;
            date.Content = DateTime.Now;
            Dashboard_Load();
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

<<<<<<< Updated upstream
=======
        private void AppButton_Click(object sender, RoutedEventArgs e)
        {
            AppointmentWindow appwindow = new AppointmentWindow();
            appwindow.Owner = this;
            appwindow.ShowDialog();
        }

>>>>>>> Stashed changes
        private void Dashboard_Load()
        {
            Timer timer = new Timer();
            timer.Interval = (10 * 1000); // 10 secs
<<<<<<< Updated upstream
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }


        private void timer_Tick(object sender, EventArgs e)
=======
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
>>>>>>> Stashed changes
        {
            date.Content = DateTime.Now;
        }
        
<<<<<<< Updated upstream


=======
>>>>>>> Stashed changes
    }
}
