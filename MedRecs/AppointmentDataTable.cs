using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MedRecs
{
    class AppointmentDataTable
    {
        private DataTable aptDT;
        private string ConnectionString = ProjectVariables.ConnectionString;

        public AppointmentDataTable()
        { 
            aptDT = new DataTable();
         
            SqlConnection conn = new SqlConnection(ConnectionString);
            string queryString = "SELECT PATIENTS.lname, PATIENTS.fname, PATIENTS.phone_number, APPOINTMENT.appid, APPOINTMENT.date, APPOINTMENT.time, HEALTHCARE_PERSONNEL.lname, HEALTHCARE_PERSONNEL.fname FROM((((PATIENTS INNER JOIN HAS ON PATIENTS.pid = HAS.pid) INNER JOIN APPOINTMENT ON HAS.appid = APPOINTMENT.appid) INNER JOIN ATTENDS ON APPOINTMENT.appid = ATTENDS.appid) INNER JOIN HEALTHCARE_PERSONNEL ON ATTENDS.empid = HEALTHCARE_PERSONNEL.empid) WHERE APPOINTMENT.date = convert(date, GETUTCDATE()) ORDER BY APPOINTMENT.date;";
            // SqlCommand cmd = new SqlCommand("SELECT * from APPOINTMENT WHERE date = convert(date, GETUTCDATE()) ORDER BY date ASC;", conn);
            SqlCommand cmd = new SqlCommand(queryString, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(aptDT);
        }

        public AppointmentDataTable(string day)
        {
            // day must be in 'YYYYMMDD' format

            aptDT = new DataTable();

            SqlConnection conn = new SqlConnection(ConnectionString);
            string queryString = "SELECT PATIENTS.lname, PATIENTS.fname, PATIENTS.phone_number, APPOINTMENT.appid, APPOINTMENT.date, APPOINTMENT.time, HEALTHCARE_PERSONNEL.lname, HEALTHCARE_PERSONNEL.fname FROM((((PATIENTS INNER JOIN HAS ON PATIENTS.pid = HAS.pid) INNER JOIN APPOINTMENT ON HAS.appid = APPOINTMENT.appid) INNER JOIN ATTENDS ON APPOINTMENT.appid = ATTENDS.appid) INNER JOIN HEALTHCARE_PERSONNEL ON ATTENDS.empid = HEALTHCARE_PERSONNEL.empid) WHERE APPOINTMENT.date = \'" + day + "\' ORDER BY APPOINTMENT.date;";
            // SqlCommand cmd = new SqlCommand("SELECT * from APPOINTMENT WHERE date = \'" + day + "\' ORDER BY date ASC;", conn);
            SqlCommand cmd = new SqlCommand(queryString, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(aptDT);
        }

        public AppointmentDataTable(int pid)
        {
            aptDT = new DataTable();

            SqlConnection conn = new SqlConnection(ConnectionString);
            string queryString = "SELECT PATIENTS.lname, PATIENTS.fname, PATIENTS.phone_number, APPOINTMENT.appid, APPOINTMENT.date, APPOINTMENT.time, HEALTHCARE_PERSONNEL.lname, HEALTHCARE_PERSONNEL.fname FROM((((PATIENTS INNER JOIN HAS ON PATIENTS.pid = HAS.pid) INNER JOIN APPOINTMENT ON HAS.appid = APPOINTMENT.appid) INNER JOIN ATTENDS ON APPOINTMENT.appid = ATTENDS.appid) INNER JOIN HEALTHCARE_PERSONNEL ON ATTENDS.empid = HEALTHCARE_PERSONNEL.empid) WHERE PATIENTS.pid = " + pid.ToString() + " ORDER BY APPOINTMENT.date;";
            // SqlCommand cmd = new SqlCommand("SELECT * from APPOINTMENT WHERE pid = " + pid.ToString() + "ORDER BY date ASC;", conn);
            SqlCommand cmd = new SqlCommand(queryString, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(aptDT);
        }

        public AppointmentDataTable(string date, int pid)
        {
            // start must be in 'YYYYMMDD' format
            aptDT = new DataTable();

            SqlConnection conn = new SqlConnection(ConnectionString);
            string queryString = "SELECT PATIENTS.lname, PATIENTS.fname, PATIENTS.phone_number, APPOINTMENT.appid, APPOINTMENT.date, APPOINTMENT.time, HEALTHCARE_PERSONNEL.lname, HEALTHCARE_PERSONNEL.fname FROM((((PATIENTS INNER JOIN HAS ON PATIENTS.pid = HAS.pid) INNER JOIN APPOINTMENT ON HAS.appid = APPOINTMENT.appid) INNER JOIN ATTENDS ON APPOINTMENT.appid = ATTENDS.appid) INNER JOIN HEALTHCARE_PERSONNEL ON ATTENDS.empid = HEALTHCARE_PERSONNEL.empid) WHERE APPOINTMENT.date = \'" + date + "\' AND PATIENTS.pid = " + pid.ToString() + " ORDER BY APPOINTMENT.date;";
            // SqlCommand cmd = new SqlCommand("SELECT * from APPOINTMENT WHERE date = \'" + date + "\'and pid = " + pid.ToString() + " ORDER BY date ASC;", conn);
            SqlCommand cmd = new SqlCommand(queryString, conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(aptDT);
        }

        public DataTable getAptDT()
        {
            return this.aptDT;
        }
    }
}
