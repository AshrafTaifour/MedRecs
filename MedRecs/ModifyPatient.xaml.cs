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
    /// Interaction logic for ModifyPatient.xaml
    /// </summary>
    public partial class ModifyPatient : Window
    {
        string patientid;
        string lastname;
        string middlename;
        string firstname;
        string regnum;
        string policyNum;
        string phoneNum;
        string email;
        public ModifyPatient(int pid, string lname, string mname, string fname, string hc_num, string policy_num, string phone_num, string p_email)
        {
            InitializeComponent();
            patientid = pid.ToString();
            lastname = lname;
            middlename = mname;
            firstname = fname;
            regnum = hc_num;
            policyNum = policy_num;
            phoneNum = phone_num;
            email = p_email;

            patientIDBox.IsEnabled = false;
            patientIDBox.Text = pid.ToString();
            lastNameBox.Text = lname;
            middleNameBox.Text = mname;
            firstNameBox.Text = fname;
            registrationNumberBox.Text = hc_num;
            policyNumberBox.Text = policy_num;
            phoneNumberBox.Text = phone_num;
            emailBox.Text = p_email;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mohamad\source\repos\MedRecs\MedRecs\MedRecs\MedicalDatabase.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE PATIENTS SET lname=@lastname, mname=@middlename, fname=@firstname, hc_num=@regnumber, policy_num=@policynumber, phone_number=@phonenumber, p_email=@email WHERE pid = @pid ";

            cmd.Parameters.AddWithValue("@lastname", lastname);
            cmd.Parameters.AddWithValue("@middlename", middlename);
            cmd.Parameters.AddWithValue("@firstname", firstname);
            cmd.Parameters.AddWithValue("@regnumber", regnum);
            cmd.Parameters.AddWithValue("@policynumber", policyNum);
            cmd.Parameters.AddWithValue("@phonenumber", phoneNum);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@pid", patientid);

            cmd.Connection = conn;

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();

            MessageBox.Show("Patient Upadate!");
            this.Close();
        }
    }
}
