using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Phoenix2.APITests.Credentials;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using System.Net;
using Phoenix2.APITests.Framework;
using Phoenix2.APITests.DTO.DealServiceDTO;

namespace Phoenix2.APITests.Tests
{
    class DealService
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
        public void DealService_DealType_PostDealsComment_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/" + DealServiceDealId + "/comments");
            DealType_PostDealsComment_Request dealsComment = new DealType_PostDealsComment_Request
            {
                Comment = "string",
                CommentActionType = 1,
                WorkflowStepId = "string",
                TextCommentColor = "string",
                IsTextBold = true
            };
            string payload = JsonConvert.SerializeObject(dealsComment, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DealType_PostDealsComment_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseContent.DealId, Is.EqualTo(DealServiceDealId));
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            });
        }
        [Test]
        public void DealService_DealType_GetDealsComment_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/" + DealServiceDealId + "/comments?Filter=1");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void DealService_DealType_GetDealsComment_NegativeScenario_InvalidDealId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/" + DealServiceInvalidDealId + "/comments?");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DealService_NegativeScenario_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseContent.Message, Is.EqualTo("Deal not found dealID " + DealServiceInvalidDealId));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            });
        }
        [Test]
        public void DealService_DealType_DealsCommentAll_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/" + DealServiceDealId + "/comments-all");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void DealService_DealType_GetDealsUsers_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/" + DealServiceDealId + "/users");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void DealService_DealType_PutDealsUsers_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/" + DealServiceDealId + "/users");
            DealType_PutDealsUsers_Request dealsUsers = new DealType_PutDealsUsers_Request();
            dealsUsers.DealUserAssignmentType = 1;
            DealUser_PutDealsUsers_Request dealUserDetail = new DealUser_PutDealsUsers_Request();
            dealUserDetail.UserId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            dealUserDetail.UserName = "string";
            dealUserDetail.DealUserType = 1;
            string payload = JsonConvert.SerializeObject(dealsUsers, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void DealService_DealType_GetDeals_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/" + DealServiceDealId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DealType_GetDeals_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Id, Is.EqualTo(DealServiceDealId));
                Assert.That(responseContent.LeadId, Is.EqualTo(DealServiceLeadId));
            });
        }
        [Test]
        public void DealService_DealType_GetDeals_NegativeScenario_InvalidDealId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/" + DealServiceInvalidDealId);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DealService_NegativeScenario_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseContent.Message, Is.EqualTo("Contact Deal not found for dealId " + DealServiceInvalidDealId));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            });
        }
        [Test]
        public void DealService_DealType_PutDeals_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/" + DealServiceDealId);
            DealType_PutDeals_Request deals = new DealType_PutDeals_Request();
            deals.DealId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            deals.LeadId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            deals.LenderCode = "string";
            deals.IsPicked = true;
            deals.IsDocsGenerated = true;
            deals.IsHotTitles = true;
            deals.IsBuyBack = true;
            deals.DownPaymentStatus = "string";
            deals.IsBlueAdvantage = true;
            deals.IsGenysisWithHoldings = true;
            FinanceConditionItem_DealType_PutDeals_Request financeConditionItem = new FinanceConditionItem_DealType_PutDeals_Request();
            deals.FinanceConditionItemResponse = financeConditionItem;
            financeConditionItem.Term = 0;
            financeConditionItem.Rate = 0;
            financeConditionItem.Apr = 0;
            financeConditionItem.SalesPrice = 0;
            financeConditionItem.DealTotal = 0;
            financeConditionItem.MonthlyPaymentAmount = 0;
            financeConditionItem.ContractDate = DateTime.Now;
            financeConditionItem.DaysToFirstPayment = 0;
            financeConditionItem.FirstPaymentDate = DateTime.Now;
            financeConditionItem.LastPaymentAmount = 0;
            financeConditionItem.LastPaymentDate = DateTime.Now;
            financeConditionItem.TotalTaxAmount = 0;
            financeConditionItem.TotalProductAmount = 0;
            financeConditionItem.TotalProductTaxAmount = 0;
            financeConditionItem.CashDownAmount = 0;
            financeConditionItem.CashBackAmount = 0;
            financeConditionItem.TotalSalesTaxPercentage = 0;
            financeConditionItem.EstimatedGrossTotalAmount = 0;
            DealFeeItem_DealType_PutDeals_Request dealFeeItem = new DealFeeItem_DealType_PutDeals_Request();
            dealFeeItem.Category = "string";
            dealFeeItem.Description = "string";
            dealFeeItem.Amount = 0;
            dealFeeItem.IsDocFee = true;
            dealFeeItem.IsAdditionalFee = true;
            financeConditionItem.RateMarkUpPercentage = 0;
            financeConditionItem.Interest = 0;
            financeConditionItem.SubTotal = 0;
            financeConditionItem.InterestPlusDocFee = 0;
            financeConditionItem.SubTotalLessDocFee = 0;
            deals.CarrierTrackingNumberIn = "string";
            deals.CarrierTrackingNumberOut = "string";
            deals.IsAch = true;
            List<DealFeeItem_DealType_PutDeals_Request> DealFeeItems = new List<DealFeeItem_DealType_PutDeals_Request> { dealFeeItem };
            financeConditionItem.DealFeeItems = DealFeeItems;
            string payload = JsonConvert.SerializeObject(deals, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Arrange
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void DealService_DealType_PostContactsLeadsDeals_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/contacts/" + DealServiceContactId + "/leads/" + DealServiceLeadId + "/deals");
            DealType_PostContactsLeadsDeals_Request contactsLeadsDeals = new DealType_PostContactsLeadsDeals_Request();
            contactsLeadsDeals.LenderCode = "string";
            contactsLeadsDeals.Rate = 0;
            contactsLeadsDeals.Term = 0;
            contactsLeadsDeals.LoanAmount = 0;
            contactsLeadsDeals.Type = 1;
            DealUser_PostContactsLeadsDeals_Request dealUsers = new DealUser_PostContactsLeadsDeals_Request();
            dealUsers.UserId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            dealUsers.UserName = "string";
            dealUsers.DealUserType = 1;
            contactsLeadsDeals.IsPreApproval = true;
            List<DealUser_PostContactsLeadsDeals_Request> DealUsers = new List<DealUser_PostContactsLeadsDeals_Request> { dealUsers };
            contactsLeadsDeals.DealUsers = DealUsers;
            string payload = JsonConvert.SerializeObject(contactsLeadsDeals, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void DealService_DealType_GetContactsLeadsDeals_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/contacts/" + DealServiceContactId + "/leads/" + DealServiceLeadId + "/deals");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void DealService_DealType_GetContactsLeadsDeals_NegativeScenario_InvalidLeadId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/contacts/" + DealServiceContactId + "/leads/" + DealServiceInvalidDealId + "/deals");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DealService_NegativeScenario_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseContent.Message, Is.EqualTo("Deals not found for lead " + DealServiceInvalidDealId));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            });
        }
        [Test]
        public void DealService_DealType_ContactsDeals_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/contacts/" + DealServiceContactId + "/deals");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void DealService_DealType_ContactsDeals_NegativeScenario_InvalidContactId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/contacts/" + DealServiceInvalidDealId + "/deals");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DealService_NegativeScenario_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Deals not found for contact " + DealServiceInvalidDealId));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void DealService_DealType_ContactsDealsSummary_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/contacts/" + DealServiceContactId + "/deals/summary");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void DealService_DealType_ContactsDealsSummary_NegativeScenario_InvalidContactId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/contacts/" + DealServiceInvalidDealId + "/deals/summary");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DealService_NegativeScenario_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Deals not found for contact " + DealServiceInvalidDealId));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void DealService_DealType_Deals_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals");
            List<object> deal = new() { DealServiceDealId };
            string payload = JsonConvert.SerializeObject(deal);
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json")
                .AddHeader("Authorization", "Bearer " + acessToken)
                .AddJsonBody(deal);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void DealService_DealType_DealsByNumericId_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals-by-numericid");
            List<object> numeric = new() { DealServiceNumericId };
            string payload = JsonConvert.SerializeObject(numeric);
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json")
                .AddHeader("Authorization", "Bearer " + acessToken)
                .AddJsonBody(numeric);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void DealService_DealType_AllDealsByContacts_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/all-deals-by-contacts");
            List<object> contact = new() { DealServiceContactId };
            string payload = JsonConvert.SerializeObject(contact);
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json")
                .AddHeader("Authorization", "Bearer " + acessToken)
                .AddJsonBody(contact);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void DealService_DealType_DealsLoanAplicationNumber_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/" + DealServiceDealId + "/loan-application-number");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DealType_DealsLoanAplicationNumber_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.DealId, Is.EqualTo(DealServiceDealId));
                Assert.That(responseContent.NumericId, Is.EqualTo(49546));
            });
        }
        [Test]
        public void DealService_DealType_DealsLoanAplicationNumber_NegativeScenario_InvalidDealId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/" + DealServiceInvalidDealId + "/loan-application-number");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DealService_NegativeScenario_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Message " + DealServiceInvalidDealId + " \n Entity type of Phoenix2.DealService.Domain.Entities.Deal"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void DealService_DealType_DealsLoanApplicationNumber_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/" + DealServiceDealId + "/loan-application-number");
            string ApplicationNumber = helper.GenerateDocName(5);
            DealType_DealsLoanApplicationNumber_Request dealsLoanApplicationNumber = new DealType_DealsLoanApplicationNumber_Request()
            {
                ApplicationNumber = ApplicationNumber
            };
            string payload = JsonConvert.SerializeObject(dealsLoanApplicationNumber, Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DealType_DealsLoanApplicationNumber_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.DealId, Is.EqualTo(DealServiceDealId));
                Assert.That(responseContent.LoanApplicationNumber, Is.EqualTo(ApplicationNumber));
            });
        }
        [Test]
        public void DealService_DealType_DealsLoanApplicationNumber_NegativeScenario_InvalidDealId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/" + DealServiceInvalidDealId + "/loan-application-number");
            DealType_DealsLoanApplicationNumber_Request dealsLoanApplicationNumber = new DealType_DealsLoanApplicationNumber_Request()
            {
                ApplicationNumber = "string"
            };
            string payload = JsonConvert.SerializeObject(dealsLoanApplicationNumber, Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DealService_NegativeScenario_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseContent.Message, Is.EqualTo("Message " + DealServiceInvalidDealId + " \n Entity type of Phoenix2.DealService.Domain.Entities.Deal"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            });
        }
        [Test]
        public void DealService_DealType_DealIdsByNumericId_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/dealIds-by-numericid");
            List<object> numeric = new() { DealServiceNumericId };
            string payload = JsonConvert.SerializeObject(numeric);
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json")
                .AddHeader("Authorization", "Bearer " + acessToken)
                .AddJsonBody(numeric);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void DealService_DealType_DealIdsByGuid_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/dealIds-by-guid");
            List<object> deal = new() { DealServiceDealId };
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json")
                .AddHeader("Authorization", "Bearer " + acessToken)
                .AddJsonBody(deal);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void DealService_DealType_DealsSalesprice_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/" + DealServiceDealId + "/salesprice");
            DealType_DealsSalesprice_Request dealsSalesprice = new DealType_DealsSalesprice_Request();
            dealsSalesprice.DealId = DealServiceDealId;
            dealsSalesprice.LeadId = DealServiceLeadId;
            dealsSalesprice.LenderCode = "string";
            dealsSalesprice.IsPicked = true;
            dealsSalesprice.IsDocsGenerated = true;
            dealsSalesprice.IsHotTitles = true;
            dealsSalesprice.IsBuyBack = true;
            dealsSalesprice.DownPaymentStatus = "string";
            dealsSalesprice.IsBlueAdvantage = true;
            dealsSalesprice.IsGenysisWithHoldings = true;
            FinanceConditionItemResponse_DealsSalesprice_Request financeConditionItem = new FinanceConditionItemResponse_DealsSalesprice_Request();
            dealsSalesprice.FinanceConditionItemResponse = financeConditionItem;
            financeConditionItem.Term = 0;
            financeConditionItem.Rate = 0;
            financeConditionItem.Apr = 0;
            financeConditionItem.SalesPrice = 0;
            financeConditionItem.DealTotal = 0;
            financeConditionItem.TotalAmountFinanced = 0;
            financeConditionItem.MonthlyPaymentAmount = 0;
            financeConditionItem.ContractDate = DateTime.Now;
            financeConditionItem.DaysToFirstPayment = 0;
            financeConditionItem.FirstPaymentDate = DateTime.Now;
            financeConditionItem.LastPaymentAmount = 0;
            financeConditionItem.LastPaymentDate = DateTime.Now;
            financeConditionItem.TotalTaxAmount = 0;
            financeConditionItem.TotalProductAmount = 0;
            financeConditionItem.TotalProductTaxAmount = 0;
            financeConditionItem.CashDownAmount = 0;
            financeConditionItem.CashBackAmount = 0;
            financeConditionItem.TotalSalesTaxPercentage = 0;
            financeConditionItem.EstimatedGrossTotalAmount = 0;
            DealFeeItem_DealsSalesprice_Request dealFeelItem = new DealFeeItem_DealsSalesprice_Request();
            dealFeelItem.Category = "string";
            dealFeelItem.Description = "string";
            dealFeelItem.Amount = 0;
            dealFeelItem.IsDocFee = true;
            dealFeelItem.IsAdditionalFee = true;
            financeConditionItem.RateMarkUpPercentage = 0;
            financeConditionItem.Interest = 0;
            financeConditionItem.SubTotal = 0;
            financeConditionItem.InterestPlusDocFee = 0;
            financeConditionItem.SubTotalLessDocFee = 0;
            dealsSalesprice.CarrierTrackingNumberIn = "string";
            dealsSalesprice.CarrierTrackingNumberOut = "string";
            dealsSalesprice.IsAch = true;
            List<DealFeeItem_DealsSalesprice_Request> DealFeelItem = new List<DealFeeItem_DealsSalesprice_Request> { dealFeelItem };
            financeConditionItem.DealFeeItems = DealFeelItem;
            string payload = JsonConvert.SerializeObject(dealsSalesprice, Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DealType_DealsSalesprice_Response>(response);
            /// Assert
            Console.WriteLine(payload);
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Id, Is.EqualTo(DealServiceDealId));
                Assert.That(responseContent.LeadId, Is.EqualTo(DealServiceLeadId));
            });
        }
        [Test]
        public void DealService_DealType_DealsSalesprice_NegativeScenario_DealId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/" + DealServiceInvalidDealId + "/salesprice");
            DealType_DealsSalesprice_Request dealsSalesprice = new DealType_DealsSalesprice_Request();
            dealsSalesprice.DealId = "3fa85f00-1111-2222-b3fc-2c000f66afa6";
            dealsSalesprice.LeadId = "3fa85f00-1111-2222-b3fc-2c000f66afa6";
            dealsSalesprice.LenderCode = "string";
            dealsSalesprice.IsPicked = true;
            dealsSalesprice.IsDocsGenerated = true;
            dealsSalesprice.IsHotTitles = true;
            dealsSalesprice.IsBuyBack = true;
            dealsSalesprice.DownPaymentStatus = "string";
            dealsSalesprice.IsBlueAdvantage = true;
            dealsSalesprice.IsGenysisWithHoldings = true;
            FinanceConditionItemResponse_DealsSalesprice_Request financeConditionItem = new FinanceConditionItemResponse_DealsSalesprice_Request();
            dealsSalesprice.FinanceConditionItemResponse = financeConditionItem;
            financeConditionItem.Term = 0;
            financeConditionItem.Rate = 0;
            financeConditionItem.Apr = 0;
            financeConditionItem.SalesPrice = 0;
            financeConditionItem.DealTotal = 0;
            financeConditionItem.TotalAmountFinanced = 0;
            financeConditionItem.MonthlyPaymentAmount = 0;
            financeConditionItem.ContractDate = DateTime.Now;
            financeConditionItem.DaysToFirstPayment = 0;
            financeConditionItem.FirstPaymentDate = DateTime.Now;
            financeConditionItem.LastPaymentAmount = 0;
            financeConditionItem.LastPaymentDate = DateTime.Now;
            financeConditionItem.TotalTaxAmount = 0;
            financeConditionItem.TotalProductAmount = 0;
            financeConditionItem.TotalProductTaxAmount = 0;
            financeConditionItem.CashDownAmount = 0;
            financeConditionItem.CashBackAmount = 0;
            financeConditionItem.TotalSalesTaxPercentage = 0;
            financeConditionItem.EstimatedGrossTotalAmount = 0;
            DealFeeItem_DealsSalesprice_Request dealFeelItem = new DealFeeItem_DealsSalesprice_Request();
            dealFeelItem.Category = "string";
            dealFeelItem.Description = "string";
            dealFeelItem.Amount = 0;
            dealFeelItem.IsDocFee = true;
            dealFeelItem.IsAdditionalFee = true;
            financeConditionItem.RateMarkUpPercentage = 0;
            financeConditionItem.Interest = 0;
            financeConditionItem.SubTotal = 0;
            financeConditionItem.InterestPlusDocFee = 0;
            financeConditionItem.SubTotalLessDocFee = 0;
            dealsSalesprice.CarrierTrackingNumberIn = "string";
            dealsSalesprice.CarrierTrackingNumberOut = "string";
            dealsSalesprice.IsAch = true;
            List<DealFeeItem_DealsSalesprice_Request> DealFeelItem = new List<DealFeeItem_DealsSalesprice_Request> { dealFeelItem };
            financeConditionItem.DealFeeItems = DealFeelItem;
            string payload = JsonConvert.SerializeObject(dealsSalesprice, Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DealService_NegativeScenario_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Contact Deal not found for dealId " + DealServiceInvalidDealId));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void DealService_DealType_DealsCalculate_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/" + DealServiceDealId + "/calculate");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void DealService_DealType_DealsCopy_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/" + DealServiceDealId + "/copy");
            RestRequest request = helper.CreatePostRequestWithoutBody(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void DealService_DealShipmentBatchType_GetDealsShipment_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/shipments?PageNumber=1&PageSize=1");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void DealService_DealShipmentBatchType_PostDealsShipment_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/shipments");
            DealShipmentBatchType_PostDealsShipment_Request dealsShipment = new DealShipmentBatchType_PostDealsShipment_Request()
            {
                DealId = DealServiceDealId,
                CheckPayeeName = "string"
            };
            string payload = JsonConvert.SerializeObject(dealsShipment, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void DealService_DealShipmentBatchType_DeleteDealsShipment_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/shipments");
            List<object> dealShipments = new() { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            RestRequest request = new RestRequest(Method.DELETE);
            request.AddHeader("Accept", "application/json")
                .AddHeader("Authorization", "Bearer " + acessToken)
                .AddJsonBody(dealShipments);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void DealService_DealShipmentBatchType_PatchDealsShipment_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/shipments?dealShipmentBatchType=1");
            List<object> dealShipments = new() { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            RestRequest request = new RestRequest(Method.PATCH);
            request.AddHeader("Accept", "application/json")
                .AddHeader("Authorization", "Bearer " + acessToken)
                .AddJsonBody(dealShipments);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void DealService_DealShipmentBatchType_DealsShipmentsInclude_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/" + DealServiceDealId + "/shipments/include");
            RestRequest request = helper.CreatePutRequestWithoutBody(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void DealService_DealShipmentBatchType_DealsShipmentsExclude_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/" + DealServiceDealId + "/shipments/exclude");
            RestRequest request = helper.CreatePutRequestWithoutBody(acessToken);
            /// Arrange
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void DealService_FundedShipmentType_GetDealsFundedShipments_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/funded/shipments?PageNumber=1&PageSize=2");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void DealService_FundedShipmentType_PostDealsFundedShipments_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/funded/shipments");
            List<object> fundedShipments = new() { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            RestRequest request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json")
                .AddHeader("Authorization", "Bearer " + acessToken)
                .AddJsonBody(fundedShipments);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void DealService_FundedShipmentType_DeleteDealsFundedShipments_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/funded/shipments");
            List<object> fundedShipments = new() { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            RestRequest request = new RestRequest(Method.DELETE);
            request.AddHeader("Accept", "application/json")
                .AddHeader("Authorization", "Bearer " + acessToken)
                .AddJsonBody(fundedShipments);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void DealService_FundedShipmentType_PatchDealsFundedShipments_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("deal-service/deals/funded/shipments?dealShipmentBatchType=1");
            List<object> fundedShipments = new() { "3fa85f64-5717-4562-b3fc-2c963f66afa6" };
            RestRequest request = new RestRequest(Method.PATCH);
            request.AddHeader("Accept", "application/json")
                .AddHeader("Authorization", "Bearer " + acessToken)
                .AddJsonBody(fundedShipments);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
    }
}
