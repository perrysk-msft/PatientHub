using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace PatientHub
{
    public class DbConnection
    {
        private static string connectionString = ConfigurationManager.AppSettings["Db"];
        private static string spGetPatients = ConfigurationManager.AppSettings["spGetPatients"];
        private static int commandTimeout = int.Parse(ConfigurationManager.AppSettings["commandTimeout"]);

        public static async Task GetPatients()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = commandTimeout;
                    command.CommandText = spGetPatients;

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
