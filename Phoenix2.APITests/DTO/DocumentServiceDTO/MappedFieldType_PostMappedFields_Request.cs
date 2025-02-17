using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DocumentServiceDTO
{
    public class MappedFieldType_PostMappedFields_Request
    { 
        [JsonProperty("fieldName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string FieldName { get; set; }
        [JsonProperty("fieldType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string FieldType { get; set; }
        [JsonProperty("fieldCategory", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string FieldCategory { get; set; }
        [JsonProperty("fillable", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool Fillable { get; set; }
        [JsonProperty("oldId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int OldId { get; set; }
    }
}
