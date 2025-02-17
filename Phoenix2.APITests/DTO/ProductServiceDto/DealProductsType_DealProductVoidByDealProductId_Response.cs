using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.ProductServiceDto
{
    public class DealProductsType_DealProductVoidByDealProductId_Response
    { 
        [JsonProperty("dealProductId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DealProductId { get; set; }
        [JsonProperty("productTypeName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object ProductTypeName { get; set; }
        [JsonProperty("isSuccess", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSuccess { get; set; }
        [JsonProperty("errorMessage", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorMessage { get; set; }
        [JsonProperty("dealProductDetails", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object DealProductDetails { get; set; }
        [JsonProperty("leadId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object LeadId { get; set; }
    }
}
