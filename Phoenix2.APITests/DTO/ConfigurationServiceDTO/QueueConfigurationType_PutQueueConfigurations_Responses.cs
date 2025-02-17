using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.ConfigurationServiceDTO
{
    public class QueueConfigurationType_PutQueueConfigurations_Responses
    { 
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("group", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Group { get; set; }
        [JsonProperty("subgroup", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Subgroup { get; set; }
        [JsonProperty("paramsType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ParamsType { get; set; }
    }
    public class QueueConfigurationType_PutQueueConfigurations_Response
    {
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("group", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Group { get; set; }
        [JsonProperty("subgroup", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Subgroup { get; set; }
        [JsonProperty("paramsType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ParamsType { get; set; }
    }
}
