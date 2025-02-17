using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.AuthorizationModels
{
    public class AzureAdOptions 
    {
        public AzureAdOptions()
        {
            TenantId = Credentials.TenantId;
            Audiences = Credentials.Audiences;
        }
        public string TenantId { get; set; }
        public string Audiences { get; set; }
    }

}
