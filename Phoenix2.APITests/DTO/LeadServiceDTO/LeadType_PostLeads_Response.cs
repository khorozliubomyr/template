using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.LeadServiceDTO
{
    public class LeadType_PostLeads_Response
    { 
        [JsonProperty("contactId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ContactId { get; set; }
        [JsonProperty("primarySourceId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PrimarySourceId { get; set; }
        [JsonProperty("secondarySourceId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SecondarySourceId { get; set; }
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
    }
}
