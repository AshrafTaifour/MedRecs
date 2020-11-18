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
    /// Interaction logic for PatientResults.xaml
    /// </summary>
    public partial class PatientResults : Window
    {
        public PatientResults()
        {
            InitializeComponent();
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            ModifyPatient mp = new ModifyPatient();
            mp.Owner = this;
            mp.ShowDialog();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            //Will delete the selected patients record from the patients table
            //Display a message comfirming deletion.
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
