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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LoginPageTest;

namespace MedRecs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            //define variables
            int asciiVal;
            string strPassword, strUsername;

            //obtain username from textbox
            strUsername = nameTextBox.Text.ToString();
            //obtain password from passwordtextbox
            strPassword = passwordTextBox.Password;

            //check to see if username or password are empty, request them to be filled
            if (String.IsNullOrEmpty(strUsername) || String.IsNullOrEmpty(strPassword))
            {
                MessageBox.Show("Please fill in all slots");
                return;
            }

            //convert string password to charArray
            char[] arrPassword = strPassword.ToCharArray();

            //convert the first password character to an ascii value
            asciiVal = Convert.ToInt32(arrPassword[0]);

            //check to see if the first letter of the password is amongst the alphabet (capitalized and non-capitalized)
            if (!((asciiVal <= 90 && asciiVal >= 65) || (asciiVal <= 122 && asciiVal >= 97)))
            {
                MessageBox.Show("The password must start with a letter");
                return;
            }

            //obtain password length
            int passLen = strPassword.Length;

            //loop through password array
            for (int loopcounter = 0; loopcounter < passLen; loopcounter++)
            {
                //check if password contains illegal characters
                if (!Char.IsLetterOrDigit(arrPassword[loopcounter]))
                {
                    MessageBox.Show("The password can not contain characters other than letters and numbers");
                    return;
                }
            }

            //check to see if password is at least 6 characters or greater
            if (passLen < 6)
            {
                MessageBox.Show("A valid password needs to have at least six characters with both letters and numbers.");
                return;
            }

            //password passed all checks, is a valid password
            var userData = new HEALTHCARE_PERSONNEL();
            if (userData.Login(strUsername, strPassword) == true)
                MessageBox.Show("You are logged in as User #" + userData.empid);
            else
                MessageBox.Show("You could not be verified. Please try again.");
        }


        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            //closes the process
            this.Close();
        }
    }
}