using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.ProductServiceDto
{
    public class ProductTypesType_PostProductType_Request
    { 
        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("rules", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<Rule_PostProductType_Request> Rules { get; set; }
    }

    public class Rule_PostProductType_Request
    {
        [JsonProperty("state", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }
        [JsonProperty("maxAllowedAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxAllowedAmount { get; set; }
        [JsonProperty("maxAllowedFormula", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MaxAllowedFormula { get; set; }
        [JsonProperty("isAllowed", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsAllowed { get; set; }
        [JsonProperty("maxTerm", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxTerm { get; set; }
    }
}
