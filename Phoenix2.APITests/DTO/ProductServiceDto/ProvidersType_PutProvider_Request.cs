using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.ProductServiceDto
{
    public class ProductTypeItem_PutProvider_Request
    {
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
    }

    public class ProvidersType_PutProvider_Request
    { 
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("address", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }
        [JsonProperty("productTypeItems", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<ProductTypeItem_PutProvider_Request> ProductTypeItems { get; set; }
    }
}
