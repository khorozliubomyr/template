using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DocumentServiceDTO
{
    class DocumentType_DocumentsGenerate_Response
    { 
        [JsonProperty("filePath", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string FilePath { get; set; }
    }
    public class DocumentType_DocumentsGenerate_Response_NegativeScenario
    {
        [JsonProperty("message", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
        [JsonProperty("code", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }
    }
}
