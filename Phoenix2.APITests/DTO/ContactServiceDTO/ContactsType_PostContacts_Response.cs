using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.ContactServiceDTO
{
    public class ContactsType_PostContacts_Response
    { 
        [JsonProperty("targetSite", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object TargetSite { get; set; }
        [JsonProperty("message", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
        [JsonProperty("innerException", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object InnerException { get; set; }
        [JsonProperty("helpLink", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object HelpLink { get; set; }
        [JsonProperty("source", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }
        [JsonProperty("hResult", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int HResult { get; set; }
        [JsonProperty("stackTrace", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object StackTrace { get; set; }
    }
}
