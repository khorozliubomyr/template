using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.UserServiceDTO
{
    public class ManagerType_PostManager_Request
    { 
        [JsonProperty("userId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }
        [JsonProperty("teamTypeID", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TeamTypeID { get; set; }
        [JsonProperty("periodId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PeriodId { get; set; }
    }

    public class ManagerType_PostManager_Response
    {
        [JsonProperty("userId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }
        [JsonProperty("teamTypeID", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TeamTypeID { get; set; }
        [JsonProperty("periodId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PeriodId { get; set; }
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("location", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Location { get; set; }
        [JsonProperty("code", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }
    }
}
