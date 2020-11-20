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

namespace MedRecs
{
    /// <summary>
    /// Interaction logic for ModifyPatient.xaml
    /// </summary>
    public partial class ModifyPatient : Window
    {
        public ModifyPatient(int pid, string lname, string mname, string fname, string hc_num, string policy_num, string phone_num, string p_email)
        {
            InitializeComponent();
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
            //Update queury with all the information
        }
    }
}
