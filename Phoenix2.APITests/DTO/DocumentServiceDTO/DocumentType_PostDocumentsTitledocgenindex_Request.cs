using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DocumentServiceDTO
{
    public class Comment_PostDocumentsTitledocgenindex_Request
    {
        [JsonProperty("comment", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Comment { get; set; }
        [JsonProperty("createdById", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string CreatedById { get; set; }
        [JsonProperty("createdDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedDate { get; set; }
    }

    public class Item_PostDocumentsTitledocgenindex_Request
    {
        [JsonProperty("documentName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DocumentName { get; set; }
        [JsonProperty("isReceived", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsReceived { get; set; }
    }

    public class DocumentType_PostDocumentsTitledocgenindex_Request
    { 
        [JsonProperty("dealId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DealId { get; set; }
        [JsonProperty("titleDocGeneration", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool TitleDocGeneration { get; set; }
        [JsonProperty("items", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<Item_PostDocumentsTitledocgenindex_Request> Items { get; set; }
        [JsonProperty("comment", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public Comment_PostDocumentsTitledocgenindex_Request Comment { get; set; }
    }
}
