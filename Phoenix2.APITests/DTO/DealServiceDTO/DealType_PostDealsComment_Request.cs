using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DealServiceDTO
{
    public class DealType_PostDealsComment_Request
    {
        [JsonProperty("comment", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Comment { get; set; }
        [JsonProperty("commentActionType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int CommentActionType { get; set; }
        [JsonProperty("workflowStepId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string WorkflowStepId { get; set; }
        [JsonProperty("textCommentColor", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TextCommentColor { get; set; }
        [JsonProperty("isTextBold", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsTextBold { get; set; }
    }
}
