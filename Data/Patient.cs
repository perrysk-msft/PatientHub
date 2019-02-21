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
                                
                                DMPRW30Days_Score = decimal.Parse(rdr["DMPatientReadmittedWithin30Days_Score"].ToString()),
                                Id = int.Parse(rdr["Id"].ToString()),
                                patientNbr = int.Parse(rdr["patient_nbr"].ToString()),
                                firstName = rdr["FirstName"].ToString(),
                                lastName = rdr["LastName"].ToString(),
                                race = rdr["race"].ToString(),
                                gender = rdr["gender"].ToString(),
                                age = rdr["age"].ToString(),
                                timeInHospital = Int16.Parse(rdr["time_in_hospital"].ToString()),
                                numberOfProcedures = Int16.Parse(rdr["num_lab_procedures"].ToString()),
                                numberOfMedications = Int16.Parse(rdr["num_medications"].ToString()),
                                numberOfDiagnoses = Int16.Parse(rdr["number_diagnoses"].ToString()),
                                admissionSource = rdr["admission_source"].ToString(),
                                admissionType = rdr["admission_type"].ToString(),
                                dischargeDisposition = rdr["discharge_disposition"].ToString()
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
