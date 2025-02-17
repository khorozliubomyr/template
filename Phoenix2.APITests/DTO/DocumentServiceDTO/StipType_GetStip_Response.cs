using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DocumentServiceDTO
{
    public class StipType_GetStip_Response
    { 
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("contactId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ContactId { get; set; }
        [JsonProperty("dealId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DealId { get; set; }
        [JsonProperty("assetId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object AssetId { get; set; }
        [JsonProperty("stipTypeId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string StipTypeId { get; set; }
    }
}
