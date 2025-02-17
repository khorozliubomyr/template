using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.AssetServiceDTO
{
    public class VehicleType_AssetVehicleTitle_Response
    { 
        [JsonProperty("hasVehicleRecordLessThanThirtyDaysOld", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool HasVehicleRecordLessThanThirtyDaysOld { get; set; }
        [JsonProperty("shouldDisplayOverrideButton", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool ShouldDisplayOverrideButton { get; set; }
        [JsonProperty("accessTokenDoesNotExists", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool AccessTokenDoesNotExists { get; set; }
    }
}
