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
        public int ModelIndex { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public string ModelFile { get; set; }
        public string ScoreFile { get; set; }
        public string ImagePath { get; set; }
        public bool isSelected { get; set; }


        public static List<Model> GetAll()
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
                                Id = int.Parse(rdr["Id"].ToString()),
                                ModelIndex = int.Parse(rdr["ModelIndex"].ToString()),
                                Name = rdr["Name"].ToString(),
                                Description = rdr["Description"].ToString(),
                                Tags = rdr["Tags"].ToString(),
                                ModelFile = rdr["ModelFile"].ToString(),
                                ScoreFile = rdr["ScoreFile"].ToString(),
                                ImagePath = rdr["ImagePath"].ToString(),
                                isSelected = false
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
