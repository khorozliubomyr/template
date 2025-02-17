using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.ProductServiceDto
{
    public class DealProductsType_DealProductRetail_Request
    { 

        [JsonProperty("newRetail", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int NewRetail { get; set; }
        [JsonProperty("newMarkUp", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int NewMarkUp { get; set; }
    }
}
