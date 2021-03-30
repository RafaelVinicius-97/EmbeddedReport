using System;

namespace EmbeddedReport.Models
{
    public class AzureModel
    {
        public Guid ClientId { get; set; }

        public string ClientSecret { get; set; }

        public string GrantType { get; set; }

        public string Resource { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string AuthorityUrl { get; set; }

        public Guid GroupId { get; set; }

        public Guid ReportId { get; set; }

        public string ApiUrl { get; set; }

        public string Scope { get; set; }
    }
}
