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
    /// Interaction logic for CreateAppointment.xaml
    /// </summary>
    public partial class CreateAppointment : Window
    {
        public CreateAppointment()
        {
            InitializeComponent();
        }

        //This will create an insertion query using the data give in the fields
        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        //Takes the current patientQuery textbox data and creates a seletion query 
        //returns the selected object back to the textbox. 
        private void Patient_Click(object sender, RoutedEventArgs e)
        {
            //Takes the patientQuery current text and coverts it into a string
            String patientText = patientQuery.Text.ToString();
            //Creates a PatientSearch window passinging in the current text
            PatientSearch pSearch = new PatientSearch(patientText);
            pSearch.Owner = this;
            pSearch.ShowDialog();
        }

        private void Physician_Click(object sender, RoutedEventArgs e)
        {
            //Takes the physicianQuery current text and coverts it into a string
            String physicianText = physicianQuery.Text.ToString();
            //Creates a PatientSearch window passinging in the current text
            PhysicianSearch phySearch = new PhysicianSearch(physicianText);
            phySearch.Owner = this;
            phySearch.ShowDialog();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
