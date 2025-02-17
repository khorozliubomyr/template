using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Phoenix2.APITests.Credentials;

namespace Phoenix2.APITests.DTO.AuthorizationModels
{
    public class ClientAdOptions
    {
        public ClientAdOptions()
        {
            this.Scope = Credentials.Scope;
            this.ClientId = Credentials.ClientId;
            this.ClientSecret = Credentials.ClientSecret;
        }
        public string Scope { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
