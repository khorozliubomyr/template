using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.ProductServiceDto
{
    public class ProductPlanType_Lates_Response
    { 
        [JsonProperty("leadId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LeadId { get; set; }
        [JsonProperty("vin", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Vin { get; set; }
        [JsonProperty("daysSinceCreatedDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int DaysSinceCreatedDate { get; set; }
    }
}
