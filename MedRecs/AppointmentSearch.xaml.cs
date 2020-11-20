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
using System.Windows.Forms;
using System.Globalization;

namespace MedRecs
{
    /// <summary>
    /// Interaction logic for AppointmentSearch.xaml
    /// </summary>
    public partial class AppointmentSearch : Window
    {
        private AppointmentDataTable aptData;

        public AppointmentSearch()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if ((DateBox.SelectedDate == null) && (String.IsNullOrEmpty(patientIDBox.Text)))
            {
                // Both fields empty, no search
                System.Windows.Forms.MessageBox.Show("Date and Patient ID cannot be blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if(!(DateBox.SelectedDate == null))
            {
                // Date is empty, search by PatientID
                aptData = new AppointmentDataTable(patientIDBox.Text);
            }
            else if (!(String.IsNullOrEmpty(patientIDBox.Text)))
            {
                // Patient is empty, search by Date
                aptData = new AppointmentDataTable(DateBox.SelectedDate.Value.ToString("YYYYMMDD"));
            }
            else
            {
                // Neither Date nor Patient are empty, search by bot Date and PatientID
                aptData = new AppointmentDataTable();
            }

            AppointmentSearchResults asr = new AppointmentSearchResults();
            asr.Owner = this;
            asr.ShowDialog();
        }
    }
}
