using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DocumentServiceDTO
{
    public class DocumentSetType_DocumentByLenderCode_Response
    { 
        [JsonProperty("documentSetId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentSetId { get; set; }
        [JsonProperty("documentGroup", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentGroup { get; set; }
        [JsonProperty("lenderCode", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LenderCode { get; set; }
        [JsonProperty("documentSetType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentSetType { get; set; }
    }
    public class TypeStipType_GetStipType_Response_NegativeScenario
    { 
        [JsonProperty("message", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
        [JsonProperty("code", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }
    }
}
