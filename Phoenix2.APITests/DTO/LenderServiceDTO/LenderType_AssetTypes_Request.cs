using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.LenderServiceDTO
{
    public class LenderType_AssetTypes_Request
    { 
        [JsonProperty("assetType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AssetType { get; set; }
        [JsonProperty("isAllowed", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsAllowed { get; set; }
    }

}
