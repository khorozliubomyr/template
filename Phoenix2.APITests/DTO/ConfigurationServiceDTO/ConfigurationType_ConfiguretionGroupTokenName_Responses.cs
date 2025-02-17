﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.ConfigurationServiceDTO
{
    public class ConfigurationType_ConfiguretionGroupTokenName_Responses
    { 
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("configurationGroup", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ConfigurationGroup { get; set; }
        [JsonProperty("tokenName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TokenName { get; set; }
        [JsonProperty("value", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
    }
}
