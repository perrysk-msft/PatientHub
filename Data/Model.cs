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
        public string MainScriptFolder { get; set; }
        public string ScoreFile { get; set; }
        public string YamlFile { get; set; }
        public string RealTimeAPIEndpoint { get; set; }
        public string BatchAPIEndpoint { get; set; }
        public string ImagePath { get; set; }
        public bool isSelected { get; set; }
        public bool isActive { get; set; }



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
                                MainScriptFolder = rdr["MainScriptFolder"].ToString(),
                                ModelFile = rdr["ModelFile"].ToString(),
                                ScoreFile = rdr["ScoreFile"].ToString(),
                                YamlFile = rdr["YamlFile"].ToString(),
                                RealTimeAPIEndpoint = rdr["RealTimeAPIEndpoint"].ToString(),
                                BatchAPIEndpoint = rdr["BatchAPIEndpoint"].ToString(),
                                ImagePath = rdr["ImagePath"].ToString(),
                                isActive = bool.Parse(rdr["IsActive"].ToString()),
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

        public static bool Insert(string name, string description, string mainScriptFolder, string modelFile, string scoreFile, string yamlFile, string realTimeAPIEndpoint, string batchAPIEndpoint, bool isActive)
        {
            bool success = false;
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
                    cmd.CommandText = Configuration.spInsert_Model;
                    cmd.Parameters.Add(new SqlParameter("Name", name));
                    cmd.Parameters.Add(new SqlParameter("Description", description));
                    cmd.Parameters.Add(new SqlParameter("MainScriptFolder", mainScriptFolder));
                    cmd.Parameters.Add(new SqlParameter("ModelFile", modelFile));
                    cmd.Parameters.Add(new SqlParameter("ScoreFile", scoreFile));
                    cmd.Parameters.Add(new SqlParameter("YamlFile", yamlFile));
                    cmd.Parameters.Add(new SqlParameter("ImagePath", @"images\DiabetesRisk.png")); // TODO: REPLACE THIS...
                    cmd.Parameters.Add(new SqlParameter("RealTimeAPIEndpoint", realTimeAPIEndpoint));
                    cmd.Parameters.Add(new SqlParameter("BatchAPIEndpoint", batchAPIEndpoint));
                    cmd.Parameters.Add(new SqlParameter("IsActive", isActive));

                    cmd.ExecuteScalar();

                    success = true;
                }
                return success;
            }
            catch (SqlException e) { throw e; }
            finally { }
        }

        public static bool Update(int modelId, string name, string description, string mainScriptFolder, string modelFile, string scoreFile, string yamlFile)
        {
            bool success = false;
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
                    cmd.CommandText = Configuration.spUpdate_Model;
                    cmd.Parameters.Add(new SqlParameter("ModelId", modelId));
                    cmd.Parameters.Add(new SqlParameter("Name", name));
                    cmd.Parameters.Add(new SqlParameter("Description", description));
                    cmd.Parameters.Add(new SqlParameter("MainScriptFolder", mainScriptFolder));
                    cmd.Parameters.Add(new SqlParameter("ModelFile", modelFile));
                    cmd.Parameters.Add(new SqlParameter("ScoreFile", scoreFile));
                    cmd.Parameters.Add(new SqlParameter("YamlFile", yamlFile));
                    cmd.Parameters.Add(new SqlParameter("ImagePath", @"images\DiabetesRisk.png")); // TODO: REPLACE THIS...

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
