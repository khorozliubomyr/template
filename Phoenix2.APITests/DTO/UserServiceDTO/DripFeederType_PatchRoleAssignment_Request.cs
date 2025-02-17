using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.UserServiceDTO
{
    public class AssignedTeam_PatchRoleAssignment_Request
    {
        [JsonProperty("teamId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }
        [JsonProperty("includeFullTeam", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IncludeFullTeam { get; set; }
        [JsonProperty("includedTeamMemberType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> IncludedTeamMemberType { get; set; }
    }

    public class AssignedTeamType_PatchRoleAssignment_Request
    {
        [JsonProperty("teamTypeId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TeamTypeId { get; set; }
        [JsonProperty("includeFullTeamType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IncludeFullTeamType { get; set; }
        [JsonProperty("includeManager", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IncludeManager { get; set; }
        [JsonProperty("includedTeamMemberType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> IncludedTeamMemberType { get; set; }
    }

    public class AssignedUser_PatchRoleAssignment_Request
    {
        [JsonProperty("userId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }
        [JsonProperty("isIncluded", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsIncluded { get; set; }
    }

    public class DripFeederType_PatchRoleAssignment_Request
    { 
        [JsonProperty("allUsers", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool AllUsers { get; set; }
        [JsonProperty("assignedUsers", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<AssignedUser_PatchRoleAssignment_Request> AssignedUsers { get; set; }
        [JsonProperty("assignedTeamTypes", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<AssignedTeamType_PatchRoleAssignment_Request> AssignedTeamTypes { get; set; }
        [JsonProperty("assignedTeams", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<AssignedTeam_PatchRoleAssignment_Request> AssignedTeams { get; set; }
        [JsonProperty("includeAllManagers", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IncludeAllManagers { get; set; }
        [JsonProperty("includeAllDirectors", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IncludeAllDirectors { get; set; }
        [JsonProperty("includeAllLieutenants", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IncludeAllLieutenants { get; set; }
    }
}
