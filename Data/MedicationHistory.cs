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
    public class MedicationHistory
    {
        public int orderMedID { get; set; } 
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
        public int ledger_transaction_id { get; set; }
        public int ledger_sequence_number { get; set; }
        public int ledger_operation_type { get; set; }
        public string ledger_operation_type_desc { get; set; }
        public string commit_time { get; set; }
        public string principal_name { get; set; }


        public static List<MedicationHistory> GetAll()
        {
            List<MedicationHistory> medicationsHistory = new List<MedicationHistory>();
            SqlCommand cmd = new SqlCommand();
            try
            {
                using (SqlConnection connection = new SqlConnection(Configuration.connectionString))
                {
                    connection.Open();

                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Configuration.commandTimeout;
                    cmd.CommandText = Configuration.spGetAllMedicationsHistory;

                    
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            MedicationHistory medicationHistory = new MedicationHistory
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
                                ledger_transaction_id = int.Parse(rdr["ledger_transaction_id"].ToString()),
                                ledger_sequence_number = int.Parse(rdr["ledger_sequence_number"].ToString()),
                                ledger_operation_type = int.Parse(rdr["ledger_operation_type"].ToString()),
                                ledger_operation_type_desc = rdr["ledger_operation_type_desc"].ToString(),
                                commit_time = rdr["commit_time"].ToString(),
                                principal_name = rdr["principal_name"].ToString(),
                            };

                            medicationsHistory.Add(medicationHistory);
                        }
                    }
                }
                return medicationsHistory;
            }
            catch (SqlException e) { throw e; }
            finally { }
        }

    }
}
