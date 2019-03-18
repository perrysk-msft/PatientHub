using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

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
        public decimal score { get; set; }
        public string sqlColumnName { get; set; }
        public string paramName { get; set; }
        public string paramValue { get; set; }
        public string distinctValues { get; set; }
    }

    public class DMPRW30Days_SingleInference
    {
        public static List<ModelParams> GetParameters(Int64 patientId, bool isPositive)
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
                    cmd.Parameters.Add(new SqlParameter("IsPositive", isPositive));

                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            ModelParams p = new ModelParams
                            {
                                score = rdr.GetDecimal(0),
                                sqlColumnName = rdr.GetString(1),
                                paramName = rdr.GetString(2),
                                paramValue = rdr.GetString(3),
                                distinctValues = rdr.GetString(4)
                            };

                            modelParams.Add(p);
                        }
                    }
                }
                return modelParams;
            }
            catch (SqlException e) { throw e;  }
            finally { }
        }

        public static string [,] GetSingleInference(Int64 patientId, string[] parameters = null)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                // Parse parameters array
                using (SqlConnection connection = new SqlConnection(Configuration.connectionString))
                {
                    connection.Open();

                    cmd.Connection = connection;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandTimeout = Configuration.commandTimeout;
                    cmd.CommandText = Configuration.spGet_DMPRW30Days_SingleInference;
                    cmd.Parameters.Add(new SqlParameter("PatientId", patientId));

                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            if(!cmd.Parameters.Contains(param.Split(',')[0]))
                                cmd.Parameters.Add(new SqlParameter(param.Split(',')[0], param.Split(',')[1]));
                        }
                    }
                    string[] ar = ((string)cmd.ExecuteScalar()).Split(',').ToArray();
                    string[,] payloadData = new string[1, ar.Length];

                    for (int i = 0; i < ar.Length; i++)
                    {
                        payloadData[0, i] = ar[i];
                    }

                    return payloadData;
                }
            }
            catch (SqlException e) { throw e; }
            finally { }
        }
        public static string GetScore( string[,] payloadData)
        {
            // Set the scoring URI and authentication key
            string scoringUri = Configuration.DMPRW30Days_singleInference_URL;
            string authKey = Configuration.DMPRW30Days_singleInference_AuthKey;

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
