using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedRecs
{
    static class ProjectVariables
    {
         public static string ConnectionString = Properties.Settings.Default.MedicalDatabaseConnection;
    }
}
