using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DealServiceDTO
{
    public class DealUser_PutDealsUsers_Request
    {
        [JsonProperty("userId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }
        [JsonProperty("userName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }
        [JsonProperty("dealUserType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int DealUserType { get; set; }
    }

    public class DealType_PutDealsUsers_Request
    { 
        [JsonProperty("dealUserAssignmentType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int DealUserAssignmentType { get; set; }
        [JsonProperty("dealUsers", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<DealUser_PutDealsUsers_Request> DealUsers { get; set; }
    }
}
