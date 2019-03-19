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
        public static string DMPRW30Days_singleInference_URL = ConfigurationManager.AppSettings["DMPRW30Days_singleInference_URL"];
        public static string DMPRW30Days_singleInference_AuthKey = ConfigurationManager.AppSettings["DMPRW30Days_singleInference_AuthKey"];
        public static string DMPRW30Days_batchInference_URL = ConfigurationManager.AppSettings["DMPRW30Days_batchInference_URL"];
        public static string DMPRW30Days_batchInference_AADToken = ConfigurationManager.AppSettings["DMPRW30Days_batchInference_AADToken"];

        public static string connectionString = ConfigurationManager.ConnectionStrings["Db"].ConnectionString;
        public static string spGetPatients = ConfigurationManager.AppSettings["spGetPatients"];
        public static string spGetSinglePatient = ConfigurationManager.AppSettings["spGetSinglePatient"];        
        public static string spGetModels = ConfigurationManager.AppSettings["spGetModels"];        
        public static string spGetDMPRW30Days_LocalExplanation = ConfigurationManager.AppSettings["spGetDMPRW30Days_LocalExplanation"];
        public static string spGet_DMPRW30Days_SingleInference = ConfigurationManager.AppSettings["spGet_DMPRW30Days_SingleInference"];
        public static int commandTimeout = int.Parse(ConfigurationManager.AppSettings["commandTimeout"]);
        public static string pyhtonPath = ConfigurationManager.AppSettings["pythonPath"];
        public static long demoPatientId = long.Parse(ConfigurationManager.AppSettings["demoPatientId"]);
    }
    
}
