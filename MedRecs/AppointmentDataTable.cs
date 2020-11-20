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
            DataSet aptDataSet = new DataSet("AppointmentTimes");

            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Mohamad\Source\Repos\AshrafTaifour\MedRecs\MedRecs\MedicalDatabase.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * from APPOINTMENT WHERE date = convert(date, GETUTCDATE()) ORDER BY date ASC;", conn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            PatientSearchDataGrid.ItemsSource = dt.DefaultView;
        }

        public AppointmentDataTable(/*Date*/)
        {

        }

        public AppointmentDataTable(/*StartDay, EndDay*/)
        {

        }
    }
}
