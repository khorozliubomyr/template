using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.WorkflowServiceDTO
{
    public class WorkflowType_PostWorkflow_Response
    {  
        [JsonProperty("workflowId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string WorkflowId { get; set; }
        [JsonProperty("workflowNumericId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int WorkflowNumericId { get; set; }
        [JsonProperty("workflowName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string WorkflowName { get; set; }
        [JsonProperty("entityType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string EntityType { get; set; }
    }
}
