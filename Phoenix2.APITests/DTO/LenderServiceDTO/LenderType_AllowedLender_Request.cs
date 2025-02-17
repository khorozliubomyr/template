using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.LenderServiceDTO
{
    public class LenderType_AllowedLender_Request
    { 
        [JsonProperty("zip", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Zip { get; set; }
        [JsonProperty("state", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }
        [JsonProperty("employerName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string EmployerName { get; set; }
        [JsonProperty("employerZip", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string EmployerZip { get; set; }
        [JsonProperty("contactId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int ContactId { get; set; }
        [JsonProperty("ficoScore", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int FicoScore { get; set; }
    }
}
