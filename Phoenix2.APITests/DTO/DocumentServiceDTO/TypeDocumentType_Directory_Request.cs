using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DocumentServiceDTO
{
    public class TypeDocumentType_Directory_Request
    { 
        [JsonProperty("ids", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Ids { get; set; }
        [JsonProperty("newDirectoryName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string NewDirectoryName { get; set; }
    }

}
