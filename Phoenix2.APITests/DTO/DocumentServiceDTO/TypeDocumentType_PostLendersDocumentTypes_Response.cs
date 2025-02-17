using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DocumentServiceDTO
{

    class TypeDocumentType_PostLendersDocumentTypes_Response
    { 
        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("lenderId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public long LenderId { get; set; }
        [JsonProperty("lenderCode", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LenderCode { get; set; }
        [JsonProperty("directoryName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DirectoryName { get; set; }
    }


}

