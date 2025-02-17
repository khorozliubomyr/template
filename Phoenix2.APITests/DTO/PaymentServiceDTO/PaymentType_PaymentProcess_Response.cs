using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.PaymentServiceDTO
{
    public class PaymentType_PaymentProcess_Response
    { 
        [JsonProperty("dateProcessed", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime DateProcessed { get; set; }
        [JsonProperty("paymentProcessStatus", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PaymentProcessStatus { get; set; }
    }

}
