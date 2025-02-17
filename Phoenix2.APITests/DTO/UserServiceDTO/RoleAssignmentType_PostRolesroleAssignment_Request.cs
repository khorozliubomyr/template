using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.UserServiceDTO
{
    public class AssignedTeam_PostRolesroleAssignment_Request
    {
        [JsonProperty("teamId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TeamId { get; set; }
        [JsonProperty("includedTeamMemberType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> IncludedTeamMemberType { get; set; }
    }

    public class AssignedTeamType_PostRolesroleAssignment_Request
    {
        [JsonProperty("teamTypeId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TeamTypeId { get; set; }
        [JsonProperty("includedTeamMemberType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> IncludedTeamMemberType { get; set; }
    }

    public class AssignedUser_PostRolesroleAssignment_Request
    {
        [JsonProperty("userId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }
        [JsonProperty("isIncluded", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsIncluded { get; set; }
    }

    public class RoleAssignmentType_PostRolesroleAssignment_Request
    { 
        [JsonProperty("roleId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string RoleId { get; set; }
        [JsonProperty("assignedUsers", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<AssignedUser_PostRolesroleAssignment_Request> AssignedUsers { get; set; }
        [JsonProperty("assignedTeamTypes", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<AssignedTeamType_PostRolesroleAssignment_Request> AssignedTeamTypes { get; set; }
        [JsonProperty("assignedTeams", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<AssignedTeam_PostRolesroleAssignment_Request> AssignedTeams { get; set; }
    }
}
