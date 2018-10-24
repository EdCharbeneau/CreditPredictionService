using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace CreditApproval.Services
{
    public class CreditPredictionService
    {
        public async Task<ApprovalStatus> PreApproveCredit(CreditProfileData creditProfileData, string apiKey)
        {
            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/416fba9fa4494b7980289be1c02c587c/services/605aa908bf874ee1bcbd5a1286f7760b/execute?api-version=2.0&format=swagger");

                HttpResponseMessage response = await client
                    .PostAsync("", new StringContent(JsonConvert.SerializeObject(creditProfileData), Encoding.UTF8, "application/json"))
                    .ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    CreditServiceResponse csr = JsonConvert.DeserializeObject<CreditServiceResponse>(result);
                    return csr.GetStatus(); 
                }
                else
                {
                    throw new HttpRequestException(string.Format("The request failed with status code: {0}", response.StatusCode));
                }
            }
        }
    }
}