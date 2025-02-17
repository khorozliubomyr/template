using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.LenderServiceDTO
{
    public class FlagshipType_PatchLoanApplication_Request
    { 
        [JsonProperty("dealId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int DealId { get; set; }
        [JsonProperty("requestedById", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int RequestedById { get; set; }
        [JsonProperty("comment", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Comment { get; set; }
        [JsonProperty("applicationNumber", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ApplicationNumber { get; set; }
    }
}
