using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.LenderServiceDTO
{
    public class LenderType_StatesAndZip_Request
    { 
        [JsonProperty("excludedStates", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ExcludedStates { get; set; }
        [JsonProperty("isCurrent", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsCurrent { get; set; }
        [JsonProperty("includedZipCodes", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> IncludedZipCodes { get; set; }
        [JsonProperty("includedContactIds", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> IncludedContactIds { get; set; }
        [JsonProperty("leadStateZipId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LeadStateZipId { get; set; }
    }
}
