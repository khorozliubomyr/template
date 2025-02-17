using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.DealServiceDTO
{
    public class DealFeeItem_DealsSalesprice_Request
    {
        [JsonProperty("category", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Category { get; set; }
        [JsonProperty("description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
        [JsonProperty("amount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Amount { get; set; }
        [JsonProperty("isDocFee", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsDocFee { get; set; }
        [JsonProperty("isAdditionalFee", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsAdditionalFee { get; set; }
    }

    public class FinanceConditionItemResponse_DealsSalesprice_Request
    {
        [JsonProperty("term", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Term { get; set; }
        [JsonProperty("rate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Rate { get; set; }
        [JsonProperty("apr", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Apr { get; set; }
        [JsonProperty("salesPrice", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int SalesPrice { get; set; }
        [JsonProperty("dealTotal", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int DealTotal { get; set; }
        [JsonProperty("totalAmountFinanced", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int TotalAmountFinanced { get; set; }
        [JsonProperty("monthlyPaymentAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MonthlyPaymentAmount { get; set; }
        [JsonProperty("contractDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ContractDate { get; set; }
        [JsonProperty("daysToFirstPayment", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int DaysToFirstPayment { get; set; }
        [JsonProperty("firstPaymentDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime FirstPaymentDate { get; set; }
        [JsonProperty("lastPaymentAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int LastPaymentAmount { get; set; }
        [JsonProperty("lastPaymentDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime LastPaymentDate { get; set; }
        [JsonProperty("totalTaxAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int TotalTaxAmount { get; set; }
        [JsonProperty("totalProductAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int TotalProductAmount { get; set; }
        [JsonProperty("totalProductTaxAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int TotalProductTaxAmount { get; set; }
        [JsonProperty("cashDownAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int CashDownAmount { get; set; }
        [JsonProperty("cashBackAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int CashBackAmount { get; set; }
        [JsonProperty("totalSalesTaxPercentage", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int TotalSalesTaxPercentage { get; set; }
        [JsonProperty("estimatedGrossTotalAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int EstimatedGrossTotalAmount { get; set; }
        [JsonProperty("dealFeeItems", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<DealFeeItem_DealsSalesprice_Request> DealFeeItems { get; set; }
        [JsonProperty("rateMarkUpPercentage", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int RateMarkUpPercentage { get; set; }
        [JsonProperty("interest", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Interest { get; set; }
        [JsonProperty("subTotal", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int SubTotal { get; set; }
        [JsonProperty("interestPlusDocFee", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int InterestPlusDocFee { get; set; }
        [JsonProperty("subTotalLessDocFee", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int SubTotalLessDocFee { get; set; }
    }

    public class DealType_DealsSalesprice_Request
    { 
        [JsonProperty("dealId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DealId { get; set; }
        [JsonProperty("leadId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LeadId { get; set; }
        [JsonProperty("lenderCode", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LenderCode { get; set; }
        [JsonProperty("isPicked", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsPicked { get; set; }
        [JsonProperty("isDocsGenerated", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsDocsGenerated { get; set; }
        [JsonProperty("isHotTitles", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsHotTitles { get; set; }
        [JsonProperty("isBuyBack", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsBuyBack { get; set; }
        [JsonProperty("downPaymentStatus", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DownPaymentStatus { get; set; }
        [JsonProperty("isBlueAdvantage", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsBlueAdvantage { get; set; }
        [JsonProperty("isGenysisWithHoldings", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsGenysisWithHoldings { get; set; }
        [JsonProperty("financeConditionItemResponse", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public FinanceConditionItemResponse_DealsSalesprice_Request FinanceConditionItemResponse { get; set; }
        [JsonProperty("carrierTrackingNumberIn", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string CarrierTrackingNumberIn { get; set; }
        [JsonProperty("carrierTrackingNumberOut", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string CarrierTrackingNumberOut { get; set; }
        [JsonProperty("isAch", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsAch { get; set; }
    }
}
