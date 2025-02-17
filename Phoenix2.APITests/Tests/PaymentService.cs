using Newtonsoft.Json;
using NUnit.Framework;
using Phoenix2.APITests.DTO.PaymentServiceDTO;
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
    class PaymentService
    {
        private APIHelper<string> helper;
        [SetUp]
        public void APIHelper()
        {
            helper = new APIHelper<string>();
        }
        [Test]
        public void PaymentService_CreditCardType_CreditCards_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("payment-service/creditcards?ContactId=" + contactIdPayment + "&CreditCardType=Visa&HolderName=" + HolderName + "&CreditCardNumber=" + CreditCardNumber + "&ExpiryDate=" + ExpiryDate + "&Cvv=" + Cvv + "&Amount=" + Amount + "&ProcessingDate=2025-07-26T07%3A31%3A51.385Z&Notes=" + Notes + "&DealId=" + DealIdPayment);
            RestRequest request = helper.CreatePostRequestWithoutBody();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<CreditCardType_CreditCards_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.ContactId, Is.EqualTo(contactIdPayment));
                Assert.That(responseContent.CreditCardType, Is.EqualTo("Visa"));
                Assert.That(responseContent.HolderName, Is.EqualTo(HolderName));
                Assert.That(responseContent.Cvv, Is.EqualTo(Cvv));
            });
        }

        [Test]
        [TestCase(CreditCardNumber, Cvv, InvalidAmount)]
        [TestCase(CreditCardNumber, InvalidCvv, Amount)]
        [TestCase(InvalidCreditCardNumber, Cvv, Amount)]
        [TestCase(InvalidCreditCardNumber, InvalidCvv, InvalidAmount)]
        public void PaymentService_CreditCardType_CreditCards_NegativeScenario(string CreditCardNumber, string Cvv, string Amount)
        {
            /// Arrange
            RestClient client = helper.SetUrl("payment-service/creditcards?ContactId=" + contactIdPayment + "&CreditCardType=Visa&HolderName=" + HolderName + "&CreditCardNumber=" + CreditCardNumber + "&ExpiryDate=" + ExpiryDate + "&Cvv=" + Cvv + "&Amount=" + Amount + "&ProcessingDate=2025-07-26T07%3A31%3A51.385Z&Notes=" + Notes + "&DealId=" + DealIdPayment);
            RestRequest request = helper.CreatePostRequestWithoutBody();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Status_PaymentService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Title, Is.EqualTo("One or more validation errors occurred."));
                Assert.That(responseContent.Status, Is.EqualTo(400));
            });
        }

        [Test]
        public void PaymentService_CreditCardType_DownpaymentCards_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("payment-service/downpayment/" + DownPaymentId + "/cards?dealId=" + DealIdPayment + "&contactId=" + contactIdPayment);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<CreditCardType_DownpaymentCards_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.ContactCreditCardId, Is.EqualTo(ContactCreditCardId));
                Assert.That(responseContent.IsActive, Is.EqualTo(true));
            });
        }
        [Test]
        [TestCase(DownPaymentId, InvalidDealIdPayment, contactIdPayment)]
        [TestCase(DownPaymentId, DealIdPayment, InvalidContactlIdPayment)]
        [TestCase(InvalidDownPaymentId, DealIdPayment, contactIdPayment)]
        [TestCase(InvalidDownPaymentId, InvalidDealIdPayment, InvalidContactlIdPayment)]
        public void PaymentService_CreditCardType_DownpaymentCards_NegativeScenario(string DownPaymentId, string DealId, string ContactId)
        {
            /// Arrange
            RestClient client = helper.SetUrl("payment-service/downpayment/" + DownPaymentId + "/cards?dealId=" + DealId + "&contactId=" + ContactId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Code_PaymentService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void PaymentService_CreditCardType_DealCards_PositiveScenario()
        {            
            /// Arrange
            RestClient client = helper.SetUrl("payment-service/deal/" + DealIdPayment + "/cards?contactId=" + contactIdPayment + "&cashDown=" + CashDown);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<CreditCardType_DealCards_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.DealId, Is.EqualTo(DealIdPayment));
                Assert.That(responseContent.ContactId, Is.EqualTo(contactIdPayment));
            });
        }

        [Test]
        public void PaymentService_CreditCardType_DealCards_NegativeScenario_InvalidDealId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("payment-service/deal/" + InvalidDealIdPayment + "/cards?contactId=" + contactIdPayment + "&cashDown=" + CashDown);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Code_PaymentService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("No record found for deal " + InvalidDealIdPayment + "."));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void PaymentService_CreditCardType_Creditcards_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("payment-service/creditcards?ContactId=" + contactIdPayment + "&CreditCardType=Visa&HolderName=" + HolderName + "&CreditCardNumber=" + CreditCardNumber + "&ExpiryDate=" + ExpiryDate + "&Cvv=" + Cvv + "&Amount=" + Amount + "&ProcessingDate=2025-07-26T07%3A31%3A51.385Z&Notes=" + Notes + "&DealId=" + DealIdPayment);
            RestRequest request = helper.CreatePostRequestWithoutBody();
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<CreditCardType_CreditCards_Response>(response);
            string Id = responseContent.Id;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient clientGet = helper.SetUrlDev("payment-service/creditcards/" + Id + "?contactId=" + contactIdPayment);
            RestRequest requestGet = helper.CreateGetRequest();
            /// Act
            IRestResponse responseGet = helper.GetResponse(clientGet, requestGet);
            var responseContentGet = helper.GetContent<CreditCardType_Creditcards_Responses>(responseGet);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseGet.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContentGet.Id, Is.EqualTo(Id));
                Assert.That(responseContentGet.ContactId, Is.EqualTo(contactIdPayment));
                Assert.That(responseContentGet.Cvv, Is.EqualTo(Cvv));
            });
        }

        [Test]
        [TestCase(InvalidIdPayment, contactIdPayment)]
        [TestCase(InvalidIdPayment, InvalidContactlIdPayment)]
        public void PaymentService_CreditCardType_Creditcards_NegativeScenario(string Id, string ContactId)
        {
            /// Arrange
            RestClient client = helper.SetUrl("payment-service/creditcards/" + Id + "?contactId=" + ContactId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Code_PaymentService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            });
        }

        [Test]
        public void PaymentService_DownPaymentType_PostDownpayments_PositiveScenario()
        {
            /// Arrange
            RestClient clientPost = helper.SetUrl("payment-service/downpayments");
            DownPaymentType_PostDownpayments_Request downpayments = new DownPaymentType_PostDownpayments_Request()
            {
                DealId = DealIdPayment,
                ContactCreditCardId = ContactCreditCardId,
                Amount = 100,
                ProcessingDate = DateTime.Now,
                ProcessedDate = DateTime.Now,
                ProcessedAmount = 0,
                Notes = "string",
                IsCurrent = true,
                IsProcessed = true,
                TransactionType = "string",
                TransactionStatus = "string",
                TransactionId = "string",
                TransactionTag = "string",
                ValidationStatus = "string",
                BankRespCode = "string",
                BankMessage = "string",
                GatewayRespCode = "string",
                GatewayMessage = "string",
                CorrelationID = "string",
                AvsCode = "string",
                CvvCode = "string",
                Errors = "string",
                PaymentType = "DownPayment",
                IsSyncedToAcumatica = 0,
                ContactId = contactIdPayment
            };
            string payload = JsonConvert.SerializeObject(downpayments, Formatting.Indented);
            RestRequest requestPost = helper.CreatePostRequest(payload);
            /// Act
            IRestResponse responsePost = helper.GetResponse(clientPost, requestPost);
            var responseContenPost = helper.GetContent<DownPaymentType_PostDownpayments_Response>(responsePost);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responsePost.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContenPost.DealId, Is.EqualTo(DealIdPayment));
                Assert.That(responseContenPost.ContactCreditCardId, Is.EqualTo(ContactCreditCardId));
            });
        }

        [Test]
        public void PaymentService_DownPaymentType_PostDownpayments_InvalidContactCreditCardId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("payment-service/downpayments");
            DownPaymentType_PostDownpayments_Request downpayments = new DownPaymentType_PostDownpayments_Request()
            {
                DealId = "string",
                ContactCreditCardId = "121",
                Amount = 0,
                ProcessingDate = DateTime.Now,
                ProcessedDate = DateTime.Now,
                ProcessedAmount = 0,
                Notes = "string",
                IsCurrent = true,
                IsProcessed = true,
                TransactionType = "string",
                TransactionStatus = "string",
                TransactionId = "string",
                TransactionTag = "string",
                ValidationStatus = "string",
                BankRespCode = "string",
                BankMessage = "string",
                GatewayRespCode = "string",
                GatewayMessage = "string",
                CorrelationID = "string",
                AvsCode = "string",
                CvvCode = "string",
                Errors = "string",
                PaymentType = "DownPayment",
                IsSyncedToAcumatica = 0,
                ContactId = contactIdPayment
            };
            string payload = JsonConvert.SerializeObject(downpayments, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Status_PaymentService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Title, Is.EqualTo("One or more validation errors occurred."));
                Assert.That(responseContent.Status, Is.EqualTo(400));
            });
        }

        [Test]
        public void PaymentService_DownPaymentType_GetDownpayments_PositiveScenario()
        {
            /// Arrange
            RestClient clientPost = helper.SetUrl("payment-service/downpayments");
            DownPaymentType_PostDownpayments_Request downpayments = new DownPaymentType_PostDownpayments_Request()
            {
                DealId = DealIdPayment,
                ContactCreditCardId = ContactCreditCardId,
                Amount = 100,
                ProcessingDate = DateTime.Now,
                ProcessedDate = DateTime.Now,
                ProcessedAmount = 0,
                Notes = "string",
                IsCurrent = true,
                IsProcessed = true,
                TransactionType = "string",
                TransactionStatus = "string",
                TransactionId = "string",
                TransactionTag = "string",
                ValidationStatus = "string",
                BankRespCode = "string",
                BankMessage = "string",
                GatewayRespCode = "string",
                GatewayMessage = "string",
                CorrelationID = "string",
                AvsCode = "string",
                CvvCode = "string",
                Errors = "string",
                PaymentType = "DownPayment",
                IsSyncedToAcumatica = 0,
                ContactId = contactIdPayment
            };
            string payload = JsonConvert.SerializeObject(downpayments, Formatting.Indented);
            RestRequest requestPost = helper.CreatePostRequest(payload);
            IRestResponse responsePost = helper.GetResponse(clientPost, requestPost);
            var responseContenPost = helper.GetContent<DownPaymentType_PostDownpayments_Response>(responsePost);
            string Id = responseContenPost.Id;
            Assert.That(responsePost.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient client = helper.SetUrl("payment-service/downpayments/" + Id + "?dealId=" + DealIdPayment);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DownPaymentType_GetDownpayments_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Id, Is.EqualTo(Id));
                Assert.That(responseContent.DealId, Is.EqualTo(DealIdPayment));
                Assert.That(responseContent.ContactCreditCardId, Is.EqualTo(ContactCreditCardId));
            });
        }

        [Test]
        [TestCase(InvalidIdPayment, DealIdPayment)]
        [TestCase(InvalidIdPayment, InvalidDealIdPayment)]
        public void PaymentService_DownPaymentType_GetDownpayments_NegativeScenario(string Id, string DealId)
        {
            /// Arrange
            RestClient client = helper.SetUrl("payment-service/downpayments/" + Id + "?dealId=" + DealId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Code_PaymentService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void PaymentService_DownPaymentType_DeleteDownpayments_PositiveScenario()
        {
            /// Arrange
            RestClient clientPost = helper.SetUrl("payment-service/downpayments");
            DownPaymentType_PostDownpayments_Request downpayments = new DownPaymentType_PostDownpayments_Request()
            {
                DealId = DealIdPayment,
                ContactCreditCardId = ContactCreditCardId,
                Amount = 100,
                ProcessingDate = DateTime.Now,
                ProcessedDate = DateTime.Now,
                ProcessedAmount = 0,
                Notes = "string",
                IsCurrent = true,
                IsProcessed = true,
                TransactionType = "string",
                TransactionStatus = "string",
                TransactionId = "string",
                TransactionTag = "string",
                ValidationStatus = "string",
                BankRespCode = "string",
                BankMessage = "string",
                GatewayRespCode = "string",
                GatewayMessage = "string",
                CorrelationID = "string",
                AvsCode = "string",
                CvvCode = "string",
                Errors = "string",
                PaymentType = "DownPayment",
                IsSyncedToAcumatica = 0,
                ContactId = contactIdPayment
            };
            string payload = JsonConvert.SerializeObject(downpayments, Formatting.Indented);
            RestRequest requestPost = helper.CreatePostRequest(payload);
            IRestResponse responsePost = helper.GetResponse(clientPost, requestPost);
            var responseContenPost = helper.GetContent<DownPaymentType_PostDownpayments_Response>(responsePost);
            string Id = responseContenPost.Id;
            Assert.That(responsePost.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient client = helper.SetUrl("payment-service/downpayments/" + Id + "?dealId=" + DealIdPayment);
            RestRequest request = helper.CreateDeleteRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        [TestCase(InvalidDownPaymentId, DealIdPayment)]
        [TestCase(InvalidDownPaymentId, InvalidDealIdPayment)]
        public void PaymentService_DownPaymentTYpe_DeleteDownpayments_NegativeScenario(string Id, string DealId)
        {
            /// Arrange
            RestClient client = helper.SetUrl("payment-service/downpayments/" + Id + "?dealId=" + DealId);
            RestRequest request = helper.CreateDeleteRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Code_PaymentService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void PaymentService_DownPaymentType_PutDownpayments_PositiveScenario()
        {
            /// Arrange
            RestClient clientPost = helper.SetUrl("payment-service/downpayments");
            DownPaymentType_PostDownpayments_Request downpayments = new DownPaymentType_PostDownpayments_Request()
            {
                DealId = DealIdPayment,
                ContactCreditCardId = ContactCreditCardId,
                Amount = 100,
                ProcessingDate = DateTime.Now,
                ProcessedDate = DateTime.Now,
                ProcessedAmount = 0,
                Notes = "string",
                IsCurrent = true,
                IsProcessed = true,
                TransactionType = "string",
                TransactionStatus = "string",
                TransactionId = "string",
                TransactionTag = "string",
                ValidationStatus = "string",
                BankRespCode = "string",
                BankMessage = "string",
                GatewayRespCode = "string",
                GatewayMessage = "string",
                CorrelationID = "string",
                AvsCode = "string",
                CvvCode = "string",
                Errors = "string",
                PaymentType = "DownPayment",
                IsSyncedToAcumatica = 0,
                ContactId = contactIdPayment
            };
            string payload = JsonConvert.SerializeObject(downpayments, Formatting.Indented);
            RestRequest requestPost = helper.CreatePostRequest(payload);
            IRestResponse responsePost = helper.GetResponse(clientPost, requestPost);
            var responseContenPost = helper.GetContent<DownPaymentType_PostDownpayments_Response>(responsePost);
            string Id = responseContenPost.Id;
            Assert.That(responsePost.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient client = helper.SetUrl("payment-service/downpayments/" + Id);
            DownPaymentType_PostDownpayments_Request updateDownpayments = new DownPaymentType_PostDownpayments_Request()
            {
                DealId = DealIdPayment,
                ContactCreditCardId = ContactCreditCardId,
                Amount = 110,
                ProcessingDate = DateTime.Now,
                ProcessedDate = DateTime.Now,
                ProcessedAmount = 0,
                Notes = "string",
                IsCurrent = true,
                IsProcessed = true,
                TransactionType = "string",
                TransactionStatus = "string",
                TransactionId = "string",
                TransactionTag = "string",
                ValidationStatus = "string",
                BankRespCode = "string",
                BankMessage = "string",
                GatewayRespCode = "string",
                GatewayMessage = "string",
                CorrelationID = "string",
                AvsCode = "string",
                CvvCode = "string",
                Errors = "string",
                PaymentType = "DownPayment",
                IsSyncedToAcumatica = 0,
                ContactId = contactIdPayment
            };
            string payloadPut = JsonConvert.SerializeObject(updateDownpayments, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payloadPut);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DownPaymentType_PutDownpayments_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Id, Is.EqualTo(Id));
                Assert.That(responseContent.DealId, Is.EqualTo(DealIdPayment));
                Assert.That(responseContent.ContactCreditCardId, Is.EqualTo(ContactCreditCardId));
                Assert.That(responseContent.Amount, Is.EqualTo(110));
            });
        }

        [Test]
        public void PaymentService_DownPaymentType_PutDownpayments_NegativeScenario_InvalidRequestBody()
        {
            /// Arrange
            RestClient clientPost = helper.SetUrl("payment-service/downpayments");
            DownPaymentType_PostDownpayments_Request downpayments = new DownPaymentType_PostDownpayments_Request()
            {
                DealId = DealIdPayment,
                ContactCreditCardId = ContactCreditCardId,
                Amount = 100,
                ProcessingDate = DateTime.Now,
                ProcessedDate = DateTime.Now,
                ProcessedAmount = 0,
                Notes = "string",
                IsCurrent = true,
                IsProcessed = true,
                TransactionType = "string",
                TransactionStatus = "string",
                TransactionId = "string",
                TransactionTag = "string",
                ValidationStatus = "string",
                BankRespCode = "string",
                BankMessage = "string",
                GatewayRespCode = "string",
                GatewayMessage = "string",
                CorrelationID = "string",
                AvsCode = "string",
                CvvCode = "string",
                Errors = "string",
                PaymentType = "DownPayment",
                IsSyncedToAcumatica = 0,
                ContactId = contactIdPayment
            };
            string payload = JsonConvert.SerializeObject(downpayments, Formatting.Indented);
            RestRequest requestPost = helper.CreatePostRequest(payload);
            IRestResponse responsePost = helper.GetResponse(clientPost, requestPost);
            var responseContenPost = helper.GetContent<DownPaymentType_PostDownpayments_Response>(responsePost);
            string Id = responseContenPost.Id;
            Assert.That(responsePost.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient client = helper.SetUrl("payment-service/downpayments/" + Id);
            DownPaymentType_PostDownpayments_Request updateDownpayments = new DownPaymentType_PostDownpayments_Request()
            {
                DealId = DealIdPayment,
                ContactCreditCardId = ContactCreditCardId,
                Amount = 0,
                ProcessingDate = DateTime.Now,
                ProcessedDate = DateTime.Now,
                ProcessedAmount = 0,
                Notes = "string",
                IsCurrent = true,
                IsProcessed = true,
                TransactionType = "string",
                TransactionStatus = "string",
                TransactionId = "string",
                TransactionTag = "string",
                ValidationStatus = "string",
                BankRespCode = "string",
                BankMessage = "string",
                GatewayRespCode = "string",
                GatewayMessage = "string",
                CorrelationID = "string",
                AvsCode = "string",
                CvvCode = "string",
                Errors = "string",
                PaymentType = "DownPayment",
                IsSyncedToAcumatica = 0,
                ContactId = contactIdPayment
            };
            string payloadPut = JsonConvert.SerializeObject(updateDownpayments, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payloadPut);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Status_PaymentService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Title, Is.EqualTo("One or more validation errors occurred."));
                Assert.That(responseContent.Status, Is.EqualTo(400));
            });
        }

        [Test]
        public void PaymentService_DownPaymentType_PutDownpayments_NegativeScenario_InvalidId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("payment-service/downpayments/" + InvalidIdPayment);
            DownPaymentType_PostDownpayments_Request updateDownpayments = new DownPaymentType_PostDownpayments_Request()
            {
                DealId = DealIdPayment,
                ContactCreditCardId = ContactCreditCardId,
                Amount = 120,
                ProcessingDate = DateTime.Now,
                ProcessedDate = DateTime.Now,
                ProcessedAmount = 0,
                Notes = "string",
                IsCurrent = true,
                IsProcessed = true,
                TransactionType = "string",
                TransactionStatus = "string",
                TransactionId = "string",
                TransactionTag = "string",
                ValidationStatus = "string",
                BankRespCode = "string",
                BankMessage = "string",
                GatewayRespCode = "string",
                GatewayMessage = "string",
                CorrelationID = "string",
                AvsCode = "string",
                CvvCode = "string",
                Errors = "string",
                PaymentType = "DownPayment",
                IsSyncedToAcumatica = 0,
                ContactId = contactIdPayment
            };
            string payload = JsonConvert.SerializeObject(updateDownpayments, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Code_PaymentService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.PaymentService.Domain.Entities.DownPayment with id '" + InvalidIdPayment + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void PaymentService_PaymentType_PaymentProcess_PositiveScenario()
        {
            /// Arrange
            RestClient clientPost = helper.SetUrl("payment-service/downpayments");
            DownPaymentType_PostDownpayments_Request downpayments = new DownPaymentType_PostDownpayments_Request()
            {
                DealId = DealIdPayment,
                ContactCreditCardId = ContactCreditCardId,
                Amount = 100,
                ProcessingDate = DateTime.Now,
                ProcessedDate = DateTime.Now,
                ProcessedAmount = 0,
                Notes = "string",
                IsCurrent = true,
                IsProcessed = true,
                TransactionType = "string",
                TransactionStatus = "string",
                TransactionId = "string",
                TransactionTag = "string",
                ValidationStatus = "string",
                BankRespCode = "string",
                BankMessage = "string",
                GatewayRespCode = "string",
                GatewayMessage = "string",
                CorrelationID = "string",
                AvsCode = "string",
                CvvCode = "string",
                Errors = "string",
                PaymentType = "DownPayment",
                IsSyncedToAcumatica = 0,
                ContactId = contactIdPayment
            };
            string payload = JsonConvert.SerializeObject(downpayments, Formatting.Indented);
            RestRequest requestPost = helper.CreatePostRequest(payload);
            IRestResponse responsePost = helper.GetResponse(clientPost, requestPost);
            var responseContenPost = helper.GetContent<DownPaymentType_PostDownpayments_Response>(responsePost);
            string Id = responseContenPost.Id;
            Assert.That(responsePost.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient client = helper.SetUrl("payment-service/payments/process?DownPaymentId=" + Id + "&PaymentType=DownPayment&DealId=" + DealIdPayment + "&ContactId=" + contactIdPayment);
            RestRequest request = helper.CreatePostRequestWithoutBody();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<PaymentType_PaymentProcess_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.PaymentProcessStatus, Is.EqualTo("approved"));
            });
        }

        [Test]
        public void PaymentService_PaymentType_PaymentProcess_NegativeScenario_InvalidDownPaymentId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("payment-service/payments/process?DownPaymentId=" + InvalidDownPaymentId + "&PaymentType=DownPayment&DealId=" + DealIdPayment + "&ContactId=" + contactIdPayment);
            RestRequest request = helper.CreatePostRequestWithoutBody();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Code_PaymentService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Payment Process Status: declined,Error: no deal downpayment record found cannot process."));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void PaymentService_PaymentType_ValidateAmount_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("payment-service/payments/validateamount?Amount=100&DealId=" + DealIdPayment + "&DownPaymentId=" + DownPaymentId + "&DownPaymentOnDeal=" + DownPaymentOnDeal + "&PaymentType=DownPayment");
            RestRequest request = helper.CreatePostRequestWithoutBody();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<PaymentType_ValidateAmount_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.IsValid, Is.EqualTo(false));
            });
        }

        [Test]
        public void PaymentService_PaymentType_ValidateAmount_NegativeScenario_InvalidDealId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("payment-service/payments/validateamount?Amount=1&DealId=" + InvalidDealIdPayment + "&DownPaymentId=" + DownPaymentId + "&DownPaymentOnDeal=" + DownPaymentOnDeal + "&PaymentType=DownPayment");
            RestRequest request = helper.CreatePostRequestWithoutBody();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Code_PaymentService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("No record found for deal " + InvalidDealIdPayment));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void PaymentService_PaymentType_CancelPayment_PositiveScenario()
        {
            /// Arrange
            RestClient clientPost = helper.SetUrl("payment-service/downpayments");
            DownPaymentType_PostDownpayments_Request downpayments = new DownPaymentType_PostDownpayments_Request()
            {
                DealId = DealIdPayment,
                ContactCreditCardId = ContactCreditCardId,
                Amount = 100,
                ProcessingDate = DateTime.Now,
                ProcessedDate = DateTime.Now,
                ProcessedAmount = 0,
                Notes = "string",
                IsCurrent = true,
                IsProcessed = true,
                TransactionType = "string",
                TransactionStatus = "string",
                TransactionId = "string",
                TransactionTag = "string",
                ValidationStatus = "string",
                BankRespCode = "string",
                BankMessage = "string",
                GatewayRespCode = "string",
                GatewayMessage = "string",
                CorrelationID = "string",
                AvsCode = "string",
                CvvCode = "string",
                Errors = "string",
                PaymentType = "DownPayment",
                IsSyncedToAcumatica = 0,
                ContactId = contactIdPayment
            };
            string payload = JsonConvert.SerializeObject(downpayments, Formatting.Indented);
            RestRequest requestPost = helper.CreatePostRequest(payload);
            IRestResponse responsePost = helper.GetResponse(clientPost, requestPost);
            var responseContenPost = helper.GetContent<DownPaymentType_PostDownpayments_Response>(responsePost);
            string Id = responseContenPost.Id;
            Assert.That(responsePost.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient client = helper.SetUrl("payment-service/payments/cancelpayment?DownPaymentId=" + Id + "&DealId=" + DealIdPayment + "&ContactId=" + contactIdPayment);
            RestRequest request = helper.CreatePostRequestWithoutBody();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<PaymentType_CancelPayment_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.DealDownPaymentId, Is.EqualTo(Id));
            });
        }

        [Test]
        [TestCase(InvalidDownPaymentId, DealIdPayment, contactIdPayment)]
        [TestCase(InvalidDownPaymentId, InvalidDealIdPayment, InvalidContactlIdPayment)]
        public void PaymentService_PaymentType_CancelPayment_NegativeScenario(string DownPaymentId, string DealId, string ContactId)
        {
            /// Arrange
            RestClient client = helper.SetUrl("payment-service/payments/cancelpayment?DownPaymentId=" + DownPaymentId + "&DealId=" + DealId + "&ContactId=" + ContactId);
            RestRequest request = helper.CreatePostRequestWithoutBody();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Code_PaymentService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.PaymentService.Domain.Entities.DownPayment with id '" + InvalidDownPaymentId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
    }
}
