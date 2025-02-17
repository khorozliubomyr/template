using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DocumentServiceDTO
{
    public class ESignatureType_Upload_Request
    { 
        [JsonProperty("dealId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int DealId { get; set; }
        [JsonProperty("dealDocumentIds", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<int> DealDocumentIds { get; set; }
        [JsonProperty("userId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }
    }
}
