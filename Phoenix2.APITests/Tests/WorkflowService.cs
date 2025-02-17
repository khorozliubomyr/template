using Newtonsoft.Json;
using NUnit.Framework;
using Phoenix2.APITests.DTO.WorkflowServiceDTO;
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
    class WorkflowService
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
        public void WorkflowService_WorkflowType_PostWorkflow_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("workflow-service/workflow");
            WorkflowType_PostWorkflow_Request workflow = new WorkflowType_PostWorkflow_Request()
            {
                Name = "string",
                EntityType = "Lead"
            };
            string payload = JsonConvert.SerializeObject(workflow, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<WorkflowType_PostWorkflow_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.WorkflowName, Is.EqualTo("string"));
                Assert.That(responseContent.EntityType, Is.EqualTo("Lead"));
            });
        }
        [Test]
        public void WorkflowService_WorkflowType_GetAllWorkflows_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("workflow-service/workflow");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void WorkflowService_WorkflowType_PostSteps_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("workflow-service/step");
            string Name = helper.GenerateDocName(5);
            WorkflowType_PostSteps_Request workflowStep = new WorkflowType_PostSteps_Request()
            {
                WorkflowId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                DisplayName = Name,
                Name = "string",
                Description = "string",
                OrderNumber = 0,
                StepType = "Step",
                MinutesGreen = 0,
                MinutesAmber = 0,
                MinutesRed = 0,
                IsDefault = true,
                TrackerStageId = 0,
                TrackerStepId = 0,
                TextCommentColor = "string",
                IsTextBold = true,
                ParentWorkflowStepId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                ReRouteWorkflowStepId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                RoleId = "3fa85f64-5717-4562-b3fc-2c963f66afa6"
            };
            string payload = JsonConvert.SerializeObject(workflowStep, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<WorkflowType_PostSteps_Responce>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.WorkflowStepNumericId, Is.EqualTo(0));
                Assert.That(responseContent.WorkflowId, Is.EqualTo("3fa85f64-5717-4562-b3fc-2c963f66afa6"));
                Assert.That(responseContent.DisplayName, Is.EqualTo(Name));
            });
        }
        [Test]
        public void WorkflowService_WorkflowType_PutStep_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("workflow-service/step");
            string Name = helper.GenerateDocName(5);
            WorkflowType_PostSteps_Request workflowStep = new WorkflowType_PostSteps_Request()
            {
                WorkflowId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                DisplayName = Name,
                Name = "string",
                Description = "string",
                OrderNumber = 0,
                StepType = "Step",
                MinutesGreen = 0,
                MinutesAmber = 0,
                MinutesRed = 0,
                IsDefault = true,
                TrackerStageId = 0,
                TrackerStepId = 0,
                TextCommentColor = "string",
                IsTextBold = true,
                ParentWorkflowStepId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                ReRouteWorkflowStepId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                RoleId = "3fa85f64-5717-4562-b3fc-2c963f66afa6"
            };
            string payload = JsonConvert.SerializeObject(workflowStep, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<WorkflowType_PostSteps_Responce>(response);
            string Id = responseContent.Id;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient Putclient = helper.SetUrl("workflow-service/step/" + Id);
            string PutName = helper.GenerateDocName(5);
            WorkflowType_PutStep_Request updateWorkflowStep = new WorkflowType_PutStep_Request()
            {
                DisplayName = PutName,
                Name = "string",
                Description = "string",
                OrderNumber = 0,
                MinutesGreen = 0,
                MinutesAmber = 0,
                MinutesRed = 0,
                IsDefault = true,
                TrackerStageId = 0,
                TrackerStepId = 0,
                TextCommentColor = "string",
                IsTextBold = true,
                ReRouteWorkflowStepId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                RoleId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                IsDeleted = true
            };
            string Putpayload = JsonConvert.SerializeObject(updateWorkflowStep, Formatting.Indented);
            RestRequest Putrequest = helper.CreatePutRequest(Putpayload, acessToken);
            /// Act
            IRestResponse Putresponse = helper.GetResponse(Putclient, Putrequest);
            /// Assert
            Assert.That(Putresponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void WorkflowService_WorkflowType_PutStep_NegativeScenario()
        {
            /// Arrange
            RestClient Putclient = helper.SetUrl("workflow-service/step/" + InvalidWorkflowId);
            string PutName = helper.GenerateDocName(5);
            WorkflowType_PutStep_Request updateWorkflowStep = new WorkflowType_PutStep_Request()
            {
                DisplayName = PutName,
                Name = "string",
                Description = "string",
                OrderNumber = 0,
                MinutesGreen = 0,
                MinutesAmber = 0,
                MinutesRed = 0,
                IsDefault = true,
                TrackerStageId = 0,
                TrackerStepId = 0,
                TextCommentColor = "string",
                IsTextBold = true,
                ReRouteWorkflowStepId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                RoleId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                IsDeleted = true
            };
            string Putpayload = JsonConvert.SerializeObject(updateWorkflowStep, Formatting.Indented);
            RestRequest Putrequest = helper.CreatePutRequest(Putpayload, acessToken);
            /// Act
            IRestResponse Putresponse = helper.GetResponse(Putclient, Putrequest);
            var responseContent = helper.GetContent<WorkflowService_Responses_NegativeScenario>(Putresponse);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(Putresponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.ErrorType, Is.EqualTo("EntityNotFound"));
                Assert.That(responseContent.ErrorMessage, Is.EqualTo("Entity type of Phoenix2.WorkflowService.Domain.Entities.WorkflowStep with id '" + InvalidWorkflowId + "' not found"));
            });
        }
        [Test]
        public void WorkflowService_WorkflowType_PostStepReason_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("workflow-service/step/reason");
            WorkflowType_PostStepReason_Request workflowStepReason = new WorkflowType_PostStepReason_Request();
            workflowStepReason.WorkflowStepId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            workflowStepReason.Label = "string";
            workflowStepReason.Description = "string";
            List<string> AutoSelectLenders = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            string payload = JsonConvert.SerializeObject(workflowStepReason, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<WorkflowType_PostStepReason_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.NumericId, Is.EqualTo(1));
                Assert.That(responseContent.Label, Is.EqualTo("string"));
            });
        }
        [Test]
        public void WorkflowService_WorkflowType_PutStepReason_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("workflow-service/step/reason");
            WorkflowType_PostStepReason_Request workflowStepReason = new WorkflowType_PostStepReason_Request();
            workflowStepReason.WorkflowStepId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            workflowStepReason.Label = "string";
            workflowStepReason.Description = "string";
            List<string> AutoSelectLenders = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            string payload = JsonConvert.SerializeObject(workflowStepReason, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<WorkflowType_PostStepReason_Response>(response);
            string Id = responseContent.Id;

            RestClient Putclient = helper.SetUrl("workflow-service/step/reason/" + Id);
            string PutName = helper.GenerateDocName(5);
            WorkflowType_PutStepReason_Request updateWorkflowStepReason = new WorkflowType_PutStepReason_Request();
            updateWorkflowStepReason.Label = "string";
            updateWorkflowStepReason.Description = "string";
            List<string> AutoSelectLendersPut = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            string Putpayload = JsonConvert.SerializeObject(updateWorkflowStepReason, Formatting.Indented);
            RestRequest Putrequest = helper.CreatePutRequest(Putpayload, acessToken);
            /// Act
            IRestResponse Putresponse = helper.GetResponse(Putclient, Putrequest);
            /// Assert
            Assert.That(Putresponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void WorkflowService_WorkflowType_PutStepReason_NegativeScenario_InvalidId()
        {
            /// Arrange
            RestClient Putclient = helper.SetUrl("workflow-service/step/reason/" + InvalidWorkflowId);
            string PutName = helper.GenerateDocName(5);
            WorkflowType_PutStepReason_Request updateWorkflowStepReason = new WorkflowType_PutStepReason_Request();
            updateWorkflowStepReason.Label = "string";
            updateWorkflowStepReason.Description = "string";
            List<string> AutoSelectLendersPut = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            string Putpayload = JsonConvert.SerializeObject(updateWorkflowStepReason, Formatting.Indented);
            RestRequest Putrequest = helper.CreatePutRequest(Putpayload, acessToken);
            /// Act
            IRestResponse Putresponse = helper.GetResponse(Putclient, Putrequest);
            var responseContent = helper.GetContent<WorkflowService_Responses_NegativeScenario>(Putresponse);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(Putresponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.ErrorType, Is.EqualTo("EntityNotFound"));
                Assert.That(responseContent.ErrorMessage, Is.EqualTo("Entity type of Phoenix2.WorkflowService.Domain.Entities.WorkflowStepReason with id '" + InvalidWorkflowId + "' not found"));
            });
        }
        [Test]
        public void WorkflowService_WorkflowType_GetWorkflowById_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("workflow-service/workflow/" + WorkflowServiceId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void WorkflowService_WorkflowType_GetWorkflowById_NegativeScenario_InvalidWorkflow()
        {
            /// Arrange
            RestClient client = helper.SetUrl("workflow-service/workflow/" + InvalidWorkflowId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
        [Test]
        public void WorkflowService_WorkflowType_StepsNextSteps_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("workflow-service/step/nextsteps?currentWorkflowStepId=" + CurrentWorkflofStepId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void WorkflowService_WorkflowType_StepsNextSteps_NegativeScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("workflow-service/step/nextsteps?currentWorkflowStepId=" + InvalidWorkflowId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<WorkflowService_Responses_NegativeScenario>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.ErrorType, Is.EqualTo("EntityNotFound"));
                Assert.That(responseContent.ErrorMessage, Is.EqualTo("Entity type of Phoenix2.WorkflowService.Domain.Entities.WorkflowStep with id '" + InvalidWorkflowId + "' not found"));
            });
        }
        [Test]
        public void WorkflowService_WorkflowType_MoveSteps_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("workflow-service/step/movestep?targetWorkflowStepId=" + TargetWorkflowStepId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void WorkflowService_WorkflowType_MoveSteps_NegativeScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("workflow-service/step/movestep?targetWorkflowStepId=" + InvalidWorkflowId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<WorkflowService_Responses_NegativeScenario>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.ErrorType, Is.EqualTo("EntityNotFound"));
                Assert.That(responseContent.ErrorMessage, Is.EqualTo("Entity type of Phoenix2.WorkflowService.Domain.Entities.WorkflowStep with id '" + InvalidWorkflowId + "' not found"));
            });
        }
        [Test]
        public void WorkflowService_WorkflowCommunicationType_GetCommunications_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("workflow-service/communications");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void WorkflowService_WorkflowCommunicationType_PostCommunications_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("workflow-service/communications");
            WorkflowCommunicationType_PostCommunications_Request workflowCommunication = new WorkflowCommunicationType_PostCommunications_Request();
            List<string> WorkflowSteps = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            workflowCommunication.WorkflowSteps = WorkflowSteps;
            workflowCommunication.IsEmail = true;
            workflowCommunication.IsSms = true;
            workflowCommunication.EmailSubject = "string";
            workflowCommunication.EmailBody = "string";
            workflowCommunication.SmsText = "string";
            workflowCommunication.DelayInMinutes = 0;
            workflowCommunication.FromEmail = "sreing";
            List<string> ExcludedStates = new List<string> { "AL" };
            string payload = JsonConvert.SerializeObject(workflowCommunication, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<WorkflowCommunicationType_PostCommunications_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.IsEmail, Is.EqualTo(true));
                Assert.That(responseContent.EmailSubject, Is.EqualTo("string"));
            });
        }
        [Test]
        public void WorkflowService_WorkflowCommunicationType_PutCommunications_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("workflow-service/communications");
            WorkflowCommunicationType_PostCommunications_Request workflowCommunication = new WorkflowCommunicationType_PostCommunications_Request();
            List<string> WorkflowSteps = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            workflowCommunication.WorkflowSteps = WorkflowSteps;
            workflowCommunication.IsEmail = true;
            workflowCommunication.IsSms = true;
            workflowCommunication.EmailSubject = "string";
            workflowCommunication.EmailBody = "string";
            workflowCommunication.SmsText = "string";
            workflowCommunication.DelayInMinutes = 0;
            workflowCommunication.FromEmail = "sreing";
            List<string> ExcludedStates = new List<string> { "AL" };
            string payload = JsonConvert.SerializeObject(workflowCommunication, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<WorkflowCommunicationType_PostCommunications_Response>(response);
            string Id = responseContent.Id;

            RestClient Putclient = helper.SetUrl("workflow-service/communications/" + Id);
            WorkflowCommunicationType_PutCommunications_Request updateWorkflowCommunication = new WorkflowCommunicationType_PutCommunications_Request();
            List<string> WorkflowStepsPut = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            updateWorkflowCommunication.WorkflowSteps = WorkflowStepsPut;
            updateWorkflowCommunication.IsEmail = true;
            updateWorkflowCommunication.IsSms = true;
            updateWorkflowCommunication.EmailSubject = "string";
            updateWorkflowCommunication.EmailBody = "string";
            updateWorkflowCommunication.SmsText = "string";
            updateWorkflowCommunication.DelayInMinutes = 0;
            updateWorkflowCommunication.FromEmail = "sreing";
            List<string> ExcludedStatesPut = new List<string> { "AL" };
            updateWorkflowCommunication.ExcludedStates = ExcludedStatesPut;
            string Putpayload = JsonConvert.SerializeObject(updateWorkflowCommunication, Formatting.Indented);
            RestRequest Putrequest = helper.CreatePutRequest(Putpayload, acessToken);
            /// Act
            IRestResponse Putresponse = helper.GetResponse(Putclient, Putrequest);
            /// Assert
            Assert.That(Putresponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void WorkflowService_WorkflowCommunicationType_PutCommunications_NegativeScenario_InvalidId()
        {
            /// Arrange
            RestClient Putclient = helper.SetUrl("workflow-service/communications/" + InvalidWorkflowId);
            WorkflowCommunicationType_PutCommunications_Request updateWorkflowCommunication = new WorkflowCommunicationType_PutCommunications_Request();
            List<string> WorkflowStepsPut = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            updateWorkflowCommunication.WorkflowSteps = WorkflowStepsPut;
            updateWorkflowCommunication.IsEmail = true;
            updateWorkflowCommunication.IsSms = true;
            updateWorkflowCommunication.EmailSubject = "string";
            updateWorkflowCommunication.EmailBody = "string";
            updateWorkflowCommunication.SmsText = "string";
            updateWorkflowCommunication.DelayInMinutes = 0;
            updateWorkflowCommunication.FromEmail = "sreing";
            List<string> ExcludedStatesPut = new List<string> { "AL" };
            updateWorkflowCommunication.ExcludedStates = ExcludedStatesPut;
            string Putpayload = JsonConvert.SerializeObject(updateWorkflowCommunication, Formatting.Indented);
            RestRequest Putrequest = helper.CreatePutRequest(Putpayload, acessToken);
            /// Act
            IRestResponse Putresponse = helper.GetResponse(Putclient, Putrequest);
            var responseContent = helper.GetContent<WorkflowService_Responses_NegativeScenario>(Putresponse);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(Putresponse.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.ErrorType, Is.EqualTo("EntityNotFound"));
                Assert.That(responseContent.ErrorMessage, Is.EqualTo("Entity type of Phoenix2.WorkflowService.Domain.Entities.WorkflowCommunication with id '" + InvalidWorkflowId + "' not found"));
            });
        }
        [Test]
        public void WorkflowService_WorkflowStepAutoMoveType_GetAutoMove_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("workflow-service/automove");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void WorkflowService_WorkflowStepAutoMoveType_PostAutoMove_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("workflow-service/automove");
            WorkflowStepAutoMoveType_PostAutoMove_Request workflowStepAutoMove = new WorkflowStepAutoMoveType_PostAutoMove_Request()
            {
                CurrentStepId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                NextStepId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                DaysInStep = 0,
                Description = "string"
            };
            string payload = JsonConvert.SerializeObject(workflowStepAutoMove, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<WorkflowStepAutoMoveType_PostAutoMove_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.CurrentStepId, Is.EqualTo("3fa85f64-5717-4562-b3fc-2c963f66afa6"));
                Assert.That(responseContent.NextStepId, Is.EqualTo("3fa85f64-5717-4562-b3fc-2c963f66afa6"));
            });
        }

        [Test]
        public void WorkflowService_WorkflowStepAutoMoveType_PutAutoMove_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("workflow-service/automove");
            WorkflowStepAutoMoveType_PostAutoMove_Request workflowStepAutoMove = new WorkflowStepAutoMoveType_PostAutoMove_Request()
            {
                CurrentStepId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                NextStepId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                DaysInStep = 0,
                Description = "string"
            };
            string payload = JsonConvert.SerializeObject(workflowStepAutoMove, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<WorkflowStepAutoMoveType_PostAutoMove_Response>(response);
            string Id = responseContent.Id;

            RestClient clientPut = helper.SetUrl("workflow-service/automove/" + Id);
            WorkflowStepAutoMoveType_PutAutoMove_Request updateWorkflowStepAutoMove = new WorkflowStepAutoMoveType_PutAutoMove_Request()
            {
                CurrentStepId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                NextStepId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                DaysInStep = 0,
                Description = "string"
            };
            string payloadPut = JsonConvert.SerializeObject(updateWorkflowStepAutoMove, Formatting.Indented);
            RestRequest requestPut = helper.CreatePutRequest(payloadPut, acessToken);
            /// Act
            IRestResponse responsePut = helper.GetResponse(clientPut, requestPut);
            /// Assert
            Assert.That(responsePut.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void WorkflowService_WorkflowStepAutoMoveType_PutAutoMove_NegativeScenario()
        {
            /// Arrange
            RestClient clientPut = helper.SetUrl("workflow-service/automove/" + InvalidWorkflowId);
            WorkflowStepAutoMoveType_PutAutoMove_Request updateWorkflowStepAutoMove = new WorkflowStepAutoMoveType_PutAutoMove_Request()
            {
                CurrentStepId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                NextStepId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                DaysInStep = 0,
                Description = "string"
            };
            string payloadPut = JsonConvert.SerializeObject(updateWorkflowStepAutoMove, Formatting.Indented);
            RestRequest requestPut = helper.CreatePutRequest(payloadPut, acessToken);
            /// Act
            IRestResponse responsePut = helper.GetResponse(clientPut, requestPut);
            /// Assert
            Assert.That(responsePut.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
        [Test]
        public void WorkflowService_WorkflowStepDealType_CurrentWorkflowByIdDeal_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("workflow-service/workflowstepdeal/" + WorkflowServiceId + "/currentworkflow");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void WorkflowService_WorkflowStepDealType_MovesStep_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("workflow-service/workflowstepdeal/" + WorkflowServiceId + "/movestep");
            WorkflowStepDealType_MovesStep_Request moveDealToStep = new WorkflowStepDealType_MovesStep_Request()
            {
                CurrentStepId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                NextStepId = "3fa85f64-5717-4562-b3fc-2c963f66afa6"
            };
            string payload = JsonConvert.SerializeObject(moveDealToStep, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void WorkflowService_WorkflowStepLeadType_CurrentWorkflowLead_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("workflow-service/workflowsteplead/" + WorkflowServiceId + "/currentworkflowlead");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void WorkflowService_WorkflowStepLeadType_MoveLeadsStep_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("workflow-service/workflowstepdeal/" + WorkflowServiceId + "/movestep");
            WorkflowStepLeadType_MoveLeadsStep_Request moveDealToStep = new WorkflowStepLeadType_MoveLeadsStep_Request()
            {
                CurrentStepId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                NextStepId = "3fa85f64-5717-4562-b3fc-2c963f66afa6"
            };
            string payload = JsonConvert.SerializeObject(moveDealToStep, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void WorkflowService_WorkflowStepLeadType_MoveLeadsStep_NegativeScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("workflow-service/workflowstepdeal/" + WorkflowServiceId + "/movestep");
            WorkflowStepLeadType_MoveLeadsStep_Request moveDealToStep = new WorkflowStepLeadType_MoveLeadsStep_Request()
            {
                CurrentStepId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                NextStepId = "3fa85f64-5717-4562-b3fc-2c963f66afa6"
            };
            string payload = JsonConvert.SerializeObject(moveDealToStep, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}
