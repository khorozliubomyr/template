using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DealServiceDTO
{
    public class DealType_DealsSalesprice_Response
    { 
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("leadId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LeadId { get; set; }
        [JsonProperty("numericId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int NumericId { get; set; }
        [JsonProperty("dealType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DealType { get; set; }
    }
}
