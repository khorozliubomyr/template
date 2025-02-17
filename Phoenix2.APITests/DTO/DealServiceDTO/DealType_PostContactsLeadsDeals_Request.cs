using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DealServiceDTO
{
    public class DealUser_PostContactsLeadsDeals_Request
    {
        [JsonProperty("userId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }
        [JsonProperty("userName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }
        [JsonProperty("dealUserType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int DealUserType { get; set; }
    }

    public class DealType_PostContactsLeadsDeals_Request
    { 
        [JsonProperty("lenderCode", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LenderCode { get; set; }
        [JsonProperty("Rate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Rate { get; set; }
        [JsonProperty("term", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Term { get; set; }
        [JsonProperty("loanAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int LoanAmount { get; set; }
        [JsonProperty("type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Type { get; set; }
        [JsonProperty("dealUsers", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<DealUser_PostContactsLeadsDeals_Request> DealUsers { get; set; }
        [JsonProperty("isPreApproval", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsPreApproval { get; set; }
    }
}
