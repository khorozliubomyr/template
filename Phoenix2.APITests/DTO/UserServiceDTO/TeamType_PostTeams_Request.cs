using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.UserServiceDTO
{
    public class TeamType_PostTeams_Request
    { 
        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("teamTypeId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TeamTypeId { get; set; }
        [JsonProperty("periodId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PeriodId { get; set; }
        [JsonProperty("copiedFromTeamId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string CopiedFromTeamId { get; set; }
        [JsonProperty("users", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<User_PostTeams_Request> Users { get; set; }
    }

    public class User_PostTeams_Request
    {
        [JsonProperty("userId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }
        [JsonProperty("userName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }
        [JsonProperty("teamMemberType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TeamMemberType { get; set; }
    }
}
