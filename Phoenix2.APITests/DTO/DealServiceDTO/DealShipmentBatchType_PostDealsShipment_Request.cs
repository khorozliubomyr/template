using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DealServiceDTO
{
    public class DealShipmentBatchType_PostDealsShipment_Request
    { 
        [JsonProperty("dealId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DealId { get; set; }
        [JsonProperty("checkPayeeName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string CheckPayeeName { get; set; }
    }
}
