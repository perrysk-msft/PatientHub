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
    public class Medication
    {
        public int orderMedID { get; set; } //TODO: Tie back to models...
        public long patientId { get; set; }
        public string startDate { get; set; }
        public string stopDate { get; set; }
        public string patientPayer { get; set; }
        public string encounter { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string dispense { get; set; }
        public string dosage { get; set; }
        public string quantity { get; set; }
        public int refills { get; set; }
        public string reasonCode { get; set; }
        public string reasonDescription { get; set; }


        public static List<Medication> GetAll(long patientId)
        {
            List<Medication> medications = new List<Medication>();
            SqlCommand cmd = new SqlCommand();
            try
            {
                using (SqlConnection connection = new SqlConnection(Configuration.connectionString))
                {
                    connection.Open();

                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Configuration.commandTimeout;
                    cmd.CommandText = Configuration.spGetMedications;

                    cmd.Parameters.Add(new SqlParameter("PatientId", patientId));

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Medication medication = new Medication
                            {
                                orderMedID = int.Parse(rdr["orderMedID"].ToString()),
                                patientId = int.Parse(rdr["patientId"].ToString()),
                                startDate = rdr["startDate"].ToString(),
                                stopDate = rdr["stopDate"].ToString(),
                                patientPayer = rdr["patient_Payer"].ToString(),
                                encounter = rdr["encounter"].ToString(),
                                code = rdr["code"].ToString(),
                                description = rdr["description"].ToString(),
                                dispense = rdr["dispense"].ToString(),
                                dosage = rdr["dosage"].ToString(),
                                quantity = rdr["quantity"].ToString(),
                                refills = Int16.Parse(rdr["refills"].ToString()),
                                reasonCode = rdr["reasonCode"].ToString(),
                                reasonDescription = rdr["reasonDescription"].ToString(),
                            };

                            medications.Add(medication);
                        }
                    }
                }
                return medications;
            }
            catch (SqlException e) { throw e; }
            finally { }
        }

        public static bool Update(int orderMedId, int refills)
        {
            bool success = false;
            List<Medication> medications = new List<Medication>();
            SqlCommand cmd = new SqlCommand();
            try
            {
                using (SqlConnection connection = new SqlConnection(Configuration.connectionString))
                {
                    connection.Open();

                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Configuration.commandTimeout;
                    cmd.CommandText = Configuration.spUpdateMedications;

                    cmd.Parameters.Add(new SqlParameter("OrderMedID", orderMedId));
                    cmd.Parameters.Add(new SqlParameter("Refills", refills));

                    cmd.ExecuteScalar();

                    success = true;
                }
                return success;
            }
            catch (SqlException e) { throw e; }
            finally { }
        }

    }
}
