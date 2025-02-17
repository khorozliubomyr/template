using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.LenderServiceDTO
{
    public class LenderProductCheckRequestPayeeType_GetCheckRequestPayeeByLenderNumericId_Response
    { 
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("lenderId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LenderId { get; set; }
        [JsonProperty("numericId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int NumericId { get; set; }
        [JsonProperty("lenderName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LenderName { get; set; }
        [JsonProperty("payeeName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PayeeName { get; set; }
        [JsonProperty("payeeAddress", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PayeeAddress { get; set; }
    }
}
