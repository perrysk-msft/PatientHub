using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;

namespace PatientHubData
{
    // The data structure expected by the service
    internal class InputData
    {
        [JsonProperty("data")]
        // The service used by this example expects an array containing
        //   one or more arrays of doubles
        internal string[,] data;
    }

    public class ModelParams
    {
        public int isTopInfluencer { get; set; }
        public string paramName { get; set; }
        public string paramValue { get; set; }

    }

    public class SingleInference
    {

        public static List<ModelParams> GetParameters(Int64 patientId)
        {
            List<ModelParams> modelParams = new List<ModelParams>();
            SqlCommand cmd = new SqlCommand();
            try
            {
                using (SqlConnection connection = new SqlConnection(Configuration.connectionString))
                {
                    connection.Open();

                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Configuration.commandTimeout;
                    cmd.CommandText = Configuration.spGetDMPRW30Days_LocalExplanation; // TODO: Read Dynamically
                    cmd.Parameters.Add(new SqlParameter("PatientId", patientId));

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            ModelParams p = new ModelParams
                            {
                                isTopInfluencer = rdr.GetInt32(0),
                                paramName = rdr.GetString(1),
                                paramValue = rdr.GetString(2)
                            };

                            modelParams.Add(p);
                        }
                    }
                }
                return modelParams;
            }
            catch (SqlException e) { throw e; }
            finally { }
        }
        public static string GetScore( string[,] payloadData)
        {
            // Set the scoring URI and authentication key
            string scoringUri = Configuration.scoringURL;
            string authKey = Configuration.authKey;

            // Set the data to be sent to the service.
            // In this case, we are sending two sets of data to be scored.
            InputData payload = new InputData();
            payload.data = payloadData;

            // Create the HTTP client
            HttpClient client = new HttpClient();
            // Set the auth header. Only needed if the web service requires authentication.
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authKey);

            // Make the request
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Post, new Uri(scoringUri));
                request.Content = new StringContent(JsonConvert.SerializeObject(payload));
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = client.SendAsync(request).Result;
                // Display the response from the web service
                return response.Content.ReadAsStringAsync().Result;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }

}
