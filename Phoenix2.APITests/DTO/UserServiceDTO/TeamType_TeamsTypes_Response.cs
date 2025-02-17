using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.UserServiceDTO
{
    public class TeamType_TeamsTypes_Response
    { 
        [JsonProperty("teamTypeId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TeamTypeId { get; set; }
        [JsonProperty("periodId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PeriodId { get; set; }
    }

    public class TeamType_TeamsTypes_ResponseWithCode
    { 
        [JsonProperty("message", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Message { get; set; }
        [JsonProperty("code", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }
    }
}
