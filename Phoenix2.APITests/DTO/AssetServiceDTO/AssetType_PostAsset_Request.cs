using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.AssetServiceDTO
{
    public class AddressCreate_PostAsset_Request
    {
        [JsonProperty("streetLine1", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string StreetLine1 { get; set; }
        [JsonProperty("streetLine2", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string StreetLine2 { get; set; }
        [JsonProperty("city", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }
        [JsonProperty("state", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int State { get; set; }
        [JsonProperty("zip", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Zip { get; set; }
    }

    public class AssetInsurance_PostAsset_Request
    {
        [JsonProperty("company", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Company { get; set; }
        [JsonProperty("phoneNumber", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; set; }
        [JsonProperty("policyNumber", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PolicyNumber { get; set; }
        [JsonProperty("effectiveDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime EffectiveDate { get; set; }
        [JsonProperty("expirationDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ExpirationDate { get; set; }
    }

    public class AssetLienHolder_PostAsset_Request
    {
        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("lienHolderId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LienHolderId { get; set; }
        [JsonProperty("remainingLoanAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int RemainingLoanAmount { get; set; }
        [JsonProperty("remainingTerm", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int RemainingTerm { get; set; }
        [JsonProperty("goodDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime GoodDate { get; set; }
        [JsonProperty("loan", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public Loan_PostAsset_Request Loan { get; set; }
        [JsonProperty("address", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public AddressCreate_PostAsset_Request Address { get; set; }
        [JsonProperty("currentProducts", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<CurrentProduct_PostAsset_Request> CurrentProducts { get; set; }
        [JsonProperty("accountNumber", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AccountNumber { get; set; }
        [JsonProperty("phoneNumber", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; set; }
    }

    public class AssetRegistration_PostAsset_Request
    {
        [JsonProperty("primaryOwner", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PrimaryOwner { get; set; }
        [JsonProperty("secondaryOwner", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SecondaryOwner { get; set; }
        [JsonProperty("number", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Number { get; set; }
        [JsonProperty("state", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }
        [JsonProperty("expirationDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ExpirationDate { get; set; }
    }

    public class CurrentProduct_PostAsset_Request
    {
        [JsonProperty("refundAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int RefundAmount { get; set; }
        [JsonProperty("productType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ProductType { get; set; }
    }

    public class Loan_PostAsset_Request
    {
        [JsonProperty("loanAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int LoanAmount { get; set; }
        [JsonProperty("term", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Term { get; set; }
        [JsonProperty("rate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Rate { get; set; }
        [JsonProperty("monthlyPayment", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MonthlyPayment { get; set; }
        [JsonProperty("perDiem", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int PerDiem { get; set; }
        [JsonProperty("nextPaymentDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime NextPaymentDate { get; set; }
    }

    public class AssetType_PostAsset_Request
    { 
        [JsonProperty("assetType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AssetType { get; set; }
        [JsonProperty("vin", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Vin { get; set; }
        [JsonProperty("year", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Year { get; set; }
        [JsonProperty("make", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Make { get; set; }
        [JsonProperty("model", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Model { get; set; }
        [JsonProperty("nadaTrim", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string NadaTrim { get; set; }
        [JsonProperty("kbbTrim", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string KbbTrim { get; set; }
        [JsonProperty("bodyStyle", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string BodyStyle { get; set; }
        [JsonProperty("mileage", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Mileage { get; set; }
        [JsonProperty("assetCondition", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AssetCondition { get; set; }
        [JsonProperty("color", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Color { get; set; }
        [JsonProperty("assetUsage", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AssetUsage { get; set; }
        [JsonProperty("assetLienHolder", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public AssetLienHolder_PostAsset_Request AssetLienHolder { get; set; }
        [JsonProperty("assetRegistration", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public AssetRegistration_PostAsset_Request AssetRegistration { get; set; }
        [JsonProperty("assetInsurance", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public AssetInsurance_PostAsset_Request AssetInsurance { get; set; }
        [JsonProperty("selectedNadaValue", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int SelectedNadaValue { get; set; }
        [JsonProperty("selectedStickerType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SelectedStickerType { get; set; }
        [JsonProperty("actualNadaTradeIn", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int ActualNadaTradeIn { get; set; }
        [JsonProperty("selectedKbbValue", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int SelectedKbbValue { get; set; }
        [JsonProperty("actualKbbWholesale", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int ActualKbbWholesale { get; set; }
        [JsonProperty("msrp", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Msrp { get; set; }
        [JsonProperty("selectedTradeInValue", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int SelectedTradeInValue { get; set; }
        [JsonProperty("bookOutDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime BookOutDate { get; set; }
        [JsonProperty("contactId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ContactId { get; set; }
    }
}
