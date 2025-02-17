using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.AssetServiceDTO
{
    public class Option_AssetVehicleBookoutDownloan_Request
    {
        [JsonProperty("description", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
        [JsonProperty("code", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }
        [JsonProperty("tradeIn", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int TradeIn { get; set; }
        [JsonProperty("retailAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int RetailAmount { get; set; }
        [JsonProperty("loan", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Loan { get; set; }
        [JsonProperty("isIncluded", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsIncluded { get; set; }
        [JsonProperty("isAdded", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsAdded { get; set; }
        [JsonProperty("accessoryCategory", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AccessoryCategory { get; set; }
        [JsonProperty("isDisabled", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsDisabled { get; set; }
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("wholeSaleAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int WholeSaleAmount { get; set; }
        [JsonProperty("isDefault", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsDefault { get; set; }
    }

    public class VehicleType_AssetVehicleBookoutDownloan_Request
    { 
        [JsonProperty("vehicleDetails", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public VehicleDetails_AssetVehicleBookoutDownloan_Request VehicleDetails { get; set; }
        [JsonProperty("vehicleValuation", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public VehicleValuation_AssetVehicleBookoutDownloan_Request VehicleValuation { get; set; }
        [JsonProperty("selectedOptions", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<string> SelectedOptions { get; set; }
        [JsonProperty("dealId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DealId { get; set; }
        [JsonProperty("state", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }
        [JsonProperty("userId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string UserId { get; set; }
        [JsonProperty("contactId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ContactId { get; set; }
        [JsonProperty("mileage", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Mileage { get; set; }
    }

    public class VehicleDetails_AssetVehicleBookoutDownloan_Request
    {
        [JsonProperty("year", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Year { get; set; }
        [JsonProperty("make", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Make { get; set; }
        [JsonProperty("model", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Model { get; set; }
        [JsonProperty("bodyStyle", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string BodyStyle { get; set; }
        [JsonProperty("providerVehicleId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int ProviderVehicleId { get; set; }
        [JsonProperty("vehicleType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string VehicleType { get; set; }
        [JsonProperty("mileageClass", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MileageClass { get; set; }
        [JsonProperty("baseMsrp", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int BaseMsrp { get; set; }
        [JsonProperty("bodyType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string BodyType { get; set; }
        [JsonProperty("doors", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Doors { get; set; }
        [JsonProperty("trim", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Trim { get; set; }
        [JsonProperty("trim2", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Trim2 { get; set; }
        [JsonProperty("driveType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DriveType { get; set; }
        [JsonProperty("liters", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Liters { get; set; }
        [JsonProperty("engineConfiguration", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string EngineConfiguration { get; set; }
        [JsonProperty("cylinders", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Cylinders { get; set; }
        [JsonProperty("inductionType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string InductionType { get; set; }
        [JsonProperty("transmission", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Transmission { get; set; }
        [JsonProperty("fuelType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string FuelType { get; set; }
        [JsonProperty("wheels", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int Wheels { get; set; }
        [JsonProperty("curbWeight", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string CurbWeight { get; set; }
        [JsonProperty("gvw", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Gvw { get; set; }
        [JsonProperty("gcw", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Gcw { get; set; }
        [JsonProperty("ucgSubSegment", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string UcgSubSegment { get; set; }
        [JsonProperty("modelNumber", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ModelNumber { get; set; }
        [JsonProperty("rollUpVehicleId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string RollUpVehicleId { get; set; }
        [JsonProperty("baseCleanTrade", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int BaseCleanTrade { get; set; }
        [JsonProperty("baseAverageTrade", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int BaseAverageTrade { get; set; }
        [JsonProperty("baseRoughTrade", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int BaseRoughTrade { get; set; }
        [JsonProperty("baseCleanRetail", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int BaseCleanRetail { get; set; }
        [JsonProperty("baseLoan", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int BaseLoan { get; set; }
        [JsonProperty("averageMileage", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int AverageMileage { get; set; }
        [JsonProperty("mileageAdjustment", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MileageAdjustment { get; set; }
        [JsonProperty("adjustedCleanTrade", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int AdjustedCleanTrade { get; set; }
        [JsonProperty("adjustedAverageTrade", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int AdjustedAverageTrade { get; set; }
        [JsonProperty("adjustedrRoughTrade", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int AdjustedrRoughTrade { get; set; }
        [JsonProperty("adjustedCleanRetail", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int AdjustedCleanRetail { get; set; }
        [JsonProperty("adjustedLoan", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int AdjustedLoan { get; set; }
        [JsonProperty("maxMileageAdj", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MaxMileageAdj { get; set; }
        [JsonProperty("minMileageAdj", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinMileageAdj { get; set; }
        [JsonProperty("minAdjRetail", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinAdjRetail { get; set; }
        [JsonProperty("minadjCleanTrade", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinadjCleanTrade { get; set; }
        [JsonProperty("minAdjaverageTrade", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinAdjaverageTrade { get; set; }
        [JsonProperty("minAdjRoughTrade", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinAdjRoughTrade { get; set; }
        [JsonProperty("minAdjLoan", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinAdjLoan { get; set; }
        [JsonProperty("minAdjRetailForLoan", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MinAdjRetailForLoan { get; set; }
        [JsonProperty("vid", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Vid { get; set; }
        [JsonProperty("vehicleClass", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string VehicleClass { get; set; }
        [JsonProperty("vehicleName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string VehicleName { get; set; }
        [JsonProperty("modelMarketName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ModelMarketName { get; set; }
        [JsonProperty("modelYearId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int ModelYearId { get; set; }
        [JsonProperty("trimId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int TrimId { get; set; }
        [JsonProperty("modelPlusTrimName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ModelPlusTrimName { get; set; }
        [JsonProperty("bedLength", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string BedLength { get; set; }
        [JsonProperty("genericBodyStyle", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string GenericBodyStyle { get; set; }
        [JsonProperty("oemBodyStyle", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string OemBodyStyle { get; set; }
        [JsonProperty("sortOrder", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int SortOrder { get; set; }
        [JsonProperty("isConsumer", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsConsumer { get; set; }
    }

    public class VehicleValuation_AssetVehicleBookoutDownloan_Request
    {
        [JsonProperty("baseRetailAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int BaseRetailAmount { get; set; }
        [JsonProperty("baseWholesaleAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int BaseWholesaleAmount { get; set; }
        [JsonProperty("baseTradeInAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int BaseTradeInAmount { get; set; }
        [JsonProperty("options", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<Option_AssetVehicleBookoutDownloan_Request> Options { get; set; }
        [JsonProperty("mileageAdjustment", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MileageAdjustment { get; set; }
        [JsonProperty("retailOptionAdjustment", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int RetailOptionAdjustment { get; set; }
        [JsonProperty("wholsaleOptionAdjustment", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int WholsaleOptionAdjustment { get; set; }
        [JsonProperty("selectedOptionsRetailPriceSum", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int SelectedOptionsRetailPriceSum { get; set; }
        [JsonProperty("selectedOptionsWholeSalePriceSum", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int SelectedOptionsWholeSalePriceSum { get; set; }
    }
}
