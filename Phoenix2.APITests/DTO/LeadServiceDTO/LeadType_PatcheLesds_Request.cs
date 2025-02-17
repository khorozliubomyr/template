using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.LeadServiceDTO
{
    public class AssignedUser_PatcheLesds_Request
    {
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("email", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

    public class InitialLeadScoreParameters_PatcheLesds_Request
    {
        [JsonProperty("state", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }
        [JsonProperty("ficoScore", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int FicoScore { get; set; }
        [JsonProperty("age", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Age { get; set; }
        [JsonProperty("assetYear", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int AssetYear { get; set; }
        [JsonProperty("lienAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int LienAmount { get; set; }
        [JsonProperty("lienRate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int LienRate { get; set; }
        [JsonProperty("lienPayment", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int LienPayment { get; set; }
        [JsonProperty("monthlyIncome", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MonthlyIncome { get; set; }
        [JsonProperty("sourceName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SourceName { get; set; }
    }

    public class LeadType_PatcheLesds_Request
    { 
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("contactId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ContactId { get; set; }
        [JsonProperty("assignedUser", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public AssignedUser_PatcheLesds_Request AssignedUser { get; set; }
        [JsonProperty("transferredToLeadId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TransferredToLeadId { get; set; }
        [JsonProperty("marketingInfo", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MarketingInfo { get; set; }
        [JsonProperty("score", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public Score_PatcheLesds_Request Score { get; set; }
    }

    public class Score_PatcheLesds_Request
    {
        [JsonProperty("initialLeadScore", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int InitialLeadScore { get; set; }
        [JsonProperty("initialLeadScoreParameters", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public InitialLeadScoreParameters_PatcheLesds_Request InitialLeadScoreParameters { get; set; }
    }
}
