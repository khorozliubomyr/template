using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.UserServiceDTO
{
    public class TeamType_TeamsCopy_Request
    { 
        [JsonProperty("oldPeriodId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string OldPeriodId { get; set; }
        [JsonProperty("newPeriodId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string NewPeriodId { get; set; }
    }
}
