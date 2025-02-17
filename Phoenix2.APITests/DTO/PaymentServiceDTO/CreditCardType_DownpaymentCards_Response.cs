using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.PaymentServiceDTO
{
    public class CreditCardType_DownpaymentCards_Response
    { 
        [JsonProperty("contactCreditCardId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ContactCreditCardId { get; set; }
        [JsonProperty("isActive", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsActive { get; set; }
    }
}
