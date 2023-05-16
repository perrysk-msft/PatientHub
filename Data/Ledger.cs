using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;


namespace PatientHubData
{
    public class Ledger
    {
        public int orderMedID { get; set; } //TODO: Tie back to models...

        public static string Verify()
        {
            string result;
            SqlCommand cmd = new SqlCommand();
            try
            {
                using (SqlConnection connection = new SqlConnection(Configuration.connectionString))
                {
                    connection.Open();

                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Configuration.commandTimeout;
                    cmd.CommandText = Configuration.spVerifyLedger;

                    result = cmd.ExecuteScalar().ToString();
                    if (result == "0")
                    {
                        result = "Ledger verification succeeded.";
                    }

                }
                return result;
            }
            catch (SqlException e) { throw e; }
            finally { }
        }

    }
}
