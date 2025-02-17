using Newtonsoft.Json;
using NUnit.Framework;
using Phoenix2.APITests.DTO.LeadServiceDTO;
using Phoenix2.APITests.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Phoenix2.APITests.Credentials;

namespace Phoenix2.APITests.Tests
{
    class LeadService
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
        public void LeadService_LeadType_ContactsLeads_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("Lead-service/contact/" + contactIdLead + "/leads");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void LeadService_LeadType_ContactsLeads_NegativeScenario_InvaidContactId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("Lead-service/contact/" + leadIdInvaild + "/leads");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Status_LeadService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("No leads for contact " + leadIdInvaild));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LeadService_LeadType_PostLeads_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("Lead-service/contact/" + contactIdLead + "/leads");
            LeadType_PostLeads_RequestBody createLeads = new LeadType_PostLeads_RequestBody();
            createLeads.ContactId = contactIdLead;
            createLeads.PrimarySourceId = contactIdLead;
            createLeads.SecondarySourceId = contactIdLead;
            AssignedUser_PostLeads_RequestBody assignedUser = new AssignedUser_PostLeads_RequestBody();
            createLeads.AssignedUser = assignedUser;
            assignedUser.Id = "string";
            assignedUser.Email = "string";
            assignedUser.Name = "string";
            createLeads.TransferredToLeadId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            createLeads.TransferredFromLeadId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            createLeads.OriginalLeadId = "0a000000-000a-0aa0-a000-a00aa000b0aa";
            createLeads.LoanApplicationId = "string";
            createLeads.MarketingInfo = "MarketingClickReference";
            Score_PostLeads_RequestBody score = new Score_PostLeads_RequestBody();
            createLeads.Score = score;
            score.InitialLeadScore = 0;
            InitialLeadScoreParameters_PostLeads_RequestBody initialLeadScoreParameter = new InitialLeadScoreParameters_PostLeads_RequestBody();
            score.InitialLeadScoreParameters = initialLeadScoreParameter;
            initialLeadScoreParameter.State = "AL";
            initialLeadScoreParameter.FicoScore = 0;
            initialLeadScoreParameter.Age = 0;
            initialLeadScoreParameter.AssetYear = 0;
            initialLeadScoreParameter.LienAmount = 0;
            initialLeadScoreParameter.LienRate = 0;
            initialLeadScoreParameter.LienPayment = 0;
            initialLeadScoreParameter.MonthlyIncome = 0;
            initialLeadScoreParameter.SourceName = "string";
            string payload = JsonConvert.SerializeObject(createLeads, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<LeadType_PostLeads_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.ContactId, Is.EqualTo(contactIdLead));
                Assert.That(responseContent.PrimarySourceId, Is.EqualTo(contactIdLead));
                Assert.That(responseContent.SecondarySourceId, Is.EqualTo(contactIdLead));
            });
        }

        [Test]
        public void LeadService_LeadType_PostLeads_NegativeScenario_WithoutContactId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("Lead-service/contact/" + contactIdLead + "/leads");
            LeadType_PostLeads_RequestBody createLeads = new LeadType_PostLeads_RequestBody();
            createLeads.ContactId = "";
            createLeads.PrimarySourceId = contactIdLead;
            createLeads.SecondarySourceId = contactIdLead;
            AssignedUser_PostLeads_RequestBody assignedUser = new AssignedUser_PostLeads_RequestBody();
            createLeads.AssignedUser = assignedUser;
            assignedUser.Id = "string";
            assignedUser.Email = "string";
            assignedUser.Name = "string";
            createLeads.TransferredToLeadId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            createLeads.TransferredFromLeadId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            createLeads.OriginalLeadId = "0a000000-000a-0aa0-a000-a00aa000b0aa";
            createLeads.LoanApplicationId = "string";
            createLeads.MarketingInfo = "MarketingClickReference";
            Score_PostLeads_RequestBody score = new Score_PostLeads_RequestBody();
            createLeads.Score = score;
            score.InitialLeadScore = 0;
            InitialLeadScoreParameters_PostLeads_RequestBody initialLeadScoreParameter = new InitialLeadScoreParameters_PostLeads_RequestBody();
            score.InitialLeadScoreParameters = initialLeadScoreParameter;
            initialLeadScoreParameter.State = "AL";
            initialLeadScoreParameter.FicoScore = 0;
            initialLeadScoreParameter.Age = 0;
            initialLeadScoreParameter.AssetYear = 0;
            initialLeadScoreParameter.LienAmount = 0;
            initialLeadScoreParameter.LienRate = 0;
            initialLeadScoreParameter.LienPayment = 0;
            initialLeadScoreParameter.MonthlyIncome = 0;
            initialLeadScoreParameter.SourceName = "string";
            string payload = JsonConvert.SerializeObject(createLeads, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LeadService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Title, Is.EqualTo("One or more validation errors occurred."));
                Assert.That(responseContent.Status, Is.EqualTo(400));
            });
        }

        [Test]
        public void LeadService_LeadType_PatcheLesds_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("Lead-service/contact/" + contactIdLeadPut + "/leads");
            LeadType_PatcheLesds_Request updateLesds = new LeadType_PatcheLesds_Request();
            updateLesds.Id = IdLeadPut;
            updateLesds.ContactId = contactIdLeadPut;
            AssignedUser_PatcheLesds_Request assignedUser = new AssignedUser_PatcheLesds_Request();
            updateLesds.AssignedUser = assignedUser;
            assignedUser.Id = "string";
            assignedUser.Email = "string";
            assignedUser.Name = "string";
            updateLesds.TransferredToLeadId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            updateLesds.MarketingInfo = "MarketingClickReference";
            Score_PatcheLesds_Request score = new Score_PatcheLesds_Request();
            updateLesds.Score = score;
            score.InitialLeadScore = 0;
            InitialLeadScoreParameters_PatcheLesds_Request initialLeadScoreParameter = new InitialLeadScoreParameters_PatcheLesds_Request();
            score.InitialLeadScoreParameters = initialLeadScoreParameter;
            initialLeadScoreParameter.State = "AL";
            initialLeadScoreParameter.FicoScore = 0;
            initialLeadScoreParameter.Age = 0;
            initialLeadScoreParameter.AssetYear = 0;
            initialLeadScoreParameter.LienAmount = 0;
            initialLeadScoreParameter.LienRate = 0;
            initialLeadScoreParameter.LienPayment = 0;
            initialLeadScoreParameter.MonthlyIncome = 0;
            initialLeadScoreParameter.SourceName = "string";
            string payload = JsonConvert.SerializeObject(updateLesds, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<LeadType_PostLeads_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.ContactId, Is.EqualTo(contactIdLeadPut));
                Assert.That(responseContent.PrimarySourceId, Is.EqualTo(primarySourceId));
            });
        }

        [Test]
        public void LeadService_LeadType_PatcheLesds_NegativeScenario_InvaildID()
        {
            /// Arrange
            RestClient client = helper.SetUrl("Lead-service/contact/" + contactIdLeadPut + "/leads");
            LeadType_PatcheLesds_Request updateLesds = new LeadType_PatcheLesds_Request();
            updateLesds.Id = contactIdLeadInvalid;
            updateLesds.ContactId = contactIdLeadPut;
            AssignedUser_PatcheLesds_Request assignedUser = new AssignedUser_PatcheLesds_Request();
            updateLesds.AssignedUser = assignedUser;
            assignedUser.Id = "string";
            assignedUser.Email = "string";
            assignedUser.Name = "string";
            updateLesds.TransferredToLeadId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            updateLesds.MarketingInfo = "MarketingClickReference";
            Score_PatcheLesds_Request score = new Score_PatcheLesds_Request();
            updateLesds.Score = score;
            score.InitialLeadScore = 0;
            InitialLeadScoreParameters_PatcheLesds_Request initialLeadScoreParameter = new InitialLeadScoreParameters_PatcheLesds_Request();
            score.InitialLeadScoreParameters = initialLeadScoreParameter;
            initialLeadScoreParameter.State = "AL";
            initialLeadScoreParameter.FicoScore = 0;
            initialLeadScoreParameter.Age = 0;
            initialLeadScoreParameter.AssetYear = 0;
            initialLeadScoreParameter.LienAmount = 0;
            initialLeadScoreParameter.LienRate = 0;
            initialLeadScoreParameter.LienPayment = 0;
            initialLeadScoreParameter.MonthlyIncome = 0;
            initialLeadScoreParameter.SourceName = "string";
            string payload = JsonConvert.SerializeObject(updateLesds, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Status_LeadService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LeadService.Domain.Entities.Lead with id '" + contactIdLeadInvalid + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LeadService_LeadType_DeleteLeads_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("Lead-service/contact/" + contactIdLead + "/leads");
            LeadType_PostLeads_RequestBody createLeads = new LeadType_PostLeads_RequestBody();
            createLeads.ContactId = contactIdLead;
            createLeads.PrimarySourceId = contactIdLead;
            createLeads.SecondarySourceId = contactIdLead;
            AssignedUser_PostLeads_RequestBody assignedUser = new AssignedUser_PostLeads_RequestBody();
            createLeads.AssignedUser = assignedUser;
            assignedUser.Id = "string";
            assignedUser.Email = "string";
            assignedUser.Name = "string";
            createLeads.TransferredToLeadId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            createLeads.TransferredFromLeadId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            createLeads.OriginalLeadId = "0a000000-000a-0aa0-a000-a00aa000b0aa";
            createLeads.LoanApplicationId = "string";
            createLeads.MarketingInfo = "MarketingClickReference";
            Score_PostLeads_RequestBody score = new Score_PostLeads_RequestBody();
            createLeads.Score = score;
            score.InitialLeadScore = 0;
            InitialLeadScoreParameters_PostLeads_RequestBody initialLeadScoreParameter = new InitialLeadScoreParameters_PostLeads_RequestBody();
            score.InitialLeadScoreParameters = initialLeadScoreParameter;
            initialLeadScoreParameter.State = "AL";
            initialLeadScoreParameter.FicoScore = 0;
            initialLeadScoreParameter.Age = 0;
            initialLeadScoreParameter.AssetYear = 0;
            initialLeadScoreParameter.LienAmount = 0;
            initialLeadScoreParameter.LienRate = 0;
            initialLeadScoreParameter.LienPayment = 0;
            initialLeadScoreParameter.MonthlyIncome = 0;
            initialLeadScoreParameter.SourceName = "string";
            string payload = JsonConvert.SerializeObject(createLeads, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<LeadType_PostLeads_Response>(response);
            string IdDelete = responseContent.Id;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient Deleteclient = helper.SetUrl("Lead-service/contact/" + contactIdLead + "/leads/" + IdDelete);
            RestRequest DeleteRequest = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse DeleteResponse = helper.GetResponse(Deleteclient, DeleteRequest);
            /// Assert
            Assert.That(DeleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        [TestCase(contactIdLead, leadIdInvaild)]
        [TestCase(contactIdLeadInvalid, leadId)]
        [TestCase(contactIdLeadInvalid, leadIdInvaild)]
        public void LeadService_LeadType_DeleteLeads_NegativeScenario(string ContactId, string LeadId)
        {
            /// Arrange
            RestClient client = helper.SetUrl("Lead-service/contact/" + ContactId + "/leads/" + LeadId);
            RestRequest request = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Status_LeadService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LeadService.Domain.Entities.Lead with id '" + LeadId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LeadService_LeadNotesType_GetLeadNotes_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("Lead-service/lead/" + leadId + "/notes");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void LeadService_LeadNotesType_GetLeadNotes_NegativeScenario_InvalidLeadId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("Lead-service/lead/" + contactIdLeadInvalid + "/notes");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Status_LeadService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LeadService.Domain.Entities.Lead with id '" + contactIdLeadInvalid + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LeadService_LeadNotesType_PostLeadNotes_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("Lead-service/lead/" + leadId + "/notes");
            LeadNotesType_PostLeadNotes_Request createNotes = new LeadNotesType_PostLeadNotes_Request();
            createNotes.ContactId = ContactIdLeadNotes;
            createNotes.LeadId = leadId;
            List<string> leadNoteTypes = new List<string> { "Call " };
            createNotes.LeadNoteTypes = leadNoteTypes;
            createNotes.Note = "string";
            string payload = JsonConvert.SerializeObject(createNotes, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<LeadNotesType_PostLeadNotes_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.ContactId, Is.EqualTo(ContactIdLeadNotes));
                Assert.That(responseContent.LeadId, Is.EqualTo(leadId));
            });
        }

        [Test]
        public void LeadService_LeadNotesType_PostLeadNotes_NegativeScenario_InvalidLeadId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("Lead-service/lead/" + leadIdInvaild + "/notes");
            LeadNotesType_PostLeadNotes_Request createNotes = new LeadNotesType_PostLeadNotes_Request();
            createNotes.ContactId = ContactIdLeadNotes;
            createNotes.LeadId = leadIdInvaild;
            List<string> leadNoteTypes = new List<string> { "Call " };
            createNotes.LeadNoteTypes = leadNoteTypes;
            createNotes.Note = "string";
            string payload = JsonConvert.SerializeObject(createNotes, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Status_LeadService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LeadService.Domain.Entities.Lead with id '" + leadIdInvaild + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LeadService_LeadNotesType_PutLeadNotes_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("Lead-service/lead/" + leadId + "/notes");
            LeadNotesType_PostLeadNotes_Request createNotes = new LeadNotesType_PostLeadNotes_Request();
            createNotes.ContactId = ContactIdLeadNotes;
            createNotes.LeadId = leadId;
            List<string> leadNoteTypes = new List<string> { "Call " };
            createNotes.LeadNoteTypes = leadNoteTypes;
            createNotes.Note = "string";
            string payload = JsonConvert.SerializeObject(createNotes, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<LeadNotesType_PostLeadNotes_Response>(response);
            string IdForPut = responseContent.Id;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient Putclient = helper.SetUrl("Lead-service/lead/" + leadId + "/notes");
            LeadNotesType_PutLeadNotes_Request updateNotes = new LeadNotesType_PutLeadNotes_Request();
            updateNotes.Id = IdForPut;
            updateNotes.ContactId = ContactIdLeadNotes;
            updateNotes.LeadId = leadId;
            List<string> leadNoteTypes1 = new List<string> { "Call " };
            updateNotes.LeadNoteTypes = leadNoteTypes1;
            updateNotes.Note = "string";
            string payloadPut = JsonConvert.SerializeObject(updateNotes, Formatting.Indented);
            RestRequest requestPut = helper.CreatePutRequest(payloadPut, acessToken);
            /// Act
            IRestResponse responsePut = helper.GetResponse(client, request);
            var responseContentPut = helper.GetContent<LeadNotesType_PutLeadNotes_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responsePut.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContentPut.Id, Is.EqualTo(IdForPut));
                Assert.That(responseContentPut.ContactId, Is.EqualTo(ContactIdLeadNotes));
                Assert.That(responseContentPut.LeadId, Is.EqualTo(leadId));
            });
        }

        [Test]
        public void LeadService_LeadNotesType_PutLeadNotes_NegativeScenario_InvalidId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("Lead-service/lead/" + leadId + "/notes");
            LeadNotesType_PutLeadNotes_Request updateNotes = new LeadNotesType_PutLeadNotes_Request();
            updateNotes.Id = leadIdInvaild;
            updateNotes.ContactId = ContactIdLeadNotes;
            updateNotes.LeadId = leadId;
            List<string> leadNoteTypes1 = new List<string> { "Call " };
            updateNotes.LeadNoteTypes = leadNoteTypes1;
            updateNotes.Note = "string";
            string payload = JsonConvert.SerializeObject(updateNotes, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Status_LeadService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LeadService.Domain.Entities.LeadNote with id '" + leadIdInvaild + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LeadService_LeadNotesType_DeleteLeadNotes_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("Lead-service/lead/" + leadId + "/notes");
            LeadNotesType_PostLeadNotes_Request createNotes = new LeadNotesType_PostLeadNotes_Request();
            createNotes.ContactId = ContactIdLeadNotes;
            createNotes.LeadId = leadId;
            List<string> leadNoteTypes = new List<string> { "Call " };
            createNotes.LeadNoteTypes = leadNoteTypes;
            createNotes.Note = "string";
            string payload = JsonConvert.SerializeObject(createNotes, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<LeadNotesType_PostLeadNotes_Response>(response);
            string IdForPut = responseContent.Id;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient Deleteclient = helper.SetUrl("Lead-service/lead/" + leadId + "/notes/" + IdForPut);
            RestRequest DeleteRequest = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse DeleteResponse = helper.GetResponse(Deleteclient, DeleteRequest);
            /// Assert
            Assert.That(DeleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        [TestCase(leadId, leadNoteIdInvalid)]
        [TestCase(leadIdInvaild, leadNoteIdInvalid)]
        public void LeadService_LeadNotesType_DeleteLeadNotes_NegativeScenario(string LeadId, string LeadNotedId)
        {
            /// Arrange
            RestClient Deleteclient = helper.SetUrl("Lead-service/lead/" + LeadId + "/notes/" + LeadNotedId);
            RestRequest request = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(Deleteclient, request);
            var responseContent = helper.GetContent<NegativeScenario_Status_LeadService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LeadService.Domain.Entities.LeadNote with id '" + LeadNotedId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LeadService_SourceType_GetSource_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("Lead-service/source");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void LeadService_SourceType_PostSource_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("Lead-service/source");
            string name = helper.GenerateDocName(6);
            string description = helper.GenerateDocName(6);
            SourceType_PostSource_RequstBody createSource = new SourceType_PostSource_RequstBody()
            {
                Name = name,
                Description = description,
                IsSecondary = true,
                AllowSecondary = true,
                IsAutoResponseEnabled = true,
                AutoResponsePostUrl = "string",
                AutoResponseVersion = 0,
                EnableCamRef = true,
                IsAutoDeadEnabled = true,
                IsAutoDelayedResponseEnabled = true,
                AutoDeadDelayedResponse = 0,
                AutoDelayedResponseOfferCallbackBaseUrl = "string"
            };
            string payload = JsonConvert.SerializeObject(createSource, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<SourceType_PostSource_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Name, Is.EqualTo(name));
                Assert.That(responseContent.Description, Is.EqualTo(description));
            });
        }

        [Test]
        public void LeadService_SourceType_PostSource_NegariveScenario_InvalidName()
        {
            /// Arrange
            RestClient client = helper.SetUrl("Lead-service/source");
            SourceType_PostSource_NegariveRequest createSource = new SourceType_PostSource_NegariveRequest()
            {
                Name = 121,
                Description = "string",
                IsSecondary = true,
                AllowSecondary = true,
                IsAutoResponseEnabled = true,
                AutoResponsePostUrl = "string",
                AutoResponseVersion = 0,
                EnableCamRef = true,
                IsAutoDeadEnabled = true,
                IsAutoDelayedResponseEnabled = true,
                AutoDeadDelayedResponse = 0,
                AutoDelayedResponseOfferCallbackBaseUrl = "string"
            };
            string payload = JsonConvert.SerializeObject(createSource, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LeadService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Title, Is.EqualTo("One or more validation errors occurred."));
                Assert.That(responseContent.Status, Is.EqualTo(400));
            });
        }

        [Test]
        public void LeadService_SourceType_PutSource_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("Lead-service/source");
            SourceType_PostSource_RequstBody createSource = new SourceType_PostSource_RequstBody()
            {
                Name = "string",
                Description = "string",
                IsSecondary = true,
                AllowSecondary = true,
                IsAutoResponseEnabled = true,
                AutoResponsePostUrl = "string",
                AutoResponseVersion = 0,
                EnableCamRef = true,
                IsAutoDeadEnabled = true,
                IsAutoDelayedResponseEnabled = true,
                AutoDeadDelayedResponse = 0,
                AutoDelayedResponseOfferCallbackBaseUrl = "string"
            };
            string payload = JsonConvert.SerializeObject(createSource, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<SourceType_PostSource_Response>(response);
            string IdForPut = responseContent.Id;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient Putclient = helper.SetUrl("Lead-service/source");
            string name = helper.GenerateDocName(6);
            string description = helper.GenerateDocName(6);
            SourceType_PutSource_Request updateSource = new SourceType_PutSource_Request()
            {
                Id = IdForPut,
                Name = name,
                Description = description,
                IsSecondary = true,
                AllowSecondary = true,
                IsAutoResponseEnabled = true,
                AutoResponsePostUrl = "string",
                AutoResponseVersion = 0,
                EnableCamRef = true,
                IsAutoDeadEnabled = true,
                IsAutoDelayedResponseEnabled = true,
                AutoDeadDelayedResponse = 0,
                AutoDelayedResponseOfferCallbackBaseUrl = "string"
            };
            string payloadPut = JsonConvert.SerializeObject(updateSource, Formatting.Indented);
            RestRequest requestPut = helper.CreatePutRequest(payloadPut, acessToken);
            /// Act
            IRestResponse responsePut = helper.GetResponse(Putclient, requestPut);
            var responseContentPut = helper.GetContent<SourceType_PutSource_Response>(responsePut);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responsePut.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContentPut.Id, Is.EqualTo(IdForPut));
                Assert.That(responseContentPut.Name, Is.EqualTo(name));
                Assert.That(responseContentPut.Description, Is.EqualTo(description));
            });
        }

        [Test]
        public void LeadService_SourceType_PutSource_NegativeScenario_InvalidId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("Lead-service/source");
            SourceType_PutSource_Request updateSource = new SourceType_PutSource_Request()
            {
                Id = leadIdInvaild,
                Name = "string",
                Description = "string",
                IsSecondary = true,
                AllowSecondary = true,
                IsAutoResponseEnabled = true,
                AutoResponsePostUrl = "string",
                AutoResponseVersion = 0,
                EnableCamRef = true,
                IsAutoDeadEnabled = true,
                IsAutoDelayedResponseEnabled = true,
                AutoDeadDelayedResponse = 0,
                AutoDelayedResponseOfferCallbackBaseUrl = "string"
            };
            string payload = JsonConvert.SerializeObject(updateSource, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Status_LeadService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LeadService.Domain.Entities.Source with id '" + leadIdInvaild + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LeadService_SourceType_DeleteSource_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("Lead-service/source");
            SourceType_PostSource_RequstBody createSource = new SourceType_PostSource_RequstBody()
            {
                Name = "string",
                Description = "string",
                IsSecondary = true,
                AllowSecondary = true,
                IsAutoResponseEnabled = true,
                AutoResponsePostUrl = "string",
                AutoResponseVersion = 0,
                EnableCamRef = true,
                IsAutoDeadEnabled = true,
                IsAutoDelayedResponseEnabled = true,
                AutoDeadDelayedResponse = 0,
                AutoDelayedResponseOfferCallbackBaseUrl = "string"
            };
            string payload = JsonConvert.SerializeObject(createSource, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<SourceType_PostSource_Response>(response);
            string IdForPut = responseContent.Id;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient Deleteclient = helper.SetUrl("Lead-service/source/" + IdForPut);
            RestRequest DeleteRequest = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse DeleteResponse = helper.GetResponse(Deleteclient, DeleteRequest);
            /// Assert
            Assert.That(DeleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void LeadService_SourceType_DeleteSource_InvalidId()
        {
            /// Arrange
            RestClient Deleteclient = helper.SetUrl("Lead-service/source/" + leadIdInvaild);
            RestRequest request = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(Deleteclient, request);
            var responseContent = helper.GetContent<NegativeScenario_Status_LeadService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LeadService.Domain.Entities.Source with id '" + leadIdInvaild + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
    }
}
