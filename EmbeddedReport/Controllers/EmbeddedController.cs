using EmbeddedReport.Contracts;
using EmbeddedReport.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Api.Models;
using Microsoft.Rest;
using System;
using System.Threading.Tasks;

namespace EmbeddedReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmbeddedController : Controller
    {
        private readonly IEmbeddedService _embeddedService;

        public EmbeddedController(IEmbeddedService embeddedService)
        {
            this._embeddedService = embeddedService;
        }

        [HttpGet("GetEmbedData")]
        public async Task<PowerBIModel> GetEmbedData([FromServices] AzureModel azureSettings)
        {
            var accessToken = await _embeddedService.GetPowerBiAccessToken(azureSettings);
            var tokenCredentials = new TokenCredentials(accessToken, "Bearer");
            var requestAccessLevel = new GenerateTokenRequest(accessLevel: "view");

            using var client = new PowerBIClient(new Uri(azureSettings.ApiUrl), tokenCredentials);

            var report = await client.Reports.GetReportInGroupAsync(azureSettings.GroupId, azureSettings.ReportId);
            var tokenResponse = await client.Reports.GenerateTokenAsync(azureSettings.GroupId, azureSettings.ReportId, requestAccessLevel);

            var result = new PowerBIModel(tokenResponse, report.EmbedUrl);

            return result;
        }
    }
}
