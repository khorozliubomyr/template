using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.LenderServiceDTO
{
    public class LenderType_PutTierCondition_Request
    { 
        [JsonProperty("minFico", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinFico { get; set; }
        [JsonProperty("maxFico", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxFico { get; set; }
        [JsonProperty("minTerm", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinTerm { get; set; }
        [JsonProperty("maxTerm", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxTerm { get; set; }
        [JsonProperty("minLtv", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinLtv { get; set; }
        [JsonProperty("maxLtv", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxLtv { get; set; }
        [JsonProperty("minDti", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinDti { get; set; }
        [JsonProperty("maxDti", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxDti { get; set; }
        [JsonProperty("minLoanAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinLoanAmount { get; set; }
        [JsonProperty("maxLoanAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxLoanAmount { get; set; }
        [JsonProperty("ltvLimit", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int LtvLimit { get; set; }
        [JsonProperty("minAssetYear", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinAssetYear { get; set; }
        [JsonProperty("maxAssetYear", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxAssetYear { get; set; }
        [JsonProperty("maxTotalLending", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxTotalLending { get; set; }
        [JsonProperty("lenderTierId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int LenderTierId { get; set; }
        [JsonProperty("rate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Rate { get; set; }
        [JsonProperty("minMiles", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinMiles { get; set; }
        [JsonProperty("maxMilesGreen", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxMilesGreen { get; set; }
        [JsonProperty("maxPti", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxPti { get; set; }
        [JsonProperty("maxCashOut", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxCashOut { get; set; }
        [JsonProperty("maxAgeGreen", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxAgeGreen { get; set; }
        [JsonProperty("maxAgeYellow", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxAgeYellow { get; set; }
        [JsonProperty("termGroup", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int TermGroup { get; set; }
        [JsonProperty("ficoGroup", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int FicoGroup { get; set; }
        [JsonProperty("termFico", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TermFico { get; set; }
        [JsonProperty("maxMarkup", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxMarkup { get; set; }
        [JsonProperty("maxFlatFeePercent", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxFlatFeePercent { get; set; }
        [JsonProperty("maxMilesYellow", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxMilesYellow { get; set; }
        [JsonProperty("dtiYellow", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int DtiYellow { get; set; }
        [JsonProperty("dtiGreen", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int DtiGreen { get; set; }
        [JsonProperty("ptiYellow", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int PtiYellow { get; set; }
        [JsonProperty("ptiGreen", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int PtiGreen { get; set; }
        [JsonProperty("type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
        [JsonProperty("minTotalAmountFinanceGreen", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinTotalAmountFinanceGreen { get; set; }
        [JsonProperty("minTotalAmountFinanceYellow", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinTotalAmountFinanceYellow { get; set; }
        [JsonProperty("maxLtvGreen", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxLtvGreen { get; set; }
        [JsonProperty("maxLtvYellow", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxLtvYellow { get; set; }
        [JsonProperty("isCashOutRate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsCashOutRate { get; set; }
        [JsonProperty("maxAllInLtv", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxAllInLtv { get; set; }
        [JsonProperty("minAgeGreen", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinAgeGreen { get; set; }
        [JsonProperty("maxFlatGreen", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxFlatGreen { get; set; }
    }
}
