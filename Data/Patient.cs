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
        public int patientNbr { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string race { get; set; }
        public string gender { get; set; }
        public string age { get; set; }
        public Int16 timeInHospital { get; set; }
        public Int16 numberOfProcedures { get; set; }
        public Int16 numberOfMedications { get; set; }
        public Int16 numberOfDiagnoses { get; set; }
        public string admissionSource { get; set; }
        public string admissionType { get; set; }
        public string dischargeDisposition { get; set; }

        public static List<Patient> GetAll()
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
                                patientNbr = rdr.GetInt32(2),
                                firstName = rdr.GetString(3),
                                lastName = rdr.GetString(4),
                                race = rdr.GetString(5),
                                gender = rdr.GetString(6),
                                age = rdr.GetString(7),
                                timeInHospital = rdr.GetInt16(8),
                                numberOfProcedures = rdr.GetInt16(9),
                                numberOfMedications = rdr.GetInt16(10),
                                numberOfDiagnoses = rdr.GetInt16(11),                                
                                admissionSource = rdr.GetString(12),
                                admissionType = rdr.GetString(13),
                                dischargeDisposition = rdr.GetString(14)
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
