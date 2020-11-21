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
        // Attributes unused
        private AppointmentDataTable aptData;
        private int pid;
        private string date;

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
            if ((!DateBox.SelectedDate.HasValue) && (String.IsNullOrEmpty(patientIDBox.Text)))
            {
                // Both fields empty, no search
                System.Windows.Forms.MessageBox.Show("Date and Patient ID cannot be blank.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else if (!DateBox.SelectedDate.HasValue)
            {
                // Date is empty, search by PatientID

                AppointmentSearchResults asr = new AppointmentSearchResults(int.Parse(patientIDBox.Text));
                asr.Owner = this;
                asr.ShowDialog();

            }
            else if ((String.IsNullOrEmpty(patientIDBox.Text)))
            {
                // Patient is empty, search by Date

                AppointmentSearchResults asr = new AppointmentSearchResults(DateBox.SelectedDate.Value.ToShortDateString());
                asr.Owner = this;
                asr.ShowDialog();
            }
            else
            {
                // Neither Date nor Patient are empty, search by bot Date and PatientID

                AppointmentSearchResults asr = new AppointmentSearchResults(DateBox.SelectedDate.Value.ToShortDateString(), int.Parse(patientIDBox.Text));
                asr.Owner = this;
                asr.ShowDialog();
            }
            return;
        }
    }
}
