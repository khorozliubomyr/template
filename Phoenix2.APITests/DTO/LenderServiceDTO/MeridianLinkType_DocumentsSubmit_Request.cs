using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.LenderServiceDTO
{
    class MeridianLinkType_DocumentsSubmit_Request
    { 
        [JsonProperty("dealId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DealId { get; set; }
        [JsonProperty("documentIds", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<int> DocumentIds { get; set; }
    }
}
