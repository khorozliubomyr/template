using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.WorkflowServiceDTO
{
    public class WorkflowCommunicationType_PutCommunications_Request
    { 
        [JsonProperty("workflowSteps", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> WorkflowSteps { get; set; }
        [JsonProperty("isEmail", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsEmail { get; set; }
        [JsonProperty("isSms", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSms { get; set; }
        [JsonProperty("emailSubject", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string EmailSubject { get; set; }
        [JsonProperty("emailBody", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string EmailBody { get; set; }
        [JsonProperty("smsText", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SmsText { get; set; }
        [JsonProperty("delayInMinutes", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int DelayInMinutes { get; set; }
        [JsonProperty("fromEmail", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string FromEmail { get; set; }
        [JsonProperty("ExcludedStates", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> ExcludedStates { get; set; }
    }

}
