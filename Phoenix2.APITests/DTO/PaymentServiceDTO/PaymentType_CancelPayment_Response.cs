using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.PaymentServiceDTO
{
    public class PaymentType_CancelPayment_Response
    { 
        [JsonProperty("dealDownPaymentId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DealDownPaymentId { get; set; }
    }
}
