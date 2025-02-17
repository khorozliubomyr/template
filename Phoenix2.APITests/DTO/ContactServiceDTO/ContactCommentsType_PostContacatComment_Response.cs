﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.ContactServiceDTO
{
    public class ContactCommentsType_PostContacatComment_Response
    { 
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("createdDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("contactId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ContactId { get; set; }
        [JsonProperty("text", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }
    }
}
