using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.ProductServiceDto
{
    public class ProviderProductTypeRuleType_PostProviderProductTypesRules_Request
    { 
        [JsonProperty("assetTypes", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AssetTypes { get; set; }
        [JsonProperty("startDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime StartDate { get; set; }
        [JsonProperty("endDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime EndDate { get; set; }
        [JsonProperty("ilendingCostAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int IlendingCostAmount { get; set; }
        [JsonProperty("ilendingCostFormula", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string IlendingCostFormula { get; set; }
        [JsonProperty("packAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int PackAmount { get; set; }
        [JsonProperty("packFormula", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PackFormula { get; set; }
        [JsonProperty("markupAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MarkupAmount { get; set; }
        [JsonProperty("markupFormula", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MarkupFormula { get; set; }
        [JsonProperty("state", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }
        [JsonProperty("minTerm", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinTerm { get; set; }
        [JsonProperty("maxTerm", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxTerm { get; set; }
        [JsonProperty("minMileage", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MinMileage { get; set; }
        [JsonProperty("maxMileage", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MaxMileage { get; set; }
        [JsonProperty("minYear", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MinYear { get; set; }
        [JsonProperty("maxYear", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MaxYear { get; set; }
    }
}
