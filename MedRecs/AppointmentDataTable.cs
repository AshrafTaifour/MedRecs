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
        private string ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\ssbri\source\repos\AshrafTaifour\MedRecs\MedRecs\MedicalDatabase.mdf";

        public AppointmentDataTable()
        { 
            aptDT = new DataTable();
         
            SqlConnection conn = new SqlConnection(ConnectionString + ";Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * from APPOINTMENT WHERE date = convert(date, GETUTCDATE()) ORDER BY date ASC;", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(aptDT);
        }

        public AppointmentDataTable(string day)
        {
            // day must be in 'YYYYMMDD' format

            aptDT = new DataTable();

            SqlConnection conn = new SqlConnection(ConnectionString + ";Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * from APPOINTMENT WHERE date = \'" + day + "\' ORDER BY date ASC;", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(aptDT);
        }

        public AppointmentDataTable(string start, string finish)
        {
            // start must be in 'YYYYMMDD' format
            // finish must be in 'YYYYMMDD' format

            aptDT = new DataTable();

            SqlConnection conn = new SqlConnection(ConnectionString + ";Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * from APPOINTMENT WHERE date >= \'" + start + "\'and date <= \'" + finish + "\' ORDER BY date ASC;", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(aptDT);
        }
    }
}
