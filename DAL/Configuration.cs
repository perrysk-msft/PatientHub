using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace PatientHubData
{
    public static class Configuration
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
        public static string spGetPatients = ConfigurationManager.AppSettings["spGetPatients"];
        public static string spGetModels = ConfigurationManager.AppSettings["spGetModels"];        
        public static int commandTimeout = int.Parse(ConfigurationManager.AppSettings["commandTimeout"]);
    }
}
