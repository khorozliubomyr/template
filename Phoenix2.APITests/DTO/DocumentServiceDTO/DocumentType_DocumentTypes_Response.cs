﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DocumentServiceDTO
{

        public class DocumentType_DocumentTypes_Response
    { 
        [JsonProperty("message", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
        [JsonProperty("code", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }
        }
}
