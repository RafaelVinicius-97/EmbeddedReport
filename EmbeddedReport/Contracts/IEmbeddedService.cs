using EmbeddedReport.Models;
using System.Threading.Tasks;

namespace EmbeddedReport.Contracts
{
    public interface IEmbeddedService
    {
        public Task<string> GetPowerBiAccessToken(AzureModel azureSettings);
    }
}
