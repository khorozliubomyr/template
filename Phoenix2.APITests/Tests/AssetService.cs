using Newtonsoft.Json;
using NUnit.Framework;
using Phoenix2.APITests.DTO.AssetServiceDTO;
using Phoenix2.APITests.DTO.UserServiceDTO;
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
    class AssetService
    {
        private APIHelper<string> helper;
        [SetUp]
        public void APIHelper()
        {
            helper = new APIHelper<string>();
        }
        [Test]
        public void AssetService_AssetType_PostAsset_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/asset");
            AssetType_PostAsset_Request createAsset = new AssetType_PostAsset_Request();
            createAsset.AssetType = "1";
            createAsset.Vin = "WAUYGAFC6CN174200";
            createAsset.Year = 2012;
            createAsset.Make = "Audi";
            createAsset.Model = "A7";
            createAsset.NadaTrim = "N102";
            createAsset.KbbTrim = "k103";
            createAsset.BodyStyle = "B1";
            createAsset.Mileage = "12";
            createAsset.AssetCondition = "1";
            createAsset.Color = "Green";
            createAsset.AssetUsage = "";
            AssetLienHolder_PostAsset_Request assetLienHolder = new AssetLienHolder_PostAsset_Request();
            createAsset.AssetLienHolder = assetLienHolder;
            assetLienHolder.Name = "LeanName";
            assetLienHolder.LienHolderId = "";
            assetLienHolder.RemainingLoanAmount = 100;
            assetLienHolder.RemainingTerm = 4;
            assetLienHolder.GoodDate = DateTime.Now;
            Loan_PostAsset_Request loan = new Loan_PostAsset_Request();
            assetLienHolder.Loan = loan;
            loan.LoanAmount = 80;
            loan.Term = 3;
            loan.Rate = 5;
            loan.MonthlyPayment = 20;
            loan.NextPaymentDate = DateTime.Now;
            AddressCreate_PostAsset_Request addressCreate = new AddressCreate_PostAsset_Request();
            assetLienHolder.Address = addressCreate;
            addressCreate.StreetLine1 = "";
            addressCreate.StreetLine2 = "";
            addressCreate.City = "";
            addressCreate.State = 0;
            addressCreate.Zip = "";
            CurrentProduct_PostAsset_Request currentProduct = new CurrentProduct_PostAsset_Request();
            currentProduct.RefundAmount = 30;
            currentProduct.ProductType = "1";
            assetLienHolder.AccountNumber = "123456789";
            assetLienHolder.PhoneNumber = "1212121212";
            AssetRegistration_PostAsset_Request assetRegistration = new AssetRegistration_PostAsset_Request();
            createAsset.AssetRegistration = assetRegistration;
            assetRegistration.PrimaryOwner = "p1";
            assetRegistration.SecondaryOwner = "p2";
            assetRegistration.Number = "3333333333";
            assetRegistration.State = "";
            assetRegistration.ExpirationDate = DateTime.Now;
            AssetInsurance_PostAsset_Request assetInsurance = new AssetInsurance_PostAsset_Request();
            createAsset.AssetInsurance = assetInsurance;
            assetInsurance.Company = "Inc Comp";
            assetInsurance.PhoneNumber = "4444444444";
            assetInsurance.PolicyNumber = "pol1234";
            assetInsurance.EffectiveDate = DateTime.Now;
            assetInsurance.ExpirationDate = DateTime.Now;
            createAsset.SelectedNadaValue = 0;
            createAsset.SelectedStickerType = "srting";
            createAsset.ActualNadaTradeIn = 0;
            createAsset.SelectedKbbValue = 0;
            createAsset.Msrp = 0;
            createAsset.SelectedTradeInValue = 0;
            createAsset.BookOutDate = DateTime.Now;
            createAsset.ContactId = AssetContactId;
            List<CurrentProduct_PostAsset_Request> currentProducts = new List<CurrentProduct_PostAsset_Request> { currentProduct };
            assetLienHolder.CurrentProducts = currentProducts;
            string payload = JsonConvert.SerializeObject(createAsset, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<AssetType_PostAsset_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseContent.AssetType, Is.EqualTo("Car"));
                Assert.That(responseContent.Year, Is.EqualTo(2012));
                Assert.That(responseContent.ContactId, Is.EqualTo(AssetContactId));
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            });
        }

        [Test]
        public void AssetService_AssetType_PostAsset_NegativeScenario_InvalidRequestBody()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/asset");
            AssetType_PostAsset_Request createAsset = new AssetType_PostAsset_Request();
            createAsset.AssetType = "string";
            createAsset.Vin = "string";
            createAsset.Year = 0;
            createAsset.Make = "string";
            createAsset.Model = "string";
            createAsset.NadaTrim = "string";
            createAsset.KbbTrim = "string";
            createAsset.BodyStyle = "string";
            createAsset.Mileage = "string";
            createAsset.AssetCondition = "string";
            createAsset.Color = "string";
            createAsset.AssetUsage = "string";
            AssetLienHolder_PostAsset_Request assetLienHolder = new AssetLienHolder_PostAsset_Request();
            createAsset.AssetLienHolder = assetLienHolder;
            assetLienHolder.Name = "string";
            assetLienHolder.LienHolderId = "string";
            assetLienHolder.RemainingLoanAmount = 0;
            assetLienHolder.RemainingTerm = 0;
            assetLienHolder.GoodDate = DateTime.Now;
            Loan_PostAsset_Request loan = new Loan_PostAsset_Request();
            assetLienHolder.Loan = loan;
            loan.LoanAmount = 0;
            loan.Term = 0;
            loan.Rate = 0;
            loan.MonthlyPayment = 0;
            loan.NextPaymentDate = DateTime.Now;
            AddressCreate_PostAsset_Request addressCreate = new AddressCreate_PostAsset_Request();
            assetLienHolder.Address = addressCreate;
            addressCreate.StreetLine1 = "string";
            addressCreate.StreetLine2 = "string";
            addressCreate.City = "string";
            addressCreate.State = 0;
            addressCreate.Zip = "string";
            CurrentProduct_PostAsset_Request currentProduct = new CurrentProduct_PostAsset_Request();
            currentProduct.RefundAmount = 0;
            currentProduct.ProductType = "string";
            assetLienHolder.AccountNumber = "string";
            assetLienHolder.PhoneNumber = "string";
            AssetRegistration_PostAsset_Request assetRegistration = new AssetRegistration_PostAsset_Request();
            createAsset.AssetRegistration = assetRegistration;
            assetRegistration.PrimaryOwner = "string";
            assetRegistration.SecondaryOwner = "string";
            assetRegistration.Number = "string";
            assetRegistration.State = "string";
            assetRegistration.ExpirationDate = DateTime.Now;
            AssetInsurance_PostAsset_Request assetInsurance = new AssetInsurance_PostAsset_Request();
            createAsset.AssetInsurance = assetInsurance;
            assetInsurance.Company = "string";
            assetInsurance.PhoneNumber = "string";
            assetInsurance.PolicyNumber = "string";
            assetInsurance.EffectiveDate = DateTime.Now;
            assetInsurance.ExpirationDate = DateTime.Now;
            createAsset.SelectedNadaValue = 0;
            createAsset.SelectedStickerType = "srting";
            createAsset.ActualNadaTradeIn = 0;
            createAsset.SelectedKbbValue = 0;
            createAsset.Msrp = 0;
            createAsset.SelectedTradeInValue = 0;
            createAsset.BookOutDate = DateTime.Now;
            createAsset.ContactId = "string";
            List<CurrentProduct_PostAsset_Request> currentProducts = new List<CurrentProduct_PostAsset_Request> { currentProduct };
            assetLienHolder.CurrentProducts = currentProducts;
            string payload = JsonConvert.SerializeObject(createAsset, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_AssetService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseContent.Title, Is.EqualTo("One or more validation errors occurred."));
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            });
        }

        [Test]
        public void AssetService_AssetType_GetAsset_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/asset/" + AssetId + "?contactId=" + AssetContactId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        [TestCase(invalidAssetId, AssetContactId)]
        [TestCase(AssetId, invalidAssetContactId)]
        [TestCase(invalidAssetId, invalidAssetContactId)]
        public void AssetService_AssetType_GetAsset_NegativeScenario(string Id, string ContactId)
        {  
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/asset/" + Id + "?contactId=" + ContactId);
            RestRequest request = helper.CreateGetRequest();

            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Message_AssetService>(response);
            
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        [TestCase(invalidAssetId, AssetContactId)]
        [TestCase(AssetId, invalidAssetContactId)]
        [TestCase(invalidAssetId, invalidAssetContactId)]
        public void AssetService_AssetType_DeleteAsset_NegativeScenario(string Id, string ContactId)
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/asset/" + invalidAssetId + "?contactId=" + invalidAssetContactId);
            RestRequest request = helper.CreateDeleteRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Message_AssetService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.AssetService.Domain.Entities.Asset with id '" + invalidAssetId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void AssetService_AssetType_PutAsset_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/asset/" + AssetId);
            AssetType_PostAsset_Request createAsset = new AssetType_PostAsset_Request();
            createAsset.AssetType = "1";
            createAsset.Vin = "WAUYGAFC6CN174200";
            createAsset.Year = 2012;
            createAsset.Make = "Audi";
            createAsset.Model = "A7";
            createAsset.NadaTrim = "N102";
            createAsset.KbbTrim = "k103";
            createAsset.BodyStyle = "B1";
            createAsset.Mileage = "12";
            createAsset.AssetCondition = "1";
            createAsset.Color = "Green";
            createAsset.AssetUsage = "";
            AssetLienHolder_PostAsset_Request assetLienHolder = new AssetLienHolder_PostAsset_Request();
            createAsset.AssetLienHolder = assetLienHolder;
            assetLienHolder.Name = "LeanName";
            assetLienHolder.LienHolderId = "";
            assetLienHolder.RemainingLoanAmount = 100;
            assetLienHolder.RemainingTerm = 4;
            assetLienHolder.GoodDate = DateTime.Now;
            Loan_PostAsset_Request loan = new Loan_PostAsset_Request();
            assetLienHolder.Loan = loan;
            loan.LoanAmount = 80;
            loan.Term = 3;
            loan.Rate = 5;
            loan.MonthlyPayment = 20;
            loan.NextPaymentDate = DateTime.Now;
            AddressCreate_PostAsset_Request addressCreate = new AddressCreate_PostAsset_Request();
            assetLienHolder.Address = addressCreate;
            addressCreate.StreetLine1 = "";
            addressCreate.StreetLine2 = "";
            addressCreate.City = "";
            addressCreate.State = 0;
            addressCreate.Zip = "";
            CurrentProduct_PostAsset_Request currentProduct = new CurrentProduct_PostAsset_Request();
            currentProduct.RefundAmount = 30;
            currentProduct.ProductType = "1";
            assetLienHolder.AccountNumber = "123456789";
            assetLienHolder.PhoneNumber = "1212121212";
            AssetRegistration_PostAsset_Request assetRegistration = new AssetRegistration_PostAsset_Request();
            createAsset.AssetRegistration = assetRegistration;
            assetRegistration.PrimaryOwner = "p1";
            assetRegistration.SecondaryOwner = "p2";
            assetRegistration.Number = "3333333333";
            assetRegistration.State = "";
            assetRegistration.ExpirationDate = DateTime.Now;
            AssetInsurance_PostAsset_Request assetInsurance = new AssetInsurance_PostAsset_Request();
            createAsset.AssetInsurance = assetInsurance;
            assetInsurance.Company = "Inc Comp";
            assetInsurance.PhoneNumber = "4444444444";
            assetInsurance.PolicyNumber = "pol1234";
            assetInsurance.EffectiveDate = DateTime.Now;
            assetInsurance.ExpirationDate = DateTime.Now;
            createAsset.SelectedNadaValue = 0;
            createAsset.SelectedStickerType = "srting";
            createAsset.ActualNadaTradeIn = 0;
            createAsset.SelectedKbbValue = 0;
            createAsset.Msrp = 0;
            createAsset.SelectedTradeInValue = 0;
            createAsset.BookOutDate = DateTime.Now;
            createAsset.ContactId = AssetContactId;
            List<CurrentProduct_PostAsset_Request> currentProducts = new List<CurrentProduct_PostAsset_Request> { currentProduct };
            assetLienHolder.CurrentProducts = currentProducts;
            string payload = JsonConvert.SerializeObject(createAsset, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<AssetType_PostAsset_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.AssetType, Is.EqualTo("Car"));
                Assert.That(responseContent.Year, Is.EqualTo(2012));
                Assert.That(responseContent.ContactId, Is.EqualTo(AssetContactId));
            });
        }

        [Test]
        public void AssetService_AssetType_PutAsset_NegativeScenario_InvalidId()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/asset/" + invalidAssetId);
            AssetType_PostAsset_Request createAsset = new AssetType_PostAsset_Request();
            createAsset.AssetType = "1";
            createAsset.Vin = "WAUYGAFC6CN174200";
            createAsset.Year = 2012;
            createAsset.Make = "Audi";
            createAsset.Model = "A7";
            createAsset.NadaTrim = "N102";
            createAsset.KbbTrim = "k103";
            createAsset.BodyStyle = "B1";
            createAsset.Mileage = "12";
            createAsset.AssetCondition = "1";
            createAsset.Color = "Green";
            createAsset.AssetUsage = "";
            AssetLienHolder_PostAsset_Request assetLienHolder = new AssetLienHolder_PostAsset_Request();
            createAsset.AssetLienHolder = assetLienHolder;
            assetLienHolder.Name = "LeanName";
            assetLienHolder.LienHolderId = "";
            assetLienHolder.RemainingLoanAmount = 100;
            assetLienHolder.RemainingTerm = 4;
            assetLienHolder.GoodDate = DateTime.Now;
            Loan_PostAsset_Request loan = new Loan_PostAsset_Request();
            assetLienHolder.Loan = loan;
            loan.LoanAmount = 80;
            loan.Term = 3;
            loan.Rate = 5;
            loan.MonthlyPayment = 20;
            loan.NextPaymentDate = DateTime.Now;
            AddressCreate_PostAsset_Request addressCreate = new AddressCreate_PostAsset_Request();
            assetLienHolder.Address = addressCreate;
            addressCreate.StreetLine1 = "";
            addressCreate.StreetLine2 = "";
            addressCreate.City = "";
            addressCreate.State = 0;
            addressCreate.Zip = "";
            CurrentProduct_PostAsset_Request currentProduct = new CurrentProduct_PostAsset_Request();
            currentProduct.RefundAmount = 30;
            currentProduct.ProductType = "1";
            assetLienHolder.AccountNumber = "123456789";
            assetLienHolder.PhoneNumber = "1212121212";
            AssetRegistration_PostAsset_Request assetRegistration = new AssetRegistration_PostAsset_Request();
            createAsset.AssetRegistration = assetRegistration;
            assetRegistration.PrimaryOwner = "p1";
            assetRegistration.SecondaryOwner = "p2";
            assetRegistration.Number = "3333333333";
            assetRegistration.State = "";
            assetRegistration.ExpirationDate = DateTime.Now;
            AssetInsurance_PostAsset_Request assetInsurance = new AssetInsurance_PostAsset_Request();
            createAsset.AssetInsurance = assetInsurance;
            assetInsurance.Company = "Inc Comp";
            assetInsurance.PhoneNumber = "4444444444";
            assetInsurance.PolicyNumber = "pol1234";
            assetInsurance.EffectiveDate = DateTime.Now;
            assetInsurance.ExpirationDate = DateTime.Now;
            createAsset.SelectedNadaValue = 0;
            createAsset.SelectedStickerType = "srting";
            createAsset.ActualNadaTradeIn = 0;
            createAsset.SelectedKbbValue = 0;
            createAsset.Msrp = 0;
            createAsset.SelectedTradeInValue = 0;
            createAsset.BookOutDate = DateTime.Now;
            createAsset.ContactId = AssetContactId;
            List<CurrentProduct_PostAsset_Request> currentProducts = new List<CurrentProduct_PostAsset_Request> { currentProduct };
            assetLienHolder.CurrentProducts = currentProducts;
            string payload = JsonConvert.SerializeObject(createAsset, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Message_AssetService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.AssetService.Domain.Entities.Asset with id '" + invalidAssetId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void AssetService_AssetType_PutAsset_NegativeScenario_InvalidContactId()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/asset/" + AssetId);
            AssetType_PostAsset_Request createAsset = new AssetType_PostAsset_Request();
            createAsset.AssetType = "1";
            createAsset.Vin = "WAUYGAFC6CN174200";
            createAsset.Year = 2012;
            createAsset.Make = "Audi";
            createAsset.Model = "A7";
            createAsset.NadaTrim = "N102";
            createAsset.KbbTrim = "k103";
            createAsset.BodyStyle = "B1";
            createAsset.Mileage = "12";
            createAsset.AssetCondition = "1";
            createAsset.Color = "Green";
            createAsset.AssetUsage = "";
            AssetLienHolder_PostAsset_Request assetLienHolder = new AssetLienHolder_PostAsset_Request();
            createAsset.AssetLienHolder = assetLienHolder;
            assetLienHolder.Name = "LeanName";
            assetLienHolder.LienHolderId = "";
            assetLienHolder.RemainingLoanAmount = 100;
            assetLienHolder.RemainingTerm = 4;
            assetLienHolder.GoodDate = DateTime.Now;
            Loan_PostAsset_Request loan = new Loan_PostAsset_Request();
            assetLienHolder.Loan = loan;
            loan.LoanAmount = 80;
            loan.Term = 3;
            loan.Rate = 5;
            loan.MonthlyPayment = 20;
            loan.NextPaymentDate = DateTime.Now;
            AddressCreate_PostAsset_Request addressCreate = new AddressCreate_PostAsset_Request();
            assetLienHolder.Address = addressCreate;
            addressCreate.StreetLine1 = "";
            addressCreate.StreetLine2 = "";
            addressCreate.City = "";
            addressCreate.State = 0;
            addressCreate.Zip = "";
            CurrentProduct_PostAsset_Request currentProduct = new CurrentProduct_PostAsset_Request();
            currentProduct.RefundAmount = 30;
            currentProduct.ProductType = "1";
            assetLienHolder.AccountNumber = "123456789";
            assetLienHolder.PhoneNumber = "1212121212";
            AssetRegistration_PostAsset_Request assetRegistration = new AssetRegistration_PostAsset_Request();
            createAsset.AssetRegistration = assetRegistration;
            assetRegistration.PrimaryOwner = "p1";
            assetRegistration.SecondaryOwner = "p2";
            assetRegistration.Number = "3333333333";
            assetRegistration.State = "";
            assetRegistration.ExpirationDate = DateTime.Now;
            AssetInsurance_PostAsset_Request assetInsurance = new AssetInsurance_PostAsset_Request();
            createAsset.AssetInsurance = assetInsurance;
            assetInsurance.Company = "Inc Comp";
            assetInsurance.PhoneNumber = "4444444444";
            assetInsurance.PolicyNumber = "pol1234";
            assetInsurance.EffectiveDate = DateTime.Now;
            assetInsurance.ExpirationDate = DateTime.Now;
            createAsset.SelectedNadaValue = 0;
            createAsset.SelectedStickerType = "srting";
            createAsset.ActualNadaTradeIn = 0;
            createAsset.SelectedKbbValue = 0;
            createAsset.Msrp = 0;
            createAsset.SelectedTradeInValue = 0;
            createAsset.BookOutDate = DateTime.Now;
            createAsset.ContactId = invalidAssetContactId;
            List<CurrentProduct_PostAsset_Request> currentProducts = new List<CurrentProduct_PostAsset_Request> { currentProduct };
            assetLienHolder.CurrentProducts = currentProducts;
            string payload = JsonConvert.SerializeObject(createAsset, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Message_AssetService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.AssetService.Domain.Entities.Asset with id '" + AssetId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void AssetService_AssetType_AssetVehicleVinDetails_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/asset/vehicle/vinDetails?firstName=Test&lastName=Test&address=Test&city=Test&state=AL&zipCode=5003");
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void AssetService_AssetType_LeadsAssets_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/leads/" + AssetLeadId + "/assets?contactId=" + AssetContactId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<AssetType_PostAsset_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.AssetType, Is.EqualTo("Car"));
                Assert.That(responseContent.Year, Is.EqualTo(2012));
                Assert.That(responseContent.ContactId, Is.EqualTo(AssetContactId));
            });
        }

        [Test]
        [TestCase(AssetLeadIdInval, AssetContactId)]
        [TestCase(AssetLeadId, invalidAssetContactId)]
        [TestCase(AssetLeadIdInval, invalidAssetContactId)]
        public void AssetService_AssetType_LeadsAssets_NegativeScenario(string LeadId, string ContactId)
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/leads/" + LeadId + "/assets?contactId=" + ContactId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Message_AssetService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void AssetService_AssetType_AssetContact_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/asset/contact/" + AssetContactId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void AssetService_AssetType_AssetContactIds_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("deal-service/deals");
            List<object> value = new() { "c7777bec-136f-4c90-9904-387ae3ce7459" };
            string payload = JsonConvert.SerializeObject(value, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload);
            /// Act           
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void AssetService_KbbType_KbbYears_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/kbb/years?modelId=" + ModelId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void AssetService_KbbType_KbbYears_NegativeScenario_InvalidModelId()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/kbb/years?modelId=" + ModelIdInvalid);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Message_AssetService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("No record found."));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void AssetService_KbbType_KbbMakes_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/kbb/makes/" + YearId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void AssetService_KbbType_KbbMakes_NegativeScenario_InvalidYear()
        {
            /// Arrange
            string Year = helper.RandomDigits(3);
            RestClient client = helper.SetUrlDev("asset-service/kbb/makes/" + Year);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Message_AssetService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("No record found for year " + Year + "."));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void AssetService_KbbType_KbbModels_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/kbb/models/" + MakeId + "/" + YearId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        [TestCase(MakeIdInvalid, YearId)]
        [TestCase(MakeId, YearIdInvalid)]
        [TestCase(MakeIdInvalid, YearIdInvalid)]
        public void AssetService_KbbType_KbbModels_NegativeScenario(string MakeId, string YearId)
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/kbb/models/" + MakeId + "/" + YearId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Message_AssetService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("No record found for makeId " + MakeId + " or yearId " + YearId + "."));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void AssetService_KbbType_KbbTrims_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/kbb/trims/" + ModelId + "/" + YearId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        [TestCase(ModelIdInvalid, YearId)]
        [TestCase(ModelId, YearIdInvalid)]
        [TestCase(ModelIdInvalid, YearIdInvalid)]
        public void AssetService_KbbType_KbbTrims_NegativeScenario(string ModelId, string YearId)
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/kbb/trims/" + ModelId + "/" + YearId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_KbbTypeResponse>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("No record found for modelId " + ModelId + " or yearId " + YearId + "."));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void AssetService_NadaType_NadaYears_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/nada/years");
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void AssetService_NadaType_NadaMakes_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/nada/makes/" + ModelYear);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void AssetService_NadaType_NadaMakes_NegativeScenario_InvalidModelYear()
        {
            /// Arrange
            string ModelYearInvalid = helper.RandomDigits(3);
            RestClient client = helper.SetUrlDev("asset-service/nada/makes/" + ModelYearInvalid);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_KbbTypeResponse>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("No record found for year " + ModelYearInvalid + "."));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void AssetService_NadaType_NadaModels_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/nada/models/" + Make + "/" + ModelYear);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        [TestCase(Make, ModelYearInvalid)]
        [TestCase(MakeInvalid, ModelYear)]
        [TestCase(MakeInvalid, ModelYearInvalid)]
        public void AssetService_NadaType_NadaModels_NegativeScenario(string Make, string ModelYear)
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/nada/models/" + Make + "/" + ModelYear);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_KbbTypeResponse>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("No record found for make " + Make + " or year " + ModelYear + "."));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void AssetService_NadaType_NadaTrims_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/nada/trims/" + ModelYear + "/" + Make + "/" + Model);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        [TestCase(ModelYearInvalid, Make, Model)]
        [TestCase(ModelYear, MakeInvalid, Model)]
        [TestCase(ModelYear, Make, ModelInvalid)]
        [TestCase(ModelYearInvalid, MakeInvalid, ModelInvalid)]
        public void AssetService_NadaType_NadaTrims_NegativeScenario(string ModelYear, string Make, string Model)
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/nada/trims/" + ModelYear + "/" + Make + "/" + Model);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_KbbTypeResponse>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("No record found for year " + ModelYear + " or make " + Make + " or model " + Model + "."));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void AssetService_VehicleType_AssetVehicleType_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/asset/vehicle/" + vinNumber + "?assetValuationType=" + AssetValuationType + "&mileage=" + mileage + "&state=MA");
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<VehicleType_AssetVehicleType_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Year, Is.EqualTo(2018));
                Assert.That(responseContent.Make, Is.EqualTo("Ford"));
                Assert.That(responseContent.ProviderVehicleId, Is.EqualTo(201834687));
            });
        }

        [Test]
        [TestCase(InvalidvinNumber, AssetValuationType, mileage)]
        [TestCase(vinNumber, AssetValuationTypeInvalid, mileage)]
        [TestCase(InvalidvinNumber, AssetValuationTypeInvalid, mileage)]
        public void AssetService_VehicleType_AssetVehicleType_NegativeScenario(string VinNumber, string AssetValuationType, string Mileage)
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/asset/vehicle/" + VinNumber + "?assetValuationType=" + AssetValuationType + "&mileage=" + Mileage + "&state=MA");
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Message_AssetService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Code, Is.EqualTo("BadRequest"));
            });
        }

        [Test]
        public void AssetService_VehicleType_AssetVehicleValuation_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/asset/" + AssetId + "/vehicle/valuation?contactId=" + AssetContactId + "&vinNumber=" + vinNumber + "&assetValuationType=Nada&mileage=" + mileage + "&state=MA&zipCode=" + zipCode);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<VehicleType_AssetVehicleValuation_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.RetailValue, Is.EqualTo(23550));
                Assert.That(responseContent.TradeInValue, Is.EqualTo(21425));
            });
        }

        [Test]
        [TestCase(AssetId, AssetContactId, InvalidvinNumber, AssetValuationType, mileage, zipCode)]
        [TestCase(AssetId, AssetContactId, vinNumber, AssetValuationTypeInvalid, mileage, zipCode)]
        [TestCase(invalidAssetId, invalidAssetContactId, InvalidvinNumber, AssetValuationTypeInvalid, mileage, zipCode)]
        public void AssetService_VehicleType_AssetVehicleValuation_NegativeScenario(string AssetId, string ContactId, string VinNumber, string AssetValuationType, string Mileage, string ZipCode)
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/asset/" + AssetId + "/vehicle/valuation?contactId=" + ContactId + "&vinNumber=" + VinNumber + "&assetValuationType=" + AssetValuationType + "&mileage=" + Mileage + "&state=MA&zipCode=" + ZipCode);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Message_AssetService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Code, Is.EqualTo("BadRequest"));
            });
        }

        [Test]
        public void AssetService_VehicleType_AssetVehicleBookoutDownloan_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/asset/" + AssetId + "/vehicle/bookout/download?vinNumber=" + vinNumber + "&assetValuationType=Nada");
            VehicleType_AssetVehicleBookoutDownloan_Request vehicleBookoutDownloan = new VehicleType_AssetVehicleBookoutDownloan_Request();
            VehicleDetails_AssetVehicleBookoutDownloan_Request vehicleDetails = new VehicleDetails_AssetVehicleBookoutDownloan_Request();
            vehicleBookoutDownloan.VehicleDetails = vehicleDetails;
            vehicleDetails.Year = 2018;
            vehicleDetails.Make = "Ford";
            vehicleDetails.Model = "Escape";
            vehicleDetails.BodyStyle = "Utility 4D Titanium EcoBoost 4WD 2.0L I4 Turbo";
            vehicleDetails.ProviderVehicleId = 201834687;
            vehicleDetails.VehicleType = "Light Truck";
            vehicleDetails.MileageClass = "2";
            vehicleDetails.BaseMsrp = 33395;
            vehicleDetails.BodyType = "Utility";
            vehicleDetails.Doors = 4;
            vehicleDetails.Trim = "Titanium";
            vehicleDetails.Trim2 = "EcoBoost";
            vehicleDetails.DriveType = "4WD";
            vehicleDetails.Liters = 2;
            vehicleDetails.EngineConfiguration = "I";
            vehicleDetails.Cylinders = "4";
            vehicleDetails.InductionType = "Turbo";
            vehicleDetails.Transmission = "N/A";
            vehicleDetails.FuelType = "Gas";
            vehicleDetails.Wheels = 4;
            vehicleDetails.CurbWeight = "3645";
            vehicleDetails.Gvw = "";
            vehicleDetails.Gcw = "";
            vehicleDetails.UcgSubSegment = "Compact SUV";
            vehicleDetails.ModelNumber = "U9J";
            vehicleDetails.RollUpVehicleId = "201834687";
            vehicleDetails.BaseCleanTrade = 24225;
            vehicleDetails.BaseAverageTrade = 23050;
            vehicleDetails.BaseRoughTrade = 21600;
            vehicleDetails.BaseCleanRetail = 26450;
            vehicleDetails.BaseLoan = 21825;
            vehicleDetails.AverageMileage = 57500;
            vehicleDetails.MileageAdjustment = 650;
            vehicleDetails.AdjustedCleanTrade = 24875;
            vehicleDetails.AdjustedAverageTrade = 23700;
            vehicleDetails.AdjustedrRoughTrade = 0;
            vehicleDetails.AdjustedCleanRetail = 27100;
            vehicleDetails.AdjustedLoan = 22475;
            vehicleDetails.MaxMileageAdj = 12113;
            vehicleDetails.MinMileageAdj = -9690;
            vehicleDetails.MinAdjRetail = 420;
            vehicleDetails.MinadjCleanTrade = 120;
            vehicleDetails.MinAdjaverageTrade = 120;
            vehicleDetails.MinAdjRoughTrade = 120;
            vehicleDetails.MinAdjLoan = 0;
            vehicleDetails.MinAdjRetailForLoan = 900;
            vehicleDetails.Vid = "93603";
            vehicleDetails.VehicleClass = null;
            vehicleDetails.VehicleName = null;
            vehicleDetails.ModelMarketName = null;
            vehicleDetails.ModelYearId = 0;
            vehicleDetails.TrimId = 0;
            vehicleDetails.ModelPlusTrimName = null;
            vehicleDetails.BedLength = null;
            vehicleDetails.GenericBodyStyle = null;
            vehicleDetails.OemBodyStyle = null;
            vehicleDetails.SortOrder = 0;
            vehicleDetails.IsConsumer = false;
            VehicleValuation_AssetVehicleBookoutDownloan_Request vehicleValuation = new VehicleValuation_AssetVehicleBookoutDownloan_Request();
            vehicleBookoutDownloan.VehicleValuation = vehicleValuation;
            vehicleValuation.BaseRetailAmount = 0;
            vehicleValuation.BaseWholesaleAmount = 0;
            vehicleValuation.BaseTradeInAmount = 0;
            Option_AssetVehicleBookoutDownloan_Request optionsValuation = new Option_AssetVehicleBookoutDownloan_Request();
            optionsValuation.Description = "Towing/Camper Pkg";
            optionsValuation.Code = "145";
            optionsValuation.TradeIn = 350;
            optionsValuation.RetailAmount = 400;
            optionsValuation.Loan = 350;
            optionsValuation.IsIncluded = false;
            optionsValuation.IsAdded = false;
            optionsValuation.AccessoryCategory = "Package";
            optionsValuation.IsDisabled = false;
            optionsValuation.Id = "145";
            optionsValuation.WholeSaleAmount = 0;
            optionsValuation.IsDefault = false;
            List<Option_AssetVehicleBookoutDownloan_Request> options = new List<Option_AssetVehicleBookoutDownloan_Request> { optionsValuation };
            vehicleValuation.Options = options;
            vehicleValuation.MileageAdjustment = 0;
            vehicleValuation.RetailOptionAdjustment = 0;
            vehicleValuation.WholsaleOptionAdjustment = 0;
            vehicleValuation.SelectedOptionsRetailPriceSum = 0;
            vehicleValuation.SelectedOptionsWholeSalePriceSum = 0;
            List<string> selectedOptions = new List<string> { "145" };
            vehicleBookoutDownloan.SelectedOptions = selectedOptions;
            vehicleBookoutDownloan.DealId = "323920";
            vehicleBookoutDownloan.State = "MA";
            vehicleBookoutDownloan.UserId = "198";
            vehicleBookoutDownloan.ContactId = "316448";
            vehicleBookoutDownloan.Mileage = 46143;
            string payload = JsonConvert.SerializeObject(vehicleBookoutDownloan, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void AssetService_VehicleType_AssetVehicleTitle_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/asset/" + AssetId + "/vehicle/title?vinNumber=" + vinNumber + "&userId=" + AssetUserId + "&vehicleServiceType=Test");
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<VehicleType_AssetVehicleTitle_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.HasVehicleRecordLessThanThirtyDaysOld, Is.EqualTo(false));
                Assert.That(responseContent.ShouldDisplayOverrideButton, Is.EqualTo(false));
                Assert.That(responseContent.AccessTokenDoesNotExists, Is.EqualTo(true));
            });
        }

        [Test]
        [TestCase(invalidAssetId, vinNumber, AssetUserId)]
        [TestCase(AssetId, InvalidvinNumber, AssetUserId)]
        [TestCase(invalidAssetId, InvalidvinNumber, AssetUserId)]
        public void AssetService_VehicleType_AssetVehicleTitle_NegativeScenario(string AssetId, string VinNumber, string UserId)
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/asset/" + AssetId + "/vehicle/title?vinNumber=" + VinNumber + "&userId=" + UserId + "&vehicleServiceType=Test");
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<VehicleType_AssetVehicleTitle_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.HasVehicleRecordLessThanThirtyDaysOld, Is.EqualTo(false));
                Assert.That(responseContent.ShouldDisplayOverrideButton, Is.EqualTo(false));
                Assert.That(responseContent.AccessTokenDoesNotExists, Is.EqualTo(false));
            });
        }

        [Test]
         public void AssetService_VehicleType_AssetVehicleToken_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/asset/redirect?code=0&error=0&error_Description=0&state=0");
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void AssetService_VehicleType_AssetVehicleSticker_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/asset/vehicle/sticker/" + vinNumber + "?assetStickerType= " + AssetStickerType);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<VehicleType_AssetVehicleTitle_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.HasVehicleRecordLessThanThirtyDaysOld, Is.EqualTo(false));
                Assert.That(responseContent.ShouldDisplayOverrideButton, Is.EqualTo(false));
                Assert.That(responseContent.AccessTokenDoesNotExists, Is.EqualTo(true));
            });
        }
        [Test]
        [TestCase(vinNumber, AssetStickerTypeInvalid)]
        [TestCase(InvalidvinNumber, AssetStickerType)]
        [TestCase(InvalidvinNumber, AssetStickerTypeInvalid)]
        public void AssetService_VehicleType_AssetVehicleSticker_NegativeScenario(string VinNumber, string AssetStickerType)
        {
            /// Arrange
            RestClient client = helper.SetUrlDev("asset-service/asset/vehicle/sticker/" + VinNumber + "?assetStickerType= " + AssetStickerType);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_Message_AssetService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Code, Is.EqualTo("BadRequest"));
            });
        }
    }
}
