using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.LeadServiceDTO
{
    public class AssignedUser_PostLeads_RequestBody
    {
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("email", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

    public class InitialLeadScoreParameters_PostLeads_RequestBody
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

    public class LeadType_PostLeads_RequestBody
    { 
        [JsonProperty("contactId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ContactId { get; set; }
        [JsonProperty("primarySourceId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PrimarySourceId { get; set; }
        [JsonProperty("secondarySourceId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SecondarySourceId { get; set; }
        [JsonProperty("assignedUser", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public AssignedUser_PostLeads_RequestBody AssignedUser { get; set; }
        [JsonProperty("transferredToLeadId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TransferredToLeadId { get; set; }
        [JsonProperty("transferredFromLeadId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TransferredFromLeadId { get; set; }
        [JsonProperty("originalLeadId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string OriginalLeadId { get; set; }
        [JsonProperty("loanApplicationId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LoanApplicationId { get; set; }
        [JsonProperty("marketingInfo", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MarketingInfo { get; set; }
        [JsonProperty("score", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public Score_PostLeads_RequestBody Score { get; set; }
    }

    public class Score_PostLeads_RequestBody
    {
        [JsonProperty("initialLeadScore", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int InitialLeadScore { get; set; }
        [JsonProperty("initialLeadScoreParameters", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public InitialLeadScoreParameters_PostLeads_RequestBody InitialLeadScoreParameters { get; set; }
    }
}
