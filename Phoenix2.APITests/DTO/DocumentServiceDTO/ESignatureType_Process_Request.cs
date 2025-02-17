using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DocumentServiceDTO
{
    public class DocuSignEnvelopeInformation_Process_Request
    {
        [JsonProperty("envelopeGuid", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string EnvelopeGuid { get; set; }
        [JsonProperty("status", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
        [JsonProperty("recipients", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<Recipient_Process_Request> Recipients { get; set; }
    }

    public class Recipient_Process_Request
    {
        [JsonProperty("recipientId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string RecipientId { get; set; }
        [JsonProperty("status", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
        [JsonProperty("routingOrder", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string RoutingOrder { get; set; }
    }

    public class ESignatureType_Process_Request
    { 
        [JsonProperty("docuSignEnvelopeInformation", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DocuSignEnvelopeInformation_Process_Request DocuSignEnvelopeInformation { get; set; }
    }
}
