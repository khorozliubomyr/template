using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.LenderServiceDTO
{
    public class LenderType_PatchLenderCreditRule_Request
    { 
        [JsonProperty("condition", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Condition { get; set; }
        [JsonProperty("yellowValue", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string YellowValue { get; set; }
        [JsonProperty("value", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
        [JsonProperty("creditRuleType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string CreditRuleType { get; set; }
    }

}
