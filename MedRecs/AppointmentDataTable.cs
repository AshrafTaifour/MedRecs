using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace LoginPageTest
{
    class AppointmentDataTable
    {
        private DataTable aptDT;

        public AppointmentDataTable()
        { 
            aptDT = new DataTable();

            string ConnectionString = @"Data Source=|DataDirectory|\MedicalDatabase.mdf";
            string dir = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(dir));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            SqlConnection conn = new SqlConnection(ConnectionString + "Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * from APPOINTMENT WHERE date = convert(date, GETUTCDATE()) ORDER BY date ASC;", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(aptDT);
        }

        public AppointmentDataTable(string day)
        {
            aptDT = new DataTable();

            string ConnectionString = @"Data Source=|DataDirectory|\MedicalDatabase.mdf";
            string dir = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(dir));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            SqlConnection conn = new SqlConnection(ConnectionString + "Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * from APPOINTMENT WHERE date = convert(date, GETUTCDATE()) ORDER BY date ASC;", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(aptDT);
        }

        public AppointmentDataTable(string start, string finish)
        {
            aptDT = new DataTable();

            string ConnectionString = @"Data Source=|DataDirectory|\MedicalDatabase.mdf";
            string dir = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(dir));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);

            SqlConnection conn = new SqlConnection(ConnectionString + "Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * from APPOINTMENT WHERE date = convert(date, GETUTCDATE()) ORDER BY date ASC;", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(aptDT);
        }
    }
}
