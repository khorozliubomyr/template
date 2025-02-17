using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.AssetServiceDTO
{
    public class AssetType_PostAsset_Response
    { 
        [JsonProperty("assetType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AssetType { get; set; }
        [JsonProperty("year", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Year { get; set; }
        [JsonProperty("contactId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ContactId { get; set; }
    }
}
