﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.LeadServiceDTO
{

    public class LeadNotesType_PutLeadNotes_Response
    {  
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("contactId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ContactId { get; set; }
        [JsonProperty("leadId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LeadId { get; set; }
    }
}
