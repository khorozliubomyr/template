using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.UserServiceDTO
{
    public class UserType_PostUsers_Request
    { 
        [JsonProperty("firstName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }
        [JsonProperty("lastName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }
        [JsonProperty("email", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
        [JsonProperty("phoneNumber", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; set; }
        [JsonProperty("phoneExtension", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneExtension { get; set; }
        [JsonProperty("isActive", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsActive { get; set; }
        [JsonProperty("isDeleted", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsDeleted { get; set; }
        [JsonProperty("phoneSystemUserId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int PhoneSystemUserId { get; set; }
        [JsonProperty("trainingPeriodId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int TrainingPeriodId { get; set; }
        [JsonProperty("officeLocationId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string OfficeLocationId { get; set; }
        [JsonProperty("terminationDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime TerminationDate { get; set; }
        [JsonProperty("paySystemUserId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PaySystemUserId { get; set; }
        [JsonProperty("isAcumaticaRecordExist", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsAcumaticaRecordExist { get; set; }
    }
}
