using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.ProductServiceDto
{
    public class DealProductsType_DealCalculatorRetail_Request
    { 
        [JsonProperty("productTypeName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTypeName { get; set; }
        [JsonProperty("newRetail", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int NewRetail { get; set; }
        [JsonProperty("leadId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LeadId { get; set; }
        [JsonProperty("lenderCode", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LenderCode { get; set; }
    }

}
