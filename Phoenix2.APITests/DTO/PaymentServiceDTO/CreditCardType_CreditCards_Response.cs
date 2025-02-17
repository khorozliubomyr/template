using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.PaymentServiceDTO
{
    public class CreditCardType_CreditCards_Response
    { 
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("contactId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ContactId { get; set; }
        [JsonProperty("creditCardType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string CreditCardType { get; set; }
        [JsonProperty("holderName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string HolderName { get; set; }
        [JsonProperty("cvv", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Cvv { get; set; }
        [JsonProperty("expiryDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ExpiryDate { get; set; }
        [JsonProperty("lastFourDigits", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LastFourDigits { get; set; }
    }
}
