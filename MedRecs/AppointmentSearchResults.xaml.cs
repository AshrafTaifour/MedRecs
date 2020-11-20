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
    /// Interaction logic for AppointmentSearchResults.xaml
    /// </summary>
    public partial class AppointmentSearchResults : Window
    {
        private AppointmentDataTable aptDT;
        
        public AppointmentSearchResults(int pid)
        {
            aptDT = new AppointmentDataTable(pid);
            InitializeComponent();
            FillDataGrid();
        }

        public AppointmentSearchResults(string date)
        {
            aptDT = new AppointmentDataTable(date);
            InitializeComponent();
            FillDataGrid();
        }

        public AppointmentSearchResults(string date, int pid)
        {
            aptDT = new AppointmentDataTable(date, pid);
            InitializeComponent();
            FillDataGrid();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void FillDataGrid()
        {
            ResultsDataGrid.ItemsSource = aptDT.getAptDT().DefaultView;
        }
    }
}
