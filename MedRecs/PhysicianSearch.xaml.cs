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
    /// Interaction logic for PhysicianSearch.xaml
    /// </summary>
    public partial class PhysicianSearch : Window
    {
        //Takes that text and will query the patient table
        public PhysicianSearch(String physicianText)
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)PhysicianSearchDataGrid.SelectedItems[0];
            string lname = selectedRow.Row.ItemArray[0].ToString();
            int empid = int.Parse(selectedRow.Row.ItemArray[1].ToString());

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void FillDataGrid()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mohamad\source\repos\MedRecs\MedRecs\MedRecs\MedicalDatabase.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT lname, fname, empid FROM healthcare_personnel ORDER BY lname ASC", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            PhysicianSearchDataGrid.ItemsSource = dt.DefaultView;
        }
    }
}