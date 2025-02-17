using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.ProductServiceDto
{
    public class ContractBlobFile_PostDealProducts_Request
    {
        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("path", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Path { get; set; }
        [JsonProperty("type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
    }

    public class DealProduct_PostDealProducts_Request
    {
        [JsonProperty("productTypeName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTypeName { get; set; }
        [JsonProperty("productTypeId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ProductTypeId { get; set; }
        [JsonProperty("providerName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ProviderName { get; set; }
        [JsonProperty("providerId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ProviderId { get; set; }
        [JsonProperty("cost", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Cost { get; set; }
        [JsonProperty("markup", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Markup { get; set; }
        [JsonProperty("retail", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Retail { get; set; }
        [JsonProperty("packPrice", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int PackPrice { get; set; }
        [JsonProperty("providerBaseAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int ProviderBaseAmount { get; set; }
        [JsonProperty("taxAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int TaxAmount { get; set; }
        [JsonProperty("maxAllowedRetail", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxAllowedRetail { get; set; }
        [JsonProperty("sefiTermId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int SefiTermId { get; set; }
        [JsonProperty("sefiPlanCode", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SefiPlanCode { get; set; }
        [JsonProperty("sefiQuoteId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int SefiQuoteId { get; set; }
        [JsonProperty("sefiRateBook", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int SefiRateBook { get; set; }
        [JsonProperty("sefiContractFormNumber", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SefiContractFormNumber { get; set; }
        [JsonProperty("plan", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public Plan_PostDealProducts_Request Plan { get; set; }
        [JsonProperty("rate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public Rate_PostDealProducts_Request Rate { get; set; }
        [JsonProperty("deductible", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public Deductible_PostDealProducts_Request Deductible { get; set; }
        [JsonProperty("options", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<Option_PostDealProducts_Request> Options { get; set; }
        [JsonProperty("dealProductId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DealProductId { get; set; }
        [JsonProperty("totalAmountFinanced", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int TotalAmountFinanced { get; set; }
        [JsonProperty("status", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }
        [JsonProperty("contractBlobFile", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public ContractBlobFile_PostDealProducts_Request ContractBlobFile { get; set; }
        [JsonProperty("assetMiles", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int AssetMiles { get; set; }
    }

    public class Deductible_PostDealProducts_Request
    {
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("amount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Amount { get; set; }
    }

    public class Option_PostDealProducts_Request
    {
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("amount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Amount { get; set; }
        [JsonProperty("isSurcharge", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsSurcharge { get; set; }
    }

    public class Plan_PostDealProducts_Request
    {
        [JsonProperty("planId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PlanId { get; set; }
        [JsonProperty("planName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PlanName { get; set; }
    }

    public class Rate_PostDealProducts_Request
    {
        [JsonProperty("rateId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string RateId { get; set; }
        [JsonProperty("minTerm", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinTerm { get; set; }
        [JsonProperty("maxTerm", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxTerm { get; set; }
        [JsonProperty("maxMiles", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxMiles { get; set; }
    }

    public class DealProductsType_PostDealProducts_Request
    { 
        [JsonProperty("dealProducts", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<DealProduct_PostDealProducts_Request> DealProducts { get; set; }
    }
}
