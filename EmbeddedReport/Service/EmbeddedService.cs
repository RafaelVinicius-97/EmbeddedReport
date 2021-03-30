using EmbeddedReport.Contracts;
using EmbeddedReport.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmbeddedReport.Service
{
    public class EmbeddedService : IEmbeddedService
    {
        public async Task<string> GetPowerBiAccessToken(AzureModel azureSettings)
        {
            using var client = new HttpClient();
            var form = new Dictionary<string, string>
            {
                ["authorityUrl"] = azureSettings.AuthorityUrl,
                ["client_id"] = azureSettings.ClientId.ToString(),
                ["client_secret"] = azureSettings.ClientSecret,
                ["grant_type"] = azureSettings.GrantType,
                ["password"] = azureSettings.Password,
                ["resource"] = azureSettings.Resource,
                ["scope"] = azureSettings.Scope,
                ["username"] = azureSettings.Username
            };

            client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded");

            using var formContent = new FormUrlEncodedContent(form);
            using var response = await client.PostAsync(azureSettings.AuthorityUrl, formContent);
            
            var body = await response.Content.ReadAsStringAsync();
            var jsonBody = JObject.Parse(body);
            var errorToken = jsonBody.SelectToken("error");

            if (errorToken != null)
                throw new Exception(errorToken.Value<string>());

            return jsonBody.SelectToken("access_token").Value<string>();
        }
    }
}
