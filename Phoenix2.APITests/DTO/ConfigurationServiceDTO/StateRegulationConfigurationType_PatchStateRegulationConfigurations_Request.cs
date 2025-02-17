using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.ConfigurationServiceDTO
{
    public class StateRegulationConfigurationType_PatchStateRegulationConfigurations_Request
    { 
        [JsonProperty("state", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string State { get; set; }
        [JsonProperty("titleHoldingStatus", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool TitleHoldingStatus { get; set; }
        [JsonProperty("sorRequiredStatus", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool SorRequiredStatus { get; set; }
        [JsonProperty("addStatus", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool AddStatus { get; set; }
        [JsonProperty("dropStatus", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool DropStatus { get; set; }
        [JsonProperty("notaryRequiredStatus", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool NotaryRequiredStatus { get; set; }
        [JsonProperty("titleDocuments", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string TitleDocuments { get; set; }
        [JsonProperty("salesTaxInformation", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SalesTaxInformation { get; set; }
        [JsonProperty("specificRequirements", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string SpecificRequirements { get; set; }
        [JsonProperty("isAllowProductAndSalesTax", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsAllowProductAndSalesTax { get; set; }
        [JsonProperty("isOutOfStateTitleAllowed", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsOutOfStateTitleAllowed { get; set; }
    }
}
