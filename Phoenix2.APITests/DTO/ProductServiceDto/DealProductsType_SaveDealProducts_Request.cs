using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.ProductServiceDto
{
    public class Product_SaveDealProducts_Request
    {
        [JsonProperty("productTypeName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTypeName { get; set; }
        [JsonProperty("productRetail", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int ProductRetail { get; set; }
    }

    public class DealProductsType_SaveDealProducts_Request
    { 
        [JsonProperty("dealId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DealId { get; set; }
        [JsonProperty("leadId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LeadId { get; set; }
        [JsonProperty("lenderCode", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LenderCode { get; set; }
        [JsonProperty("totalAmountFinanced", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int TotalAmountFinanced { get; set; }
        [JsonProperty("products", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<Product_SaveDealProducts_Request> Products { get; set; }
    }
}
