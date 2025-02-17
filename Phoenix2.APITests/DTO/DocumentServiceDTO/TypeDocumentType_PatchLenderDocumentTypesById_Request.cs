using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DocumentServiceDTO
{
    public class TypeDocumentType_PatchLenderDocumentTypesById_Request
    { 
        [JsonProperty("documentTypeName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentTypeName { get; set; }
    }

}
 