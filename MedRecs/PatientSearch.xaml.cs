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
    /// Interaction logic for PatientSearch.xaml
    /// This is used for the "Create New Appointment" use case
    /// </summary>
    public partial class PatientSearch : Window
    {
        //Takes that text and will query the patient table
        public PatientSearch(String patientText)
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)PatientSearchDataGrid.SelectedItems[0];
            string lname = selectedRow.Row.ItemArray[0].ToString();
            string fname = selectedRow.Row.ItemArray[1].ToString();
            int pid = int.Parse(selectedRow.Row.ItemArray[2].ToString());
            string fullname = fname + " " + lname;

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FillDataGrid()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mohamad\source\repos\MedRecs\MedRecs\MedRecs\MedicalDatabase.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT lname, fname, pid FROM patients ORDER BY lname ASC", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            PatientSearchDataGrid.ItemsSource = dt.DefaultView;
        }
    }
}