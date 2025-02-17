using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DocumentServiceDTO
{
    public class TypeDocumentType_DocumentConditions_RequestBody
    { 
        [JsonProperty("mappedFieldId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MappedFieldId { get; set; }
        [JsonProperty("@operator", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string @operator { get; set; }
        [JsonProperty("value", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Value { get; set; }
        [JsonProperty("valueType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ValueType { get; set; }
    }
}
