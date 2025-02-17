using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DocumentServiceDTO
{
    public class DocumentTypeForCreateAsync_PostDocumentset_Request
    {
        [JsonProperty("documentTypeId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentTypeId { get; set; }
        [JsonProperty("orderNumber", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int OrderNumber { get; set; }
    }
    public class DocumentSetType_PostDocumentset_Request
    { 
        [JsonProperty("documentSetType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentSetType { get; set; }
        [JsonProperty("documentTypes", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<DocumentTypeForCreateAsync_PostDocumentset_Request> DocumentTypes { get; set; }
    }
}
