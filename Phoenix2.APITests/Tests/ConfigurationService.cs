using Newtonsoft.Json;
using NUnit.Framework;
using Phoenix2.APITests.DTO.ConfigurationServiceDTO;
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
    class ConfigurationService
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
        public void ConfigurationService_ConfigurationType_GetConfigurations_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("configuration-service/configurations");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void ConfigurationService_ConfigurationType_ConfiguretionGroupTokenName_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("configuration-service/configurations");
            string Group = helper.GenerateDocName(6);
            string Token = helper.GenerateDocName(6);
            string description = helper.GenerateDocName(3);
            string ValueData = helper.GenerateDocName(4);
            ConfigurationType_PostConfigurations_Request cretingConfigGroup = new ConfigurationType_PostConfigurations_Request()
            {
                ConfigurationGroup = Group,
                TokenName = Token,
                Value = ValueData,
                Description = description
            };
            string payload = JsonConvert.SerializeObject(cretingConfigGroup, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<ConfigurationType_PostConfigurations_Responses>(response);
            string CofidurationGroup = responseContent.ConfigurationGroup;
            string TokenName = responseContent.TokenName;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient clientGet = helper.SetUrl("configuration-service/configurations/configuration-group/" + CofidurationGroup + "/token-name/" + TokenName);
            RestRequest requestGet = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse responseGet = helper.GetResponse(clientGet, requestGet);
            var responseContentGet = helper.GetContent<ConfigurationType_ConfiguretionGroupTokenName_Responses>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseGet.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContentGet.ConfigurationGroup, Is.EqualTo(CofidurationGroup));
                Assert.That(responseContentGet.TokenName, Is.EqualTo(TokenName));
                Assert.That(responseContentGet.Value, Is.EqualTo(ValueData));
            });
        }

        [Test]
        [TestCase(ConfigurationGroupInvalid, tokenName)]
        [TestCase(ConfigurationGroup, tokenNameInvalid)]
        [TestCase(ConfigurationGroupInvalid, tokenNameInvalid)]
        public void ConfigurationService_ConfigurationType_ConfiguretionGroupTokenName_NegativeScenario(string ConfigurationGroup, string tokenName)
        {
            /// Arrange
            RestClient client = helper.SetUrl("configuration-service/configurations/configuration-group/" + ConfigurationGroup + "/token-name/" + tokenName);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_ConfigurationService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Exception of type 'Phoenix.Common.Models.Exceptions.EntityNotFoundException' was thrown."));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void ConfigurationService_ConfigurationType_PostConfigurations_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("configuration-service/configurations");
            string Group = helper.GenerateDocName(6);
            string Token = helper.GenerateDocName(6);
            string description = helper.GenerateDocName(3);
            ConfigurationType_PostConfigurations_Request cretingConfigGroup = new ConfigurationType_PostConfigurations_Request()
            {
                ConfigurationGroup = Group,
                TokenName = Token,
                Value = "string",
                Description = description
            };
            string payload = JsonConvert.SerializeObject(cretingConfigGroup, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload,acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<ConfigurationType_PostConfigurations_Responses>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.ConfigurationGroup, Is.EqualTo(Group));
                Assert.That(responseContent.TokenName, Is.EqualTo(Token));
                Assert.That(responseContent.Description, Is.EqualTo(description));
            });
        }

        [Test]
        public void ConfigurationService_ConfigurationType_PostConfigurations_NegativeScenario_ExistingData()
        {
            /// Arrange
            RestClient client = helper.SetUrl("configuration-service/configurations");
            ConfigurationType_PostConfigurations_Request cretingConfigGroup = new ConfigurationType_PostConfigurations_Request()
            {
                ConfigurationGroup = "string",
                TokenName = "string",
                Value = "string",
                Description = "string"
            };
            string payload = JsonConvert.SerializeObject(cretingConfigGroup, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_ConfigurationService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Message, Is.EqualTo("Key: model : Message Combination of Configuration Group and Token Name should be unique.\n"));
                Assert.That(responseContent.Code, Is.EqualTo("BadRequest"));
            });
        }

        [Test]
        public void ConfigurationService_ConfigurationType_PatchConfigurations_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("configuration-service/configurations");
            string Group = helper.GenerateDocName(6);
            string Token = helper.GenerateDocName(6);
            string description = helper.GenerateDocName(3);
            ConfigurationType_PostConfigurations_Request cretingConfigGroup = new ConfigurationType_PostConfigurations_Request()
            {
                ConfigurationGroup = Group,
                TokenName = Token,
                Value = "string",
                Description = description
            };
            string payload = JsonConvert.SerializeObject(cretingConfigGroup, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<ConfigurationType_PostConfigurations_Responses>(response);
            string CofidurationId = responseContent.Id;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient clientPatch = helper.SetUrl("configuration-service/configurations/" + CofidurationId);
            string GroupPatch = helper.GenerateDocName(6);
            string TokenPatch = helper.GenerateDocName(6);
            string descriptionPatch = helper.GenerateDocName(3);
            ConfigurationType_PatchConfigurations_Request changeConfigGroup = new ConfigurationType_PatchConfigurations_Request()
            {
                ConfigurationGroup = GroupPatch,
                TokenName = TokenPatch,
                Value = "string",
                Description = descriptionPatch
            };
            string payloadPatch = JsonConvert.SerializeObject(changeConfigGroup, Formatting.Indented);
            RestRequest requestPatch = helper.CreatePatchRequest(payloadPatch, acessToken);
            /// Act
            IRestResponse responsePatch = helper.GetResponse(clientPatch, requestPatch);
            var responseContentPut = helper.GetContent<ConfigurationType_PatchConfigurations_Responses>(responsePatch);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responsePatch.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContentPut.Id, Is.EqualTo(CofidurationId));
                Assert.That(responseContentPut.ConfigurationGroup, Is.EqualTo(GroupPatch));
                Assert.That(responseContentPut.TokenName, Is.EqualTo(TokenPatch));
                Assert.That(responseContentPut.Description, Is.EqualTo(descriptionPatch));
            });
        }

        [Test]
        public void ConfigurationService_ConfigurationType_PatchConfigurations_NegativeScenario_InvalidConfigurationId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("configuration-service/configurations/" + IdConfigurationInvalid);
            string Group = helper.GenerateDocName(6);
            string Token = helper.GenerateDocName(6);
            string description = helper.GenerateDocName(3);
            ConfigurationType_PostConfigurations_Request changeConfigGroup = new ConfigurationType_PostConfigurations_Request()
            {
                ConfigurationGroup = Group,
                TokenName = Token,
                Value = "string",
                Description = description
            };
            string payload = JsonConvert.SerializeObject(changeConfigGroup, Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_ConfigurationService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.ConfigurationService.Domain.Entities.Configuration with id '" + IdConfigurationInvalid + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void ConfigurationService_ConfigurationType_DeleteConfigurations_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("configuration-service/configurations");
            string Group = helper.GenerateDocName(6);
            string Token = helper.GenerateDocName(6);
            string description = helper.GenerateDocName(3);
            ConfigurationType_PostConfigurations_Request cretingConfigGroup = new ConfigurationType_PostConfigurations_Request()
            {
                ConfigurationGroup = Group,
                TokenName = Token,
                Value = "string",
                Description = description
            };
            string payload = JsonConvert.SerializeObject(cretingConfigGroup, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<ConfigurationType_PostConfigurations_Responses>(response);
            string CofidurationId = responseContent.Id;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient clientDelete = helper.SetUrl("configuration-service/configurations/" + CofidurationId);
            RestRequest DeleteRequest = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse DeleteResponse = helper.GetResponse(clientDelete, DeleteRequest);
            /// Assert
            Assert.That(DeleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void ConfigurationService_ConfigurationType_DeleteConfigurations_NegativeScenario_InvalidConfigurationId()
        {
            /// Arrange
            RestClient Deleteclient = helper.SetUrl("configuration-service/configurations/" + IdConfigurationInvalid);
            RestRequest request = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(Deleteclient, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void ConfigurationService_ConfigurationType_GroupsToken_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("configuration-service/configurations/groups-tokens");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void ConfigurationService_MenuType_Items_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("configuration-service/menu/items");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void ConfigurationService_QueueConfigurationType_GroupsAndSubgroups_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("configuration-service/queue-configurations/groups-and-subgroups");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void ConfigurationService_QueueConfigurationType_GroupsSubgroups_PositiveScenario()
        {
            /// Arrange
            RestClient clientPut = helper.SetUrl("configuration-service/queue-configurations");
            string Group = helper.GenerateDocName(6);
            string SubGroup = helper.GenerateDocName(6);
            QueueConfigurationType_PutQueueConfigurations_Request ueueConfigurationqs = new QueueConfigurationType_PutQueueConfigurations_Request();
            ueueConfigurationqs.Group = Group;
            ueueConfigurationqs.Subgroup = SubGroup;
            ueueConfigurationqs.ParamsType = "DealIndexParams";
            MenuWorkflows_PutQueueConfigurations_Request menuWorkflows = new MenuWorkflows_PutQueueConfigurations_Request();
            List<string> workflowIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            menuWorkflows.WorkflowIds = workflowIds;
            List<string> stepIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            menuWorkflows.StepIds = stepIds;
            ueueConfigurationqs.MenuWorkflows = menuWorkflows;
            ueueConfigurationqs.HasMyContacts = true;
            ueueConfigurationqs.HasMyTeamContacts = true;
            ueueConfigurationqs.HasMyDeals = true;
            ueueConfigurationqs.HasMyTeamDeals = true;
            ueueConfigurationqs.HasRedDeals = true;
            ueueConfigurationqs.HasAmberDeals = true;
            ueueConfigurationqs.HasGreenDeals = true;
            ueueConfigurationqs.HasRedContacts = true;
            ueueConfigurationqs.HasAmberContacts = true;
            ueueConfigurationqs.HasGreenContacts = true;
            ueueConfigurationqs.IsUnAssigned = true;
            ueueConfigurationqs.HasDeals = "False";
            ueueConfigurationqs.HasActiveDeal = "False";
            ueueConfigurationqs.UnAssignedTag = "Accounting";
            List<string> excludedLenderIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            ueueConfigurationqs.ExcludedLenderIds = excludedLenderIds;
            ueueConfigurationqs.IsDealActive = "False";
            ueueConfigurationqs.AssetSelected = "False";
            ueueConfigurationqs.IsHotTitles = true;
            ueueConfigurationqs.IsQueueEnabled = true;
            ueueConfigurationqs.CheckRequestStatus = "AddComment";
            ueueConfigurationqs.IsQueueEmailRequired = true;
            List<string> queueEmailRoles = new List<string> { "LC" };
            ueueConfigurationqs.QueueEmailRoles = queueEmailRoles;
            ueueConfigurationqs.Description = "string";
            ueueConfigurationqs.RoleId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            ueueConfigurationqs.IsCountRequired = true;
            ueueConfigurationqs.IsDownPaymentDeclineQueue = true;
            ueueConfigurationqs.IsBuyBackQueue = true;
            List<string> includedLenderIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            ueueConfigurationqs.IncludedLenderIds = includedLenderIds;
            List<string> lenderIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            ueueConfigurationqs.LenderIds = lenderIds;
            ueueConfigurationqs.HasReferralContactId = "False";
            string payloadPut = JsonConvert.SerializeObject(ueueConfigurationqs, Formatting.Indented);
            RestRequest requestPut = helper.CreatePutRequest(payloadPut, acessToken);
            Console.WriteLine(payloadPut);
            IRestResponse responsePut = helper.GetResponse(clientPut, requestPut);
            var responseContentPut = helper.GetContent<QueueConfigurationType_PutQueueConfigurations_Responses>(responsePut);
            string group = responseContentPut.Group;
            string subgroup = responseContentPut.Subgroup;
            string id = responseContentPut.Id;
            Assert.That(responsePut.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient client = helper.SetUrl("configuration-service/queue-configurations/groups/" + group + "/subgroups/" + subgroup);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<QueueConfigurationType_PutQueueConfigurations_Responses>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Id, Is.EqualTo(id));
                Assert.That(responseContent.Group, Is.EqualTo(group));
                Assert.That(responseContent.Subgroup, Is.EqualTo(subgroup));
            });
        }

        [Test]
        [TestCase(ConfigurationGroup, ConfigurationSubGroupInvalid)]
        [TestCase(ConfigurationGroupInvalid, ConfigurationSubGroupInvalid)]
        public void ConfigurationService_QueueConfigurationType_GroupsSubgroups_NegativeScenario(string Group, string SubGroup)
        {
            /// Arrange
            RestClient client = helper.SetUrl("configuration-service/queue-configurations/groups/" + Group + "/subgroups/" + SubGroup);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_ConfigurationService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Message There is no Queue Configuration with Group: " + Group + " and Subgroup: " + SubGroup + " \n Entity type of Phoenix2.ConfigurationService.Domain.Entities.QueueConfiguration"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void ConfigurationService_QueueConfigurationType_WorkflowsSteps_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("configuration-service/queue-configurations/workflows/" + WorkflowId + "/steps/" + StepId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ConfigurationService_QueueConfigurationType_WorkflowsSteps_NegativeScenario_InvalidData()
        {
            /// Arrange
            RestClient client = helper.SetUrl("configuration-service/queue-configurations/workflows/" + leadIdInvaild + "/steps/" + leadNoteIdInvalid);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
        [Test]
        public void ConfigurationService_QueueConfigurationType_ParameterTypes_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("configuration-service/queue-configurations/parameter-types");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ConfigurationService_QueueConfigurationType_QueueEmailRoleTypes_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("configuration-service/queue-configurations/queue-email-role-types");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void ConfigurationService_QueueConfigurationType_PatchQueueConfigurations_PositiveScenario()
        {
            /// Arrange
            RestClient clientPut = helper.SetUrl("configuration-service/queue-configurations");
            string Group = helper.GenerateDocName(6);
            string SubGroup = helper.GenerateDocName(6);
            QueueConfigurationType_PutQueueConfigurations_Request queueConfigurations = new QueueConfigurationType_PutQueueConfigurations_Request();
            queueConfigurations.Group = Group;
            queueConfigurations.Subgroup = SubGroup;
            queueConfigurations.ParamsType = "DealIndexParams";
            MenuWorkflows_PutQueueConfigurations_Request menuWorkflows = new MenuWorkflows_PutQueueConfigurations_Request();
            List<string> workflowIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            menuWorkflows.WorkflowIds = workflowIds;
            List<string> stepIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            menuWorkflows.StepIds = stepIds;
            queueConfigurations.MenuWorkflows = menuWorkflows;
            queueConfigurations.HasMyContacts = true;
            queueConfigurations.HasMyTeamContacts = true;
            queueConfigurations.HasMyDeals = true;
            queueConfigurations.HasMyTeamDeals = true;
            queueConfigurations.HasRedDeals = true;
            queueConfigurations.HasAmberDeals = true;
            queueConfigurations.HasGreenDeals = true;
            queueConfigurations.HasRedContacts = true;
            queueConfigurations.HasAmberContacts = true;
            queueConfigurations.HasGreenContacts = true;
            queueConfigurations.IsUnAssigned = true;
            queueConfigurations.HasDeals = "False";
            queueConfigurations.HasActiveDeal = "False";
            queueConfigurations.UnAssignedTag = "Accounting";
            List<string> excludedLenderIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            queueConfigurations.ExcludedLenderIds = excludedLenderIds;
            queueConfigurations.IsDealActive = "False";
            queueConfigurations.AssetSelected = "False";
            queueConfigurations.IsHotTitles = true;
            queueConfigurations.IsQueueEnabled = true;
            queueConfigurations.CheckRequestStatus = "AddComment";
            queueConfigurations.IsQueueEmailRequired = true;
            List<string> queueEmailRoles = new List<string> { "LC" };
            queueConfigurations.QueueEmailRoles = queueEmailRoles;
            queueConfigurations.Description = "string";
            queueConfigurations.RoleId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            queueConfigurations.IsCountRequired = true;
            queueConfigurations.IsDownPaymentDeclineQueue = true;
            queueConfigurations.IsBuyBackQueue = true;
            List<string> includedLenderIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            queueConfigurations.IncludedLenderIds = includedLenderIds;
            List<string> lenderIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            queueConfigurations.LenderIds = lenderIds;
            queueConfigurations.HasReferralContactId = "False";
            string payloadPut = JsonConvert.SerializeObject(queueConfigurations, Formatting.Indented);
            RestRequest requestPut = helper.CreatePutRequest(payloadPut, acessToken);
            /// Act
            IRestResponse responsePut = helper.GetResponse(clientPut, requestPut);
            var responseContentPut = helper.GetContent<QueueConfigurationType_PutQueueConfigurations_Responses>(responsePut);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responsePut.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContentPut.Group, Is.EqualTo(Group));
                Assert.That(responseContentPut.Subgroup, Is.EqualTo(SubGroup));
                Assert.That(responseContentPut.ParamsType, Is.EqualTo("DealIndexParams"));
            });
        }
        [Test]
        public void ConfigurationService_QueueConfigurationType_PatchQueueConfigurations_NegativeScenario_ExistingGroup()
        {
            /// Arrange
            RestClient client = helper.SetUrl("configuration-service/queue-configurations");
            string Group = helper.GenerateDocName(6);
            string SubGroup = helper.GenerateDocName(6);
            QueueConfigurationType_PutQueueConfigurations_Request queueConfigurations = new QueueConfigurationType_PutQueueConfigurations_Request();
            queueConfigurations.Group = "string";
            queueConfigurations.Subgroup = "string";
            queueConfigurations.ParamsType = "DealIndexParams";
            MenuWorkflows_PutQueueConfigurations_Request menuWorkflows = new MenuWorkflows_PutQueueConfigurations_Request();
            List<string> workflowIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            menuWorkflows.WorkflowIds = workflowIds;
            List<string> stepIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            menuWorkflows.StepIds = stepIds;
            queueConfigurations.MenuWorkflows = menuWorkflows;
            queueConfigurations.HasMyContacts = true;
            queueConfigurations.HasMyTeamContacts = true;
            queueConfigurations.HasMyDeals = true;
            queueConfigurations.HasMyTeamDeals = true;
            queueConfigurations.HasRedDeals = true;
            queueConfigurations.HasAmberDeals = true;
            queueConfigurations.HasGreenDeals = true;
            queueConfigurations.HasRedContacts = true;
            queueConfigurations.HasAmberContacts = true;
            queueConfigurations.HasGreenContacts = true;
            queueConfigurations.IsUnAssigned = true;
            queueConfigurations.HasDeals = "False";
            queueConfigurations.HasActiveDeal = "False";
            queueConfigurations.UnAssignedTag = "Accounting";
            List<string> excludedLenderIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            queueConfigurations.ExcludedLenderIds = excludedLenderIds;
            queueConfigurations.IsDealActive = "False";
            queueConfigurations.AssetSelected = "False";
            queueConfigurations.IsHotTitles = true;
            queueConfigurations.IsQueueEnabled = true;
            queueConfigurations.CheckRequestStatus = "AddComment";
            queueConfigurations.IsQueueEmailRequired = true;
            List<string> queueEmailRoles = new List<string> { "LC" };
            queueConfigurations.QueueEmailRoles = queueEmailRoles;
            queueConfigurations.Description = "string";
            queueConfigurations.RoleId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            queueConfigurations.IsCountRequired = true;
            queueConfigurations.IsDownPaymentDeclineQueue = true;
            queueConfigurations.IsBuyBackQueue = true;
            List<string> includedLenderIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            queueConfigurations.IncludedLenderIds = includedLenderIds;
            List<string> lenderIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            queueConfigurations.LenderIds = lenderIds;
            queueConfigurations.HasReferralContactId = "False";
            string payload = JsonConvert.SerializeObject(queueConfigurations, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_ConfigurationService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Message, Is.EqualTo("Key: model : Message Subgroup should be unique in a particular Group.\n"));
                Assert.That(responseContent.Code, Is.EqualTo("BadRequest"));
            });
        }

        [Test]
        public void ConfigurationService_QueueConfigurationType_PutQueueConfigurations_PositiveScenario()
        {
            /// Arrange
            RestClient clientPut = helper.SetUrl("configuration-service/queue-configurations");
            string Group = helper.GenerateDocName(6);
            string SubGroup = helper.GenerateDocName(6);
            QueueConfigurationType_PutQueueConfigurations_Request queueConfigurations = new QueueConfigurationType_PutQueueConfigurations_Request();
            queueConfigurations.Group = Group;
            queueConfigurations.Subgroup = SubGroup;
            queueConfigurations.ParamsType = "DealIndexParams";
            MenuWorkflows_PutQueueConfigurations_Request menuWorkflows = new MenuWorkflows_PutQueueConfigurations_Request();
            List<string> workflowIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            menuWorkflows.WorkflowIds = workflowIds;
            List<string> stepIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            menuWorkflows.StepIds = stepIds;
            queueConfigurations.MenuWorkflows = menuWorkflows;
            queueConfigurations.HasMyContacts = true;
            queueConfigurations.HasMyTeamContacts = true;
            queueConfigurations.HasMyDeals = true;
            queueConfigurations.HasMyTeamDeals = true;
            queueConfigurations.HasRedDeals = true;
            queueConfigurations.HasAmberDeals = true;
            queueConfigurations.HasGreenDeals = true;
            queueConfigurations.HasRedContacts = true;
            queueConfigurations.HasAmberContacts = true;
            queueConfigurations.HasGreenContacts = true;
            queueConfigurations.IsUnAssigned = true;
            queueConfigurations.HasDeals = "False";
            queueConfigurations.HasActiveDeal = "False";
            queueConfigurations.UnAssignedTag = "Accounting";
            List<string> excludedLenderIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            queueConfigurations.ExcludedLenderIds = excludedLenderIds;
            queueConfigurations.IsDealActive = "False";
            queueConfigurations.AssetSelected = "False";
            queueConfigurations.IsHotTitles = true;
            queueConfigurations.IsQueueEnabled = true;
            queueConfigurations.CheckRequestStatus = "AddComment";
            queueConfigurations.IsQueueEmailRequired = true;
            List<string> queueEmailRoles = new List<string> { "LC" };
            queueConfigurations.QueueEmailRoles = queueEmailRoles;
            queueConfigurations.Description = "string";
            queueConfigurations.RoleId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            queueConfigurations.IsCountRequired = true;
            queueConfigurations.IsDownPaymentDeclineQueue = true;
            queueConfigurations.IsBuyBackQueue = true;
            List<string> includedLenderIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            queueConfigurations.IncludedLenderIds = includedLenderIds;
            List<string> lenderIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            queueConfigurations.LenderIds = lenderIds;
            queueConfigurations.HasReferralContactId = "False";
            string payloadPut = JsonConvert.SerializeObject(queueConfigurations, Formatting.Indented);
            RestRequest requestPut = helper.CreatePutRequest(payloadPut, acessToken);
            IRestResponse responsePut = helper.GetResponse(clientPut, requestPut);
            var responseContentPut = helper.GetContent<QueueConfigurationType_PutQueueConfigurations_Responses>(responsePut);
            string Id = responseContentPut.Id;
            Assert.That(responsePut.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient client = helper.SetUrl("configuration-service/queue-configurations/" + Id);
            string GroupPatch = helper.GenerateDocName(6);
            string SubGroupPatch = helper.GenerateDocName(6);
            QueueConfigurationType_PutQueueConfigurations_Request changeQueueConfigurations = new QueueConfigurationType_PutQueueConfigurations_Request();
            changeQueueConfigurations.Group = GroupPatch;
            changeQueueConfigurations.Subgroup = SubGroupPatch;
            changeQueueConfigurations.ParamsType = "DealIndexParams";
            MenuWorkflows_PutQueueConfigurations_Request changeMenuWorkflows = new MenuWorkflows_PutQueueConfigurations_Request();
            List<string> workflowIds1 = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            changeMenuWorkflows.WorkflowIds = workflowIds1;
            List<string> stepIds1 = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            changeMenuWorkflows.StepIds = stepIds1;
            changeQueueConfigurations.MenuWorkflows = changeMenuWorkflows;
            changeQueueConfigurations.HasMyContacts = true;
            changeQueueConfigurations.HasMyTeamContacts = true;
            changeQueueConfigurations.HasMyDeals = true;
            changeQueueConfigurations.HasMyTeamDeals = true;
            changeQueueConfigurations.HasRedDeals = true;
            changeQueueConfigurations.HasAmberDeals = true;
            changeQueueConfigurations.HasGreenDeals = true;
            changeQueueConfigurations.HasRedContacts = true;
            changeQueueConfigurations.HasAmberContacts = true;
            changeQueueConfigurations.HasGreenContacts = true;
            changeQueueConfigurations.IsUnAssigned = true;
            changeQueueConfigurations.HasDeals = "False";
            changeQueueConfigurations.HasActiveDeal = "False";
            changeQueueConfigurations.UnAssignedTag = "Accounting";
            List<string> excludedLenderIds1 = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            changeQueueConfigurations.ExcludedLenderIds = excludedLenderIds1;
            changeQueueConfigurations.IsDealActive = "False";
            changeQueueConfigurations.AssetSelected = "False";
            changeQueueConfigurations.IsHotTitles = true;
            changeQueueConfigurations.IsQueueEnabled = true;
            changeQueueConfigurations.CheckRequestStatus = "AddComment";
            changeQueueConfigurations.IsQueueEmailRequired = true;
            List<string> queueEmailRoles1 = new List<string> { "LC" };
            changeQueueConfigurations.QueueEmailRoles = queueEmailRoles1;
            changeQueueConfigurations.Description = "string";
            changeQueueConfigurations.RoleId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            changeQueueConfigurations.IsCountRequired = true;
            changeQueueConfigurations.IsDownPaymentDeclineQueue = true;
            changeQueueConfigurations.IsBuyBackQueue = true;
            List<string> includedLenderIds1 = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            changeQueueConfigurations.IncludedLenderIds = includedLenderIds1;
            List<string> lenderIds1 = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            changeQueueConfigurations.LenderIds = lenderIds1;
            changeQueueConfigurations.HasReferralContactId = "False";
            string payload = JsonConvert.SerializeObject(changeQueueConfigurations, Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<QueueConfigurationType_PutQueueConfigurations_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Group, Is.EqualTo(GroupPatch));
                Assert.That(responseContent.Subgroup, Is.EqualTo(SubGroupPatch));
                Assert.That(responseContent.ParamsType, Is.EqualTo("DealIndexParams"));
            });
        }
        [Test]
        public void ConfigurationService_QueueConfigurationType_DeleteQueueConfigurations_PositiveScenario()
        {
            /// Arrange
            RestClient clientPut = helper.SetUrl("configuration-service/queue-configurations");
            string Group = helper.GenerateDocName(6);
            string SubGroup = helper.GenerateDocName(6);
            QueueConfigurationType_PutQueueConfigurations_Request queueConfigurations = new QueueConfigurationType_PutQueueConfigurations_Request();
            queueConfigurations.Group = Group;
            queueConfigurations.Subgroup = SubGroup;
            queueConfigurations.ParamsType = "DealIndexParams";
            MenuWorkflows_PutQueueConfigurations_Request menuWorkflows = new MenuWorkflows_PutQueueConfigurations_Request();
            List<string> workflowIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            menuWorkflows.WorkflowIds = workflowIds;
            List<string> stepIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            menuWorkflows.StepIds = stepIds;
            queueConfigurations.MenuWorkflows = menuWorkflows;
            queueConfigurations.HasMyContacts = true;
            queueConfigurations.HasMyTeamContacts = true;
            queueConfigurations.HasMyDeals = true;
            queueConfigurations.HasMyTeamDeals = true;
            queueConfigurations.HasRedDeals = true;
            queueConfigurations.HasAmberDeals = true;
            queueConfigurations.HasGreenDeals = true;
            queueConfigurations.HasRedContacts = true;
            queueConfigurations.HasAmberContacts = true;
            queueConfigurations.HasGreenContacts = true;
            queueConfigurations.IsUnAssigned = true;
            queueConfigurations.HasDeals = "False";
            queueConfigurations.HasActiveDeal = "False";
            queueConfigurations.UnAssignedTag = "Accounting";
            List<string> excludedLenderIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            queueConfigurations.ExcludedLenderIds = excludedLenderIds;
            queueConfigurations.IsDealActive = "False";
            queueConfigurations.AssetSelected = "False";
            queueConfigurations.IsHotTitles = true;
            queueConfigurations.IsQueueEnabled = true;
            queueConfigurations.CheckRequestStatus = "AddComment";
            queueConfigurations.IsQueueEmailRequired = true;
            List<string> queueEmailRoles = new List<string> { "LC" };
            queueConfigurations.QueueEmailRoles = queueEmailRoles;
            queueConfigurations.Description = "string";
            queueConfigurations.RoleId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            queueConfigurations.IsCountRequired = true;
            queueConfigurations.IsDownPaymentDeclineQueue = true;
            queueConfigurations.IsBuyBackQueue = true;
            List<string> includedLenderIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            queueConfigurations.IncludedLenderIds = includedLenderIds;
            List<string> lenderIds = new List<string> { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            queueConfigurations.LenderIds = lenderIds;
            queueConfigurations.HasReferralContactId = "False";
            string payloadPut = JsonConvert.SerializeObject(queueConfigurations, Formatting.Indented);
            RestRequest requestPut = helper.CreatePutRequest(payloadPut, acessToken);
            IRestResponse responsePut = helper.GetResponse(clientPut, requestPut);
            var responseContentPut = helper.GetContent<QueueConfigurationType_PutQueueConfigurations_Responses>(responsePut);
            string Id = responseContentPut.Id;
            Assert.That(responsePut.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient client = helper.SetUrl("configuration-service/queue-configurations/" + Id);
            RestRequest request = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void ConfigurationService_QueueConfigurationType_DeleteQueueConfigurations_NegativeScenario_InvalidId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("configuration-service/queue-configurations/" + teamTypeId);
            RestRequest request = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void ConfigurationService_StateRegulationConfiguration_Get_StateRegulationConfigurations_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("configuration-service/state-regulation-configurations");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ConfigurationService_StateRegulationConfigurationType_PutStateRegulationConfigurations_PositiveScenario()
        {
            /// Arrange
            RestClient clientPut = helper.SetUrl("configuration-service/state-regulation-configurations");
            string State = helper.RandomDigits(3);
            StateRegulationConfigurationType_PutStateRegulationConfigurations_Request stateRegulation = new StateRegulationConfigurationType_PutStateRegulationConfigurations_Request()
            {
                State = State,
                TitleHoldingStatus = true,
                SorRequiredStatus = true,
                AddStatus = true,
                DropStatus = true,
                NotaryRequiredStatus = true,
                TitleDocuments = "string",
                SalesTaxInformation = "string",
                SpecificRequirements = "string",
                IsAllowProductAndSalesTax = true,
                IsOutOfStateTitleAllowed = true
            };
            string payloadPut = JsonConvert.SerializeObject(stateRegulation, Formatting.Indented);
            RestRequest requestPut = helper.CreatePutRequest(payloadPut, acessToken);
            IRestResponse responsePut = helper.GetResponse(clientPut, requestPut);
            var responseContentPut = helper.GetContent<StateRegulationConfigurationType_PutStateRegulationConfigurations_Response>(responsePut);
            string Id = responseContentPut.Id;
            Assert.That(responsePut.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient client = helper.SetUrl("configuration-service/state-regulation-configurations/" + Id);
            RestRequest request = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void ConfigurationService_StateRegulationConfigurationType_PutStateRegulationConfigurations_NegativeScenario_ExistingState()
        {
            /// Arrange
            RestClient clientPut = helper.SetUrl("configuration-service/state-regulation-configurations");
            StateRegulationConfigurationType_PutStateRegulationConfigurations_Request stateRegulation = new StateRegulationConfigurationType_PutStateRegulationConfigurations_Request()
            {
                State = "AL",
                TitleHoldingStatus = true,
                SorRequiredStatus = true,
                AddStatus = true,
                DropStatus = true,
                NotaryRequiredStatus = true,
                TitleDocuments = "string",
                SalesTaxInformation = "string",
                SpecificRequirements = "string",
                IsAllowProductAndSalesTax = true,
                IsOutOfStateTitleAllowed = true
            };
            string payloadPut = JsonConvert.SerializeObject(stateRegulation, Formatting.Indented);
            RestRequest requestPut = helper.CreatePutRequest(payloadPut, acessToken);
            /// Act
            IRestResponse responsePut = helper.GetResponse(clientPut, requestPut);
            var responseContent = helper.GetContent<NegativeScenario_ConfigurationService>(responsePut);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responsePut.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Message, Is.EqualTo("Key: model : Message State should be unique.\n"));
                Assert.That(responseContent.Code, Is.EqualTo("BadRequest"));
            });
        }
        [Test]
        public void ConfigurationService_StateRegulationConfigurationType_State_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("configuration-service/state-regulation-configurations/AL");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ConfigurationService_StateRegulationConfigurationType_PatchStateRegulationConfigurations_PositiveScenario()
        {
            /// Arrange
            RestClient clientPut = helper.SetUrl("configuration-service/state-regulation-configurations");
            string State = helper.RandomDigits(3);
            StateRegulationConfigurationType_PutStateRegulationConfigurations_Request stateRegulation = new StateRegulationConfigurationType_PutStateRegulationConfigurations_Request()
            {
                State = State,
                TitleHoldingStatus = true,
                SorRequiredStatus = true,
                AddStatus = true,
                DropStatus = true,
                NotaryRequiredStatus = true,
                TitleDocuments = "string",
                SalesTaxInformation = "string",
                SpecificRequirements = "string",
                IsAllowProductAndSalesTax = true,
                IsOutOfStateTitleAllowed = true
            };
            string payloadPut = JsonConvert.SerializeObject(stateRegulation, Formatting.Indented);
            RestRequest requestPut = helper.CreatePutRequest(payloadPut, acessToken);
            IRestResponse responsePut = helper.GetResponse(clientPut, requestPut);
            var responseContentPut = helper.GetContent<StateRegulationConfigurationType_PutStateRegulationConfigurations_Response>(responsePut);
            string Id = responseContentPut.Id;
            Assert.That(responsePut.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient client = helper.SetUrl("configuration-service/state-regulation-configurations/33fe49e6-b583-45da-a50f-834ff7b47811");
            StateRegulationConfigurationType_PatchStateRegulationConfigurations_Request changeStateRegulation = new StateRegulationConfigurationType_PatchStateRegulationConfigurations_Request()
            {
                State = State,
                TitleHoldingStatus = true,
                SorRequiredStatus = true,
                AddStatus = true,
                DropStatus = true,
                NotaryRequiredStatus = true,
                TitleDocuments = "string",
                SalesTaxInformation = "string",
                SpecificRequirements = "string",
                IsAllowProductAndSalesTax = true,
                IsOutOfStateTitleAllowed = true
            };
            string payload = JsonConvert.SerializeObject(changeStateRegulation, Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void ConfigurationService_StateRegulationConfigurationType_DeleteStateRegulationConfigurations_PositiveScenario()
        {
            /// Arrange
            RestClient clientDelete = helper.SetUrl("configuration-service/state-regulation-configurations/33fe49e6-b583-45da-a50f-834ff7b47811");
            RestRequest requestDelete = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse responseDelete = helper.GetResponse(clientDelete, requestDelete);
            /// Assert
            Assert.That(responseDelete.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
    }
}
