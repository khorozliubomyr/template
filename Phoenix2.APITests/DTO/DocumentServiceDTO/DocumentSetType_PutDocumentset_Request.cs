using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DocumentServiceDTO
{

    public class DocumentType_PutDocumentset_Request
    {
        [JsonProperty("documentTypeId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentTypeId { get; set; }
        [JsonProperty("orderNumber", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int OrderNumber { get; set; }
    }

    public class DocumentSetType_PutDocumentset_Request
    { 
        [JsonProperty("documentSetId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentSetId { get; set; }
        [JsonProperty("isDeleted", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsDeleted { get; set; }
        [JsonProperty("documentTypes", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<DocumentType_PutDocumentset_Request> DocumentTypes { get; set; }
    }



}

