using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace LoginPageTest
{
    class AppointmentDataTable
    {
        private DataTable aptDT;

        public AppointmentDataTable()
        {
            DataSet aptDataSet = new DataSet("AppointmentTimes");

        }

        public AppointmentDataTable(/*Date*/)
        {

        }

        public AppointmentDataTable(/*StartDay, EndDay*/)
        {

        }
    }
}
