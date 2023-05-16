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
        public static string spGetMedications = ConfigurationManager.AppSettings["spGetMedications"];
        public static string spUpdateMedications = ConfigurationManager.AppSettings["spUpdateMedications"];

        public static string spGetAllMedicationsHistory = ConfigurationManager.AppSettings["spGetAllMedicationsHistory"];
        public static string spVerifyLedger = ConfigurationManager.AppSettings["spVerifyLedger"];

        public static string spGetSinglePatient = ConfigurationManager.AppSettings["spGetSinglePatient"];        
        public static string spGetModels = ConfigurationManager.AppSettings["spGetModels"];        
        public static string spGetDMPRW30Days_LocalExplanation = ConfigurationManager.AppSettings["spGetDMPRW30Days_LocalExplanation"];
        public static string spGet_DMPRW30Days_SingleInference = ConfigurationManager.AppSettings["spGet_DMPRW30Days_SingleInference"];
        public static string spInsert_Model = ConfigurationManager.AppSettings["spInsert_Model"];
        public static string spUpdate_Model = ConfigurationManager.AppSettings["spUpdate_Model"];

        public static int commandTimeout = int.Parse(ConfigurationManager.AppSettings["commandTimeout"]);
        public static string pyhtonPath = ConfigurationManager.AppSettings["pythonPath"];
        public static long demoPatientId = long.Parse(ConfigurationManager.AppSettings["demoPatientId"]);

        public static string SubscriptionId = ConfigurationManager.AppSettings["SubscriptionId"];
        public static string ResourceGroup = ConfigurationManager.AppSettings["ResourceGroup"];
        public static string WorkspaceName = ConfigurationManager.AppSettings["WorkspaceName"];
        public static string Region = ConfigurationManager.AppSettings["Region"];
        public static string AKSClusterName = ConfigurationManager.AppSettings["AKSClusterName"];

    }

}
