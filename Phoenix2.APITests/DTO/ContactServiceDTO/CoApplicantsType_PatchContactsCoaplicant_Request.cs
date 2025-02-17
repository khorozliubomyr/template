using Fare;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.APITests.DTO.ContactServiceDTO
{
    public class Address_PatchContactsCoaplicant_Request
    {
        [JsonProperty("isCurrent", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsCurrent { get; set; }
        [JsonProperty("includeInDti", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IncludeInDti { get; set; }
        [JsonProperty("monthsAtAddress", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MonthsAtAddress { get; set; }
        [JsonProperty("streetLine1", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string StreetLine1 { get; set; }
        [JsonProperty("streetLine2", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string StreetLine2 { get; set; }
        [JsonProperty("city", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }
        [JsonProperty("state", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public Enum State { get; set; }
        [JsonProperty("zip", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Zip { get; set; }
        [JsonProperty("type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
        [JsonProperty("county", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string County { get; set; }
    }

    public class Employment_PatchContactsCoaplicant_Request
    {
        [JsonProperty("monthsAtJob", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MonthsAtJob { get; set; }
        [JsonProperty("jobTitle", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string JobTitle { get; set; }
        [JsonProperty("employmentType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string EmploymentType { get; set; }
        [JsonProperty("companyName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string CompanyName { get; set; }
        [JsonProperty("monthlyIncomeAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MonthlyIncomeAmount { get; set; }
        [JsonProperty("isCurrent", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsCurrent { get; set; }
        [JsonProperty("isPrimary", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsPrimary { get; set; }
        [JsonProperty("streetLine1", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string StreetLine1 { get; set; }
        [JsonProperty("streetLine2", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string StreetLine2 { get; set; }
        [JsonProperty("city", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }
        [JsonProperty("state", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public Enum  State { get; set; }
        [JsonProperty("zip", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Zip { get; set; }
        [JsonProperty("type", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }
        [JsonProperty("county", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string County { get; set; }
    }

    public class OtherIncome_PatchContactsCoaplicant_Request
    {
        [JsonProperty("monthlyAmount", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MonthlyAmount { get; set; }
        [JsonProperty("incomeType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string IncomeType { get; set; }
        [JsonProperty("isCurrent", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsCurrent { get; set; }
        [JsonProperty("monthsAtJob", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public int MonthsAtJob { get; set; }
    }

    public class Reference_PatchContactsCoaplicant_Request
    {
        [JsonProperty("fullName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string FullName { get; set; }
        [JsonProperty("phoneNumber", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; set; }
        [JsonProperty("emailAddress", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string EmailAddress { get; set; }
        [JsonProperty("streetLine1", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string StreetLine1 { get; set; }
        [JsonProperty("streetLine2", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string StreetLine2 { get; set; }
        [JsonProperty("city", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }
        [JsonProperty("state", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public Enum State { get; set; }
        [JsonProperty("zip", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Zip { get; set; }
        [JsonProperty("addressType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string AddressType { get; set; }
        [JsonProperty("county", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string County { get; set; }
        [JsonProperty("relationshipType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string RelationshipType { get; set; }
    }
    class CoApplicantsType_PatchContactsCoaplicant_Request
    { 
        [JsonProperty("firstName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string FirstName { get; set; }
        [JsonProperty("middleInitial", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MiddleInitial { get; set; }
        [JsonProperty("lastName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string LastName { get; set; }
        [JsonProperty("suffix", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Suffix { get; set; }
        [JsonProperty("maidenName", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MaidenName { get; set; }
        [JsonProperty("ssn", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Ssn { get; set; }
        [JsonProperty("dateOfBirth", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime DateOfBirth { get; set; }
        [JsonProperty("homePhone", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string HomePhone { get; set; }
        [JsonProperty("workPhone", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string WorkPhone { get; set; }
        [JsonProperty("workPhoneExtension", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string WorkPhoneExtension { get; set; }
        [JsonProperty("cellPhone", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string CellPhone { get; set; }
        [JsonProperty("email", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }
        [JsonProperty("workEmail", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string WorkEmail { get; set; }
        [JsonProperty("militaryStatus", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MilitaryStatus { get; set; }
        [JsonProperty("maritalStatus", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string MaritalStatus { get; set; }
        [JsonProperty("driveLicenseNumber", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string DriveLicenseNumber { get; set; }
        [JsonProperty("driverLicenseExpireDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime DriverLicenseExpireDate { get; set; }
        [JsonProperty("driverLicenseIssuesOnDate", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public DateTime DriverLicenseIssuesOnDate { get; set; }
        [JsonProperty("driverLicenseState", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public Enum DriverLicenseState { get; set; }
        [JsonProperty("isMilitaryLendingActAvailable", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsMilitaryLendingActAvailable { get; set; }
        [JsonProperty("residencyStatusType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ResidencyStatusType { get; set; }
        [JsonProperty("isDeceased", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsDeceased { get; set; }
        [JsonProperty("isOptOut", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public bool IsOptOut { get; set; }
        [JsonProperty("referralContactId", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string ReferralContactId { get; set; }
        [JsonProperty("relationshipType", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public string RelationshipType { get; set; }
        [JsonProperty("addresses", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<Address_PatchContactsCoaplicant_Request> Addresses { get; set; }
        [JsonProperty("employments", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<Employment_PatchContactsCoaplicant_Request> Employments { get; set; }
        [JsonProperty("otherIncomes", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<OtherIncome_PatchContactsCoaplicant_Request> OtherIncomes { get; set; }
        [JsonProperty("references", Required = Required.Default, NullValueHandling = NullValueHandling.Ignore)]
        public List<Reference_PatchContactsCoaplicant_Request> References { get; set; }
    }
}
