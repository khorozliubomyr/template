using Newtonsoft.Json;
using NUnit.Framework;
using Phoenix2.APITests.DTO.LenderServiceDTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using static Phoenix2.APITests.Credentials;
using static Phoenix2.APITests.DTO.ContactServiceDTO.States;
using Phoenix2.APITests.DTO.AuthorizationModels;
using Phoenix2.APITests.Framework;

namespace Phoenix2.APITests.Tests
{
    class LenderService
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
        public void LenderService_FifsType_LoanApplicationSubmit_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/fifs/loan-application/submit");
            string payload = helper.Serialize(new
            {
                DealId = "54793",
                RequestedById = 55810,
                Comment = "string"
            });
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<FifsType_LoanApplicationSubmit_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.IsSuccess, Is.EqualTo(true));
            });
        }

        [Test]
        public void LenderService_FifsType_LoanApplicationSubmit_NegativeScenario_InvalidRequestBody()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/fifs/loan-application/submit");
            string payload = helper.Serialize(new
            {
                DealId = 0,
                RequestedById = 0,
                Comment = "string"
            });
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<FifsType_LoanApplicationSubmit_NegativeResponse>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Message  \n Entity type of Phoenix.Common.Client.HttpСlients.SDK.Models.ResponseModels.Deal.DealResponse"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_FlagshipType_PostLoanApplication_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/flagship/loan-application");
            string payload = helper.Serialize(new
            {
                DealId = "54793",
                RequestedById = 55810,
                Comment = "string"
            });
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<FifsType_LoanApplicationSubmit_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.IsSuccess, Is.EqualTo(true));
            });
        }

        [Test]
        public void LenderService_FlagshipType_PostLoanApplication_NegativeScenario_InvalidRequestBody()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/flagship/loan-application");
            string payload = helper.Serialize(new
            {
                DealId = 0,
                RequestedById = 0,
                Comment = "string"
            });
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<FifsType_LoanApplicationSubmit_NegativeResponse>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Message  \n Entity type of Phoenix.Common.Client.HttpСlients.SDK.Models.ResponseModels.Deal.DealResponse"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_FlagshipType_PatchLoanApplication_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/flagship/loan-application");
            string payload = helper.Serialize(new
            {
                DealId = "54793",
                RequestedById = 55810,
                Comment = "string"
            });
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<FifsType_LoanApplicationSubmit_Response>(response);
            string ApplicationNumber = responseContent.ApplicationNumber;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient clientPatch = helper.SetUrl("lender-service/flagship/loan-application");
            FlagshipType_PatchLoanApplication_Request updateLoanApplication = new FlagshipType_PatchLoanApplication_Request()
            {
                DealId = 54793,
                RequestedById = 55810,
                Comment = "string",
                ApplicationNumber = ApplicationNumber
            };
            string payloadPatch = JsonConvert.SerializeObject(updateLoanApplication, Formatting.Indented);
            RestRequest requestPatch = helper.CreatePatchRequest(payloadPatch, acessToken);
            /// Act
            IRestResponse responsePatch = helper.GetResponse(clientPatch, requestPatch);
            /// Assert
            Assert.That(responsePatch.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void LenderService_FlagshipType_PatchLoanApplication_NegativeScenario_InvalidAplicationNumber()
        {
            /// Arrange
            RestClient clientPatch = helper.SetUrl("lender-service/flagship/loan-application");
            FlagshipType_PatchLoanApplication_Request updateLoanApplication = new FlagshipType_PatchLoanApplication_Request()
            {
                DealId = 54793,
                RequestedById = 55810,
                Comment = "string",
                ApplicationNumber = "1"
            };
            string payloadPatch = JsonConvert.SerializeObject(updateLoanApplication, Formatting.Indented);
            RestRequest requestPatch = helper.CreatePatchRequest(payloadPatch, acessToken);
            /// Act
            IRestResponse responsePatch = helper.GetResponse(clientPatch, requestPatch);
            var responseContent = helper.GetContent<FifsType_LoanApplicationSubmit_NegativeResponse>(responsePatch);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responsePatch.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Message, Is.EqualTo("Application number not found 1."));
                Assert.That(responseContent.Code, Is.EqualTo("BadRequest"));
            });
        }


        [Test]
        public void LenderService_FoursightType_LoanApplicationSubmit_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/foursight/loan-application/submit");
            string payload = helper.Serialize(new
            {
                DealId = "54793",
                RequestedById = 55810,
                Comment = "string"
            });
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void LenderService_FoursightType_LoanApplicationSubmit_NegativeScenario_InvalidRequestBody()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/foursight/loan-application/submit");
            string payload = helper.Serialize(new
            {
                DealId = 0,
                RequestedById = 0,
                Comment = "string"
            });
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<FifsType_LoanApplicationSubmit_NegativeResponse>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Message  \n Entity type of Phoenix.Common.Client.HttpСlients.SDK.Models.ResponseModels.Deal.DealResponse"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }


        [Test]
        public void LenderService_InnovateAutoFinanceType_LoanApplicationSubmit_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/innovate-auto-finance/loan-application/submit");
            string payload = helper.Serialize(new
            {
                DealId = "54793",
                RequestedById = 55810,
                Comment = "string"
            });
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<FifsType_LoanApplicationSubmit_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.IsSuccess, Is.EqualTo(true));
                Assert.That(responseContent.ApplicationNumber, Is.EqualTo(null));
            });
        }

        [Test]
        public void LenderService_InnovateAutoFinanceType_LoanApplicationSubmit_NegativeScenario_InvalidRequestBody()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/innovate-auto-finance/loan-application/submit");
            string payload = helper.Serialize(new
            {
                DealId = 0,
                RequestedById = 0,
                Comment = "string"
            });
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<FifsType_LoanApplicationSubmit_NegativeResponse>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Message  \n Entity type of Phoenix.Common.Client.HttpСlients.SDK.Models.ResponseModels.Deal.DealResponse"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_LenderType_GetLenders_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void LenderService_LenderType_PostLenders_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders");
            string code = helper.GenerateDocName(6);
            string name = helper.GenerateDocName(6);
            LenderType_PostLenders_Request createLender = new LenderType_PostLenders_Request();
            createLender.Name = name;
            createLender.Address = "string";
            createLender.State = "AL";
            createLender.PostCode = "12345";
            createLender.ContactPerson = "string";
            createLender.ContactPhone = "1234567890";
            createLender.City = "string";
            createLender.Code = code;
            createLender.Rank = 1;
            createLender.LtvType = "FrontEnd";
            createLender.UseBothLtv = true;
            createLender.IsOpenLending = true;
            createLender.IsDocGen2 = true;
            createLender.IsDefi = true;
            createLender.MeridianLenderReferenceId = "string";
            createLender.MeridianOrgReferenceId = "string";
            createLender.LenderPurposeType = "string";
            createLender.AcumaticaId = "string";
            createLender.IsGenericAprCalculation = true;
            createLender.IsAcumaticaSpecialProcessing = true;
            createLender.AutoSubmitLoanApplication = true;
            createLender.NumericId = 0;
            createLender.IsFlStampFee = true;
            createLender.IsDealertrack = true;
            createLender.DealertrackId = 0;
            createLender.SubRank = 0;
            createLender.IsRestrictDr = true;
            GeneralInfo_PostLenders_Request generalInfo = new GeneralInfo_PostLenders_Request();
            generalInfo.DaysToFirstPaymentGreen = 0;
            generalInfo.DaysToFirstPaymentYellow = 0;
            generalInfo.MaxDtiGreen = 0;
            generalInfo.MaxDtiYellow = 0;
            generalInfo.MaxPtiGreen = 0;
            generalInfo.MaxPtiYellow = 0;
            generalInfo.AvailableMarkupIncrements = "string";
            generalInfo.MaxMileageGreen = 0;
            generalInfo.MaxMileageYellow = 0;
            generalInfo.MaxAgeGreen = 0;
            generalInfo.MaxAgeYellow = 0;
            generalInfo.MinPrimaryFicoGreen = 0;
            generalInfo.MinPrimaryFicoYellow = 0;
            generalInfo.MinSecondaryFicoGreen = 0;
            generalInfo.MinSecondaryFicoYellow = 0;
            generalInfo.ApprovalDaysGreen = 0;
            generalInfo.ApprovalDaysYellow = 0;
            generalInfo.MaxCashOutGreen = 0;
            generalInfo.MaxCashOutYellow = 0;
            generalInfo.MaxFlatPercentGreen = 0;
            generalInfo.MaxFlatPercentYellow = 0;
            generalInfo.MaxGapGreen = 0;
            generalInfo.MaxGapYellow = 0;
            generalInfo.GapLtvLimit = 0;
            generalInfo.MaxFlatGreen = 0;
            generalInfo.MaxFlatYellow = 0;
            generalInfo.FlatPercent = 0;
            generalInfo.MaxOtherProducts = 0;
            generalInfo.ExperianDefaultScore = "Eqf";
            generalInfo.SecondaryBureau = "Eqf";
            generalInfo.PrimaryBureau = "Eqf";
            generalInfo.FundingFeeYellow = 0;
            generalInfo.AllowEmployerZip = true;
            generalInfo.StatedFunds = 0;
            generalInfo.ExpectedFunds = 0;
            generalInfo.AchDiscount = 0;
            generalInfo.MaxVsc = 0;
            generalInfo.MaxProduct = 0;
            generalInfo.Requirements = "string";
            generalInfo.UseAprBasedCalculation = true;
            generalInfo.ContractDateForUsingAprBasedCalculations = DateTime.Now;
            generalInfo.MaxVrp = 0;
            generalInfo.CreditReport = "Eqf";
            List<string> defaultVal = new List<string> { "KbbRetail" };
            generalInfo.DefaultValuationMethods = defaultVal;
            createLender.GeneralInfo = generalInfo;
            string payload = JsonConvert.SerializeObject(createLender, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<LenderType_PostLenders_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Name, Is.EqualTo(name));
                Assert.That(responseContent.ContactPhone, Is.EqualTo("1234567890"));
                Assert.That(responseContent.Code, Is.EqualTo(code));
            });
        }

        [Test]
        public void LenderService_LenderType_PostLenders_NegativeScenario_InvalidRequestBody()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders");
            LenderType_PostLenders_Request createLender = new LenderType_PostLenders_Request();
            createLender.Name = "string";
            createLender.Address = "string";
            createLender.State = "AL";
            createLender.PostCode = "string";
            createLender.ContactPerson = "string";
            createLender.ContactPhone = "string";
            createLender.City = "string";
            createLender.Code = "string";
            createLender.Rank = 0;
            createLender.LtvType = "FrontEnd";
            createLender.UseBothLtv = true;
            createLender.IsOpenLending = true;
            createLender.IsDocGen2 = true;
            createLender.IsDefi = true;
            createLender.MeridianLenderReferenceId = "string";
            createLender.MeridianOrgReferenceId = "string";
            createLender.LenderPurposeType = "string";
            createLender.AcumaticaId = "string";
            createLender.IsGenericAprCalculation = true;
            createLender.IsAcumaticaSpecialProcessing = true;
            createLender.AutoSubmitLoanApplication = true;
            createLender.NumericId = 0;
            createLender.IsFlStampFee = true;
            createLender.IsDealertrack = true;
            createLender.DealertrackId = 0;
            createLender.SubRank = 0;
            createLender.IsRestrictDr = true;
            GeneralInfo_PostLenders_Request generalInfo = new GeneralInfo_PostLenders_Request();
            generalInfo.DaysToFirstPaymentGreen = 0;
            generalInfo.DaysToFirstPaymentYellow = 0;
            generalInfo.MaxDtiGreen = 0;
            generalInfo.MaxDtiYellow = 0;
            generalInfo.MaxPtiGreen = 0;
            generalInfo.MaxPtiYellow = 0;
            generalInfo.AvailableMarkupIncrements = "string";
            generalInfo.MaxMileageGreen = 0;
            generalInfo.MaxMileageYellow = 0;
            generalInfo.MaxAgeGreen = 0;
            generalInfo.MaxAgeYellow = 0;
            generalInfo.MinPrimaryFicoGreen = 0;
            generalInfo.MinPrimaryFicoYellow = 0;
            generalInfo.MinSecondaryFicoGreen = 0;
            generalInfo.MinSecondaryFicoYellow = 0;
            generalInfo.ApprovalDaysGreen = 0;
            generalInfo.ApprovalDaysYellow = 0;
            generalInfo.MaxCashOutGreen = 0;
            generalInfo.MaxCashOutYellow = 0;
            generalInfo.MaxFlatPercentGreen = 0;
            generalInfo.MaxFlatPercentYellow = 0;
            generalInfo.MaxGapGreen = 0;
            generalInfo.MaxGapYellow = 0;
            generalInfo.GapLtvLimit = 0;
            generalInfo.MaxFlatGreen = 0;
            generalInfo.MaxFlatYellow = 0;
            generalInfo.FlatPercent = 0;
            generalInfo.MaxOtherProducts = 0;
            generalInfo.ExperianDefaultScore = "Eqf";
            generalInfo.SecondaryBureau = "Eqf";
            generalInfo.PrimaryBureau = "Eqf";
            generalInfo.FundingFeeYellow = 0;
            generalInfo.AllowEmployerZip = true;
            generalInfo.StatedFunds = 0;
            generalInfo.ExpectedFunds = 0;
            generalInfo.AchDiscount = 0;
            generalInfo.MaxVsc = 0;
            generalInfo.MaxProduct = 0;
            generalInfo.Requirements = "string";
            generalInfo.UseAprBasedCalculation = true;
            generalInfo.ContractDateForUsingAprBasedCalculations = DateTime.Now;
            generalInfo.MaxVrp = 0;
            generalInfo.CreditReport = "Eqf";
            List<string> defaultVal = new List<string> { "KbbRetail" };
            generalInfo.DefaultValuationMethods = defaultVal;
            createLender.GeneralInfo = generalInfo;
            string payload = JsonConvert.SerializeObject(createLender, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<LenderType_PostLenders_NegativeResponse>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Message, Is.EqualTo("Key: PostCode : Message 'Post Code' length should be like 12345 or 123456789 or 12345-1234\nKey: ContactPhone : Message Property length should be 10\nKey: Rank : Message 'Rank' must be greater than '0'.\n"));
                Assert.That(responseContent.Code, Is.EqualTo("BadRequest"));
            });
        }

        [Test]
        public void LenderService_LenderType_ActiveLenders_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/activelenders");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void LenderService_LenderType_GetLender_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<LenderType_GetLender_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Id, Is.EqualTo(LenderServiceId));
            });
        }

        [Test]
        public void LenderService_LenderType_GetLender_NegativeScenario_InvalidLenderId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + InvalidLenderId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LenderService.Domain.Entities.Lender with id '" + InvalidLenderId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_LenderType_GetBylenderCode_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceLenderCode);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<LenderType_GetLender_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Id, Is.EqualTo(LenderServiceId));
            });
        }

        [Test]
        public void LenderService_LenderType_GetBylenderCode_NegativeScenario_InvalidLenderCode()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + InvalidLenderId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LenderService.Domain.Entities.Lender with id '" + InvalidLenderId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_LenderType_GetByNumericId_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + NumericId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<LenderType_GetLender_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Id, Is.EqualTo(LenderServiceId));
            });
        }
        [Test]
        public void LenderService_LenderType_GetByNumericId_NegativeScenario_InvavidNumericId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + InvalidId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Message NumericId " + InvalidId + " \n Entity type of Phoenix2.LenderService.Domain.Entities.Lender"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_LenderType_GetEligibleLenders_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/eligible-lenders");
            RestRequest request = helper.CreateGetRequest(acessToken);
            request.AddParameter("LeadId", 361870);
            request.AddParameter("ContactId", 343486);
            request.AddParameter("CoContactId", 343487);
            request.AddParameter("DealId", 325330);
            request.AddParameter("IsDealEdit", true);
            request.AddParameter("IsEstimatedScore", true);
            request.AddParameter("EstimatedScore", 762);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void LenderService_Lender_GetEligibleLenders_NegativeScenario_InvavidAllInputData()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/eligible-lenders");
            RestRequest request = helper.CreateGetRequest(acessToken);
            request.AddParameter("LeadId", 1111);
            request.AddParameter("ContactId", 1111);
            request.AddParameter("CoContactId", 1111);
            request.AddParameter("DealId", 1111);
            request.AddParameter("UserId", 1111);
            request.AddParameter("IsDealEdit", true);
            request.AddParameter("IsEstimatedScore", true);
            request.AddParameter("EstimatedScore", 1111);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Message {\"Message\":\"An error has occurred.\"} \n Entity type of Phoenix.Common.Client.HttpСlients.SDK.Models.ResponseModels.Lead.LeadResponse"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_LenderType_EligibleLenderTierConditions_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/eligible-lenders-tierconditions");
            LenderType_EligibleLenderTierConditions_Request eligibleLenderTierConditions = new LenderType_EligibleLenderTierConditions_Request();
            LenderFicoList_EligibleLenderTierConditions_Request ficoList = new LenderFicoList_EligibleLenderTierConditions_Request();
            ficoList.LenderCode = LenderServiceLenderCode;
            ficoList.Fico = 0;
            eligibleLenderTierConditions.VehicleAge = 0;
            eligibleLenderTierConditions.AssetMiles = 0;
            eligibleLenderTierConditions.AssetType = "Car";
            eligibleLenderTierConditions.AssetMake = "string";
            List<LenderFicoList_EligibleLenderTierConditions_Request> lenderFicoList = new List<LenderFicoList_EligibleLenderTierConditions_Request> { ficoList };
            eligibleLenderTierConditions.LenderFicoList = lenderFicoList;
            string payload = JsonConvert.SerializeObject(eligibleLenderTierConditions, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void LenderService_LenderType_EligibleLenderTierConditions_NegativeScenario_InvalidLenderCode()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/eligible-lenders-tierconditions");
            LenderType_EligibleLenderTierConditions_Request eligibleLenderTierConditions = new LenderType_EligibleLenderTierConditions_Request();
            LenderFicoList_EligibleLenderTierConditions_Request ficoList = new LenderFicoList_EligibleLenderTierConditions_Request();
            ficoList.LenderCode = "LB";
            ficoList.Fico = 0;
            eligibleLenderTierConditions.VehicleAge = 0;
            eligibleLenderTierConditions.AssetMiles = 0;
            eligibleLenderTierConditions.AssetType = "Car";
            eligibleLenderTierConditions.AssetMake = "string";
            List<LenderFicoList_EligibleLenderTierConditions_Request> lenderFicoList = new List<LenderFicoList_EligibleLenderTierConditions_Request> { ficoList };
            eligibleLenderTierConditions.LenderFicoList = lenderFicoList;
            string payload = JsonConvert.SerializeObject(eligibleLenderTierConditions, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("No lenders found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void LenderService_LenderType_LenderFees_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/lender-fees?lenderCode=" + LenderServiceLenderCode + "&state=" + State.AL + "&contactId=" + ContactIdLenderService);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        [TestCase(InvalidLenderCode, "AL", ContactIdLenderService)]
        [TestCase(LenderServiceLenderCode, InvalidState, ContactIdLenderService)]
        [TestCase(InvalidLenderCode, InvalidState, ContactIdLenderService)]
        public void LenderService_LenderType_LenderFees_NegativeScenario(string LenderCode, string State, string ContactId)
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/lender-fees?lenderCode=" + LenderCode + "&state=" + State + "&contactId=" + ContactId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void LenderService_LenderType_LenderFeesByNumericId_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/lender-fees-bynumericid?numericId=" + NumericId + "&state=" + State.AL + "&contactId=" + ContactIdLenderService);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        [TestCase(InvalidNumericId, "AL", ContactIdLenderService)]
        [TestCase(NumericId, "XXX", ContactIdLenderService)]
        [TestCase(InvalidNumericId, "XXX", ContactIdLenderService)]
        public void LenderService_LenderType_LenderFeesByNumericId_NegativeScenario(string NumericId, string State, string ContactId)
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/lender-fees-bynumericid?numericId=" + NumericId + "&state=" + State + "&contactId=" + ContactId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_LenderType_LendersGeneral_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/general");
            string name = helper.GenerateDocName(6);
            LenderType_LendersGeneral_Request generalInfo = new LenderType_LendersGeneral_Request();
            generalInfo.Name = "string";
            generalInfo.Address = "string";
            generalInfo.State = "AL";
            generalInfo.PostCode = "12345";
            generalInfo.ContactPerson = "string";
            generalInfo.ContactPhone = "1234567890";
            generalInfo.City = "string";
            generalInfo.Rank = 1;
            generalInfo.LtvType = "FrontEnd";
            generalInfo.IsOpenLending = true;
            generalInfo.IsDocGen2 = true;
            generalInfo.IsDefi = true;
            generalInfo.MeridianLenderReferenceId = "string";
            generalInfo.MeridianOrgReferenceId = "string";
            generalInfo.LenderPurposeType = "string";
            generalInfo.AcumaticaId = "string";
            generalInfo.IsGenericAprCalculation = true;
            generalInfo.IsAcumaticaSpecialProcessing = true;
            generalInfo.AutoSubmitLoanApplication = true;
            generalInfo.IsFlStampFee = true;
            generalInfo.IsDealertrack = true;
            generalInfo.DealertrackId = 0;
            generalInfo.SubRank = 0;
            generalInfo.IsRestrictDr = true;
            OpenLendingConfiguration_LendersGeneral_Request openLending = new OpenLendingConfiguration_LendersGeneral_Request();
            generalInfo.OpenLendingConfiguration = openLending;
            openLending.UserName = "string";
            openLending.Password = "string";
            openLending.InstitutionId = "string";
            GeneralInfoNew_LendersGeneral_Request generalInfoNew = new GeneralInfoNew_LendersGeneral_Request();
            generalInfo.GeneralInfo = generalInfoNew;
            List<string> defaultValuationMethods = new List<string> { "KbbRetail" };
            generalInfoNew.DefaultValuationMethods = defaultValuationMethods;
            generalInfo.GeneralInfo = generalInfoNew;
            generalInfoNew.DaysToFirstPaymentGreen = 0;
            generalInfoNew.DaysToFirstPaymentYellow = 0;
            generalInfoNew.MaxDtiGreen = 0;
            generalInfoNew.MaxDtiYellow = 0;
            generalInfoNew.MaxPtiGreen = 0;
            generalInfoNew.MaxPtiYellow = 0;
            generalInfoNew.AvailableMarkupIncrements = "string";
            generalInfoNew.MaxMileageGreen = 0;
            generalInfoNew.MaxMileageYellow = 0;
            generalInfoNew.MaxAgeGreen = 0;
            generalInfoNew.MaxAgeYellow = 0;
            generalInfoNew.MinPrimaryFicoGreen = 0;
            generalInfoNew.MinPrimaryFicoYellow = 0;
            generalInfoNew.MinSecondaryFicoGreen = 0;
            generalInfoNew.MinSecondaryFicoYellow = 0;
            generalInfoNew.ApprovalDaysGreen = 0;
            generalInfoNew.ApprovalDaysYellow = 0;
            generalInfoNew.MaxCashOutGreen = 0;
            generalInfoNew.MaxCashOutYellow = 0;
            generalInfoNew.MaxFlatPercentGreen = 0;
            generalInfoNew.MaxFlatPercentYellow = 0;
            generalInfoNew.MaxGapGreen = 0;
            generalInfoNew.MaxGapYellow = 0;
            generalInfoNew.GapLtvLimit = 0;
            generalInfoNew.MaxFlatGreen = 0;
            generalInfoNew.MaxFlatYellow = 0;
            generalInfoNew.FlatPercent = 0;
            generalInfoNew.MaxOtherProducts = 0;
            generalInfoNew.ExperianDefaultScore = "Eqf";
            generalInfoNew.SecondaryBureau = "Eqf";
            generalInfoNew.PrimaryBureau = "Eqf";
            generalInfoNew.FundingFeeGreen = 0;
            generalInfoNew.FundingFeeYellow = 0;
            generalInfoNew.AllowEmployerZip = true;
            generalInfoNew.StatedFunds = 0;
            generalInfoNew.ExpectedFunds = 0;
            generalInfoNew.AchDiscount = 0;
            generalInfoNew.MaxVsc = 0;
            generalInfoNew.MaxProduct = 0;
            generalInfoNew.Requirements = "string";
            generalInfoNew.UseAprBasedCalculation = true;
            generalInfoNew.ContractDateForUsingAprBasedCalculations = DateTime.Now;
            generalInfoNew.MaxVrp = 0;
            generalInfoNew.CreditReport = "Eqf";
            string payload = JsonConvert.SerializeObject(generalInfo, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void LenderService_LenderType_LendersGeneral_NegativeScenario_InvalidInvalidLenderId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + InvalidLenderId + "/general");
            string name = helper.GenerateDocName(6);
            LenderType_LendersGeneral_Request generalInfo = new LenderType_LendersGeneral_Request();
            generalInfo.Name = "string";
            generalInfo.Address = "string";
            generalInfo.State = "AL";
            generalInfo.PostCode = "12345";
            generalInfo.ContactPerson = "string";
            generalInfo.ContactPhone = "1234567890";
            generalInfo.City = "string";
            generalInfo.Rank = 1;
            generalInfo.LtvType = "FrontEnd";
            generalInfo.IsOpenLending = true;
            generalInfo.IsDocGen2 = true;
            generalInfo.IsDefi = true;
            generalInfo.MeridianLenderReferenceId = "string";
            generalInfo.MeridianOrgReferenceId = "string";
            generalInfo.LenderPurposeType = "string";
            generalInfo.AcumaticaId = "string";
            generalInfo.IsGenericAprCalculation = true;
            generalInfo.IsAcumaticaSpecialProcessing = true;
            generalInfo.AutoSubmitLoanApplication = true;
            generalInfo.IsFlStampFee = true;
            generalInfo.IsDealertrack = true;
            generalInfo.DealertrackId = 0;
            generalInfo.SubRank = 0;
            generalInfo.IsRestrictDr = true;
            OpenLendingConfiguration_LendersGeneral_Request openLending = new OpenLendingConfiguration_LendersGeneral_Request();
            generalInfo.OpenLendingConfiguration = openLending;
            openLending.UserName = "string";
            openLending.Password = "string";
            openLending.InstitutionId = "string";
            GeneralInfoNew_LendersGeneral_Request generalInfoNew = new GeneralInfoNew_LendersGeneral_Request();
            generalInfo.GeneralInfo = generalInfoNew;
            List<string> defaultValuationMethods = new List<string> { "KbbRetail" };
            generalInfoNew.DefaultValuationMethods = defaultValuationMethods;
            generalInfo.GeneralInfo = generalInfoNew;
            generalInfoNew.DaysToFirstPaymentGreen = 0;
            generalInfoNew.DaysToFirstPaymentYellow = 0;
            generalInfoNew.MaxDtiGreen = 0;
            generalInfoNew.MaxDtiYellow = 0;
            generalInfoNew.MaxPtiGreen = 0;
            generalInfoNew.MaxPtiYellow = 0;
            generalInfoNew.AvailableMarkupIncrements = "string";
            generalInfoNew.MaxMileageGreen = 0;
            generalInfoNew.MaxMileageYellow = 0;
            generalInfoNew.MaxAgeGreen = 0;
            generalInfoNew.MaxAgeYellow = 0;
            generalInfoNew.MinPrimaryFicoGreen = 0;
            generalInfoNew.MinPrimaryFicoYellow = 0;
            generalInfoNew.MinSecondaryFicoGreen = 0;
            generalInfoNew.MinSecondaryFicoYellow = 0;
            generalInfoNew.ApprovalDaysGreen = 0;
            generalInfoNew.ApprovalDaysYellow = 0;
            generalInfoNew.MaxCashOutGreen = 0;
            generalInfoNew.MaxCashOutYellow = 0;
            generalInfoNew.MaxFlatPercentGreen = 0;
            generalInfoNew.MaxFlatPercentYellow = 0;
            generalInfoNew.MaxGapGreen = 0;
            generalInfoNew.MaxGapYellow = 0;
            generalInfoNew.GapLtvLimit = 0;
            generalInfoNew.MaxFlatGreen = 0;
            generalInfoNew.MaxFlatYellow = 0;
            generalInfoNew.FlatPercent = 0;
            generalInfoNew.MaxOtherProducts = 0;
            generalInfoNew.ExperianDefaultScore = "Eqf";
            generalInfoNew.SecondaryBureau = "Eqf";
            generalInfoNew.PrimaryBureau = "Eqf";
            generalInfoNew.FundingFeeGreen = 0;
            generalInfoNew.FundingFeeYellow = 0;
            generalInfoNew.AllowEmployerZip = true;
            generalInfoNew.StatedFunds = 0;
            generalInfoNew.ExpectedFunds = 0;
            generalInfoNew.AchDiscount = 0;
            generalInfoNew.MaxVsc = 0;
            generalInfoNew.MaxProduct = 0;
            generalInfoNew.Requirements = "string";
            generalInfoNew.UseAprBasedCalculation = true;
            generalInfoNew.ContractDateForUsingAprBasedCalculations = DateTime.Now;
            generalInfoNew.MaxVrp = 0;
            generalInfoNew.CreditReport = "Eqf";
            string payload = JsonConvert.SerializeObject(generalInfo, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LenderService.Domain.Entities.Lender with id '" + InvalidLenderId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void LenderService_LenderType_LenderCard_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/card");
            string payload = helper.Serialize
            (new
            {
                FromDate = "2022-04-15T10:35:23.329Z",
                ToDate = "2022-04-15T10:35:23.329Z"
            });
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void LenderService_LenderType_LenderCard_NegativeScenario_InvalidLenderId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + InvalidLenderId + "/card");
            string payload = helper.Serialize
            (new
            {
                FromDate = "2022-04-15T10:35:23.329Z",
                ToDate = "2022-04-15T10:35:23.329Z"
            });
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LenderService.Domain.Entities.Lender with id '" + InvalidLenderId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void LenderService_LenderType_PatchLendersCard_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/card");
            string payload = helper.Serialize
            (new
            {
                Id = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                FromDate = "2022-04-15T10:35:23.329Z",
                ToDate = "2022-04-15T10:35:23.329Z",
                CreatedDate = "2022-04-15T10:42:15.488Z"

            });
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void LenderService_LenderType_PatchLendersCard_NegativeScenario_InvalidLenderiD()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + InvalidLenderId + "/card");
            string payload = helper.Serialize
            (new
            {
                Id = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                FromDate = "2022-04-15T10:35:23.329Z",
                ToDate = "2022-04-15T10:35:23.329Z",
                CreatedDate = "2022-04-15T10:42:15.488Z"

            });
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LenderService.Domain.Entities.Lender with id '" + InvalidLenderId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void LenderService_LenderType_DeleteLenderCard_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/card/" + CardIdForDelete);
            RestRequest request = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void LenderService_LenderType_DeleteLenderCard_NegativeScenario_InvalidLenderId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + InvalidLenderId + "/card/" + CardIdForDelete);
            RestRequest request = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LenderService.Domain.Entities.Lender with id '" + InvalidLenderId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void LenderService_LenderType_CopyCard_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/card-copy/" + CardId);
            RestRequest request = helper.CreatePostRequestWithoutBody(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        [TestCase(InvalidLenderId, CardId)]
        [TestCase(LenderServiceId, CardIdInvalid)]
        [TestCase(InvalidLenderId, CardIdInvalid)]
        public void LenderService_LenderType_CopyCard_NegativeScenario(string LenderId, string CardId)
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderId + "/card-copy/" + CardId);
            RestRequest request = helper.CreatePostRequestWithoutBody(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void LenderService_LenderType_PutLendersTier_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/tier/" + CardId);
            string payload = helper.Serialize(new
            {
                TierLabel = "Test",
                TierDescription = "Test",
                MinFico = 0,
                MaxFico = 1000
            });
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        [TestCase(InvalidLenderId, CardId)]
        [TestCase(LenderServiceId, CardIdInvalid)]
        [TestCase(InvalidLenderId, CardIdInvalid)]
        public void LenderService_LenderType_PutLendersTier_NegativeScenario(string LenderId, string CardId)
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderId + "/tier/" + CardId);
            string payload = helper.Serialize(new
            {
                TierLabel = "Test",
                TierDescription = "Test",
                MinFico = 0,
                MaxFico = 1000
            });
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void LenderService_LenderType_PatchLendersTier_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/tier");
            string payload = helper.Serialize(new
            {
                Id = CardtiersId,
                TierLabel = "Test",
                TierDescription = "Test",
                MinFico = 0,
                MaxFico = 1000,
                CreatedDate = "2022-04-18T12:08:43.046Z"
            });
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void LenderService_LenderType_PatchLendersTier_NegativeScenario_InvalidLenderId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + InvalidLenderId + "/tier");
            string payload = helper.Serialize(new
            {
                Id = "a62bc377-d1b8-427b-9b3b-739a2bee0668",
                TierLabel = "Test",
                TierDescription = "Test",
                MinFico = 0,
                MaxFico = 1000,
                CreatedDate = "2022-04-18T12:08:43.046Z"
            });
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LenderService.Domain.Entities.Lender with id '" + InvalidLenderId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void LenderService_LenderType_CopyTier_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/tier-copy/" + TierId);
            RestRequest request = helper.CreatePostRequestWithoutBody(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        [TestCase(LenderServiceId, TierIdInvalid)]
        [TestCase(InvalidLenderId, TierId)]
        [TestCase(InvalidLenderId, TierIdInvalid)]
        public void LenderService_LenderType_CopyTier_NegativeScenario(string LenderId, string TierId)
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderId + "/tier-copy/" + TierId);
            RestRequest request = helper.CreatePostRequestWithoutBody(acessToken);
            /// Assert
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void LenderService_LenderType_PutTierCondition_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/tier-copy/" + TierId);
            LenderType_PutTierCondition_Request tierCondition = new LenderType_PutTierCondition_Request()
            {
                MinFico = 0,
                MaxFico = 0,
                MinTerm = 0,
                MaxTerm = 0,
                MinLtv = 0,
                MaxLtv = 0,
                MinDti = 0,
                MaxDti = 0,
                MinLoanAmount = 0,
                MaxLoanAmount = 0,
                LtvLimit = 0,
                MinAssetYear = 0,
                MaxAssetYear = 0,
                MaxTotalLending = 0,
                LenderTierId = 0,
                Rate = 0,
                MinMiles = 0,
                MaxMilesGreen = 0,
                MaxPti = 0,
                MaxCashOut = 0,
                MaxAgeGreen = 0,
                MaxAgeYellow = 0,
                TermGroup = 0,
                FicoGroup = 0,
                TermFico = "string",
                MaxMarkup = 0,
                MaxFlatFeePercent = 0,
                MaxMilesYellow = 0,
                DtiYellow = 0,
                DtiGreen = 0,
                PtiYellow = 0,
                PtiGreen = 0,
                Type = "string",
                MinTotalAmountFinanceGreen = 0,
                MinTotalAmountFinanceYellow = 0,
                MaxLtvGreen = 0,
                MaxLtvYellow = 0,
                IsCashOutRate = true,
                MaxAllInLtv = 0,
                MinAgeGreen = 0,
                MaxFlatGreen = 0
            };
            string payload = JsonConvert.SerializeObject(tierCondition, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        [TestCase(LenderServiceId, TierIdInvalid)]
        [TestCase(InvalidLenderId, TierId)]
        [TestCase(InvalidLenderId, TierIdInvalid)]
        public void LenderService_LenderType_PutTierCondition_NegativeScenario(string LenderId, string TierId)
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderId + "/tier-copy/" + TierId);
            LenderType_PutTierCondition_Request tierCondition = new LenderType_PutTierCondition_Request()
            {
                MinFico = 0,
                MaxFico = 0,
                MinTerm = 0,
                MaxTerm = 0,
                MinLtv = 0,
                MaxLtv = 0,
                MinDti = 0,
                MaxDti = 0,
                MinLoanAmount = 0,
                MaxLoanAmount = 0,
                LtvLimit = 0,
                MinAssetYear = 0,
                MaxAssetYear = 0,
                MaxTotalLending = 0,
                LenderTierId = 0,
                Rate = 0,
                MinMiles = 0,
                MaxMilesGreen = 0,
                MaxPti = 0,
                MaxCashOut = 0,
                MaxAgeGreen = 0,
                MaxAgeYellow = 0,
                TermGroup = 0,
                FicoGroup = 0,
                TermFico = "string",
                MaxMarkup = 0,
                MaxFlatFeePercent = 0,
                MaxMilesYellow = 0,
                DtiYellow = 0,
                DtiGreen = 0,
                PtiYellow = 0,
                PtiGreen = 0,
                Type = "string",
                MinTotalAmountFinanceGreen = 0,
                MinTotalAmountFinanceYellow = 0,
                MaxLtvGreen = 0,
                MaxLtvYellow = 0,
                IsCashOutRate = true,
                MaxAllInLtv = 0,
                MinAgeGreen = 0,
                MaxFlatGreen = 0
            };
            string payload = JsonConvert.SerializeObject(tierCondition, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }


        [Test]
        public void LenderService_LenderType_PatchTierCondition_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/tierCondition");
            LenderType_PatchTierCondition_Request updateTierCondition = new LenderType_PatchTierCondition_Request()
            {
                Id = TierConditionIdforupdate,
                MinFico = 0,
                MaxFico = 0,
                MinTerm = 0,
                MaxTerm = 0,
                MinLtv = 0,
                MaxLtv = 0,
                MinDti = 0,
                MaxDti = 0,
                MinLoanAmount = 0,
                MaxLoanAmount = 0,
                LtvLimit = 0,
                MinAssetYear = 0,
                MaxAssetYear = 0,
                MaxTotalLending = 0,
                LenderTierId = 0,
                Rate = 0,
                MinMiles = 0,
                MaxMilesGreen = 0,
                MaxPti = 0,
                MaxCashOut = 0,
                MaxAgeGreen = 0,
                MaxAgeYellow = 0,
                TermGroup = 0,
                FicoGroup = 0,
                TermFico = "string",
                MaxMarkup = 0,
                MaxFlatFeePercent = 0,
                MaxMilesYellow = 0,
                DtiYellow = 0,
                DtiGreen = 0,
                PtiYellow = 0,
                PtiGreen = 0,
                Type = "string",
                MinTotalAmountFinanceGreen = 0,
                MinTotalAmountFinanceYellow = 0,
                MaxLtvGreen = 0,
                MaxLtvYellow = 0,
                IsCashOutRate = true,
                MaxAllInLtv = 0,
                MinAgeGreen = 0,
                MaxFlatGreen = 0,
                CreatedDate = DateTime.Now
            };
            string payload = JsonConvert.SerializeObject(updateTierCondition, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void LenderService_LenderType_PatchTierCondition_NegativeScenario_InvalidLenderId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + InvalidLenderId + "/tierCondition");
            LenderType_PatchTierCondition_Request updateTierCondition = new LenderType_PatchTierCondition_Request()
            {
                Id = "24d2c282-929d-427b-8357-fa75265e3083",
                MinFico = 0,
                MaxFico = 0,
                MinTerm = 0,
                MaxTerm = 0,
                MinLtv = 0,
                MaxLtv = 0,
                MinDti = 0,
                MaxDti = 0,
                MinLoanAmount = 0,
                MaxLoanAmount = 0,
                LtvLimit = 0,
                MinAssetYear = 0,
                MaxAssetYear = 0,
                MaxTotalLending = 0,
                LenderTierId = 0,
                Rate = 0,
                MinMiles = 0,
                MaxMilesGreen = 0,
                MaxPti = 0,
                MaxCashOut = 0,
                MaxAgeGreen = 0,
                MaxAgeYellow = 0,
                TermGroup = 0,
                FicoGroup = 0,
                TermFico = "string",
                MaxMarkup = 0,
                MaxFlatFeePercent = 0,
                MaxMilesYellow = 0,
                DtiYellow = 0,
                DtiGreen = 0,
                PtiYellow = 0,
                PtiGreen = 0,
                Type = "string",
                MinTotalAmountFinanceGreen = 0,
                MinTotalAmountFinanceYellow = 0,
                MaxLtvGreen = 0,
                MaxLtvYellow = 0,
                IsCashOutRate = true,
                MaxAllInLtv = 0,
                MinAgeGreen = 0,
                MaxFlatGreen = 0,
                CreatedDate = DateTime.Now
            };
            string payload = JsonConvert.SerializeObject(updateTierCondition, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LenderService.Domain.Entities.Lender with id '" + InvalidLenderId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_LenderType_TierConditionCopy_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/tierCondition-copy/" + TierConditionIdforupdate);
            RestRequest request = helper.CreatePostRequestWithoutBody(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        [TestCase(LenderServiceId, TierIdInvalid)]
        [TestCase(InvalidLenderId, TierConditionIdforupdate)]
        [TestCase(InvalidLenderId, TierIdInvalid)]
        public void LenderService_LenderType_TierConditionCopy_NegativeScenario(string LenderId, string tierConditionId)
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderId + "/tierCondition-copy/" + tierConditionId);
            RestRequest request = helper.CreatePostRequestWithoutBody(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_LenderType_StatesAndZip_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/statesAndZips");
            LenderType_StatesAndZip_Request statesAndZip = new LenderType_StatesAndZip_Request();
            List<string> excludedStates = new List<string> { "AL" };
            statesAndZip.ExcludedStates = excludedStates;
            statesAndZip.IsCurrent = true;
            List<string> includedZipCodes = new List<string> { "string" };
            statesAndZip.IncludedZipCodes = includedZipCodes;
            List<string> includedContactIds = new List<string> { "string" };
            statesAndZip.IncludedContactIds = includedContactIds;
            statesAndZip.LeadStateZipId = "string";
            string payload = JsonConvert.SerializeObject(statesAndZip, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void LenderService_LenderType_StatesAndZip_NegativeScenario_InvalidLenderId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + InvalidLenderId + "/statesAndZips");
            LenderType_StatesAndZip_Request statesAndZip = new LenderType_StatesAndZip_Request();
            List<string> excludedStates = new List<string> { "AL" };
            statesAndZip.ExcludedStates = excludedStates;
            statesAndZip.IsCurrent = true;
            List<string> includedZipCodes = new List<string> { "string" };
            statesAndZip.IncludedZipCodes = includedZipCodes;
            List<string> includedContactIds = new List<string> { "string" };
            statesAndZip.IncludedContactIds = includedContactIds;
            statesAndZip.LeadStateZipId = "string";
            string payload = JsonConvert.SerializeObject(statesAndZip, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LenderService.Domain.Entities.Lender with id '" + InvalidLenderId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void LenderService_LenderType_PutStateRule_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/stateRule");
            LenderType_PutStateRule_Request stateRule = new LenderType_PutStateRule_Request();
            stateRule.State = "AL";
            stateRule.Bureau = "Eqf";
            List<string> zips = new List<string> { "string" };
            stateRule.Zips = zips;
            stateRule.DaysToFirstPayment = 0;
            stateRule.LoanAmount = 0;
            stateRule.LoanAmountOperator = "Equal";
            stateRule.Apr = 0;
            stateRule.AprOperator = "Equal";
            stateRule.Rate = 0;
            stateRule.RateOperator = "Equal";
            string payload = JsonConvert.SerializeObject(stateRule, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void LenderService_LenderType_PutStateRule_NegativeScenario_InvalidLenderId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + InvalidLenderId + "/stateRule");
            LenderType_PutStateRule_Request stateRule = new LenderType_PutStateRule_Request();
            stateRule.State = "AL";
            stateRule.Bureau = "Eqf";
            List<string> zips = new List<string> { "string" };
            stateRule.Zips = zips;
            stateRule.DaysToFirstPayment = 0;
            stateRule.LoanAmount = 0;
            stateRule.LoanAmountOperator = "Equal";
            stateRule.Apr = 0;
            stateRule.AprOperator = "Equal";
            stateRule.Rate = 0;
            stateRule.RateOperator = "Equal";
            string payload = JsonConvert.SerializeObject(stateRule, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LenderService.Domain.Entities.Lender with id '" + InvalidLenderId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_LenderType_PatchStateRule_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/stateRule");
            LenderType_PatchStateRule_Request updateStateRule = new LenderType_PatchStateRule_Request();
            updateStateRule.Id = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            updateStateRule.State = "AL";
            updateStateRule.StateName = "string";
            updateStateRule.Bureau = "Eqf";
            List<string> zips = new List<string> { "string" };
            updateStateRule.Zips = zips;
            updateStateRule.DaysToFirstPayment = 0;
            updateStateRule.LoanAmount = 0;
            updateStateRule.LoanAmountOperator = "Equal";
            updateStateRule.Apr = 0;
            updateStateRule.AprOperator = "Equal";
            updateStateRule.Rate = 0;
            updateStateRule.RateOperator = "Equal";
            string payload = JsonConvert.SerializeObject(updateStateRule, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void LenderService_LenderType_PatchStateRule_NegativeScenario_InvalidLenderId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + InvalidLenderId + "/stateRule");
            LenderType_PatchStateRule_Request updateStateRule = new LenderType_PatchStateRule_Request();
            updateStateRule.Id = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            updateStateRule.State = "AL";
            updateStateRule.StateName = "string";
            updateStateRule.Bureau = "Eqf";
            List<string> zips = new List<string> { "string" };
            updateStateRule.Zips = zips;
            updateStateRule.DaysToFirstPayment = 0;
            updateStateRule.LoanAmount = 0;
            updateStateRule.LoanAmountOperator = "Equal";
            updateStateRule.Apr = 0;
            updateStateRule.AprOperator = "Equal";
            updateStateRule.Rate = 0;
            updateStateRule.RateOperator = "Equal";
            string payload = JsonConvert.SerializeObject(updateStateRule, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LenderService.Domain.Entities.Lender with id '" + InvalidLenderId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void LenderService_LenderType_AssetTypes_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/assetType");
            LenderType_AssetTypes_Request assetTypes = new LenderType_AssetTypes_Request()
            {
                AssetType = "Car",
                IsAllowed = true
            };
            List<object> value = new List<object> { assetTypes };
            string payload = JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void LenderService_LenderType_AssetTypes_NegativeScenario_InvalidLenderId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + InvalidLenderId + "/assetType");
            LenderType_AssetTypes_Request assetTypes = new LenderType_AssetTypes_Request()
            {
                AssetType = "Car",
                IsAllowed = true
            };
            List<object> value = new List<object> { assetTypes };
            string payload = JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LenderService.Domain.Entities.Lender with id '" + InvalidLenderId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_LenderType_PutDocFeeStateExclusion_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/docFeeStateExclusion");
            string payload = helper.Serialize(new
            {
                State = "AL",
                Amount = 0,
                Category = "string",
                Description = "string",
                IsDocFee = true
            });
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void LenderService_LenderType_PutDocFeeStateExclusion_NegativeScenario_InvalidLenderId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + InvalidLenderId + "/docFeeStateExclusion");
            string payload = helper.Serialize(new
            {
                State = "AL",
                Amount = 0,
                Category = "string",
                Description = "string",
                IsDocFee = true
            });
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LenderService.Domain.Entities.Lender with id '" + InvalidLenderId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }


        [Test]
        public void LenderService_LenderType_PatchDocFeeStateExclusion_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/docFeeStateExclusion");
            string payload = helper.Serialize(new
            {
                Id = docFeeStateExclusionsID,
                State = "AL",
                Amount = 0,
                Category = "string",
                Description = "string",
                IsDocFee = true
            });
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void LenderService_LenderType_PatchDocFeeStateExclusion_NegativeScenario_InvalidLenderId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + InvalidLenderId + "/docFeeStateExclusion");
            string payload = helper.Serialize(new
            {
                Id = "9ba4cdc8-d46e-4ca9-a20a-0bdd28126718",
                State = "AL",
                Amount = 0,
                Category = "string",
                Description = "string",
                IsDocFee = true
            });
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LenderService.Domain.Entities.Lender with id '" + InvalidLenderId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_LenderType_PutDealFee_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/dealFee");
            string payload = helper.Serialize(new
            {
                Category = "string",
                Description = "string",
                Amount = 0,
                MinFico = 0,
                MaxFico = 0,
                IsCurrent = true,
                IsIncluded = true,
                IsDocFee = true
            });
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void LenderService_LenderType_PutDealFee_NegativeScenario_InvalidLenderId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + InvalidLenderId + "/dealFee");
            string payload = helper.Serialize(new
            {
                Category = "string",
                Description = "string",
                Amount = 0,
                MinFico = 0,
                MaxFico = 0,
                IsCurrent = true,
                IsIncluded = true,
                IsDocFee = true
            });
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LenderService.Domain.Entities.Lender with id '" + InvalidLenderId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void LenderService_LenderType_PatchDealFee_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/dealFee");
            string payload = helper.Serialize(new
            {
                Id = "7f468e38-83b1-43dd-bf32-1e38aade3381",
                Category = "string",
                Description = "string",
                Amount = 0,
                MinFico = 0,
                MaxFico = 0,
                IsCurrent = true,
                IsIncluded = true,
                IsDocFee = true
            });
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void LenderService_LenderType_PatchDealFee_NegativeScenario_InvalidLenderId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + InvalidLenderId + "/dealFee");
            string payload = helper.Serialize(new
            {
                Id = "7f468e38-83b1-43dd-bf32-1e38aade3381",
                Category = "string",
                Description = "string",
                Amount = 0,
                MinFico = 0,
                MaxFico = 0,
                IsCurrent = true,
                IsIncluded = true,
                IsDocFee = true
            });
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LenderService.Domain.Entities.Lender with id '" + InvalidLenderId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_LenderType_PatchProductTypeExclusionRules_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/productTypeExclusionRule");
            LenderType_PatchProductTypeExclusionRules_Request productExclusionRules = new LenderType_PatchProductTypeExclusionRules_Request();
            productExclusionRules.IsCurrent = true;
            productExclusionRules.IsDeleted = true;
            productExclusionRules.ProductType = "Gap";
            CreatedByUpdateProduct_PatchProductTypeExclusionRules_Request createdExclusionRules = new CreatedByUpdateProduct_PatchProductTypeExclusionRules_Request();
            createdExclusionRules.Id = "string";
            createdExclusionRules.Email = "string";
            createdExclusionRules.Name = "string";
            productExclusionRules.CreatedDate = DateTime.Now;
            UpdatedByUpdateProduct_PatchProductTypeExclusionRules_Request updatedExclusionRules = new UpdatedByUpdateProduct_PatchProductTypeExclusionRules_Request();
            updatedExclusionRules.Id = "string";
            updatedExclusionRules.Email = "string";
            updatedExclusionRules.Name = "string";
            productExclusionRules.UpdatedDate = DateTime.Now;
            productExclusionRules.CreatedByupdateProduct = createdExclusionRules;
            productExclusionRules.UpdatedByupdateProduct = updatedExclusionRules;
            List<object> value = new List<object> { productExclusionRules };
            string payload = JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void LenderService_LenderType_PatchProductTypeExclusionRules_NegativeScenario_InvalidLenderId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + InvalidLenderId + "/productTypeExclusionRule");
            LenderType_PatchProductTypeExclusionRules_Request productExclusionRules = new LenderType_PatchProductTypeExclusionRules_Request();
            productExclusionRules.IsCurrent = true;
            productExclusionRules.IsDeleted = true;
            productExclusionRules.ProductType = "Gap";
            CreatedByUpdateProduct_PatchProductTypeExclusionRules_Request createdExclusionRules = new CreatedByUpdateProduct_PatchProductTypeExclusionRules_Request();
            createdExclusionRules.Id = "string";
            createdExclusionRules.Email = "string";
            createdExclusionRules.Name = "string";
            productExclusionRules.CreatedDate = DateTime.Now;
            UpdatedByUpdateProduct_PatchProductTypeExclusionRules_Request updatedExclusionRules = new UpdatedByUpdateProduct_PatchProductTypeExclusionRules_Request();
            updatedExclusionRules.Id = "string";
            updatedExclusionRules.Email = "string";
            updatedExclusionRules.Name = "string";
            productExclusionRules.UpdatedDate = DateTime.Now;
            productExclusionRules.CreatedByupdateProduct = createdExclusionRules;
            productExclusionRules.UpdatedByupdateProduct = updatedExclusionRules;
            List<object> value = new List<object> { productExclusionRules };
            string payload = JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LenderService.Domain.Entities.Lender with id '" + InvalidLenderId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_LenderType_GetCreditRules_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/creditRules");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void LenderService_LenderType_PutLenderCreditRule_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/lenderCreditRule");
            string payload = helper.Serialize(new
            {
                Condition = "Equal",
                YellowValue = 0,
                Value = 0,
                CreditRule = "NumberOfOpenTradeLines"
            });
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void LenderService_LenderType_PutLenderCreditRule_NegativeScenario_InvalidLenderId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + InvalidLenderId + "/lenderCreditRule");
            string payload = helper.Serialize(new
            {
                Condition = "Equal",
                YellowValue = 0,
                Value = 0,
                CreditRule = "NumberOfOpenTradeLines"
            });
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LenderService.Domain.Entities.Lender with id '" + InvalidLenderId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_LenderType_PatchLenderCreditRule_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/" + LenderServiceId + "/lenderCreditRule/" + LenderCreditRuleId);
            LenderType_PatchLenderCreditRule_Request updateCreditRule = new LenderType_PatchLenderCreditRule_Request()
            {
                Condition = "Equal",
                YellowValue = "string",
                Value = "string",
                CreditRuleType = "NumberOfOpenTradeLines"
            };
            string payload = JsonConvert.SerializeObject(updateCreditRule, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        [TestCase(LenderServiceId, LenderCreditRuleIdInvalid)]
        [TestCase(InvalidLenderId, LenderCreditRuleId)]
        [TestCase(InvalidLenderId, LenderCreditRuleIdInvalid)]
        public void LenderService_LenderType_PatchLenderCreditRule_NegativeScenario(string LenderId, string LenderCreditRuleId)
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lender-service/" + LenderId + "/lenderCreditRule/" + LenderCreditRuleId);
            LenderType_PatchLenderCreditRule_Request updateCreditRule = new LenderType_PatchLenderCreditRule_Request()
            {
                Condition = "Equal",
                YellowValue = "string",
                Value = "string",
                CreditRuleType = "NumberOfOpenTradeLines"
            };
            string payload = JsonConvert.SerializeObject(updateCreditRule, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }


        [Test]
        public void LenderService_LenderType_PutFormula_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/formula");
            string payload = helper.Serialize(new
            {
                LtvType = "FrontEnd",
                FormulaValue = "string",

            });
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void LenderService_LenderType_PutFormula_NegativeScenario_InvalidLenderId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + InvalidLenderId + "/formula");
            string payload = helper.Serialize(new
            {
                LtvType = "FrontEnd",
                FormulaValue = "string",

            });
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LenderService.Domain.Entities.Lender with id '" + InvalidLenderId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_LenderType_PatchFormula_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/formula");
            string payload = helper.Serialize(new
            {
                Id = formulaID,
                LtvType = "FrontEnd",
                FormulaValue = "string",

            });
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void LenderService_LenderType_PatchFormula_NegativeScenario_InvalidLenderId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + InvalidLenderId + "/formula");
            string payload = helper.Serialize(new
            {
                Id = "4f29215f-41fb-40f9-940a-fb9b2fe815d8",
                LtvType = "FrontEnd",
                FormulaValue = "string",

            });
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LenderService.Domain.Entities.Lender with id '" + InvalidLenderId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_LenderType_Variable_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/formula/variables");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void LenderService_LenderType_PatchLenderRequirementsByNumericId_PositiveScenario()
        {
            RestClient client = helper.SetUrl("lender-service/lenders/" + NumericId + "/requirements");
            var restRequest = new RestRequest(Method.PATCH);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddJsonBody("string");
            IRestResponse response = helper.GetResponse(client, restRequest);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void LenderService_LenderType_PatchLenderRequirementsByNumericId_NegativeScenario_InvalidNumericId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + InvalidNumericId + "/requirements");
            var restRequest = new RestRequest(Method.PATCH);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddJsonBody("string");
            /// Act
            IRestResponse response = helper.GetResponse(client, restRequest);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("NumericId: " + InvalidNumericId + " not found."));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }


        [Test]
        public void LenderService_LenderType_PatchLenderRequirementsByLenderId_PostiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/requirements");
            var restRequest = new RestRequest(Method.PATCH);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddJsonBody("string");
            /// Act
            IRestResponse response = helper.GetResponse(client, restRequest);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void LenderService_LenderType_PatchLenderRequirementsByLenderId_NegativeScenario_InvalidLenderId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + InvalidLenderId + "/requirements");
            var restRequest = new RestRequest(Method.PATCH);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddJsonBody("string");
            /// Act
            IRestResponse response = helper.GetResponse(client, restRequest);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LenderService.Domain.Entities.Lender with id '" + InvalidLenderId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_LenderType_GetLenderRequirements_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + LenderServiceId + "/requirements");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<LenderType_GetLenderRequirements_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Requirements, Is.EqualTo("string"));
            });
        }

        [Test]
        public void LenderService_LenderType_GetLenderRequirements_NegativeScenario_InvalidLenderId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/" + InvalidLenderId + "/requirements");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LenderService.Domain.Entities.Lender with id '" + InvalidLenderId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_LenderType_PutLanderRank_PostiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/lenderrank");
            LenderType_PutLanderRank_Request landerRank = new LenderType_PutLanderRank_Request()
            {
                Id = LenderServiceId,
                Rank = 0,
                SubRank = 0
            };
            List<object> value = new List<object> { landerRank };
            string payload = JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void LenderService_LenderType_PutLanderRank_NegativeScenario_InvalidID_RequestBody()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/lenderrank");
            LenderType_PutLanderRank_Request landerRank = new LenderType_PutLanderRank_Request()
            {
                Id = InvalidLenderId,
                Rank = 0,
                SubRank = 0
            };
            List<object> value = new List<object> { landerRank };
            string payload = JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LenderService.Domain.Entities.Lender with id '" + InvalidLenderId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_LenderType_AllowedLender_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/allowed-lenders");
            LenderType_AllowedLender_Request allowedLender = new LenderType_AllowedLender_Request()
            {
                Zip = "string",
                State = "string",
                EmployerName = "string",
                EmployerZip = "string",
                ContactId = 0,
                FicoScore = 0
            };
            string payload = JsonConvert.SerializeObject(allowedLender, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void LenderService_LenderType_DefaultFico_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenders/defaultfico");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Arrange
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void LenderService_LenderDocumentsType_GetLenderDocuments_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenderdocuments/" + LenderServiceId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void LenderService_LenderDocumentsType_GetLenderDocuments_NegativeScenario_InvalidLenderId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenderdocuments/" + InvalidLenderId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("No documents found for lender " + InvalidLenderId));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_LenderDocumentsType_PostLenderDocumentByLenderId_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenderdocuments/" + LenderServiceId);
            string payload = helper.Serialize(new
            {
                FileContent = PdfFileInBase64,
                FileName = "string",
                DocumentType = "RateCard",
                UserId = 0
            });
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void LenderService_LenderDocumentsType_GetByLenderNumericId_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenderdocuments/" + NumericId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void LenderService_LenderDocumentsType_GetByLenderNumericId_NegativeScenario_InvalidNumericId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenderdocuments/" + InvalidNumericId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Message NumericId " + InvalidNumericId + " \n Entity type of Phoenix2.LenderService.Domain.Entities.Lender"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_LenderDocuments_PostLenderDocumentByNumericId_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/lenderdocuments/" + NumericId);
            string payload = helper.Serialize(new
            {
                FileContent = PdfFileInBase64,
                FileName = "string",
                DocumentType = "RateCard",
                UserId = 0
            });
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void LenderService_LenderProductCheckRequestPayeeType_GetCheckRequestPayee_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/checkrequestpayee");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void LenderService_LenderProductCheckRequestPayeeType_GetCheckRequestPayeeByLenderNumericId_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/checkrequestpayee/" + NumericId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<LenderProductCheckRequestPayeeType_GetCheckRequestPayeeByLenderNumericId_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Id, Is.EqualTo("3a0920b0-c4e4-4b4f-94f9-8b9e2b9db810"));
                Assert.That(responseContent.LenderId, Is.EqualTo(LenderServiceId));
            });
        }

        [Test]
        public void LenderService_LenderProductCheckRequestPayeeType_GetCheckRequestPayeeByLenderNumericId_NegativeScenario_InvalidNumericId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/checkrequestpayee/" + InvalidNumericId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Message NumericId: " + InvalidNumericId + " \n Entity type of Phoenix2.LenderService.Domain.Entities.Lender"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_LenderProductCheckRequestPayeeType_PostCheckRequestPayeeByLenderId_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/checkrequestpayee/" + LenderServiceId);
            LenderProductCheckRequestPayeeType_PostCheckRequestPayeeByLenderId_Request upsert = new LenderProductCheckRequestPayeeType_PostCheckRequestPayeeByLenderId_Request()
            {
                PayeeName = "string",
                PayeeAddress = "string"
            };
            string payload = JsonConvert.SerializeObject(upsert, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<LenderProductCheckRequestPayeeType_GetCheckRequestPayeeByLenderNumericId_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Id, Is.EqualTo("3a0920b0-c4e4-4b4f-94f9-8b9e2b9db810"));
                Assert.That(responseContent.LenderId, Is.EqualTo(LenderServiceId));
            });
        }

        [Test]
        public void LenderService_LenderProductCheckRequestPayeeType_PostCheckRequestPayeeByLenderId_NegativeScenario_InvalidLenderId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/checkrequestpayee/" + InvalidLenderId);
            LenderProductCheckRequestPayeeType_PostCheckRequestPayeeByLenderId_Request upsert = new LenderProductCheckRequestPayeeType_PostCheckRequestPayeeByLenderId_Request()
            {
                PayeeName = "string",
                PayeeAddress = "string"
            };
            string payload = JsonConvert.SerializeObject(upsert, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Arrange
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.LenderService.Domain.Entities.Lender with id '" + InvalidLenderId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void LenderService_LenderProductCheckRequestPayeeType_PostCheckRequestPayeeByNumericId_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/checkrequestpayee/" + NumericId);
            LenderProductCheckRequestPayeeType_PostCheckRequestPayeeByLenderId_Request upsert = new LenderProductCheckRequestPayeeType_PostCheckRequestPayeeByLenderId_Request()
            {
                PayeeName = "string",
                PayeeAddress = "string"
            };
            string payload = JsonConvert.SerializeObject(upsert, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Arrange
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<LenderProductCheckRequestPayeeType_GetCheckRequestPayeeByLenderNumericId_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Id, Is.EqualTo("3a0920b0-c4e4-4b4f-94f9-8b9e2b9db810"));
                Assert.That(responseContent.LenderId, Is.EqualTo(LenderServiceId));
            });
        }

        [Test]
        public void LenderService_LenderProductCheckRequestPayeeType_PostCheckRequestPayeeByNumericId_InvalidNumericId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/checkrequestpayee/" + InvalidNumericId);
            LenderProductCheckRequestPayeeType_PostCheckRequestPayeeByLenderId_Request upsert = new LenderProductCheckRequestPayeeType_PostCheckRequestPayeeByLenderId_Request()
            {
                PayeeName = "string",
                PayeeAddress = "string"
            };
            string payload = JsonConvert.SerializeObject(upsert, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_LenderService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Message NumericId: " + InvalidNumericId + " \n Entity type of Phoenix2.LenderService.Domain.Entities.Lender"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }


        [Test]
        public void LenderService_MeridianLinkType_LoanApplicationSubmit_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/meridian-link/loan-application/submit");
            string payload = helper.Serialize(new
            {
                DealId = 54793,
                RequestedById = 55810,
                Comment = "string"
            });
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public void LenderService_MeridianLinkType_LoanApplicationSubmit_NegativeScenario_InvalidDealId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/meridian-link/loan-application/submit");
            string payload = helper.Serialize(new
            {
                DealId = InvalidDealId,
                RequestedById = 55810,
                Comment = "string"
            });
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void LenderService_MeridianLinkType_DocumentsSubmit_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/meridian-link/documents/submit");
            MeridianLinkType_DocumentsSubmit_Request submitDocuments = new MeridianLinkType_DocumentsSubmit_Request()
            {
                DealId = "54793",
                DocumentIds = new List<int> { 0 }
            };
            string payload = JsonConvert.SerializeObject(submitDocuments, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }


        [Test]
        public void LenderService_MeridianLinkType_DocumentsSubmit_NegativeScenario_InvalidDealId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/meridian-link/documents/submit");
            MeridianLinkType_DocumentsSubmit_Request submitDocuments = new MeridianLinkType_DocumentsSubmit_Request()
            {
                DealId = InvalidDealId,
                DocumentIds = new List<int> { 0 }
            };
            string payload = JsonConvert.SerializeObject(submitDocuments, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void LenderService_WestlakeType_SubmitLoanApplicationSubmit_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("lender-service/westlake/loan-application/submit");
            WestlakeType_SubmitLoanApplicationSubmit_Request submitLoanApplication = new WestlakeType_SubmitLoanApplicationSubmit_Request()
            {
                DealId = 54793,
                RequestedById = 55810,
                Comment = "string"
            };
            string payload = JsonConvert.SerializeObject(submitLoanApplication, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }


    }
}
