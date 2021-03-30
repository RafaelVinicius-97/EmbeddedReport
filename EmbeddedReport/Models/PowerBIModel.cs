using Microsoft.PowerBI.Api.Models;

namespace EmbeddedReport.Models
{
    public class PowerBIModel
    {
        public PowerBIModel(EmbedToken embedToken, string embedUrl)
        {
            EmbedToken = embedToken;
            EmbedUrl = embedUrl;
        }

        public EmbedToken EmbedToken { get; set; }

        public string EmbedUrl { get; set; }
    }
}
