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
using System.Data.SqlClient;
using System.Data;


namespace MedRecs
{
    /// <summary>
    /// Interaction logic for CreateAppointment.xaml
    /// </summary>
    public partial class CreateAppointment : Window
    {
        string pid;
        string empid;
        
        public CreateAppointment()
        {
            InitializeComponent();
        }

        //This will create an insertion query using the data give in the fields
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            string date = dateSelector.SelectedDate.Value.ToShortDateString();
            string time = timeBox.Text.ToString();
            
       
            //Create the appointment record
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mohamad\source\repos\MedRecs\MedRecs\MedRecs\MedicalDatabase.mdf;Integrated Security=True");
            SqlCommand cmdApp = new SqlCommand();
            cmdApp.CommandType = CommandType.Text;
            cmdApp.CommandText = "INSERT INTO APPOINTMENT( date, time) VALUES (@appdate, @apptime);";
            cmdApp.Parameters.AddWithValue("@appdate", date);
            cmdApp.Parameters.AddWithValue("@apptime", time);
            cmdApp.Connection = conn;
            conn.Open();
            cmdApp.ExecuteNonQuery();

            //Query for the appointments appid
            SqlCommand cmdAppID = new SqlCommand();
            cmdAppID.CommandType = CommandType.Text;
            cmdAppID.CommandText = "SELECT appid FROM APPOINTMENT WHERE date = @appdate AND time = @apptime";
            cmdAppID.Parameters.AddWithValue("@appdate", date);
            cmdAppID.Parameters.AddWithValue("@apptime", time);
            cmdAppID.Connection = conn;
            //Executes appointment query and stores app id for next queery 
            int appid = cmdAppID.ExecuteNonQuery();

            //links patient to appointment in HAS
            SqlCommand cmdHas = new SqlCommand();
            cmdHas.CommandType = CommandType.Text;
            cmdHas.CommandText = "INSERT INTO HAS( pid, appid) VALUES (@patientid, @appointID);";
            cmdHas.Parameters.AddWithValue("@patientID", pid);
            cmdHas.Parameters.AddWithValue("@appointID", appid);
            cmdHas.Connection = conn;

            //Links healthcare personnel to appointment in ATTENDS
            SqlCommand cmdATT = new SqlCommand();
            cmdATT.CommandType = CommandType.Text;
            cmdATT.CommandText = "INSERT INTO ATTENDS( appid, empid) VALUES (@appointID, @empployid);";
            cmdATT.Parameters.AddWithValue("@appointID", appid);
            cmdATT.Parameters.AddWithValue("@aemployID", empid);
            cmdATT.Connection = conn;

            //Execute the cmdHAS and cmdATT commands
            cmdHas.ExecuteNonQuery();
            cmdATT.ExecuteNonQuery();

            conn.Close();
            MessageBox.Show("Appointment created!");

            this.Close();
        }

        //Takes the current patientQuery textbox data and creates a seletion query 
        //returns the selected object back to the textbox. 
        private void Patient_Click(object sender, RoutedEventArgs e)
        {
            //Takes the patientQuery current text and coverts it into a string
            string patientText = patientQuery.Text.ToString();
            //Creates a PatientSearch window passinging in the current text
            PatientSearch pSearch = new PatientSearch(patientText);
            pSearch.Owner = this;
            pSearch.ShowDialog();
            patientQuery.Text = pSearch.fullname;
            pid = pSearch.pid;
        }

        private void Physician_Click(object sender, RoutedEventArgs e)
        {
            //Takes the physicianQuery current text and coverts it into a string
            string physicianText = physicianQuery.Text.ToString();
            //Creates a PatientSearch window passinging in the current text
            PhysicianSearch phySearch = new PhysicianSearch(physicianText);
            phySearch.Owner = this;
            phySearch.ShowDialog();
            physicianQuery.Text = phySearch.lname;
            empid = phySearch.empid;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
