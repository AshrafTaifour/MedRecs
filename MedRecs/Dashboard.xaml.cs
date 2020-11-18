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
using LoginPageTest;

namespace MedRecs
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        private HEALTHCARE_PERSONNEL user;
        public Dashboard(HEALTHCARE_PERSONNEL user)
        {
            InitializeComponent();
            this.user = user;
            username.Content = this.user.email;
            date.Content = DateTime.Today;
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
