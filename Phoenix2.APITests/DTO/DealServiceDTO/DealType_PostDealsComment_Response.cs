using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DealServiceDTO
{

    public class DealType_PostDealsComment_Response
    { 
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("createdDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("dealId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DealId { get; set; }
        [JsonProperty("text", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }
        [JsonProperty("commentType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string CommentType { get; set; }
        [JsonProperty("background", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Background { get; set; }
        [JsonProperty("isTextBold", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsTextBold { get; set; }
        [JsonProperty("textCommentColor", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TextCommentColor { get; set; }
        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

}
