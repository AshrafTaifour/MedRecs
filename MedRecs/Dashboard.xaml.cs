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
            FillDataGrid();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            date.Content = DateTime.Now;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)AppointmentsDataGrid.SelectedItems[0];
            string appID = selectedRow.Row.ItemArray[0].ToString();

            //MAKE SURE THIS HAS THE CORRECT CONNECTION SOURCE.
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mohamad\source\repos\MedRecs\MedRecs\MedRecs\MedicalDatabase.mdf;Integrated Security=True");

            string DELHAS_str = "DELETE FROM HAS WHERE appid = " + appID;
            SqlCommand DELHAS_cmd = new SqlCommand(DELHAS_str, conn);

            string DELAPT_str = "DELETE FROM APPOINTMENT WHERE appid = " + appID;
            SqlCommand DELAPT_cmd = new SqlCommand(DELAPT_str, conn);

            conn.Open();

            DELHAS_cmd.ExecuteNonQuery();
            DELAPT_cmd.ExecuteNonQuery();

            conn.Close();
            System.Windows.MessageBox.Show("Appointment has been successfully deleted!");
            FillDataGrid();

        }

        private void Patients_Click(object sender, RoutedEventArgs e)
        {
            PatientWindow pw = new PatientWindow();
            pw.Owner = this;
            pw.ShowDialog();
        }

        private void FillDataGrid()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mohamad\source\repos\MedRecs\MedRecs\MedRecs\MedicalDatabase.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT  APPOINTMENT.appid, PATIENTS.lname, APPOINTMENT.time from PATIENTS, APPOINTMENT, HAS WHERE date = convert(date, GETUTCDATE()) AND patients.pid = has.pid AND APPOINTMENT.appid = has.appid ORDER BY date ASC", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            AppointmentsDataGrid.ItemsSource = dt.DefaultView;
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }
    }
}
