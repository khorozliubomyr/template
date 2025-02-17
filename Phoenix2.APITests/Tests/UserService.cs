using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using NUnit.Framework;
using Phoenix2.APITests.DTO.AuthorizationModels;
using Phoenix2.APITests.DTO.UserServiceDTO;
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
    class UserService
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
        public void UserService_DripFeederType_PostDripFeeder_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/dripFeeder");
            string name = helper.GenerateDocName(3);
            DripFeederType_PostDripFeeder_Request createDripFeeder = new DripFeederType_PostDripFeeder_Request();
            createDripFeeder.Rank = 1;
            createDripFeeder.Name = name;
            Source_PostDripFeeder_Request sourceDripFeeder = new Source_PostDripFeeder_Request();
            List<Source_PostDripFeeder_Request> sources = new List<Source_PostDripFeeder_Request> { sourceDripFeeder };
            createDripFeeder.Sources = sources;
            sourceDripFeeder.SourceId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            sourceDripFeeder.Order = 0;
            sourceDripFeeder.MaxPulls = 0;
            sourceDripFeeder.IsRankedSource = true;
            createDripFeeder.RoleId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            createDripFeeder.MaxPulls = 0;
            createDripFeeder.MinutesBetweenPulls = 0;
            createDripFeeder.PullNewestFirst = true;
            createDripFeeder.UseSourceWithLowestCountFirst = true;
            createDripFeeder.IsFronterSet = true;
            string payload = JsonConvert.SerializeObject(createDripFeeder, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DripFeederType_PostDripFeeder_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Rank, Is.EqualTo(1));
                Assert.That(responseContent.Name, Is.EqualTo(name));
            });
        }
        [Test]
        public void UserService_DripFeederType_PostDripFeeder_NegativeScenario_ExistingData()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/dripFeeder");
            DripFeederType_PostDripFeeder_Request createDripFeeder = new DripFeederType_PostDripFeeder_Request();
            createDripFeeder.Rank = 1;
            createDripFeeder.Name = "string";
            Source_PostDripFeeder_Request sourceDripFeeder = new Source_PostDripFeeder_Request();
            List<Source_PostDripFeeder_Request> sources = new List<Source_PostDripFeeder_Request> { sourceDripFeeder };
            createDripFeeder.Sources = sources;
            sourceDripFeeder.SourceId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            sourceDripFeeder.Order = 0;
            sourceDripFeeder.MaxPulls = 0;
            sourceDripFeeder.IsRankedSource = true;
            createDripFeeder.RoleId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            createDripFeeder.MaxPulls = 0;
            createDripFeeder.MinutesBetweenPulls = 0;
            createDripFeeder.PullNewestFirst = true;
            createDripFeeder.UseSourceWithLowestCountFirst = true;
            createDripFeeder.IsFronterSet = true;
            string payload = JsonConvert.SerializeObject(createDripFeeder, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<UserService_NegativeScenario>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Message, Is.EqualTo("Key: model : Message The Drip Feeder rank should be unique.\n"));
                Assert.That(responseContent.Code, Is.EqualTo("BadRequest"));
            });
        }
        [Test]
        public void UserService_DripFeederType_GetDripFeeder_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/dripFeeder");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void UserService_DripFeederType_PatchDripFeeder_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/dripFeeder");
            string name = helper.GenerateDocName(3);
            DripFeederType_PostDripFeeder_Request createDripFeeder = new DripFeederType_PostDripFeeder_Request();
            createDripFeeder.Rank = 1;
            createDripFeeder.Name = name;
            Source_PostDripFeeder_Request sourceDripFeeder = new Source_PostDripFeeder_Request();
            List<Source_PostDripFeeder_Request> sources = new List<Source_PostDripFeeder_Request> { sourceDripFeeder };
            createDripFeeder.Sources = sources;
            sourceDripFeeder.SourceId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            sourceDripFeeder.Order = 0;
            sourceDripFeeder.MaxPulls = 0;
            sourceDripFeeder.IsRankedSource = true;
            createDripFeeder.RoleId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            createDripFeeder.MaxPulls = 0;
            createDripFeeder.MinutesBetweenPulls = 0;
            createDripFeeder.PullNewestFirst = true;
            createDripFeeder.UseSourceWithLowestCountFirst = true;
            createDripFeeder.IsFronterSet = true;
            string payload = JsonConvert.SerializeObject(createDripFeeder, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DripFeederType_PostDripFeeder_Response>(response);
            string Id = responseContent.Id;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient clientPatch = helper.SetUrl("user-service/dripFeeder/" + Id);
            string namePatch = helper.GenerateDocName(3);
            DripFeederType_PostDripFeeder_Request updateDripFeeder = new DripFeederType_PostDripFeeder_Request();
            updateDripFeeder.Rank = 1;
            updateDripFeeder.Name = namePatch;
            Source_PostDripFeeder_Request updateSource = new Source_PostDripFeeder_Request();
            List<Source_PostDripFeeder_Request> updateSources = new List<Source_PostDripFeeder_Request> { updateSource };
            updateDripFeeder.Sources = updateSources;
            updateSource.SourceId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            updateSource.Order = 0;
            updateSource.MaxPulls = 0;
            updateSource.IsRankedSource = true;
            updateDripFeeder.RoleId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            updateDripFeeder.MaxPulls = 0;
            updateDripFeeder.MinutesBetweenPulls = 0;
            updateDripFeeder.PullNewestFirst = true;
            updateDripFeeder.UseSourceWithLowestCountFirst = true;
            updateDripFeeder.IsFronterSet = true;
            string payloadPatch = JsonConvert.SerializeObject(updateDripFeeder, Formatting.Indented);
            RestRequest requestPatsh = helper.CreatePostRequest(payloadPatch, acessToken);
            /// Act
            IRestResponse responsePatch = helper.GetResponse(clientPatch, requestPatsh);
            /// Assert
            Assert.That(responsePatch.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void UserService_DripFeederType_PatchDripFeeder_NegativeScenario_InvalidId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/dripFeeder/" + InvalidGuidContactId);
            string namePatch = helper.GenerateDocName(3);
            DripFeederType_PostDripFeeder_Request updateDripFeeder = new DripFeederType_PostDripFeeder_Request();
            updateDripFeeder.Rank = 1;
            updateDripFeeder.Name = namePatch;
            Source_PostDripFeeder_Request updateSource = new Source_PostDripFeeder_Request();
            List<Source_PostDripFeeder_Request> updateSources = new List<Source_PostDripFeeder_Request> { updateSource };
            updateDripFeeder.Sources = updateSources;
            updateSource.SourceId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            updateSource.Order = 0;
            updateSource.MaxPulls = 0;
            updateSource.IsRankedSource = true;
            updateDripFeeder.RoleId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            updateDripFeeder.MaxPulls = 0;
            updateDripFeeder.MinutesBetweenPulls = 0;
            updateDripFeeder.PullNewestFirst = true;
            updateDripFeeder.UseSourceWithLowestCountFirst = true;
            updateDripFeeder.IsFronterSet = true;
            string payload = JsonConvert.SerializeObject(updateDripFeeder, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<UserService_NegativeScenario>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.UserService.Domain.Entities.OfficeLocation with id '" + InvalidGuidContactId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void UserService_DripFeederType_DeleteDripFeeder_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/dripFeeder");
            string name = helper.GenerateDocName(3);
            DripFeederType_PostDripFeeder_Request createDripFeeder = new DripFeederType_PostDripFeeder_Request();
            createDripFeeder.Rank = 1;
            createDripFeeder.Name = name;
            Source_PostDripFeeder_Request sourceDripFeeder = new Source_PostDripFeeder_Request();
            List<Source_PostDripFeeder_Request> sources = new List<Source_PostDripFeeder_Request> { sourceDripFeeder };
            createDripFeeder.Sources = sources;
            sourceDripFeeder.SourceId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            sourceDripFeeder.Order = 0;
            sourceDripFeeder.MaxPulls = 0;
            sourceDripFeeder.IsRankedSource = true;
            createDripFeeder.RoleId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            createDripFeeder.MaxPulls = 0;
            createDripFeeder.MinutesBetweenPulls = 0;
            createDripFeeder.PullNewestFirst = true;
            createDripFeeder.UseSourceWithLowestCountFirst = true;
            createDripFeeder.IsFronterSet = true;
            string payload = JsonConvert.SerializeObject(createDripFeeder, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DripFeederType_PostDripFeeder_Response>(response);
            string Id = responseContent.Id;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient clientPatch = helper.SetUrl("user-service/dripFeeder/" + Id);
            RestRequest requestPatsh = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse responsePatch = helper.GetResponse(clientPatch, requestPatsh);
            /// Assert
            Assert.That(responsePatch.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void UserService_DripFeederType_EditUsers_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/dripFeeder");
            string name = helper.GenerateDocName(3);
            DripFeederType_PostDripFeeder_Request createDripFeeder = new DripFeederType_PostDripFeeder_Request();
            createDripFeeder.Rank = 1;
            createDripFeeder.Name = name;
            Source_PostDripFeeder_Request sourceDripFeeder = new Source_PostDripFeeder_Request();
            List<Source_PostDripFeeder_Request> sources = new List<Source_PostDripFeeder_Request> { sourceDripFeeder };
            createDripFeeder.Sources = sources;
            sourceDripFeeder.SourceId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            sourceDripFeeder.Order = 0;
            sourceDripFeeder.MaxPulls = 0;
            sourceDripFeeder.IsRankedSource = true;
            createDripFeeder.RoleId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            createDripFeeder.MaxPulls = 0;
            createDripFeeder.MinutesBetweenPulls = 0;
            createDripFeeder.PullNewestFirst = true;
            createDripFeeder.UseSourceWithLowestCountFirst = true;
            createDripFeeder.IsFronterSet = true;
            string payload = JsonConvert.SerializeObject(createDripFeeder, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DripFeederType_PostDripFeeder_Response>(response);
            string roleId = responseContent.RoleId;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient clientPatch = helper.SetUrl("user-service/dripFeeder/editUsers/" + roleId);
            RestRequest requestPatsh = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse responsePatch = helper.GetResponse(clientPatch, requestPatsh);
            /// Assert
            Assert.That(responsePatch.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void UserService_DripFeederType_EditUsers_NegativeScenario_InvalidRoleId()
        {
            /// Arrange
            RestClient clientPatch = helper.SetUrl("user-service/dripFeeder/editUsers/" + InvalidDealIdPayment);
            RestRequest requestPatsh = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(clientPatch, requestPatsh);
            var responseContent = helper.GetContent<UserService_NegativeScenario>(response);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.UserService.Domain.Entities.Role with id '" + InvalidDealIdPayment + "' not found"));
            Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
        }

        [Test]
        public void UserService_DripFeederType_PostRoleAssignment_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/dripFeeder");
            string name = helper.GenerateDocName(3);
            DripFeederType_PostDripFeeder_Request createDripFeeder = new DripFeederType_PostDripFeeder_Request();
            createDripFeeder.Rank = 1;
            createDripFeeder.Name = name;
            Source_PostDripFeeder_Request sourceDripFeeder = new Source_PostDripFeeder_Request();
            List<Source_PostDripFeeder_Request> sources = new List<Source_PostDripFeeder_Request> { sourceDripFeeder };
            createDripFeeder.Sources = sources;
            sourceDripFeeder.SourceId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            sourceDripFeeder.Order = 0;
            sourceDripFeeder.MaxPulls = 0;
            sourceDripFeeder.IsRankedSource = true;
            createDripFeeder.RoleId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            createDripFeeder.MaxPulls = 0;
            createDripFeeder.MinutesBetweenPulls = 0;
            createDripFeeder.PullNewestFirst = true;
            createDripFeeder.UseSourceWithLowestCountFirst = true;
            createDripFeeder.IsFronterSet = true;
            string payload = JsonConvert.SerializeObject(createDripFeeder, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DripFeederType_PostDripFeeder_Response>(response);
            string roleId = responseContent.RoleId;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient clientPost = helper.SetUrl("user-service/dripFeeder/roleAssignment");
            DripFeederType_PostRoleAssignment_Request roleAssignment = new DripFeederType_PostRoleAssignment_Request();
            roleAssignment.RoleId = roleId;
            roleAssignment.AllUsers = true;
            AssignedUser_PostRoleAssignment_Request assignedUser = new AssignedUser_PostRoleAssignment_Request();
            List<AssignedUser_PostRoleAssignment_Request> assignedUsers = new List<AssignedUser_PostRoleAssignment_Request> { assignedUser };
            roleAssignment.AssignedUsers = assignedUsers;
            assignedUser.UserId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            assignedUser.IsIncluded = true;
            AssignedTeamType_PostRoleAssignment_Request teamType = new AssignedTeamType_PostRoleAssignment_Request();
            List<AssignedTeamType_PostRoleAssignment_Request> assignedTeamTypes = new List<AssignedTeamType_PostRoleAssignment_Request> { teamType };
            roleAssignment.AssignedTeamTypes = assignedTeamTypes;
            teamType.TeamTypeId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            teamType.IncludeFullTeamType = true;
            teamType.IncludeManager = true;
            List<string> includedTeamMemberType = new List<string> { "Director" };
            teamType.IncludedTeamMemberType = includedTeamMemberType;
            AssignedTeam_PostRoleAssignment_Request team = new AssignedTeam_PostRoleAssignment_Request();
            List<AssignedTeam_PostRoleAssignment_Request> assignedTeams = new List<AssignedTeam_PostRoleAssignment_Request> { team };
            roleAssignment.AssignedTeams = assignedTeams;
            team.TeamId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            team.IncludeFullTeam = true;
            team.IncludedTeamMemberType = includedTeamMemberType;
            roleAssignment.IncludeAllManagers = true;
            roleAssignment.IncludeAllDirectors = true;
            roleAssignment.IncludeAllLieutenants = true;
            string payloadPost = JsonConvert.SerializeObject(roleAssignment, Formatting.Indented);
            RestRequest requestPost = helper.CreatePostRequest(payloadPost, acessToken);
            /// Act
            IRestResponse responsePost = helper.GetResponse(clientPost, requestPost);
            var responseContentPost = helper.GetContent<DripFeederType_PostDripFeeder_Response>(responsePost);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responsePost.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContentPost.RoleId, Is.EqualTo(roleId));
            });
        }
        [Test]
        public void UserService_DripFeederType_PatchRoleAssignment_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/dripFeeder");
            string name = helper.GenerateDocName(3);
            DripFeederType_PostDripFeeder_Request createDripFeeder = new DripFeederType_PostDripFeeder_Request();
            createDripFeeder.Rank = 1;
            createDripFeeder.Name = name;
            Source_PostDripFeeder_Request sourceDripFeeder = new Source_PostDripFeeder_Request();
            List<Source_PostDripFeeder_Request> sources = new List<Source_PostDripFeeder_Request> { sourceDripFeeder };
            createDripFeeder.Sources = sources;
            sourceDripFeeder.SourceId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            sourceDripFeeder.Order = 0;
            sourceDripFeeder.MaxPulls = 0;
            sourceDripFeeder.IsRankedSource = true;
            createDripFeeder.RoleId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            createDripFeeder.MaxPulls = 0;
            createDripFeeder.MinutesBetweenPulls = 0;
            createDripFeeder.PullNewestFirst = true;
            createDripFeeder.UseSourceWithLowestCountFirst = true;
            createDripFeeder.IsFronterSet = true;
            string payload = JsonConvert.SerializeObject(createDripFeeder, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DripFeederType_PostDripFeeder_Response>(response);
            string roleId = responseContent.RoleId;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient clientPost = helper.SetUrl("user-service/dripFeeder/roleAssignment/" + roleId);
            DripFeederType_PatchRoleAssignment_Request roleAssignment = new DripFeederType_PatchRoleAssignment_Request();
            roleAssignment.AllUsers = true;
            AssignedUser_PatchRoleAssignment_Request assignedUser = new AssignedUser_PatchRoleAssignment_Request();
            List<AssignedUser_PatchRoleAssignment_Request> assignedUsers = new List<AssignedUser_PatchRoleAssignment_Request> { assignedUser };
            roleAssignment.AssignedUsers = assignedUsers;
            assignedUser.UserId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            assignedUser.IsIncluded = true;
            AssignedTeamType_PatchRoleAssignment_Request teamType = new AssignedTeamType_PatchRoleAssignment_Request();
            List<AssignedTeamType_PatchRoleAssignment_Request> assignedTeamTypes = new List<AssignedTeamType_PatchRoleAssignment_Request> { teamType };
            roleAssignment.AssignedTeamTypes = assignedTeamTypes;
            teamType.TeamTypeId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            teamType.IncludeFullTeamType = true;
            teamType.IncludeManager = true;
            List<string> includedTeamMemberType = new List<string> { "Director" };
            teamType.IncludedTeamMemberType = includedTeamMemberType;
            AssignedTeam_PatchRoleAssignment_Request team = new AssignedTeam_PatchRoleAssignment_Request();
            List<AssignedTeam_PatchRoleAssignment_Request> assignedTeams = new List<AssignedTeam_PatchRoleAssignment_Request> { team };
            roleAssignment.AssignedTeams = assignedTeams;
            team.TeamId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            team.IncludeFullTeam = true;
            team.IncludedTeamMemberType = includedTeamMemberType;
            roleAssignment.IncludeAllManagers = true;
            roleAssignment.IncludeAllDirectors = true;
            roleAssignment.IncludeAllLieutenants = true;
            string payloadPost = JsonConvert.SerializeObject(roleAssignment, Formatting.Indented);
            RestRequest requestPost = helper.CreatePatchRequest(payloadPost, acessToken);
            /// Act
            IRestResponse responsePost = helper.GetResponse(clientPost, requestPost);
            /// Assert
            Assert.That(responsePost.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void UserService_ManagerType_PostManager_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/manager");
            ManagerType_PostManager_Request manager = new ManagerType_PostManager_Request()
            {
                UserId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                TeamTypeID = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                PeriodId = "3fa85f64-5717-4562-b3fc-2c963f66afa6"
            };
            string payload = JsonConvert.SerializeObject(manager, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<ManagerType_PostManager_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.TeamTypeID, Is.EqualTo("3fa85f64-5717-4562-b3fc-2c963f66afa6"));
                Assert.That(responseContent.UserId, Is.EqualTo("3fa85f64-5717-4562-b3fc-2c963f66afa6"));
            });
        }

        [Test]
        public void UserService_ManagerType_PostManager_NegativeScenario_InvalidId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/manager");
            ManagerType_PostManager_Request manager = new ManagerType_PostManager_Request()
            {
                UserId = "1",
                TeamTypeID = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                PeriodId = "3fa85f64-5717-4562-b3fc-2c963f66afa6"
            };
            string payload = JsonConvert.SerializeObject(manager, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void UserService_ManagerType_GetManager_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/manager");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void UserService_OfficeLocationType_PostOfficeLocation_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/officeLocation");
            string name = helper.GenerateDocName(6);
            OfficeLocationType_PostOfficeLocation_Request officeLocation = new OfficeLocationType_PostOfficeLocation_Request()
            {
                Location = name,
                Code = "string"
            };
            string payload = JsonConvert.SerializeObject(officeLocation, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act            
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<ManagerType_PostManager_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Location, Is.EqualTo(name));
                Assert.That(responseContent.Code, Is.EqualTo("string"));
            });
        }

        [Test]
        public void UserService_OfficeLocationType_PostOfficeLocation_NegativeScenario_InvalidLocation()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/officeLocation");
            OfficeLocationType_PostOfficeLocation_Request officeLocation = new OfficeLocationType_PostOfficeLocation_Request()
            {
                Location = "string",
                Code = "string"
            };
            string payload = JsonConvert.SerializeObject(officeLocation, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<UserService_NegativeScenario>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Message, Is.EqualTo("Key: model : Message The office location name should be unique.\n"));
                Assert.That(responseContent.Code, Is.EqualTo("BadRequest"));
            });
        }
        [Test]
        public void UserService_OfficeLocationType_GetOfficeLocation_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/officeLocation");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void UserService_OfficeLocationType_PatchOfficeLocation_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/officeLocation/" + officeLocationId);
            OfficeLocationType_PostOfficeLocation_Request officeLocation = new OfficeLocationType_PostOfficeLocation_Request()
            {
                Location = "string",
                Code = "string"
            };
            string payload = JsonConvert.SerializeObject(officeLocation, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void UserService_OfficeLocationType_PatchOfficeLocation_NegativeScenario_InvalidId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/officeLocation/" + invalidOfficeLocationId);
            OfficeLocationType_PostOfficeLocation_Request officeLocation = new OfficeLocationType_PostOfficeLocation_Request()
            {
                Location = "string",
                Code = "string"
            };
            string payload = JsonConvert.SerializeObject(officeLocation, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Arrange
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<UserService_NegativeScenario>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.UserService.Domain.Entities.OfficeLocation with id '" + invalidOfficeLocationId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void UserService_OffceLocationType_DeleteOffceLocation_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/officeLocation/" + invalidOfficeLocationId);
            RestRequest request = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void UserService_PeriodType_PostPeriod_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/period");
            string payload = helper.Serialize
           (new
           {
               Name = "string",
               Year = 2000,
               FromDate = DateTime.Now,
               ToDate = DateTime.Today
           });
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Arrange
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<PeriodType_PostPeriod_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Name, Is.EqualTo("string"));
                Assert.That(responseContent.Year, Is.EqualTo(2000));
            });
        }

        [Test]
        public void UserService_PeriodType_PostPeriod_NegativeScenario_InvalidYear()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/period");
            string payload = helper.Serialize
           (new
           {
               Name = "string",
               Year = 200,
               FromDate = DateTime.Now,
               ToDate = DateTime.Today
           });
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<UserService_NegativeScenario>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Message, Is.EqualTo("Key: Year : Message Property value should be within the range 1900-2200\n"));
                Assert.That(responseContent.Code, Is.EqualTo("BadRequest"));
            });
        }

        [Test]
        public void UserService_PeriodType_GetPeriod_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/roles");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void UserService_RoleType_PostRoles_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/roles");
            string RoleName = helper.GenerateDocName(8);
            string payload = helper.Serialize
            (new
            {
                Name = RoleName,
                CommentsColor = "string",
                CommentsColorPriority = 0,
                Permission = "AdminMenuView"
            });
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Arrange
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<RoleType_PostRoles_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Name, Is.EqualTo(RoleName));
            });
        }

        [Test]
        public void UserService_RoleType_GetRoles_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/roles");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void UserService_RoleType_PutRoles_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/roles/" + UserServiceRoleId);
            string payload = helper.Serialize
            (new
            {
                Mame = "string",
                CommentsColor = "string",
                CommentsColorPriority = 0,
                Permission = "AdminMenuView"
            });
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Arrange
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void UserService_RoleType_PutRoles_NegativeScenario_InvalidId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/roles/" + invalidOfficeLocationId);
            string payload = helper.Serialize
            (new
            {
                Name = "string",
                CommentsColor = "string",
                CommentsColorPriority = 0,
                Permission = "AdminMenuView"
            });
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Arrange
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<UserService_NegativeScenario>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.UserService.Domain.Entities.Role with id '" + invalidOfficeLocationId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void UserService_RoleType_DeleteRoles_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/roles/" + invalidOfficeLocationId);
            RestRequest request = helper.CreateDeleteRequest(acessToken);
            /// Arrange
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void UserService_RoleAssignmentType_PostRolesroleAssignment_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/roleAssignment");
            RoleAssignmentType_PostRolesroleAssignment_Request createRoleAssignment = new RoleAssignmentType_PostRolesroleAssignment_Request();
            createRoleAssignment.RoleId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            AssignedUser_PostRolesroleAssignment_Request assignedUser = new AssignedUser_PostRolesroleAssignment_Request();
            assignedUser.UserId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            assignedUser.IsIncluded = true;
            AssignedTeamType_PostRolesroleAssignment_Request assignedTeamType = new AssignedTeamType_PostRolesroleAssignment_Request();
            assignedTeamType.TeamTypeId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            List<string> includedTeamMemberType = new List<string> { "Director" };
            assignedTeamType.IncludedTeamMemberType = includedTeamMemberType;
            AssignedTeam_PostRolesroleAssignment_Request assignedTeam = new AssignedTeam_PostRolesroleAssignment_Request();
            assignedTeam.TeamId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            assignedTeam.IncludedTeamMemberType = includedTeamMemberType;
            List<AssignedUser_PostRolesroleAssignment_Request> assignedUsers = new List<AssignedUser_PostRolesroleAssignment_Request> { assignedUser };
            createRoleAssignment.AssignedUsers = assignedUsers;
            List<AssignedTeamType_PostRolesroleAssignment_Request> assignedTeamTypes = new List<AssignedTeamType_PostRolesroleAssignment_Request> { assignedTeamType };
            createRoleAssignment.AssignedTeamTypes = assignedTeamTypes;
            List<AssignedTeam_PostRolesroleAssignment_Request> assignedTeams = new List<AssignedTeam_PostRolesroleAssignment_Request> { assignedTeam };
            createRoleAssignment.AssignedTeams = assignedTeams;
            string payload = JsonConvert.SerializeObject(createRoleAssignment, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void UserService_RoleAssignmentType_GetRoleAssignment_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/roleAssignment");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void UserService_RoleAssignment_PutRolesroleAssignment_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/roleAssignment/" + UserServiceRoleAssignmentId);
            RoleAssignmentType_PostRolesroleAssignment_Request createRoleAssignment = new RoleAssignmentType_PostRolesroleAssignment_Request();
            createRoleAssignment.RoleId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            AssignedUser_PostRolesroleAssignment_Request assignedUser = new AssignedUser_PostRolesroleAssignment_Request();
            assignedUser.UserId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            assignedUser.IsIncluded = true;
            AssignedTeamType_PostRolesroleAssignment_Request assignedTeamType = new AssignedTeamType_PostRolesroleAssignment_Request();
            assignedTeamType.TeamTypeId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            List<string> includedTeamMemberType = new List<string> { "Director" };
            assignedTeamType.IncludedTeamMemberType = includedTeamMemberType;
            AssignedTeam_PostRolesroleAssignment_Request assignedTeam = new AssignedTeam_PostRolesroleAssignment_Request();
            assignedTeam.TeamId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            assignedTeam.IncludedTeamMemberType = includedTeamMemberType;
            List<AssignedUser_PostRolesroleAssignment_Request> assignedUsers = new List<AssignedUser_PostRolesroleAssignment_Request> { assignedUser };
            createRoleAssignment.AssignedUsers = assignedUsers;
            List<AssignedTeamType_PostRolesroleAssignment_Request> assignedTeamTypes = new List<AssignedTeamType_PostRolesroleAssignment_Request> { assignedTeamType };
            createRoleAssignment.AssignedTeamTypes = assignedTeamTypes;
            List<AssignedTeam_PostRolesroleAssignment_Request> assignedTeams = new List<AssignedTeam_PostRolesroleAssignment_Request> { assignedTeam };
            createRoleAssignment.AssignedTeams = assignedTeams;
            string payload = JsonConvert.SerializeObject(createRoleAssignment, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void UserService_RoleAssignment_PutRolesroleAssignment_NegativeScenario_InvalidId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/roleAssignment/" + invalidOfficeLocationId);
            RoleAssignmentType_PostRolesroleAssignment_Request createRoleAssignment = new RoleAssignmentType_PostRolesroleAssignment_Request();
            createRoleAssignment.RoleId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            AssignedUser_PostRolesroleAssignment_Request assignedUser = new AssignedUser_PostRolesroleAssignment_Request();
            assignedUser.UserId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            assignedUser.IsIncluded = true;
            AssignedTeamType_PostRolesroleAssignment_Request assignedTeamType = new AssignedTeamType_PostRolesroleAssignment_Request();
            assignedTeamType.TeamTypeId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            List<string> includedTeamMemberType = new List<string> { "Director" };
            assignedTeamType.IncludedTeamMemberType = includedTeamMemberType;
            AssignedTeam_PostRolesroleAssignment_Request assignedTeam = new AssignedTeam_PostRolesroleAssignment_Request();
            assignedTeam.TeamId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            assignedTeam.IncludedTeamMemberType = includedTeamMemberType;
            List<AssignedUser_PostRolesroleAssignment_Request> assignedUsers = new List<AssignedUser_PostRolesroleAssignment_Request> { assignedUser };
            createRoleAssignment.AssignedUsers = assignedUsers;
            List<AssignedTeamType_PostRolesroleAssignment_Request> assignedTeamTypes = new List<AssignedTeamType_PostRolesroleAssignment_Request> { assignedTeamType };
            createRoleAssignment.AssignedTeamTypes = assignedTeamTypes;
            List<AssignedTeam_PostRolesroleAssignment_Request> assignedTeams = new List<AssignedTeam_PostRolesroleAssignment_Request> { assignedTeam };
            createRoleAssignment.AssignedTeams = assignedTeams;
            string payload = JsonConvert.SerializeObject(createRoleAssignment, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<UserService_NegativeScenario>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.UserService.Domain.Entities.RoleAssignment with id '" + invalidOfficeLocationId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void UserService_RoleAssignmentType_RoleAssignmentPermission_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/roleAssignment/permission/" + AssignmentUserId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act            
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<RoleAssignmentType_RoleAssignmentPermission_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.UserId, Is.EqualTo(AssignmentUserId));
            });
        }

        [Test]
        public void UserService_RoleAssignmentType_RoleAssignmentPermission_NegativeScenario_InvalidUserId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/roleAssignment/permission/" + invalidOfficeLocationId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<UserService_NegativeScenario>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseContent.Message, Is.EqualTo("Key: model : Message User is not Active\n"));
                Assert.That(responseContent.Code, Is.EqualTo("BadRequest"));
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            });
        }

        [Test]
        public void UserService_RoleAssignmentType_RoleAssignmentSelections_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/roleAssignment/permission/" + AssignmentRoleId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void UserService_RoleAssignmentType_RoleAssignmentSelections_NegativeScenario_InvalidRoleId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/roleAssignment/permission/" + invalidOfficeLocationId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void UserService_RoleAssignmentType_DeleteRoleAssignment_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/roles/" + invalidOfficeLocationId);
            RestRequest request = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void UserService_TeamType_PostTeams_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/teams");
            string name = helper.GenerateDocName(6);
            TeamType_PostTeams_Request createTeam = new TeamType_PostTeams_Request();
            createTeam.Name = name;
            createTeam.TeamTypeId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            createTeam.PeriodId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            createTeam.CopiedFromTeamId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            User_PostTeams_Request userTeam = new User_PostTeams_Request();
            userTeam.UserId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            userTeam.UserName = "string";
            userTeam.TeamMemberType = "Director";
            List<User_PostTeams_Request> users = new List<User_PostTeams_Request> { userTeam };
            createTeam.Users = users;
            string payload = JsonConvert.SerializeObject(createTeam, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<TeamType_PostTeams_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Name, Is.EqualTo(name));
            });
        }

        [Test]
        public void UserService_TeamType_PostTeams_NegativeScenario_ExistsName()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/teams");
            TeamType_PostTeams_Request createTeam = new TeamType_PostTeams_Request();
            createTeam.Name = "string";
            createTeam.TeamTypeId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            createTeam.PeriodId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            createTeam.CopiedFromTeamId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            User_PostTeams_Request userTeam = new User_PostTeams_Request();
            userTeam.UserId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            userTeam.UserName = "string";
            userTeam.TeamMemberType = "Director";
            List<User_PostTeams_Request> users = new List<User_PostTeams_Request> { userTeam };
            createTeam.Users = users;
            string payload = JsonConvert.SerializeObject(createTeam, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<UserService_NegativeScenario>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Message, Is.EqualTo("Key: model : Message The Team Name for TeamTypeId already exists.\n"));
                Assert.That(responseContent.Code, Is.EqualTo("BadRequest"));
            });
        }

        [Test]
        public void UserService_TeamType_PatchTeams_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/teams/" + UserServiceTEAMId);
            TeamType_PatchTeams_Request updateTeam = new TeamType_PatchTeams_Request();
            updateTeam.Name = "string";
            updateTeam.TeamTypeId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            updateTeam.PeriodId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            updateTeam.CopiedFromTeamId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            UserTeam_PatchTeams_Request updateUserTeam = new UserTeam_PatchTeams_Request();
            updateUserTeam.UserId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            updateUserTeam.UserName = "string";
            updateUserTeam.TeamMemberType = "Director";
            List<UserTeam_PatchTeams_Request> users = new List<UserTeam_PatchTeams_Request> { updateUserTeam };
            updateTeam.Users = users;
            string payload = JsonConvert.SerializeObject(updateTeam, Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void UserService_TeamType_PatchTeams_NegativeScenario_InvalidId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/teams/" + invalidOfficeLocationId);
            TeamType_PatchTeams_Request updateTeam = new TeamType_PatchTeams_Request();
            updateTeam.Name = "string";
            updateTeam.TeamTypeId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            updateTeam.PeriodId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            updateTeam.CopiedFromTeamId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            UserTeam_PatchTeams_Request updateUserTeam = new UserTeam_PatchTeams_Request();
            updateUserTeam.UserId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            updateUserTeam.UserName = "string";
            updateUserTeam.TeamMemberType = "Director";
            List<UserTeam_PatchTeams_Request> users = new List<UserTeam_PatchTeams_Request> { updateUserTeam };
            updateTeam.Users = users;
            string payload = JsonConvert.SerializeObject(updateTeam, Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<UserService_NegativeScenario>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.UserService.Domain.Entities.Team with id '" + invalidOfficeLocationId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void UserService_TeamType_DeleteTeams_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/roles/" + invalidOfficeLocationId);
            RestRequest request = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void UserService_TeamType_TeamsTypes_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/teams/types/" + teamTypeId + "/" + periodId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<TeamType_TeamsTypes_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.TeamTypeId, Is.EqualTo(teamTypeId));
                Assert.That(responseContent.PeriodId, Is.EqualTo(periodId));
            });
        }

        [Test]
        public void UserService_TeamType_TeamsTypes_NegativeScenario_InvalidTeamTypeId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/teams/types/" + invalidOfficeLocationId + "/" + periodId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<TeamType_TeamsTypes_ResponseWithCode>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.UserService.Domain.Entities.Team with id '" + invalidOfficeLocationId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void UserService_TeamType_GetTeamsByTeamId_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/teams/" + teamId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void UserService_TeamType_GetTeamsByTeamId_NegativeScenario_InvalidTeamId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/teams/" + invalidOfficeLocationId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<TeamType_TeamsTypes_ResponseWithCode>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.UserService.Domain.Entities.Team with id '" + invalidOfficeLocationId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void UserService_TeamType_TeamMemberType_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/teams/" + teamMemberTypeId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void UserService_TeamType_TeamMemberType_NegativeScenario_InvalidTeamMemberType()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/teams/" + invalidOfficeLocationId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<TeamType_TeamsTypes_ResponseWithCode>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.UserService.Domain.Entities.Team with id '" + invalidOfficeLocationId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void UserService_TeamType_TeamsTypesByTeamTypeId_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/teams/" + teamTypeId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void UserService_TeamType_TeamsTypesByTeamTypeId_NegativeScenario_InvalidTeamTypeId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/teams/" + invalidOfficeLocationId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<TeamType_TeamsTypes_ResponseWithCode>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.UserService.Domain.Entities.Team with id '" + invalidOfficeLocationId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void UserService_TeamType_TeamsCopy_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/teams/copy");
            TeamType_TeamsCopy_Request teams = new TeamType_TeamsCopy_Request()
            {
                OldPeriodId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                NewPeriodId = "3fa85f64-5717-4562-b3fc-2c963f66afa6"
            };
            string payload = JsonConvert.SerializeObject(teams, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void UserService_TypeTeamType_PostTeamType_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/TeamType");
            string name = helper.GenerateDocName(6);
            TypeTeamType_PostTeamType_Request teamType = new TypeTeamType_PostTeamType_Request()
            {
                Name = name
            };
            string payload = JsonConvert.SerializeObject(teamType, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<TypeTeamType_PostTeamType_ResponseWithCode>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Name, Is.EqualTo(name));
            });
        }

        [Test]
        public void UserService_TypeTeamType_PostTeamType_NegativeScenario_ExistingName()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/TeamType");
            TypeTeamType_PostTeamType_Request teamType = new TypeTeamType_PostTeamType_Request()
            {
                Name = "string"
            };
            string payload = JsonConvert.SerializeObject(teamType, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<TypeTeamType_PostTeamType_ResponseWithCode>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Message, Is.EqualTo("Key: model : Message The TeamType Name already exists.\n"));
                Assert.That(responseContent.Code, Is.EqualTo("BadRequest"));
            });
        }
        [Test]
        public void UserService_TypeTeamType_GetTeamType_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/TeamType");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void UserService_TypeTeamType_PutTeamType_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/TeamType/" + TeamTypeId);
            string payload = helper.Serialize
            (new
            {
                Name = "string",
            });
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void UserService_TypeTeamType_PutTeamType_NegativeScenario_InvalidId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/TeamType/" + InvalidId);
            string payload = helper.Serialize
            (new
            {
                Name = "string",
            });
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<TypeTeamType_PostTeamType_ResponseWithCode>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.UserService.Domain.Entities.TeamType with id '" + InvalidId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void UserService_TypeTeamType_DeleteTeamType_PositiveScenario()
        {            
            /// Arrange
            RestClient client = helper.SetUrl("user-service/TeamType/" + invalidOfficeLocationId);
            RestRequest request = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void UserService_UserType_GetUsersId_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/users/" + UsersId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<UserType_GetUsersId_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Id, Is.EqualTo(UsersId));
            });
        }
        [Test]
        public void UserService_UserType_DeleteUsers_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/users/" + Id);
            RestRequest request = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void UserService_UserType_DeleteUsers_NegativeScenario_InvalidId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/users/" + invalidOfficeLocationId);
            RestRequest request = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<TypeTeamType_PostTeamType_ResponseWithCode>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.UserService.Domain.Entities.User with id '" + invalidOfficeLocationId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void UserService_UserType_PostUsers_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/users");
            string email = helper.GenerateDocName(6);
            string phone = helper.GenerateDocName(10);
            UserType_PostUsers_Request users = new UserType_PostUsers_Request()
            {
                FirstName = "string",
                LastName = "string",
                Email = email,
                PhoneNumber = phone,
                PhoneExtension = "string",
                IsActive = true,
                IsDeleted = true,
                PhoneSystemUserId = 0,
                TrainingPeriodId = 0,
                OfficeLocationId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                TerminationDate = DateTime.Now,
                PaySystemUserId = "string",
                IsAcumaticaRecordExist = true
            };
            string payload = JsonConvert.SerializeObject(users, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<UserType_PostUsers_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Email, Is.EqualTo(email));
                Assert.That(responseContent.PhoneNumber, Is.EqualTo(phone));
            });
        }

        [Test]
        public void UserService_UserType_PostUsers_NegativeScenario_ExistingEmail()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/users");
            string phone = helper.GenerateDocName(10);
            UserType_PostUsers_Request users = new UserType_PostUsers_Request()
            {
                FirstName = "string",
                LastName = "string",
                Email = "string",
                PhoneNumber = phone,
                PhoneExtension = "string",
                IsActive = true,
                IsDeleted = true,
                PhoneSystemUserId = 0,
                TrainingPeriodId = 0,
                OfficeLocationId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                TerminationDate = DateTime.Now,
                PaySystemUserId = "string",
                IsAcumaticaRecordExist = true
            };
            string payload = JsonConvert.SerializeObject(users, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<TypeTeamType_PostTeamType_ResponseWithCode>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Message, Is.EqualTo("Key: model : Message The user email must be unique.\n"));
                Assert.That(responseContent.Code, Is.EqualTo("BadRequest"));
            });
        }
        [Test]
        public void UserService_UserType_GetUsers_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/users");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void UserService_UserType_PatchUsers_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/users/" + UsersId);
            string phone = helper.GenerateDocName(10);
            UserType_PostUsers_Request updatUesers = new UserType_PostUsers_Request()
            {
                FirstName = "string",
                LastName = "string",
                Email = "string",
                PhoneNumber = phone,
                PhoneExtension = "string",
                IsActive = true,
                IsDeleted = true,
                PhoneSystemUserId = 0,
                TrainingPeriodId = 0,
                OfficeLocationId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                TerminationDate = DateTime.Now,
                PaySystemUserId = "string",
                IsAcumaticaRecordExist = true
            };
            string payload = JsonConvert.SerializeObject(updatUesers, Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void UserService_UserType_PatchUsers_NegativeScenario_InvalidUserId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/users/" + invalidOfficeLocationId);
            string phone = helper.GenerateDocName(10);
            UserType_PostUsers_Request updatUesers = new UserType_PostUsers_Request()
            {
                FirstName = "string",
                LastName = "string",
                Email = "string",
                PhoneNumber = phone,
                PhoneExtension = "string",
                IsActive = true,
                IsDeleted = true,
                PhoneSystemUserId = 0,
                TrainingPeriodId = 0,
                OfficeLocationId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                TerminationDate = DateTime.Now,
                PaySystemUserId = "string",
                IsAcumaticaRecordExist = true
            };
            string payload = JsonConvert.SerializeObject(updatUesers, Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<TypeTeamType_PostTeamType_ResponseWithCode>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.UserService.Domain.Entities.User with id '" + invalidOfficeLocationId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void UserService_UserType_UsersUnassigned_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("user-service/users/unassigned");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

    }
}

