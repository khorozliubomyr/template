using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.LenderServiceDTO
{
    public class CreatedByUpdateProduct_PatchProductTypeExclusionRules_Request
    {
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("email", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

    public class LenderType_PatchProductTypeExclusionRules_Request
    { 
        [JsonProperty("isCurrent", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsCurrent { get; set; }
        [JsonProperty("isDeleted", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsDeleted { get; set; }
        [JsonProperty("productType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ProductType { get; set; }
        [JsonProperty("createdByupdateProduct", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public CreatedByUpdateProduct_PatchProductTypeExclusionRules_Request CreatedByupdateProduct { get; set; }
        [JsonProperty("createdDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime CreatedDate { get; set; }
        [JsonProperty("updatedByupdateProduct", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public UpdatedByUpdateProduct_PatchProductTypeExclusionRules_Request UpdatedByupdateProduct { get; set; }
        [JsonProperty("updatedDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime UpdatedDate { get; set; }
    }

    public class UpdatedByUpdateProduct_PatchProductTypeExclusionRules_Request
    {
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("email", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
        [JsonProperty("name", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }
}
