using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DocumentServiceDTO
{
    public class ESignatureType_Send_Request
    { 
        [JsonProperty("dealId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int DealId { get; set; }
        [JsonProperty("userId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int UserId { get; set; }
        [JsonProperty("isCustomDocuSign", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsCustomDocuSign { get; set; }
        [JsonProperty("documentGenerationType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentGenerationType { get; set; }
        [JsonProperty("shouldSendToCoBorrowerForCustomDocuSign", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool ShouldSendToCoBorrowerForCustomDocuSign { get; set; }
    }
}
