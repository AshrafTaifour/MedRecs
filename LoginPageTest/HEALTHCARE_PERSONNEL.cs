using System;
using System.Security.Cryptography.X509Certificates;

namespace LoginPageTest
{
    public class HEALTHCARE_PERSONNEL
    {
        public int empid { set; get; }

        public string email { set; get; }

        public string Password { set; get; }

        public Boolean Login(string ElectronicMail, string password)
        {
            var dbUser = new HCUserInfo();
            empid = dbUser.Login(ElectronicMail, password);
            if (empid > 0)
            {
                this.email = ElectronicMail;
                Password = password;
                return true;
            }
            else
                return false;
        }

    }
}