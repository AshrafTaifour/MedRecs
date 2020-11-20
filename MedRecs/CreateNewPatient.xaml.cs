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
using System.Data;
using System.Data.SqlClient;

namespace MedRecs
{
    /// <summary>
    /// Interaction logic for CreateNewPatient.xaml
    /// </summary>
    public partial class CreateNewPatient : Window
    {
        public CreateNewPatient()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            string lname = null;
            string mname = null;
            string fname = null;
            string regNum = null;
            string policyNum = null;
            string phoneNum = null;
            string email = null;

            if(lastNameBox.Text.ToString() != null)
            {
                lname = lastNameBox.Text.ToString();
            }
         
            if(middleNameBox.Text.ToString() != null)
            {
                mname = middleNameBox.Text.ToString();
            }

            if(firstNameBox.Text.ToString() != null)
            {
                fname = firstNameBox.Text.ToString();
            }

            if(registrationNumberBox.Text.ToString() != null)
            {
                regNum = registrationNumberBox.Text.ToString();
            }

            if (policyNumberBox.Text.ToString() != null)
            {
                policyNum = policyNumberBox.Text.ToString();
            }

            if(phoneNumberBox.Text.ToString() != null)
            {
                phoneNum = phoneNumberBox.Text.ToString();
            }

            if(emailBox.Text.ToString() != null)
            {
                email = emailBox.Text.ToString();
            }

            if (lname != null || fname != null || regNum != null || phoneNum != null)
            {
                SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mohamad\source\repos\MedRecs\MedRecs\MedRecs\MedicalDatabase.mdf;Integrated Security=True");
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO PATIENTS(lname, mname, fname, hc_num, policy_num, phone_number, p_email) VALUES(@lastname, @middlename, @firstname, @regnumber, @policynumber, @phonenumber, @email)";
                cmd.Parameters.AddWithValue("@lastname", lname);
                cmd.Parameters.AddWithValue("@middlename", mname);
                cmd.Parameters.AddWithValue("@firstname", fname);
                cmd.Parameters.AddWithValue("@regnumber", regNum);
                cmd.Parameters.AddWithValue("@policynumber", policyNum);
                cmd.Parameters.AddWithValue("@phonenumber", phoneNum);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Connection = conn;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Patient Created!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please provide all required informatiom (*).");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
