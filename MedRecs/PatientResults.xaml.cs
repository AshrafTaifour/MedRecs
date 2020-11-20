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
    /// Interaction logic for PatientResults.xaml
    /// </summary>
    public partial class PatientResults : Window
    {
        string pid;
        public PatientResults()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)PatientResultDataGrid.SelectedItems[0];
            pid = selectedRow.Row.ItemArray[0].ToString();
            MessageBox.Show(pid);
            string lname = selectedRow.Row.ItemArray[1].ToString();
            string mname = selectedRow.Row.ItemArray[2].ToString();
            string fname = selectedRow.Row.ItemArray[3].ToString();
            string hc_num = selectedRow.Row.ItemArray[4].ToString();
            string policy_num = selectedRow.Row.ItemArray[5].ToString();
            string phone_num = selectedRow.Row.ItemArray[6].ToString();
            string p_email = selectedRow.Row.ItemArray[7].ToString();

            ModifyPatient mp = new ModifyPatient(int.Parse(pid), lname, mname, fname, hc_num, policy_num, phone_num, p_email);
            mp.Owner = this;
            mp.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)PatientResultDataGrid.SelectedItems[0];
            pid = selectedRow.Row.ItemArray[0].ToString();
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mohamad\source\repos\MedRecs\MedRecs\MedRecs\MedicalDatabase.mdf;Integrated Security=True");
            string str_cmd_goes = "DELETE FROM GOES_TO WHERE pid = " + pid;
            string str_cmd_has = "DELETE FROM HAS WHERE pid = " + pid;
            string str_cmd_pat = "DELETE FROM PATIENTS WHERE pid = " + pid;
            SqlCommand cmdgoes = new SqlCommand(str_cmd_goes, conn);
            SqlCommand cmdhas = new SqlCommand(str_cmd_has, conn);
            SqlCommand cmdpat = new SqlCommand(str_cmd_pat, conn);
            conn.Open();
            cmdgoes.ExecuteNonQuery();
            cmdhas.ExecuteNonQuery();
            cmdpat.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Patient record deleted!");
            FillDataGrid();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FillDataGrid()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mohamad\source\repos\MedRecs\MedRecs\MedRecs\MedicalDatabase.mdf;Integrated Security=True");
            string str_cmd = "SELECT pid, lname, mname, fname, hc_num, policy_num, phone_number, p_email FROM patients ORDER BY lname ASC";
            SqlCommand cmd = new SqlCommand(str_cmd, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            PatientResultDataGrid.ItemsSource = dt.DefaultView;
        }
    }
}
