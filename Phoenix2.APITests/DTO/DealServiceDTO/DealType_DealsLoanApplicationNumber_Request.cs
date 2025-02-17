using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DealServiceDTO
{
    public class DealType_DealsLoanApplicationNumber_Request
    { 
        [JsonProperty("applicationNumber", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ApplicationNumber { get; set; }
    }
}
