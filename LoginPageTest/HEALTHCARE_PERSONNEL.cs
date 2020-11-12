using System;
using System.Security.Cryptography.X509Certificates;

namespace LoginPageTest
{
    public class HEALTHCARE_PERSONNEL
    {
        public int empid { set; get; }

        public string fname { set; get; }

        public string Password { set; get; }

        public Boolean Login(string firstName, string password)
        {
            var dbUser = new HCUserInfo();
            empid = dbUser.Login(firstName, password);
            if (empid > 0)
            {
                fname = firstName;
                Password = password;
                return true;
            }
            else
                return false;
        }

    }
}