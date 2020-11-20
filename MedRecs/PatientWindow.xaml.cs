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
    /// Interaction logic for PatientWindow.xaml
    /// </summary>
    public partial class PatientWindow : Window
    {
        public PatientWindow()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            PatientResults pm = new PatientResults();
            pm.Owner = this;
            pm.ShowDialog();
        }

        private void CreatePatient_Click(object sender, RoutedEventArgs e)
        {
            CreateNewPatient cnp = new CreateNewPatient();
            cnp.Owner = this;
            cnp.ShowDialog();
        }
    }
}

