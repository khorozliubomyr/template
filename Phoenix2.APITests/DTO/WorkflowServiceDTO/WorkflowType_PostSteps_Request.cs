using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.WorkflowServiceDTO
{
    public class WorkflowType_PostSteps_Request
    { 
        [JsonProperty("workflowId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string WorkflowId { get; set; }
        [JsonProperty("displayName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DisplayName { get; set; }
        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
        [JsonProperty("orderNumber", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int OrderNumber { get; set; }
        [JsonProperty("stepType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string StepType { get; set; }
        [JsonProperty("minutesGreen", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinutesGreen { get; set; }
        [JsonProperty("minutesAmber", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinutesAmber { get; set; }
        [JsonProperty("minutesRed", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinutesRed { get; set; }
        [JsonProperty("isDefault", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsDefault { get; set; }
        [JsonProperty("trackerStageId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int TrackerStageId { get; set; }
        [JsonProperty("trackerStepId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int TrackerStepId { get; set; }
        [JsonProperty("textCommentColor", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TextCommentColor { get; set; }
        [JsonProperty("isTextBold", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsTextBold { get; set; }
        [JsonProperty("parentWorkflowStepId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ParentWorkflowStepId { get; set; }
        [JsonProperty("reRouteWorkflowStepId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ReRouteWorkflowStepId { get; set; }
        [JsonProperty("roleId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string RoleId { get; set; }
    }

}
