using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.LeadServiceDTO
{
    public class SourceType_PostSource_RequstBody
    { 
        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
        [JsonProperty("isSecondary", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSecondary { get; set; }
        [JsonProperty("allowSecondary", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool AllowSecondary { get; set; }
        [JsonProperty("isAutoResponseEnabled", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsAutoResponseEnabled { get; set; }
        [JsonProperty("autoResponsePostUrl", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AutoResponsePostUrl { get; set; }
        [JsonProperty("autoResponseVersion", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int AutoResponseVersion { get; set; }
        [JsonProperty("enableCamRef", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool EnableCamRef { get; set; }
        [JsonProperty("isAutoDeadEnabled", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsAutoDeadEnabled { get; set; }
        [JsonProperty("isAutoDelayedResponseEnabled", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsAutoDelayedResponseEnabled { get; set; }
        [JsonProperty("autoDeadDelayedResponse", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int AutoDeadDelayedResponse { get; set; }
        [JsonProperty("autoDelayedResponseOfferCallbackBaseUrl", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AutoDelayedResponseOfferCallbackBaseUrl { get; set; }
    }
}
