using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.ConfigurationServiceDTO
{
    public class MenuWorkflows_PutQueueConfigurations_Request
    {
        [JsonProperty("workflowIds", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> WorkflowIds { get; set; }
        [JsonProperty("stepIds", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> StepIds { get; set; }
    }

    public class QueueConfigurationType_PutQueueConfigurations_Request
    { 
        [JsonProperty("group", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Group { get; set; }
        [JsonProperty("subgroup", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Subgroup { get; set; }
        [JsonProperty("paramsType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ParamsType { get; set; }
        [JsonProperty("menuWorkflows", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public MenuWorkflows_PutQueueConfigurations_Request MenuWorkflows { get; set; }
        [JsonProperty("hasMyContacts", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool HasMyContacts { get; set; }
        [JsonProperty("hasMyTeamContacts", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool HasMyTeamContacts { get; set; }
        [JsonProperty("hasMyDeals", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool HasMyDeals { get; set; }
        [JsonProperty("hasMyTeamDeals", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool HasMyTeamDeals { get; set; }
        [JsonProperty("hasRedDeals", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool HasRedDeals { get; set; }
        [JsonProperty("hasAmberDeals", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool HasAmberDeals { get; set; }
        [JsonProperty("hasGreenDeals", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool HasGreenDeals { get; set; }
        [JsonProperty("hasRedContacts", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool HasRedContacts { get; set; }
        [JsonProperty("hasAmberContacts", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool HasAmberContacts { get; set; }
        [JsonProperty("hasGreenContacts", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool HasGreenContacts { get; set; }
        [JsonProperty("isUnAssigned", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsUnAssigned { get; set; }
        [JsonProperty("hasDeals", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string HasDeals { get; set; }
        [JsonProperty("hasActiveDeal", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string HasActiveDeal { get; set; }
        [JsonProperty("unAssignedTag", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string UnAssignedTag { get; set; }
        [JsonProperty("excludedLenderIds", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]

        public List<string> ExcludedLenderIds { get; set; }
        [JsonProperty("isDealActive", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string IsDealActive { get; set; }
        [JsonProperty("assetSelected", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AssetSelected { get; set; }
        [JsonProperty("isHotTitles", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsHotTitles { get; set; }
        [JsonProperty("isQueueEnabled", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsQueueEnabled { get; set; }
        [JsonProperty("checkRequestStatus", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string CheckRequestStatus { get; set; }
        [JsonProperty("isQueueEmailRequired", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsQueueEmailRequired { get; set; }
        [JsonProperty("queueEmailRoles", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> QueueEmailRoles { get; set; }
        [JsonProperty("description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
        [JsonProperty("roleId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string RoleId { get; set; }
        [JsonProperty("isCountRequired", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsCountRequired { get; set; }
        [JsonProperty("isDownPaymentDeclineQueue", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsDownPaymentDeclineQueue { get; set; }
        [JsonProperty("isBuyBackQueue", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsBuyBackQueue { get; set; }
        [JsonProperty("includedLenderIds", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> IncludedLenderIds { get; set; }
        [JsonProperty("lenderIds", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> LenderIds { get; set; }
        [JsonProperty("hasReferralContactId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string HasReferralContactId { get; set; }
    }
}
