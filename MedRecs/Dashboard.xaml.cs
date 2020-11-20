using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
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
using System.Data.SqlClient;
using System.Data;


namespace MedRecs
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        private HEALTHCARE_PERSONNEL user { set; get; }


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

        private void AppButton_Click(object sender, RoutedEventArgs e)
        {
            AppointmentWindow appwindow = new AppointmentWindow();
            appwindow.Owner = this;
            appwindow.ShowDialog();
        }

        private void Dashboard_Load()
        {
            Timer timer = new Timer();
            timer.Interval = (10 * 1000); // 10 secs
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            date.Content = DateTime.Now;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //This will delete the selected appointment from the appointment table
        }

        private void Patients_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow pw = new PatientWindow();
            pw.Owner = this;
            pw.ShowDialog();
        }

        private void FillDataGrid()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\MedicalDatabase.mdf;Integrated Security=True");
            string timeToday = DateTime.Now.ToString();
            /*FOR TESTING */
            PrintDialog printDlg = new PrintDialog();
            Console.WriteLine(timeToday);
            SqlCommand cmd = new SqlCommand("SELECT PATIENTs.lname, APPOINTMENT.time FROM patients, APPOINTMENTS ORDER BY APPOINTMENT.time ASC", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            AppointmentsDataGrid.ItemsSource = dt.DefaultView;
        }
    }
}
