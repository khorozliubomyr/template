using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.ContactServiceDTO
{
    class CoApplicantsType_GetContactsCoaplicant_Response
    { 
        [JsonProperty("coApplicantId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string CoApplicantId { get; set; }
        [JsonProperty("relationshipType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string RelationshipType { get; set; }
        [JsonProperty("id", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Id { get; set; }
        [JsonProperty("numericId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int NumericId { get; set; }
        [JsonProperty("firstName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }
        [JsonProperty("middleInitial", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MiddleInitial { get; set; }
        [JsonProperty("lastName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }
    }
}
