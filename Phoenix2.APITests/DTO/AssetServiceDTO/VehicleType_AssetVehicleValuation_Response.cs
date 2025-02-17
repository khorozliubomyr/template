using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.AssetServiceDTO
{
    public class VehicleType_AssetVehicleValuation_Response
    { 
        [JsonProperty("retailValue", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int RetailValue { get; set; }
        [JsonProperty("tradeInValue", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int TradeInValue { get; set; }
        [JsonProperty("wholesaleValue", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public object WholesaleValue { get; set; }
    }
}
