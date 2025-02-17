using Newtonsoft.Json;
using NUnit.Framework;
using Phoenix2.APITests.DTO.ContactServiceDTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Phoenix2.APITests.DTO.ContactServiceDTO.States;
using static Phoenix2.APITests.Credentials;
using Phoenix2.APITests.Framework;

namespace Phoenix2.APITests.Tests
{
    class ContactService
    {
        private APIHelper<string> helper;
        private ClientCredentialProvider credprovider;
        private string acessToken;
        [SetUp]
        public void APIHelper()
        {
            helper = new APIHelper<string>();
            credprovider = new ClientCredentialProvider();
            acessToken = credprovider.GetClientCredentialsTokenAsync().Result;
        }
        [Test]
        public void ContactService_CoApplicantsType_GetContactsCoaplicant_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("contact-service/contacts/" + GuidContactId + "/co-applicants/" + CoApplicantId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<CoApplicantsType_GetContactsCoaplicant_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.CoApplicantId, Is.EqualTo(CoApplicantId));
                Assert.That(responseContent.Id, Is.EqualTo(GuidContactId));
            });
        }

        [Test]
        [TestCase(GuidContactId, InvalidCoContactId)]
        [TestCase(InvalidGuidContactId, CoApplicantId)]
        [TestCase(InvalidGuidContactId, InvalidCoContactId)]
        public void ContactService_CoApplicantsType_GetContactsCoaplicant_NegativeScenario(string ContactId, string CoApplicantId)
        {
            /// Arrange
            RestClient client = helper.SetUrl("contact-service/contacts/" + ContactId + "/co-applicants/" + CoApplicantId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_ContatService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.ErrorType, Is.EqualTo("EntityNotFound"));
                Assert.That(responseContent.ErrorMessage, Is.EqualTo("Entity type of Phoenix2.ContactService.Domain.Entities.CoApplicant with id '" + CoApplicantId + "' not found"));
            });
        }
        [Test]
        public void ContactService_CoApplicantsType_PatchContactsCoaplicant_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("contact-service/contacts/" + GuidContactId + "/co-applicants/" + CoApplicantId);
            string Name = helper.GenerateDocName(6);
            CoApplicantsType_PatchContactsCoaplicant_Request contactsCoaplicant = new CoApplicantsType_PatchContactsCoaplicant_Request();
            contactsCoaplicant.FirstName = Name;
            contactsCoaplicant.MiddleInitial = "string";
            contactsCoaplicant.LastName = "string";
            contactsCoaplicant.Suffix = "string";
            contactsCoaplicant.MaidenName = "string";
            contactsCoaplicant.Ssn = "string";
            contactsCoaplicant.DateOfBirth = DateTime.Now;
            contactsCoaplicant.HomePhone = "1112223334";
            contactsCoaplicant.WorkPhone = "1112223334";
            contactsCoaplicant.WorkPhoneExtension = "string";
            contactsCoaplicant.CellPhone = "1112223334";
            contactsCoaplicant.Email = "string";
            contactsCoaplicant.WorkEmail = "string";
            contactsCoaplicant.MilitaryStatus = "W10";
            contactsCoaplicant.MaritalStatus = "Widowed";
            contactsCoaplicant.DriveLicenseNumber = "string";
            contactsCoaplicant.DriverLicenseExpireDate = DateTime.Now;
            contactsCoaplicant.DriverLicenseIssuesOnDate = DateTime.Now;
            contactsCoaplicant.DriverLicenseState = State.AL;
            contactsCoaplicant.IsMilitaryLendingActAvailable = true;
            contactsCoaplicant.ResidencyStatusType = "Citizen";
            contactsCoaplicant.IsDeceased = true;
            contactsCoaplicant.IsOptOut = true;
            contactsCoaplicant.ReferralContactId = null;
            contactsCoaplicant.RelationshipType = "Spouse";
            Address_PatchContactsCoaplicant_Request address = new Address_PatchContactsCoaplicant_Request();
            address.IsCurrent = true;
            address.IncludeInDti = true;
            address.MonthsAtAddress = 0;
            address.StreetLine1 = "string";
            address.StreetLine2 = "string";
            address.City = "string";
            address.State = State.AL;
            address.Zip = "string";
            address.Type = "NotSet";
            address.County = "string";
            Employment_PatchContactsCoaplicant_Request employment = new Employment_PatchContactsCoaplicant_Request();
            employment.MonthsAtJob = 0;
            employment.JobTitle = "string";
            employment.EmploymentType = "FullTime";
            employment.CompanyName = "string";
            employment.MonthlyIncomeAmount = 0;
            employment.IsCurrent = true;
            employment.IsPrimary = true;
            employment.StreetLine1 = "string";
            employment.StreetLine2 = "string";
            employment.City = "string";
            employment.State = State.AL;
            employment.Zip = "string";
            employment.Type = "NotSet";
            employment.County = "string";
            OtherIncome_PatchContactsCoaplicant_Request otherIncome = new OtherIncome_PatchContactsCoaplicant_Request();
            otherIncome.MonthlyAmount = 0;
            otherIncome.IncomeType = "Other";
            otherIncome.IsCurrent = true;
            otherIncome.MonthsAtJob = 0;
            Reference_PatchContactsCoaplicant_Request reference = new Reference_PatchContactsCoaplicant_Request();
            reference.FullName = "string";
            reference.PhoneNumber = "string";
            reference.EmailAddress = "string";
            reference.StreetLine1 = "string";
            reference.StreetLine2 = "string";
            reference.City = "string";
            reference.State = State.AL;
            reference.Zip = "string";
            reference.AddressType = "NotSet";
            reference.County = "string";
            reference.RelationshipType = "Spouse";
            List<Address_PatchContactsCoaplicant_Request> addresses = new List<Address_PatchContactsCoaplicant_Request> { address };
            contactsCoaplicant.Addresses = addresses;
            List<Employment_PatchContactsCoaplicant_Request> employments = new List<Employment_PatchContactsCoaplicant_Request> { employment };
            contactsCoaplicant.Employments = employments;
            List<OtherIncome_PatchContactsCoaplicant_Request> otherIncomes = new List<OtherIncome_PatchContactsCoaplicant_Request> { otherIncome };
            contactsCoaplicant.OtherIncomes = otherIncomes;
            List<Reference_PatchContactsCoaplicant_Request> references = new List<Reference_PatchContactsCoaplicant_Request> { reference };
            contactsCoaplicant.References = references;
            string payload = JsonConvert.SerializeObject(contactsCoaplicant, Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<CoApplicantsType_GetContactsCoaplicant_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.CoApplicantId, Is.EqualTo(CoApplicantId));
                Assert.That(responseContent.Id, Is.EqualTo(GuidContactId));
            });
        }
        [Test]
        [TestCase(GuidContactId, InvalidCoContactId)]
        [TestCase(InvalidGuidContactId, CoApplicantId)]
        [TestCase(InvalidGuidContactId, InvalidCoContactId)]
        public void ContactService_CoApplicantsType_PatchContactsCoaplicant_NegativeScenario(string ContactId, string CoApplicantId)
        {
            /// Arrange
            RestClient client = helper.SetUrl("contact-service/contacts/" + ContactId + "/co-applicants/" + CoApplicantId);
            string Name = helper.GenerateDocName(6);
            CoApplicantsType_PatchContactsCoaplicant_Request contactsCoaplicant = new CoApplicantsType_PatchContactsCoaplicant_Request();
            contactsCoaplicant.FirstName = Name;
            contactsCoaplicant.MiddleInitial = "string";
            contactsCoaplicant.LastName = "string";
            contactsCoaplicant.Suffix = "string";
            contactsCoaplicant.MaidenName = "string";
            contactsCoaplicant.Ssn = "string";
            contactsCoaplicant.DateOfBirth = DateTime.Now;
            contactsCoaplicant.HomePhone = "1112223334";
            contactsCoaplicant.WorkPhone = "1112223334";
            contactsCoaplicant.WorkPhoneExtension = "string";
            contactsCoaplicant.CellPhone = "1112223334";
            contactsCoaplicant.Email = "string";
            contactsCoaplicant.WorkEmail = "string";
            contactsCoaplicant.MilitaryStatus = "W10";
            contactsCoaplicant.MaritalStatus = "Widowed";
            contactsCoaplicant.DriveLicenseNumber = "string";
            contactsCoaplicant.DriverLicenseExpireDate = DateTime.Now;
            contactsCoaplicant.DriverLicenseIssuesOnDate = DateTime.Now;
            contactsCoaplicant.DriverLicenseState = State.AL;
            contactsCoaplicant.IsMilitaryLendingActAvailable = true;
            contactsCoaplicant.ResidencyStatusType = "Citizen";
            contactsCoaplicant.IsDeceased = true;
            contactsCoaplicant.IsOptOut = true;
            contactsCoaplicant.ReferralContactId = null;
            contactsCoaplicant.RelationshipType = "Spouse";
            Address_PatchContactsCoaplicant_Request address = new Address_PatchContactsCoaplicant_Request();
            address.IsCurrent = true;
            address.IncludeInDti = true;
            address.MonthsAtAddress = 0;
            address.StreetLine1 = "string";
            address.StreetLine2 = "string";
            address.City = "string";
            address.State = State.AL;
            address.Zip = "string";
            address.Type = "NotSet";
            address.County = "string";
            Employment_PatchContactsCoaplicant_Request employment = new Employment_PatchContactsCoaplicant_Request();
            employment.MonthsAtJob = 0;
            employment.JobTitle = "string";
            employment.EmploymentType = "FullTime";
            employment.CompanyName = "string";
            employment.MonthlyIncomeAmount = 0;
            employment.IsCurrent = true;
            employment.IsPrimary = true;
            employment.StreetLine1 = "string";
            employment.StreetLine2 = "string";
            employment.City = "string";
            employment.State = State.AL;
            employment.Zip = "string";
            employment.Type = "NotSet";
            employment.County = "string";
            OtherIncome_PatchContactsCoaplicant_Request otherIncome = new OtherIncome_PatchContactsCoaplicant_Request();
            otherIncome.MonthlyAmount = 0;
            otherIncome.IncomeType = "Other";
            otherIncome.IsCurrent = true;
            otherIncome.MonthsAtJob = 0;
            Reference_PatchContactsCoaplicant_Request reference = new Reference_PatchContactsCoaplicant_Request();
            reference.FullName = "string";
            reference.PhoneNumber = "string";
            reference.EmailAddress = "string";
            reference.StreetLine1 = "string";
            reference.StreetLine2 = "string";
            reference.City = "string";
            reference.State = State.AL;
            reference.Zip = "string";
            reference.AddressType = "NotSet";
            reference.County = "string";
            reference.RelationshipType = "Spouse";
            List<Address_PatchContactsCoaplicant_Request> addresses = new List<Address_PatchContactsCoaplicant_Request> { address };
            contactsCoaplicant.Addresses = addresses;
            List<Employment_PatchContactsCoaplicant_Request> employments = new List<Employment_PatchContactsCoaplicant_Request> { employment };
            contactsCoaplicant.Employments = employments;
            List<OtherIncome_PatchContactsCoaplicant_Request> otherIncomes = new List<OtherIncome_PatchContactsCoaplicant_Request> { otherIncome };
            contactsCoaplicant.OtherIncomes = otherIncomes;
            List<Reference_PatchContactsCoaplicant_Request> references = new List<Reference_PatchContactsCoaplicant_Request> { reference };
            contactsCoaplicant.References = references;
            string payload = JsonConvert.SerializeObject(contactsCoaplicant, Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_ContatService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.ErrorType, Is.EqualTo("EntityNotFound"));
            });
        }

        [Test]
        public void ContactService_CoApplicantsType_PostContactsCoAplicants_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("contact-service/contacts/" + GuidContactId + "/co-applicants");
            string Name = helper.GenerateDocName(6);
            CoApplicantsType_PatchContactsCoaplicant_Request contactsCoaplicant = new CoApplicantsType_PatchContactsCoaplicant_Request();
            contactsCoaplicant.FirstName = Name;
            contactsCoaplicant.MiddleInitial = "string";
            contactsCoaplicant.LastName = "string";
            contactsCoaplicant.Suffix = "string";
            contactsCoaplicant.MaidenName = "string";
            contactsCoaplicant.Ssn = "string";
            contactsCoaplicant.DateOfBirth = DateTime.Now;
            contactsCoaplicant.HomePhone = "1234566666";
            contactsCoaplicant.WorkPhone = "1234566666";
            contactsCoaplicant.WorkPhoneExtension = "string";
            contactsCoaplicant.CellPhone = "1234566666";
            contactsCoaplicant.Email = "string";
            contactsCoaplicant.WorkEmail = "string";
            contactsCoaplicant.MilitaryStatus = "W10";
            contactsCoaplicant.MaritalStatus = "Widowed";
            contactsCoaplicant.DriveLicenseNumber = "string";
            contactsCoaplicant.DriverLicenseExpireDate = DateTime.Now;
            contactsCoaplicant.DriverLicenseIssuesOnDate = DateTime.Now;
            contactsCoaplicant.DriverLicenseState = State.AL;
            contactsCoaplicant.IsMilitaryLendingActAvailable = true;
            contactsCoaplicant.ResidencyStatusType = "Citizen";
            contactsCoaplicant.IsDeceased = true;
            contactsCoaplicant.IsOptOut = true;
            contactsCoaplicant.ReferralContactId = null;
            contactsCoaplicant.RelationshipType = "Spouse";
            Address_PatchContactsCoaplicant_Request address = new Address_PatchContactsCoaplicant_Request();
            address.IsCurrent = true;
            address.IncludeInDti = true;
            address.MonthsAtAddress = 0;
            address.StreetLine1 = "string";
            address.StreetLine2 = "string";
            address.City = "string";
            address.State = State.AL;
            address.Zip = "string";
            address.Type = "NotSet";
            address.County = "string";
            Employment_PatchContactsCoaplicant_Request employment = new Employment_PatchContactsCoaplicant_Request();
            employment.MonthsAtJob = 0;
            employment.JobTitle = "string";
            employment.EmploymentType = "FullTime";
            employment.CompanyName = "string";
            employment.MonthlyIncomeAmount = 0;
            employment.IsCurrent = true;
            employment.IsPrimary = true;
            employment.StreetLine1 = "string";
            employment.StreetLine2 = "string";
            employment.City = "string";
            employment.State = State.AL;
            employment.Zip = "string";
            employment.Type = "NotSet";
            employment.County = "string";
            OtherIncome_PatchContactsCoaplicant_Request otherIncome = new OtherIncome_PatchContactsCoaplicant_Request();
            otherIncome.MonthlyAmount = 0;
            otherIncome.IncomeType = "Other";
            otherIncome.IsCurrent = true;
            otherIncome.MonthsAtJob = 0;
            Reference_PatchContactsCoaplicant_Request reference = new Reference_PatchContactsCoaplicant_Request();
            reference.FullName = "string";
            reference.PhoneNumber = "string";
            reference.EmailAddress = "string";
            reference.StreetLine1 = "string";
            reference.StreetLine2 = "string";
            reference.City = "string";
            reference.State = State.AL;
            reference.Zip = "string";
            reference.AddressType = "NotSet";
            reference.County = "string";
            reference.RelationshipType = "Spouse";
            List<Address_PatchContactsCoaplicant_Request> addresses = new List<Address_PatchContactsCoaplicant_Request> { address };
            contactsCoaplicant.Addresses = addresses;
            List<Employment_PatchContactsCoaplicant_Request> employments = new List<Employment_PatchContactsCoaplicant_Request> { employment };
            contactsCoaplicant.Employments = employments;
            List<OtherIncome_PatchContactsCoaplicant_Request> otherIncomes = new List<OtherIncome_PatchContactsCoaplicant_Request> { otherIncome };
            contactsCoaplicant.OtherIncomes = otherIncomes;
            List<Reference_PatchContactsCoaplicant_Request> references = new List<Reference_PatchContactsCoaplicant_Request> { reference };
            contactsCoaplicant.References = references;
            string payload = JsonConvert.SerializeObject(contactsCoaplicant, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<CoApplicantsType_GetContactsCoaplicant_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.FirstName, Is.EqualTo(Name));
            });
        }

        [Test]
        public void ContactService_CoApplicantsType_PostContactsCoAplicants_NegativeScenario_InvalidContactId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("contact-service/contacts/" + InvalidGuidContactId + "/co-applicants");
            string Name = helper.GenerateDocName(6);
            CoApplicantsType_PatchContactsCoaplicant_Request contactsCoaplicant = new CoApplicantsType_PatchContactsCoaplicant_Request();
            contactsCoaplicant.FirstName = Name;
            contactsCoaplicant.MiddleInitial = "string";
            contactsCoaplicant.LastName = "string";
            contactsCoaplicant.Suffix = "string";
            contactsCoaplicant.MaidenName = "string";
            contactsCoaplicant.Ssn = "string";
            contactsCoaplicant.DateOfBirth = DateTime.Now;
            contactsCoaplicant.HomePhone = "1234555555";
            contactsCoaplicant.WorkPhone = "1234555555";
            contactsCoaplicant.WorkPhoneExtension = "string";
            contactsCoaplicant.CellPhone = "1234555555";
            contactsCoaplicant.Email = "string";
            contactsCoaplicant.WorkEmail = "string";
            contactsCoaplicant.MilitaryStatus = "W10";
            contactsCoaplicant.MaritalStatus = "Widowed";
            contactsCoaplicant.DriveLicenseNumber = "string";
            contactsCoaplicant.DriverLicenseExpireDate = DateTime.Now;
            contactsCoaplicant.DriverLicenseIssuesOnDate = DateTime.Now;
            contactsCoaplicant.DriverLicenseState = State.AL;
            contactsCoaplicant.IsMilitaryLendingActAvailable = true;
            contactsCoaplicant.ResidencyStatusType = "Citizen";
            contactsCoaplicant.IsDeceased = true;
            contactsCoaplicant.IsOptOut = true;
            contactsCoaplicant.ReferralContactId = null;
            contactsCoaplicant.RelationshipType = "Spouse";
            Address_PatchContactsCoaplicant_Request address = new Address_PatchContactsCoaplicant_Request();
            address.IsCurrent = true;
            address.IncludeInDti = true;
            address.MonthsAtAddress = 0;
            address.StreetLine1 = "string";
            address.StreetLine2 = "string";
            address.City = "string";
            address.State = State.AL;
            address.Zip = "string";
            address.Type = "NotSet";
            address.County = "string";
            Employment_PatchContactsCoaplicant_Request employment = new Employment_PatchContactsCoaplicant_Request();
            employment.MonthsAtJob = 0;
            employment.JobTitle = "string";
            employment.EmploymentType = "FullTime";
            employment.CompanyName = "string";
            employment.MonthlyIncomeAmount = 0;
            employment.IsCurrent = true;
            employment.IsPrimary = true;
            employment.StreetLine1 = "string";
            employment.StreetLine2 = "string";
            employment.City = "string";
            employment.State = State.AL;
            employment.Zip = "string";
            employment.Type = "NotSet";
            employment.County = "string";
            OtherIncome_PatchContactsCoaplicant_Request otherIncome = new OtherIncome_PatchContactsCoaplicant_Request();
            otherIncome.MonthlyAmount = 0;
            otherIncome.IncomeType = "Other";
            otherIncome.IsCurrent = true;
            otherIncome.MonthsAtJob = 0;
            Reference_PatchContactsCoaplicant_Request reference = new Reference_PatchContactsCoaplicant_Request();
            reference.FullName = "string";
            reference.PhoneNumber = "string";
            reference.EmailAddress = "string";
            reference.StreetLine1 = "string";
            reference.StreetLine2 = "string";
            reference.City = "string";
            reference.State = State.AL;
            reference.Zip = "string";
            reference.AddressType = "NotSet";
            reference.County = "string";
            reference.RelationshipType = "Spouse";
            List<Address_PatchContactsCoaplicant_Request> addresses = new List<Address_PatchContactsCoaplicant_Request> { address };
            contactsCoaplicant.Addresses = addresses;
            List<Employment_PatchContactsCoaplicant_Request> employments = new List<Employment_PatchContactsCoaplicant_Request> { employment };
            contactsCoaplicant.Employments = employments;
            List<OtherIncome_PatchContactsCoaplicant_Request> otherIncomes = new List<OtherIncome_PatchContactsCoaplicant_Request> { otherIncome };
            contactsCoaplicant.OtherIncomes = otherIncomes;
            List<Reference_PatchContactsCoaplicant_Request> references = new List<Reference_PatchContactsCoaplicant_Request> { reference };
            contactsCoaplicant.References = references;
            string payload = JsonConvert.SerializeObject(contactsCoaplicant, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_ContatService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.ErrorType, Is.EqualTo("EntityNotFound"));
                Assert.That(responseContent.ErrorMessage, Is.EqualTo("Entity type of Phoenix2.ContactService.Domain.Entities.ContactEntities.Contact with id '" + InvalidGuidContactId + "' not found"));
            });
        }
        [Test]
        public void ContactService_ContactCommentsType_GetContactComments_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("contact-service/contact-comments?PageNumber=1&PageSize=1&ContactId=" + GuidContactId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void ContactService_ContactCommentsType_PostContacatComment_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("contact-service/contact-comments");
            string Test = helper.GenerateDocName(6);
            ContactCommentsType_PostContacatComment_Request contacatComment = new ContactCommentsType_PostContacatComment_Request()
            {
                ContactId = GuidContactId,
                Text = Test
            };
            string payload = JsonConvert.SerializeObject(contacatComment, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<ContactCommentsType_PostContacatComment_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.ContactId, Is.EqualTo(GuidContactId));
                Assert.That(responseContent.Text, Is.EqualTo(Test));
            });
        }
        [Test]
        public void ContactService_ContactCommentsType_PostContacatComment_NegativeScenario_InvalidContactId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("contact-service/contact-comments");
            string Test = helper.GenerateDocName(6);
            ContactCommentsType_PostContacatComment_Request contacatComment = new ContactCommentsType_PostContacatComment_Request()
            {
                ContactId = InvalidGuidContactId,
                Text = Test
            };
            string payload = JsonConvert.SerializeObject(contacatComment, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_ContatService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.ErrorType, Is.EqualTo("EntityNotFound"));
                Assert.That(responseContent.ErrorMessage, Is.EqualTo("Entity type of Phoenix2.ContactService.Domain.Entities.ContactEntities.Contact with id '" + InvalidGuidContactId + "' not found"));
            });
        }
        [Test]
        public void ContactService_ContactsType_Header_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("contact-service/contacts/" + GuidContactId + "/header");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<CoApplicantsType_GetContactsCoaplicant_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.MiddleInitial, Is.EqualTo("string"));
                Assert.That(responseContent.LastName, Is.EqualTo("string"));
            });
        }
        [Test]
        public void ContactService_ContactsType_Header_NegativeScenario_InvalidId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("contact-service/contacts/" + InvalidGuidContactId + "/header");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_ContatService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.ErrorType, Is.EqualTo("EntityNotFound"));
                Assert.That(responseContent.ErrorMessage, Is.EqualTo("Entity type of Phoenix2.ContactService.Domain.Entities.ContactEntities.Contact with id '" + InvalidGuidContactId + "' not found"));
            });
        }
        [Test]
        public void ContactService_ContactsType_GetContact_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("contact-service/contacts/" + GuidContactId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ContactService_Contactstype_GetContact_NegativeScenario_InvalidId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("contact-service/contacts/" + InvalidGuidContactId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Arrange
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_ContatService>(response);
            /// Arrange
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.ErrorType, Is.EqualTo("EntityNotFound"));
                Assert.That(responseContent.ErrorMessage, Is.EqualTo("Entity type of Phoenix2.ContactService.Domain.Entities.ContactEntities.Contact with id '" + InvalidGuidContactId + "' not found"));
            });
        }
        [Test]
        public void ContactService_ContactsType_PatchContacts_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("contact-service/contacts/2538f3a5-e19f-46ef-b304-ffcfec1723ef");
            string Name = helper.GenerateDocName(7);
            string Street = helper.GenerateDocName(7);
            string num = helper.RandomDigits(10);
            ContactsType_PatchContacts_Request contact = new ContactsType_PatchContacts_Request();
            contact.FirstName = "13";
            contact.MiddleInitial = "string";
            contact.LastName = "string";
            contact.Suffix = "string";
            contact.MaidenName = "string";
            contact.Ssn = "+HE1CjUf+nRZ8o/qWRt35c81PI+sacnSMQtvUiOAi1ZWOlN9I/NKUmjFg6vhoM53";
            contact.DateOfBirth = DateTime.Now;
            contact.HomePhone = "1234321123";
            contact.WorkPhone = "1234321123";
            contact.WorkPhoneExtension = "string";
            contact.CellPhone = "1234321123";
            contact.Email = "13@gmail.com";
            contact.WorkEmail = "string";
            contact.MilitaryStatus = "W10";
            contact.MaritalStatus = "Widowed";
            contact.DriveLicenseNumber = "string";
            contact.DriverLicenseExpireDate = DateTime.Now;
            contact.DriverLicenseIssuesOnDate = DateTime.Now;
            contact.DriverLicenseState = "AL";
            contact.IsMilitaryLendingActAvailable = true;
            contact.ResidencyStatusType = "Citizen";
            contact.IsDeceased = true;
            contact.IsOptOut = true;
            contact.ReferralContactId = null;
            Address_PatchContacts_Request address = new Address_PatchContacts_Request();
            List<Address_PatchContacts_Request> addresses = new List<Address_PatchContacts_Request> { address };
            contact.Addresses = addresses;
            address.IsCurrent = true;
            address.IncludeInDti = true;
            address.MonthsAtAddress = 0;
            address.StreetLine1 = "13";
            address.StreetLine2 = "string";
            address.City = "string";
            address.State = "AL";
            address.Zip = "string";
            address.Type = "NotSet";
            address.County = "string";
            Employment_PatchContacts_Request employment = new Employment_PatchContacts_Request();
            List<Employment_PatchContacts_Request> employments = new List<Employment_PatchContacts_Request> { employment };
            contact.Employments = employments;
            employment.MonthsAtJob = 0;
            employment.JobTitle = "string";
            employment.EmploymentType = "FullTime";
            employment.CompanyName = "string";
            employment.MonthlyIncomeAmount = 0;
            employment.IsCurrent = true;
            employment.IsPrimary = true;
            employment.StreetLine1 = "string";
            employment.StreetLine2 = "string";
            employment.City = "string";
            employment.State = "AL";
            employment.Zip = "string";
            employment.AddressType = "NotSet";
            employment.county = "string";
            OtherIncome_PatchContacts_Request otherIncome = new OtherIncome_PatchContacts_Request();
            List<OtherIncome_PatchContacts_Request> otherIncomes = new List<OtherIncome_PatchContacts_Request> { otherIncome };
            contact.OtherIncomes = otherIncomes;
            otherIncome.MonthlyAmount = 0;
            otherIncome.IncomeType = "Other";
            otherIncome.IsCurrent = true;
            otherIncome.MonthsAtJob = 0;
            Reference_PatchContacts_Request reference = new Reference_PatchContacts_Request();
            List<Reference_PatchContacts_Request> references = new List<Reference_PatchContacts_Request> { reference };
            contact.References = references;
            reference.FullName = "string";
            reference.PhoneNumber = "string";
            reference.EmailAddress = "string";
            reference.StreetLine1 = "string";
            reference.StreetLine2 = "string";
            reference.City = "string";
            reference.State = "AL";
            reference.Zip = "string";
            reference.AddressType = "NotSet";
            reference.County = "string";
            reference.RelationshipType = "Spouse";
            Asset_PatchContacts_Request asset = new Asset_PatchContacts_Request();
            contact.Asset = asset;
            asset.AssetType = "Car";
            asset.Vin = "string";
            asset.Year = 2013;
            asset.Make = "string";
            asset.Model = "string";
            asset.KbbTrim = "string";
            asset.ActualNadaTradeIn = 0;
            asset.Mileage = "string";
            asset.SelectedTradeInValue = 0;
            asset.AssetCondition = "User";
            string payload = JsonConvert.SerializeObject(contact, Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void ContactService_ContactsType_PutContacts_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("contact-service/contacts");
            ContactsType_PutContacts_Request contact = new ContactsType_PutContacts_Request();
            contact.FirstName = "5";
            contact.MiddleInitial = "string";
            contact.LastName = "string";
            contact.Suffix = "string";
            contact.MaidenName = "string";
            contact.Ssn = "string";
            contact.DateOfBirth = DateTime.Now;
            contact.HomePhone = "1234321123";
            contact.WorkPhone = "1234321123";
            contact.WorkPhoneExtension = "string";
            contact.CellPhone = "1234321123";
            contact.Email = "13@3.com";
            contact.WorkEmail = "string";
            contact.MilitaryStatus = "W10";
            contact.MaritalStatus = "Widowed";
            contact.DriveLicenseNumber = "string";
            contact.DriverLicenseExpireDate = DateTime.Now;
            contact.DriverLicenseIssuesOnDate = DateTime.Now;
            contact.DriverLicenseState = "AL";
            contact.IsMilitaryLendingActAvailable = true;
            contact.ResidencyStatusType = "Citizen";
            contact.IsDeceased = true;
            contact.IsOptOut = true;
            contact.ReferralContactId = null;
            Address_PutContacts_Request address = new Address_PutContacts_Request();
            address.IsCurrent = true;
            address.IncludeInDti = true;
            address.MonthsAtAddress = 0;
            address.StreetLine1 = "4";
            address.StreetLine2 = "string";
            address.City = "string";
            address.State = "AL";
            address.Zip = "string";
            address.Type = "NotSet";
            address.County = "string";
            Employment_PutContacts_Request employment = new Employment_PutContacts_Request();
            employment.MonthsAtJob = 0;
            employment.JobTitle = "string";
            employment.EmploymentType = "FullTime";
            employment.CompanyName = "string";
            employment.MonthlyIncomeAmount = 0;
            employment.IsCurrent = true;
            employment.IsPrimary = true;
            employment.StreetLine1 = "string";
            employment.StreetLine2 = "string";
            employment.City = "string";
            employment.State = "AL";
            employment.Zip = "string";
            employment.AddressType = "NotSet";
            employment.County = "string";
            OtherIncome_PutContacts_Request otherIncome = new OtherIncome_PutContacts_Request();
            otherIncome.MonthlyAmount = 0;
            otherIncome.IncomeType = "Other";
            otherIncome.IsCurrent = true;
            otherIncome.MonthsAtJob = 0;
            Reference_PutContacts_Request reference = new Reference_PutContacts_Request();
            reference.FullName = "string";
            reference.PhoneNumber = "string";
            reference.EmailAddress = "string";
            reference.StreetLine1 = "string";
            reference.StreetLine2 = "string";
            reference.City = "string";
            reference.State = "AL";
            reference.Zip = "string";
            reference.AddressType = "NotSet";
            reference.County = "string";
            reference.RelationshipType = "Spouse";
            Asset_PutContacts_Request asset = new Asset_PutContacts_Request();
            asset.AssetType = "Car";
            asset.Vin = "string";
            asset.Year = 2013;
            asset.Make = "string";
            asset.Model = "string";
            asset.KbbTrim = "string";
            asset.ActualNadaTradeIn = 0;
            asset.Mileage = "string";
            asset.SelectedTradeInValue = 0;
            asset.AssetCondition = "User";
            List<Address_PutContacts_Request> addresses = new List<Address_PutContacts_Request> { address };
            contact.Addresses = addresses;
            List<Employment_PutContacts_Request> employments = new List<Employment_PutContacts_Request> { employment };
            contact.Employments = employments;
            List<OtherIncome_PutContacts_Request> otherIncomes = new List<OtherIncome_PutContacts_Request> { otherIncome };
            contact.OtherIncomes = otherIncomes;
            List<Reference_PutContacts_Request> references = new List<Reference_PutContacts_Request> { reference };
            contact.References = references;
            contact.Asset = asset;
            string payload = JsonConvert.SerializeObject(contact, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void ContactService_ContactsType_PostContacts_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("contact-service/contacts");
            string Name = helper.GenerateDocName(7);
            string Street = helper.GenerateDocName(7);
            string num = helper.RandomDigits(10);
            ContactsType_PostContacts_Request contact = new ContactsType_PostContacts_Request();
            contact.FirstName = Name;
            contact.MiddleInitial = "string";
            contact.LastName = "string";
            contact.Suffix = "string";
            contact.MaidenName = "string";
            contact.Ssn = SSN;
            contact.DateOfBirth = DateTime.Now;
            contact.HomePhone = num;
            contact.WorkPhone = num;
            contact.WorkPhoneExtension = "string";
            contact.CellPhone = num;
            contact.Email = Name;
            contact.WorkEmail = "string";
            contact.MilitaryStatus = "W10";
            contact.MaritalStatus = "Widowed";
            contact.DriveLicenseNumber = "string";
            contact.DriverLicenseExpireDate = DateTime.Now;
            contact.DriverLicenseIssuesOnDate = DateTime.Now;
            contact.DriverLicenseState = "AL";
            contact.IsMilitaryLendingActAvailable = true;
            contact.ResidencyStatusType = "Citizen";
            contact.IsDeceased = true;
            contact.IsOptOut = true;
            contact.ReferralContactId = null;
            Address_PostContacts_Request address = new Address_PostContacts_Request();
            List<Address_PostContacts_Request> addresses = new List<Address_PostContacts_Request> { address };
            contact.Addresses = addresses;
            address.IsCurrent = true;
            address.IncludeInDti = true;
            address.MonthsAtAddress = 0;
            address.StreetLine1 = Street;
            address.StreetLine2 = "string";
            address.City = "string";
            address.State = "AL";
            address.Zip = "string";
            address.Type = "NotSet";
            address.County = "string";
            Employment_PostContacts_Request employment = new Employment_PostContacts_Request();
            List<Employment_PostContacts_Request> employments = new List<Employment_PostContacts_Request> { employment };
            contact.Employments = employments;
            employment.MonthsAtJob = 0;
            employment.JobTitle = "string";
            employment.EmploymentType = "FullTime";
            employment.CompanyName = "string";
            employment.MonthlyIncomeAmount = 0;
            employment.IsCurrent = true;
            employment.IsPrimary = true;
            employment.StreetLine1 = "string";
            employment.StreetLine2 = "string";
            employment.City = "string";
            employment.State = "AL";
            employment.Zip = "string";
            employment.AddressType = "NotSet";
            employment.County = "string";
            OtherIncome_PostContacts_Request otherIncome = new OtherIncome_PostContacts_Request();
            List<OtherIncome_PostContacts_Request> otherIncomes = new List<OtherIncome_PostContacts_Request> { otherIncome };
            contact.OtherIncomes = otherIncomes;
            otherIncome.MonthlyAmount = 0;
            otherIncome.IncomeType = "Other";
            otherIncome.IsCurrent = true;
            otherIncome.MonthsAtJob = 0;
            Reference_PostContacts_Request reference = new Reference_PostContacts_Request();
            List<Reference_PostContacts_Request> references = new List<Reference_PostContacts_Request> { reference };
            contact.References = references;
            reference.FullName = "string";
            reference.PhoneNumber = "string";
            reference.EmailAddress = "string";
            reference.StreetLine1 = "string";
            reference.StreetLine2 = "string";
            reference.City = "string";
            reference.State = "AL";
            reference.Zip = "string";
            reference.AddressType = "NotSet";
            reference.County = "string";
            reference.RelationshipType = "Spouse";
            Asset_PostContacts_Request asset = new Asset_PostContacts_Request();
            contact.Asset = asset;
            asset.AssetType = "Car";
            asset.Vin = "string";
            asset.Year = 2010;
            asset.Make = "string";
            asset.Model = "string";
            asset.KbbTrim = "string";
            asset.ActualNadaTradeIn = 0;
            asset.Mileage = "string";
            asset.SelectedTradeInValue = 0;
            asset.AssetCondition = "User";
            string payload = JsonConvert.SerializeObject(contact, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<ContactsType_PostContacts_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Source, Is.EqualTo("ValidationErrorKey: HomePhone : Message 'Home Phone' is not in the correct format.\nKey: CellPhone : Message 'Cell Phone' is not in the correct format.\nKey: WorkPhone : Message 'Work Phone' is not in the correct format.\nKey: Asset : Message Year should be greater then 0\n"));
                Assert.That(responseContent.Message, Is.EqualTo("Exception of type 'Phoenix.Common.Models.Errors.ValidationExceptionModel' was thrown."));
            });
        }
        [Test]
        public void ContactService_ContactsType_GetContacts_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("contact-service/contacts/");
            RestRequest request = helper.CreateGetRequest(acessToken);
            request.AddParameter("PageNumber", "1");
            request.AddParameter("PageSize", "1");
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void ContactService_ContactsType_ContactCellPhone_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("contact-service/contacts/12312312312");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ContactService_ContactsType_ContactCellPhone_NegativeScenario_InvalidCellPhone()
        {
            /// Arrange
            RestClient client = helper.SetUrl("contact-service/contacts/123123123123");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_ContatService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.ErrorType, Is.EqualTo("EntityNotFound"));
                Assert.That(responseContent.ErrorMessage, Is.EqualTo("No record found for CellPhone: 123123123123"));
            });
        }

        [Test]
        public void ContactService_ContactsType_ContactListByNumericId_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("contact-service/contacts/numeric?numericIds=108");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void ContactService_CreditReportsType_CreditReports_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("contact-service/credit-reports/0936e7bf-d8af-4672-8569-0e5967e6bcf8");
            RestRequest request = helper.CreateGetRequest(acessToken);
            request.AddParameter("bureauType", "Equifax");
            request.AddParameter("isSoftPull", "true");
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}
