using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.LenderServiceDTO
{
    public class GeneralInfo_PostLenders_Request
    {
        [JsonProperty("defaultValuationMethods", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> DefaultValuationMethods { get; set; }
        [JsonProperty("daysToFirstPaymentGreen", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int DaysToFirstPaymentGreen { get; set; }
        [JsonProperty("daysToFirstPaymentYellow", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int DaysToFirstPaymentYellow { get; set; }
        [JsonProperty("maxDtiGreen", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxDtiGreen { get; set; }
        [JsonProperty("maxDtiYellow", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxDtiYellow { get; set; }
        [JsonProperty("maxPtiGreen", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxPtiGreen { get; set; }
        [JsonProperty("maxPtiYellow", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxPtiYellow { get; set; }
        [JsonProperty("availableMarkupIncrements", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AvailableMarkupIncrements { get; set; }
        [JsonProperty("maxMileageGreen", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxMileageGreen { get; set; }
        [JsonProperty("maxMileageYellow", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxMileageYellow { get; set; }
        [JsonProperty("maxAgeGreen", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxAgeGreen { get; set; }
        [JsonProperty("maxAgeYellow", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxAgeYellow { get; set; }
        [JsonProperty("minPrimaryFicoGreen", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinPrimaryFicoGreen { get; set; }
        [JsonProperty("minPrimaryFicoYellow", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinPrimaryFicoYellow { get; set; }
        [JsonProperty("minSecondaryFicoGreen", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinSecondaryFicoGreen { get; set; }
        [JsonProperty("minSecondaryFicoYellow", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinSecondaryFicoYellow { get; set; }
        [JsonProperty("approvalDaysGreen", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int ApprovalDaysGreen { get; set; }
        [JsonProperty("approvalDaysYellow", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int ApprovalDaysYellow { get; set; }
        [JsonProperty("maxCashOutGreen", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxCashOutGreen { get; set; }
        [JsonProperty("maxCashOutYellow", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxCashOutYellow { get; set; }
        [JsonProperty("maxFlatPercentGreen", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxFlatPercentGreen { get; set; }
        [JsonProperty("maxFlatPercentYellow", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxFlatPercentYellow { get; set; }
        [JsonProperty("maxGapGreen", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxGapGreen { get; set; }
        [JsonProperty("maxGapYellow", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxGapYellow { get; set; }
        [JsonProperty("gapLtvLimit", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int GapLtvLimit { get; set; }
        [JsonProperty("maxFlatGreen", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxFlatGreen { get; set; }
        [JsonProperty("maxFlatYellow", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxFlatYellow { get; set; }
        [JsonProperty("flatPercent", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int FlatPercent { get; set; }
        [JsonProperty("maxOtherProducts", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxOtherProducts { get; set; }
        [JsonProperty("experianDefaultScore", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ExperianDefaultScore { get; set; }
        [JsonProperty("secondaryBureau", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SecondaryBureau { get; set; }
        [JsonProperty("primaryBureau", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PrimaryBureau { get; set; }
        [JsonProperty("fundingFeeGreen", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int FundingFeeGreen { get; set; }
        [JsonProperty("fundingFeeYellow", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int FundingFeeYellow { get; set; }
        [JsonProperty("allowEmployerZip", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool AllowEmployerZip { get; set; }
        [JsonProperty("statedFunds", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int StatedFunds { get; set; }
        [JsonProperty("expectedFunds", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int ExpectedFunds { get; set; }
        [JsonProperty("achDiscount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int AchDiscount { get; set; }
        [JsonProperty("maxVsc", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxVsc { get; set; }
        [JsonProperty("maxProduct", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxProduct { get; set; }
        [JsonProperty("requirements", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Requirements { get; set; }
        [JsonProperty("useAprBasedCalculation", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool UseAprBasedCalculation { get; set; }
        [JsonProperty("contractDateForUsingAprBasedCalculations", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime ContractDateForUsingAprBasedCalculations { get; set; }
        [JsonProperty("maxVrp", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxVrp { get; set; }
        [JsonProperty("creditReport", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string CreditReport { get; set; }
    }

    public class LenderType_PostLenders_Request
    { 
        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("address", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Address { get; set; }
        [JsonProperty("state", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }
        [JsonProperty("postCode", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PostCode { get; set; }
        [JsonProperty("contactPerson", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ContactPerson { get; set; }
        [JsonProperty("contactPhone", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ContactPhone { get; set; }
        [JsonProperty("city", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }
        [JsonProperty("code", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }
        [JsonProperty("rank", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Rank { get; set; }
        [JsonProperty("ltvType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LtvType { get; set; }
        [JsonProperty("useBothLtv", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool UseBothLtv { get; set; }
        [JsonProperty("isOpenLending", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsOpenLending { get; set; }
        [JsonProperty("isDocGen2", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsDocGen2 { get; set; }
        [JsonProperty("isDefi", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsDefi { get; set; }
        [JsonProperty("meridianLenderReferenceId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MeridianLenderReferenceId { get; set; }
        [JsonProperty("meridianOrgReferenceId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MeridianOrgReferenceId { get; set; }
        [JsonProperty("lenderPurposeType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LenderPurposeType { get; set; }
        [JsonProperty("acumaticaId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AcumaticaId { get; set; }
        [JsonProperty("isGenericAprCalculation", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsGenericAprCalculation { get; set; }
        [JsonProperty("isAcumaticaSpecialProcessing", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsAcumaticaSpecialProcessing { get; set; }
        [JsonProperty("autoSubmitLoanApplication", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool AutoSubmitLoanApplication { get; set; }
        [JsonProperty("numericId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int NumericId { get; set; }
        [JsonProperty("isFlStampFee", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsFlStampFee { get; set; }
        [JsonProperty("isDealertrack", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsDealertrack { get; set; }
        [JsonProperty("dealertrackId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int DealertrackId { get; set; }
        [JsonProperty("subRank", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int SubRank { get; set; }
        [JsonProperty("isRestrictDr", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsRestrictDr { get; set; }
        [JsonProperty("generalInfo", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public GeneralInfo_PostLenders_Request GeneralInfo { get; set; }
    }

}
