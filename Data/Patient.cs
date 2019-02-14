using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace PatientHubData
{
    public class Patient
    {
        public decimal DMPRW30Days_Score { get; set; }
        public long Id { get; set; }
        //public int patientNbr { get; set; }
        //public string firstName { get; set; }
        //public string lastName { get; set; }
        //public string race { get; set; }
        //public string gender { get; set; }
        //public string age { get; set; }
        //public string weight { get; set; }

        public List<Patient> GetAll()
        {
            List<Patient> patients = new List<Patient>();
            SqlCommand cmd = new SqlCommand();
            try
            {
                using (SqlConnection connection = new SqlConnection(Configuration.connectionString))
                {
                    connection.Open();

                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Configuration.commandTimeout;
                    cmd.CommandText = Configuration.spGetPatients;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Patient patient = new Patient
                            {
                                DMPRW30Days_Score = rdr.GetDecimal(0),
                                Id = rdr.GetInt64(1),

                                //TODO: Read all columns
                                //patientNbr = rdr.GetInt32(2)
                            };

                            patients.Add(patient);
                        }
                    }
                }
                return patients;
            }
            catch (SqlException e) { throw e; }
            finally { }
        }
    }
}
