using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.AssetServiceDTO
{
    public class VehicleType_AssetVehicleType_Response
    { 
        [JsonProperty("year", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Year { get; set; }
        [JsonProperty("providerVehicleId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int ProviderVehicleId { get; set; }
        [JsonProperty("make", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Make { get; set; }
    }
}
