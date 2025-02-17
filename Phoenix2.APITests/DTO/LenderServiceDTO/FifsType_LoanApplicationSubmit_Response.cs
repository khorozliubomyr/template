using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.LenderServiceDTO
{
     public class FifsType_LoanApplicationSubmit_Response
    { 
        [JsonProperty("errors", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Errors { get; set; }
        [JsonProperty("isSuccess", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSuccess { get; set; }
        [JsonProperty("applicationNumber", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ApplicationNumber { get; set; }
    }
}
