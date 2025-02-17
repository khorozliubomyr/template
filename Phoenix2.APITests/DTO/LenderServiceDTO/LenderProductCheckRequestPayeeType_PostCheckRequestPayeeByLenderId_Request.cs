using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.LenderServiceDTO
{
    public class LenderProductCheckRequestPayeeType_PostCheckRequestPayeeByLenderId_Request
    { 
        [JsonProperty("payeeName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PayeeName { get; set; }
        [JsonProperty("payeeAddress", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PayeeAddress { get; set; }
    }
}
