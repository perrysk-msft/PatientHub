using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using PatientHubData;

namespace PatientHubData
{
    public class Model
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Model> GetAll()
        {
            List<Model> models = new List<Model>();
            SqlCommand cmd = new SqlCommand();
            try
            {
                using (SqlConnection connection = new SqlConnection(Configuration.connectionString))
                {
                    connection.Open();

                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Configuration.commandTimeout;
                    cmd.CommandText = Configuration.spGetModels;

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Model model = new Model
                            {
                                Id = rdr.GetInt32(0),
                                Name = rdr.GetString(1)

                                //TODO: Read all columns
                            };

                            models.Add(model);
                        }
                    }
                }
                return models;
            }
            catch (SqlException e) { throw e; }
            finally { }
        }
    }
}
