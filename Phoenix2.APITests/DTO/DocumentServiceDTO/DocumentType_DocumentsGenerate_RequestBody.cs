using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DocumentServiceDTO
{
    public class DocumentType_DocumentsGenerate_RequestBody
    { 
        [JsonProperty("dealId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DealId { get; set; }
        [JsonProperty("userId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }
        [JsonProperty("documentGenerationType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentGenerationType { get; set; }
        [JsonProperty("ignoreProducts", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IgnoreProducts { get; set; }
        [JsonProperty("filterDocumentTypeIds", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> FilterDocumentTypeIds { get; set; }
    }
}
