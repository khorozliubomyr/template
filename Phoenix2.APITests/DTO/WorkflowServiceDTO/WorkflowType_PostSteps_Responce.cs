using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.WorkflowServiceDTO
{
    public class WorkflowType_PostSteps_Responce
    { 
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("numericId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int NumericId { get; set; }
        [JsonProperty("workflowStepId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string WorkflowStepId { get; set; }
        [JsonProperty("workflowStepNumericId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int WorkflowStepNumericId { get; set; }
        [JsonProperty("workflowId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string WorkflowId { get; set; }
        [JsonProperty("displayName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }
        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("roleId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string RoleId { get; set; }
    }
}
