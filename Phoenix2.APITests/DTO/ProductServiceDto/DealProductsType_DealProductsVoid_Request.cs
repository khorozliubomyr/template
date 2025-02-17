using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.ProductServiceDto
{
    public class DealProduct_DealProductsVoid_Request
    {
        [JsonProperty("dealProductId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DealProductId { get; set; }
        [JsonProperty("productTypeName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTypeName { get; set; }
    }

    public class DealProductsType_DealProductsVoid_Request
    { 
        [JsonProperty("dealProduct", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<DealProduct_DealProductsVoid_Request> DealProduct { get; set; }
    }
}
