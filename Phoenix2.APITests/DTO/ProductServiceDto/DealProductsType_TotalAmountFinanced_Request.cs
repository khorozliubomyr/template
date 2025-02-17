using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.ProductServiceDto
{
    public class DealProductsType_TotalAmountFinanced_Request
    { 
        [JsonProperty("dealId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DealId { get; set; }
    }
}
