using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.LenderServiceDTO
{

    public class LenderFicoList_EligibleLenderTierConditions_Request
    {
        [JsonProperty("lenderCode", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LenderCode { get; set; }
        [JsonProperty("fico", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Fico { get; set; }
    }

    public class LenderType_EligibleLenderTierConditions_Request
    { 
        [JsonProperty("lenderFicoList", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<LenderFicoList_EligibleLenderTierConditions_Request> LenderFicoList { get; set; }
        [JsonProperty("vehicleAge", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int VehicleAge { get; set; }
        [JsonProperty("assetMiles", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int AssetMiles { get; set; }
        [JsonProperty("assetType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AssetType { get; set; }
        [JsonProperty("assetMake", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AssetMake { get; set; }
    }
}
