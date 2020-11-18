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
    /// Interaction logic for PatientSearch.xaml
    /// This is used for the "Create New Appointment" use case
    /// </summary>
    public partial class PatientSearch : Window
    {
        //Takes that text and will query the patient table
        public PatientSearch(String patientText)
        {
            InitializeComponent();
            //Query 
            //Show in data table: Patient Name, PID, and reg#
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            //Return the selected patient id and name to the CreateAppointment window
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
