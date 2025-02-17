using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.PaymentServiceDTO
{
    public class PaymentType_ValidateAmount_Response
    { 
        [JsonProperty("isValid", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsValid { get; set; }
    }
}
