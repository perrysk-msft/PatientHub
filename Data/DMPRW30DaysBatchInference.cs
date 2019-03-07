using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace PatientHubData
{
    public class DMPRW30Days_BatchInference
    {
        private static string ClientId = "e71e8369-81ed-4373-8d5f-973c6bc0eb59";
        //private static string Tenant = "common";

        public static PublicClientApplication PublicClientApp = new PublicClientApplication(ClientId);

        public static string GetScore()
        {
            try { 
            string[] _scopes = new string[] { "user.read" };

            //var accounts = await PublicClientApp.GetAccountsAsync();
            //var authResult = await PublicClientApp.AcquireTokenSilentAsync(_scopes, accounts.FirstOrDefault());
            //var authResult = await PublicClientApp.AcquireTokenAsync(_scopes);
            

            HttpClient client = new HttpClient();
            
            // Set the scoring URI and authentication key
            string scoringUri = Configuration.DMPRW30Days_batchInference_URL;
            string AADToken = Configuration.DMPRW30Days_batchInference_AADToken;
            //string Account = authResult.Account.Username; //Configuration.DMPRW30Days_batchInference_AADToken;


            string payload = @"{'ExperimentName': 'batch_scoring','ParameterAssignments': { 'param_batch_size': 50}}";

            // Create the HTTP client
            //HttpClient client = new HttpClient();
            
            // Set the auth header. Only needed if the web service requires authentication.

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AADToken);
            
            // Make the request
            
                var request = new HttpRequestMessage(HttpMethod.Post, new Uri(scoringUri));
                request.Content = new StringContent(payload);

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
