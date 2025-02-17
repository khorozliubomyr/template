using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.WorkflowServiceDTO
{
    public class WorkflowStepDealType_MovesStep_Request
    { 
        [JsonProperty("currentStepId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string CurrentStepId { get; set; }
        [JsonProperty("nextStepId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string NextStepId { get; set; }
    }
}
