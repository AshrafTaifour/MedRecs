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
    /// Interaction logic for AppointmentWindow.xaml
    /// </summary>
    public partial class AppointmentWindow : Window
    {
        public AppointmentWindow()
        {
            InitializeComponent();
        }

        private void CreateAppointment_Click(object sender, RoutedEventArgs e)
        {
            CreateAppointment addAppointment = new CreateAppointment();
            addAppointment.Owner = this;
            addAppointment.ShowDialog();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            SearchAppointment searchApp = new SearchAppointment();
            searchApp.Owner = this;
            searchApp.ShowDialog();
        }
    }
}
