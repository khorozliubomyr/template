using Newtonsoft.Json;
using NUnit.Framework;
using Phoenix2.APITests.DTO.ProductServiceDto;
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
    class ProductService
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
        public void ProductService_DealProductsType_DealProductsSummary_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/deals/" + DealIdProduct + "/dealproducts/summary");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ProductService_DealProductsType_DealProducts_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/deals/" + DealIdProduct + "/dealproducts");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ProductService_DealProductsType_PostDealProducts_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/deals/" + DealIdProduct + "/dealproducts");
            DealProductsType_PostDealProducts_Request createDealProduct = new DealProductsType_PostDealProducts_Request();
            DealProduct_PostDealProducts_Request dealProduct = new DealProduct_PostDealProducts_Request();
            List<DealProduct_PostDealProducts_Request> dealProducts = new List<DealProduct_PostDealProducts_Request> { dealProduct };
            createDealProduct.DealProducts = dealProducts;
            dealProduct.ProductTypeName = productTypeName;
            dealProduct.ProductTypeId = productTypeId;
            dealProduct.ProviderName = providerName;
            dealProduct.ProviderId = ProviderId;
            dealProduct.Cost = 0;
            dealProduct.Markup = 0;
            dealProduct.Retail = 0;
            dealProduct.PackPrice = 0;
            dealProduct.ProviderBaseAmount = 0;
            dealProduct.TaxAmount = 0;
            dealProduct.MaxAllowedRetail = 0;
            dealProduct.SefiTermId = 0;
            dealProduct.SefiPlanCode = "string";
            dealProduct.SefiQuoteId = 0;
            dealProduct.SefiRateBook = 0;
            dealProduct.SefiContractFormNumber = "string";
            Plan_PostDealProducts_Request plan = new Plan_PostDealProducts_Request();
            dealProduct.Plan = plan;
            plan.PlanId = PlanId;
            plan.PlanName = "string";
            Rate_PostDealProducts_Request rate = new Rate_PostDealProducts_Request();
            dealProduct.Rate = rate;
            rate.RateId = RateId;
            rate.MinTerm = 0;
            rate.MaxTerm = 0;
            rate.MaxMiles = 0;
            Deductible_PostDealProducts_Request deductible = new Deductible_PostDealProducts_Request();
            dealProduct.Deductible = deductible;
            deductible.Id = "19";
            deductible.Name = "string";
            deductible.Amount = 0;
            Option_PostDealProducts_Request option = new Option_PostDealProducts_Request();
            List<Option_PostDealProducts_Request> options = new List<Option_PostDealProducts_Request> { option };
            dealProduct.Options = options;
            option.Id = "string";
            option.Name = "string";
            option.Amount = 0;
            option.IsSurcharge = true;
            dealProduct.DealProductId = DealProductIdProduct;
            dealProduct.TotalAmountFinanced = 0;
            dealProduct.Status = "Contracted";
            ContractBlobFile_PostDealProducts_Request contractBlobFile = new ContractBlobFile_PostDealProducts_Request();
            dealProduct.ContractBlobFile = contractBlobFile;
            contractBlobFile.Name = "string";
            contractBlobFile.Path = "string";
            contractBlobFile.Type = "PDF";
            dealProduct.AssetMiles = 0;
            string payload = JsonConvert.SerializeObject(createDealProduct, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ProductService_DealProductsType_PostDealProducts_NegativeScenario_InvalidDealProductId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/deals/" + DealIdProduct + "/dealproducts");
            DealProductsType_PostDealProducts_Request createDealProduct = new DealProductsType_PostDealProducts_Request();
            DealProduct_PostDealProducts_Request dealProduct = new DealProduct_PostDealProducts_Request();
            List<DealProduct_PostDealProducts_Request> dealProducts = new List<DealProduct_PostDealProducts_Request> { dealProduct };
            createDealProduct.DealProducts = dealProducts;
            dealProduct.ProductTypeName = "string";
            dealProduct.ProductTypeId = productTypeId;
            dealProduct.ProviderName = "string";
            dealProduct.ProviderId = ProviderId;
            dealProduct.Cost = 0;
            dealProduct.Markup = 0;
            dealProduct.Retail = 0;
            dealProduct.PackPrice = 0;
            dealProduct.ProviderBaseAmount = 0;
            dealProduct.TaxAmount = 0;
            dealProduct.MaxAllowedRetail = 0;
            dealProduct.SefiTermId = 0;
            dealProduct.SefiPlanCode = "string";
            dealProduct.SefiQuoteId = 0;
            dealProduct.SefiRateBook = 0;
            dealProduct.SefiContractFormNumber = "string";
            Plan_PostDealProducts_Request plan = new Plan_PostDealProducts_Request();
            dealProduct.Plan = plan;
            plan.PlanId = PlanId;
            plan.PlanName = "string";
            Rate_PostDealProducts_Request rate = new Rate_PostDealProducts_Request();
            dealProduct.Rate = rate;
            rate.RateId = RateId;
            rate.MinTerm = 0;
            rate.MaxTerm = 0;
            rate.MaxMiles = 0;
            Deductible_PostDealProducts_Request deductible = new Deductible_PostDealProducts_Request();
            dealProduct.Deductible = deductible;
            deductible.Id = "19";
            deductible.Name = "string";
            deductible.Amount = 0;
            Option_PostDealProducts_Request option = new Option_PostDealProducts_Request();
            List<Option_PostDealProducts_Request> options = new List<Option_PostDealProducts_Request> { option };
            dealProduct.Options = options;
            option.Id = "string";
            option.Name = "string";
            option.Amount = 0;
            option.IsSurcharge = true;
            dealProduct.DealProductId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
            dealProduct.TotalAmountFinanced = 0;
            dealProduct.Status = "Contracted";
            ContractBlobFile_PostDealProducts_Request contractBlobFile = new ContractBlobFile_PostDealProducts_Request();
            dealProduct.ContractBlobFile = contractBlobFile;
            contractBlobFile.Name = "string";
            contractBlobFile.Path = "string";
            contractBlobFile.Type = "PDF";
            dealProduct.AssetMiles = 0;
            string payload = JsonConvert.SerializeObject(createDealProduct, Formatting.Indented);
            Console.WriteLine(payload);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_ProductService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Deal Product string with string Not Found on this deal, when trying to update"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void ProductService_DealProductsType_DealProductsExists_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/deals/" + DealIdProduct + "/dealproducts/exists");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ProductService_DealProductsType_DealsDealProduct_NegativeScenario_InvalidProductId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/deals/" + DealIdProduct + "/dealproducts/" + DealProductIdProductInvalid);
            RestRequest request = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_ProductService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Deal Product not found using " + DealProductIdProductInvalid));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void ProductService_DealProductsType_DealProductRetail_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/deals/" + DealIdProduct + "/dealproducts/" + DealProductIdProduct + "/retail");
            DealProductsType_DealProductRetail_Request updateRetail = new DealProductsType_DealProductRetail_Request()
            {
                NewRetail = 10,
                NewMarkUp = 0
            };
            string payload = JsonConvert.SerializeObject(updateRetail, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ProductService_DealProductsType_DealProductRetail_NegativeScenario_InvalidDealProductId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/deals/" + DealIdProduct + "/dealproducts/" + DealProductIdProductInvalid + "/retail");
            DealProductsType_DealProductRetail_Request updateRetail = new DealProductsType_DealProductRetail_Request()
            {
                NewRetail = 10,
                NewMarkUp = 0
            };
            string payload = JsonConvert.SerializeObject(updateRetail, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_ProductService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Deal Product " + DealProductIdProductInvalid + " with. Not Found on this deal, when trying to update"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void ProductService_DealProductsType_DealProductsVoid_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/deals/" + DealIdProduct + "/dealproducts/void");
            string Name = helper.GenerateDocName(6);
            DealProductsType_DealProductsVoid_Request createDealProduct = new DealProductsType_DealProductsVoid_Request();
            DealProduct_DealProductsVoid_Request voidDealProduct = new DealProduct_DealProductsVoid_Request();
            List<DealProduct_DealProductsVoid_Request> dealProduct = new List<DealProduct_DealProductsVoid_Request> { voidDealProduct };
            createDealProduct.DealProduct = dealProduct;
            voidDealProduct.DealProductId = DealProductIdProduct;
            voidDealProduct.ProductTypeName = Name;
            string payload = JsonConvert.SerializeObject(createDealProduct, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ProductService_DealProductsType_DealProductsVoid_NegativeScenario_InvalidDealProductId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/deals/" + DealIdProduct + "/dealproducts/void");
            string Name = helper.GenerateDocName(6);
            DealProductsType_DealProductsVoid_Request createDealProduct = new DealProductsType_DealProductsVoid_Request();
            DealProduct_DealProductsVoid_Request voidDealProduct = new DealProduct_DealProductsVoid_Request();
            List<DealProduct_DealProductsVoid_Request> dealProduct = new List<DealProduct_DealProductsVoid_Request> { voidDealProduct };
            createDealProduct.DealProduct = dealProduct;
            voidDealProduct.DealProductId = DealProductIdProductInvalid;
            voidDealProduct.ProductTypeName = Name;
            string payload = JsonConvert.SerializeObject(createDealProduct, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
        [Test]
        public void ProductService_DealProductsType_DealProductVoidByDealProductId_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/deals/" + DealIdProduct + "/dealproducts/" + DealProductIdProduct + "/void");
            RestRequest request = helper.CreatePostRequestWithoutBody(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DealProductsType_DealProductVoidByDealProductId_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.DealProductId, Is.EqualTo(DealProductIdProduct));
            });
        }
        [Test]
        public void ProductService_DealProductsType_DealProductVoidByDealProductId_NegativeScenario_InvalidDealProductId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/deals/" + DealIdProduct + "/dealproducts/" + DealProductIdProductInvalid + "/void");
            RestRequest request = helper.CreatePostRequestWithoutBody(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
        [Test]
        public void ProductService_DealProductsType_DealProductsContact_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/deals/" + DealIdProduct + "/dealproducts/contract");
            RestRequest request = helper.CreatePostRequestWithoutBody(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ProductService_DealProductsType_DealProductsContact_NegativeScenario_InvalidDealId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/deals/" + DealIdProductInvalid + "/dealproducts/contract");
            RestRequest request = helper.CreatePostRequestWithoutBody(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<NegativeScenario_ProductService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Message, Is.EqualTo("'ContractDate' is 90+ days in the past or 30+ days in the future is invalid date;\n'Vin' must not be empty;\n"));
                Assert.That(responseContent.Code, Is.EqualTo("BadRequest"));
            });
        }
        [Test]
        public void ProductService_DealProductsType_DealCalculator_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/leads/" + LeadId + "/dealcalculator");
            DealProductsType_DealCalculator_Request dealCalculator = new DealProductsType_DealCalculator_Request();
            dealCalculator.LenderCode = "";
            DealCalculatorLeadProduct_DealCalculator_Request calculatorLeadProduct = new DealCalculatorLeadProduct_DealCalculator_Request();
            List<DealCalculatorLeadProduct_DealCalculator_Request> dealCalculatorLeadProductDtos = new List<DealCalculatorLeadProduct_DealCalculator_Request> { calculatorLeadProduct };
            dealCalculator.DealCalculatorLeadProductDtos = dealCalculatorLeadProductDtos;
            calculatorLeadProduct.ProductTypeName = "string";
            calculatorLeadProduct.ProductTypeId = "string";
            calculatorLeadProduct.ProviderName = "string";
            calculatorLeadProduct.ProviderId = "string";
            calculatorLeadProduct.Cost = 0;
            calculatorLeadProduct.Markup = 0;
            calculatorLeadProduct.Retail = 0;
            calculatorLeadProduct.PackPrice = 0;
            calculatorLeadProduct.ProviderBaseAmount = 0;
            calculatorLeadProduct.TaxAmount = 0;
            calculatorLeadProduct.MaxAllowedRetail = 0;
            calculatorLeadProduct.SefiTermId = 0;
            calculatorLeadProduct.SefiPlanCode = "string";
            calculatorLeadProduct.SefiQuoteId = 0;
            calculatorLeadProduct.SefiRateBook = 0;
            calculatorLeadProduct.SefiContractFormNumber = "string";
            Plan_DealCalculator_Request plan = new Plan_DealCalculator_Request();
            calculatorLeadProduct.Plan = plan;
            plan.PlanId = PlanId;
            plan.PlanName = "string";
            Rate_DealCalculator_Request rate = new Rate_DealCalculator_Request();
            calculatorLeadProduct.Rate = rate;
            rate.RateId = RateId;
            rate.MinTerm = 0;
            rate.MaxTerm = 0;
            rate.MaxMiles = 0;
            Deductible_DealCalculator_Request deductible = new Deductible_DealCalculator_Request();
            calculatorLeadProduct.Deductible = deductible;
            deductible.Id = "19";
            deductible.Name = "string";
            deductible.Amount = 0;
            Option_DealCalculator_Request option = new Option_DealCalculator_Request();
            List<Option_DealCalculator_Request> options = new List<Option_DealCalculator_Request> { option };
            calculatorLeadProduct.Options = options;
            option.Id = "string";
            option.Name = "string";
            option.Amount = 0;
            option.IsSurcharge = true;
            calculatorLeadProduct.DealCalculatorLeadProductId = "";
            calculatorLeadProduct.LenderCode = "";
            string payload = JsonConvert.SerializeObject(dealCalculator, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ProductService_DealProductsType_GetDealCalculator_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/leads/dealcalculator?LeadId=" + LeadId + "&LenderCode=" + lenderCodeProduct);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ProductService_DealProductsType_GetDealProductTotalTax_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/deals/" + DealIdProduct + "/totalproductstax?dealId=" + DealIdProduct);
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ProductService_DealProductsType_SaveDealProducts_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/dealcalculator/savedealproducts");
            DealProductsType_SaveDealProducts_Request saveDealProducts = new DealProductsType_SaveDealProducts_Request();
            saveDealProducts.DealId = DealIdProduct;
            saveDealProducts.LeadId = LeadId;
            saveDealProducts.LenderCode = lenderCodeProduct;
            saveDealProducts.TotalAmountFinanced = 0;
            Product_SaveDealProducts_Request product = new Product_SaveDealProducts_Request();
            List<Product_SaveDealProducts_Request> products = new List<Product_SaveDealProducts_Request> { product };
            saveDealProducts.Products = products;
            product.ProductTypeName = ProductTypeNameLender;
            product.ProductRetail = 0;
            string payload = JsonConvert.SerializeObject(saveDealProducts, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ProductService_DealProductsType_DealCalculatorRetail_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/dealcalculator/retail");
            DealProductsType_DealCalculatorRetail_Request dealCalculatorProductRetail = new DealProductsType_DealCalculatorRetail_Request()
            {
                ProductTypeName = ProductTypeNameLender,
                NewRetail = 0,
                LeadId = LeadId,
                LenderCode = lenderCodeProduct
            };
            string payload = JsonConvert.SerializeObject(dealCalculatorProductRetail, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ProductService_DealProductsType_TotalAmountFinanced_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/totalamountfinance");
            DealProductsType_TotalAmountFinanced_Request dealProductsTotalAmountFinanced = new DealProductsType_TotalAmountFinanced_Request()
            {
                DealId = DealIdProduct
            };
            string payload = JsonConvert.SerializeObject(dealProductsTotalAmountFinanced, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ProductService_DealProductsType_UpdateGapWhenDealTermChanged_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/updategapwhendealtermchanged");
            DealProductsType_UpdateGapWhenDealTermChanged_Request gapDealProductWhenDealTermChanged = new DealProductsType_UpdateGapWhenDealTermChanged_Request()
            {
                DealProductId = DealProductIdProduct,
                DealId = DealIdProduct
            };
            string payload = JsonConvert.SerializeObject(gapDealProductWhenDealTermChanged, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ProductService_ProductPlanType_DealPlan_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/deals/" + DealIdProduct + "/plans?newVersion=true");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ProductService_ProductPlanType_LeadPlans_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/leads/" + LeadId + "/plans?lenderCode=" + lenderCodeProduct + "&newVersion=true");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ProductService_ProductPlanType_Lates_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/" + LeadId + "/latest");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<ProductPlanType_Lates_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.LeadId, Is.EqualTo(LeadId));
            });
        }

        [Test]
        public void ProductService_ProductTypesType_GetProductTypes_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/producttypes");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ProductService_ProductTypesType_PostProductType_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/producttypes");
            string Name = helper.GenerateDocName(5);
            ProductTypesType_PostProductType_Request productType = new ProductTypesType_PostProductType_Request();
            productType.Name = Name;
            Rule_PostProductType_Request rule = new Rule_PostProductType_Request();
            List<Rule_PostProductType_Request> rules = new List<Rule_PostProductType_Request> { rule };
            productType.Rules = rules;
            rule.State = "string";
            rule.MaxAllowedAmount = 0;
            rule.MaxAllowedFormula = "string";
            rule.IsAllowed = true;
            rule.MaxTerm = 0;
            string payload = JsonConvert.SerializeObject(productType, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<ProductTypesType_PostProductType_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Name, Is.EqualTo(Name));
            });
        }
        [Test]
        public void ProductService_ProductTypesType_PutProductType_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/producttypes");
            string Name = helper.GenerateDocName(5);
            ProductTypesType_PostProductType_Request productType = new ProductTypesType_PostProductType_Request();
            productType.Name = Name;
            Rule_PostProductType_Request rule = new Rule_PostProductType_Request();
            List<Rule_PostProductType_Request> rules = new List<Rule_PostProductType_Request> { rule };
            productType.Rules = rules;
            rule.State = "string";
            rule.MaxAllowedAmount = 0;
            rule.MaxAllowedFormula = "string";
            rule.IsAllowed = true;
            rule.MaxTerm = 0;
            string payload = JsonConvert.SerializeObject(productType, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<ProductTypesType_PostProductType_Response>(response);
            string Id = responseContent.Id;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient clientPut = helper.SetUrl("product-service/producttypes");
            string GroupPatch = helper.GenerateDocName(6);
            string TokenPatch = helper.GenerateDocName(6);
            ProductTypesType_PutProductType_Request updateProductType = new ProductTypesType_PutProductType_Request();
            updateProductType.Id = Id;
            updateProductType.Name = Name;
            Rule_PutProductType_Request updateRules = new Rule_PutProductType_Request();
            List<Rule_PutProductType_Request> updateRule = new List<Rule_PutProductType_Request> { updateRules };
            updateProductType.Rules = updateRule;
            updateRules.State = "string";
            updateRules.MaxAllowedAmount = 10;
            updateRules.MaxAllowedFormula = "string";
            updateRules.IsAllowed = true;
            updateRules.MaxTerm = 0;
            string payloadPut = JsonConvert.SerializeObject(updateProductType, Formatting.Indented);
            RestRequest requestPut = helper.CreatePutRequest(payloadPut, acessToken);
            /// Act
            IRestResponse responsePut = helper.GetResponse(clientPut, requestPut);
            var responseContentPut = helper.GetContent<ProductTypesType_PostProductType_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responsePut.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContentPut.Id, Is.EqualTo(Id));
                Assert.That(responseContentPut.Name, Is.EqualTo(Name));
            });
        }
        [Test]
        public void ProductService_ProductTypesType_ProductTypeById_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/producttypes");
            string Name = helper.GenerateDocName(5);
            ProductTypesType_PostProductType_Request productType = new ProductTypesType_PostProductType_Request();
            productType.Name = Name;
            Rule_PostProductType_Request rule = new Rule_PostProductType_Request();
            List<Rule_PostProductType_Request> rules = new List<Rule_PostProductType_Request> { rule };
            productType.Rules = rules;
            rule.State = "string";
            rule.MaxAllowedAmount = 0;
            rule.MaxAllowedFormula = "string";
            rule.IsAllowed = true;
            rule.MaxTerm = 0;
            string payload = JsonConvert.SerializeObject(productType, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<ProductTypesType_PostProductType_Response>(response);
            string Id = responseContent.Id;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient clientGet = helper.SetUrl("product-service/producttypes/" + Id);
            RestRequest requestGet = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse responseGet = helper.GetResponse(clientGet, requestGet);
            var responseContentGet = helper.GetContent<ProductTypesType_PostProductType_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseGet.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContentGet.Id, Is.EqualTo(Id));
                Assert.That(responseContentGet.Name, Is.EqualTo(Name));
            });
        }
        [Test]
        public void ProductService_ProductTypesType_DeletedProductType_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/producttypes");
            string Name = helper.GenerateDocName(5);
            ProductTypesType_PostProductType_Request productType = new ProductTypesType_PostProductType_Request();
            productType.Name = Name;
            Rule_PostProductType_Request rule = new Rule_PostProductType_Request();
            List<Rule_PostProductType_Request> rules = new List<Rule_PostProductType_Request> { rule };
            productType.Rules = rules;
            rule.State = "string";
            rule.MaxAllowedAmount = 0;
            rule.MaxAllowedFormula = "string";
            rule.IsAllowed = true;
            rule.MaxTerm = 0;
            string payload = JsonConvert.SerializeObject(productType, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<ProductTypesType_PostProductType_Response>(response);
            string Id = responseContent.Id;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient clientDelete = helper.SetUrl("product-service/producttypes/" + Id);
            RestRequest requestDelete = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse responseDelete = helper.GetResponse(clientDelete, requestDelete);
            /// Assert
            Assert.That(responseDelete.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void ProductService_ProviderProductTypeRuleType_GetProviderProductTypesRules_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/providers/" + ProviderIdLender + "/productTypes/" + ProductTypeIdProduct + "/rules");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ProductService_ProviderProductTypeRuleType_PostProviderProductTypesRules_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/providers/" + ProviderIdLender + "/productTypes/" + ProductTypeIdProduct + "/rules");
            ProviderProductTypeRuleType_PostProviderProductTypesRules_Request providerProductTypeRule = new ProviderProductTypeRuleType_PostProviderProductTypesRules_Request()
            {
                AssetTypes = "string",
                StartDate = DateTime.Now,
                EndDate = DateTime.Today,
                IlendingCostAmount = 0,
                IlendingCostFormula = "string",
                PackAmount = 0,
                PackFormula = "string",
                MarkupAmount = 0,
                MarkupFormula = "string",
                State = "string",
                MinTerm = 0,
                MaxTerm = 0,
                MinMileage = "string",
                MaxMileage = "string",
                MinYear = "string",
                MaxYear = "string"
            };
            string payload = JsonConvert.SerializeObject(providerProductTypeRule, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ProductService_ProviderProductTypeRuleType_DeleteProviderProductTypesRules_NegativeScenario_InvalidId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/providers/" + ProviderIdLender + "/productTypes/" + ProductTypeIdProduct + "/rules/" + DealProductIdProductInvalid);
            RestRequest request = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContentGet = helper.GetContent<NegativeScenario_ProductService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContentGet.Message, Is.EqualTo("Rule not be found to update productProviderRuleId " + DealProductIdProductInvalid));
                Assert.That(responseContentGet.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void ProductService_ProviderProductTypeRuleType_PutProviderProductTypesRules_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/providers/" + ProviderIdLender + "/productTypes/" + ProductTypeIdProduct + "/rules/" + DealProductIdProductInvalid);
            ProviderProductTypeRuleType_PutProviderProductTypesRules_Request providerProductRule = new ProviderProductTypeRuleType_PutProviderProductTypesRules_Request()
            {
                Id = DealProductIdProductInvalid,
                ProviderId = ProviderIdLender,
                ProductTypeId = ProductTypeIdProduct,
                AssetTypes = "string",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                IlendingCostAmount = 10,
                IlendingCostFormula = "string",
                PackAmount = 0,
                PackFormula = "string",
                MarkupAmount = 0,
                MarkupFormula = "string",
                State = "string",
                MinTerm = 0,
                MaxTerm = 0,
                MinMileage = "string",
                MaxMileage = "string",
                MinYear = "string",
                MaxYear = "string"
            };
            string payload = JsonConvert.SerializeObject(providerProductRule, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ProductService_ProviderProductTypeRuleType_GetSchedules_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/providers/" + ProviderIdLender + "/productTypes/" + ProductTypeIdProduct + "/schedules");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ProductService_ProviderProductTypeRuleType_ApiProvidersRuleVariables_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/api/providers/rulevariables");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ProductService_ProviderType_GetProvider_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/providers");
            RestRequest request = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void ProductService_ProvidersType_PostProvider_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/providers");
            string Name = helper.GenerateDocName(5);
            string Address = helper.GenerateDocName(5);
            ProvidersType_PostProvider_Request createProvider = new ProvidersType_PostProvider_Request();
            createProvider.Name = Name;
            createProvider.Address = Address;
            ProductTypeItem_PostProvider_Request productType = new ProductTypeItem_PostProvider_Request();
            List<ProductTypeItem_PostProvider_Request> productTypeItems = new List<ProductTypeItem_PostProvider_Request> { productType };
            createProvider.ProductTypeItems = productTypeItems;
            productType.Id = ProductTypeId;
            string payload = JsonConvert.SerializeObject(createProvider, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContentGet = helper.GetContent<ProvidersType_PostProvider_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContentGet.Name, Is.EqualTo(Name));
                Assert.That(responseContentGet.Address, Is.EqualTo(Address));
            });
        }
        [Test]
        public void ProductService_ProvidersType_PostProvider_NegativeScenario_InvalidProductId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/providers");
            string Name = helper.GenerateDocName(5);
            string Address = helper.GenerateDocName(5);
            ProvidersType_PostProvider_Request createProvider = new ProvidersType_PostProvider_Request();
            createProvider.Name = Name;
            createProvider.Address = Address;
            ProductTypeItem_PostProvider_Request productType = new ProductTypeItem_PostProvider_Request();
            List<ProductTypeItem_PostProvider_Request> productTypeItems = new List<ProductTypeItem_PostProvider_Request> { productType };
            createProvider.ProductTypeItems = productTypeItems;
            productType.Id = DealProductIdProductInvalid;
            string payload = JsonConvert.SerializeObject(createProvider, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContentGet = helper.GetContent<NegativeScenario_ProductService>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContentGet.Message, Is.EqualTo("Key: model : Message Product types " + DealProductIdProductInvalid + " is in valid\n"));
                Assert.That(responseContentGet.Code, Is.EqualTo("BadRequest"));
            });
        }
        [Test]
        public void ProductService_ProvidersType_PutProvider_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/providers");
            string Name = helper.GenerateDocName(5);
            string Address = helper.GenerateDocName(5);
            ProvidersType_PostProvider_Request createProvider = new ProvidersType_PostProvider_Request();
            createProvider.Name = Name;
            createProvider.Address = Address;
            ProductTypeItem_PostProvider_Request productType = new ProductTypeItem_PostProvider_Request();
            List<ProductTypeItem_PostProvider_Request> productTypeItems = new List<ProductTypeItem_PostProvider_Request> { productType };
            createProvider.ProductTypeItems = productTypeItems;
            productType.Id = ProductTypeId;
            string payload = JsonConvert.SerializeObject(createProvider, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContentGet = helper.GetContent<ProvidersType_PostProvider_Response>(response);
            string Id = responseContentGet.Id;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient clientPut = helper.SetUrl("product-service/providers");
            string AddressPut = helper.GenerateDocName(4);
            ProvidersType_PutProvider_Request updateProvider = new ProvidersType_PutProvider_Request();
            updateProvider.Id = Id;
            updateProvider.Name = Name;
            updateProvider.Address = AddressPut;
            ProductTypeItem_PutProvider_Request updateProductType = new ProductTypeItem_PutProvider_Request();
            List<ProductTypeItem_PutProvider_Request> productTypeItemsPut = new List<ProductTypeItem_PutProvider_Request> { updateProductType };
            updateProvider.ProductTypeItems = productTypeItemsPut;
            updateProductType.Id = ProductTypeId;
            string payloadPut = JsonConvert.SerializeObject(updateProvider, Formatting.Indented);
            RestRequest requestPut = helper.CreatePutRequest(payloadPut, acessToken);
            /// Act
            IRestResponse responsePut = helper.GetResponse(clientPut, requestPut);
            var responseContentPut = helper.GetContent<ProvidersType_PutProvider_Response>(responsePut);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responsePut.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContentPut.Id, Is.EqualTo(Id));
                Assert.That(responseContentPut.Address, Is.EqualTo(AddressPut));
            });
        }
        [Test]
        public void ProductService_ProvidersType_PutProvider_NegativeScenario_InvalidProductTypeItemId()
        {
            /// Arrange
            RestClient clientPut = helper.SetUrl("product-service/providers");
            string AddressPut = helper.GenerateDocName(4);
            ProvidersType_PutProvider_Request updateProvider = new ProvidersType_PutProvider_Request();
            updateProvider.Id = DealProductIdProductInvalid;
            updateProvider.Name = "string";
            updateProvider.Address = AddressPut;
            ProductTypeItem_PutProvider_Request updateProductType = new ProductTypeItem_PutProvider_Request();
            List<ProductTypeItem_PutProvider_Request> productTypeItemsPut = new List<ProductTypeItem_PutProvider_Request> { updateProductType };
            updateProvider.ProductTypeItems = productTypeItemsPut;
            updateProductType.Id = DealProductIdProductInvalid;
            string payloadPut = JsonConvert.SerializeObject(updateProvider, Formatting.Indented);
            RestRequest requestPut = helper.CreatePutRequest(payloadPut, acessToken);
            /// Act
            IRestResponse responsePut = helper.GetResponse(clientPut, requestPut);
            var responseContentGet = helper.GetContent<NegativeScenario_ProductService>(responsePut);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responsePut.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContentGet.Message, Is.EqualTo("Provider could not be found to update " + DealProductIdProductInvalid));
                Assert.That(responseContentGet.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void ProductService_ProvidersType_GetProviderById_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/providers");
            string Name = helper.GenerateDocName(5);
            string Address = helper.GenerateDocName(5);
            ProvidersType_PostProvider_Request createProvider = new ProvidersType_PostProvider_Request();
            createProvider.Name = Name;
            createProvider.Address = Address;
            ProductTypeItem_PostProvider_Request productType = new ProductTypeItem_PostProvider_Request();
            List<ProductTypeItem_PostProvider_Request> productTypeItems = new List<ProductTypeItem_PostProvider_Request> { productType };
            createProvider.ProductTypeItems = productTypeItems;
            productType.Id = ProductTypeId;
            string payload = JsonConvert.SerializeObject(createProvider, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContentGet = helper.GetContent<ProvidersType_PostProvider_Response>(response);
            string Id = responseContentGet.Id;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient clientGet = helper.SetUrl("product-service/providers/" + Id);
            RestRequest requestGet = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse responseGet = helper.GetResponse(clientGet, requestGet);
            var responseContent = helper.GetContent<ProductTypesType_PostProductType_Response>(responseGet);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseGet.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Id, Is.EqualTo(Id));
                Assert.That(responseContent.Name, Is.EqualTo(Name));
            });
        }
        [Test]
        public void ProductService_ProvidersType_GetProviderById_NegativeScenario_InvalidId()
        {
            /// Arrange
            RestClient clientGet = helper.SetUrl("product-service/providers/" + DealProductIdProductInvalid);
            RestRequest requestGet = helper.CreateGetRequest(acessToken);
            /// Act
            IRestResponse responseGet = helper.GetResponse(clientGet, requestGet);
            var responseContentGet = helper.GetContent<NegativeScenario_ProductService>(responseGet);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseGet.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContentGet.Message, Is.EqualTo("Provider could not be found to update " + DealProductIdProductInvalid));
                Assert.That(responseContentGet.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void ProductService_ProvidersType_DeleteProvider_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/providers");
            string Name = helper.GenerateDocName(5);
            string Address = helper.GenerateDocName(5);
            ProvidersType_PostProvider_Request createProvider = new ProvidersType_PostProvider_Request();
            createProvider.Name = Name;
            createProvider.Address = Address;
            ProductTypeItem_PostProvider_Request productType = new ProductTypeItem_PostProvider_Request();
            List<ProductTypeItem_PostProvider_Request> productTypeItems = new List<ProductTypeItem_PostProvider_Request> { productType };
            createProvider.ProductTypeItems = productTypeItems;
            productType.Id = ProductTypeId;
            string payload = JsonConvert.SerializeObject(createProvider, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContentGet = helper.GetContent<ProvidersType_PostProvider_Response>(response);
            string Id = responseContentGet.Id;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient clientDelete = helper.SetUrl("product-service/providers/" + Id);
            RestRequest requestDelete = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse responseDelete = helper.GetResponse(clientDelete, requestDelete);
            /// Assert
            Assert.That(responseDelete.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void ProductService_ProvidersType_DeleteProvider_NegativeScenario_InvalidId()
        {
            /// Arrange
            RestClient clientDelete = helper.SetUrl("product-service/providers/" + DealProductIdProductInvalid);
            RestRequest requestDelete = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse responseDelete = helper.GetResponse(clientDelete, requestDelete);
            var responseContentGet = helper.GetContent<NegativeScenario_ProductService>(responseDelete);
            /// Assert
            Assert.That(responseDelete.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
            Assert.That(responseContentGet.Message, Is.EqualTo("Provider could not be found to update " + DealProductIdProductInvalid));
            Assert.That(responseContentGet.Code, Is.EqualTo("NotFound"));
        }
        [Test]
        public void ProductService_ProvidersType_PostByProvidersAndByProductTypes_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/producttypes");
            string Name = helper.GenerateDocName(5);
            ProductTypesType_PostProductType_Request createProvider = new ProductTypesType_PostProductType_Request();
            createProvider.Name = Name;
            Rule_PostProductType_Request productType = new Rule_PostProductType_Request();
            List<Rule_PostProductType_Request> rules = new List<Rule_PostProductType_Request> { productType };
            createProvider.Rules = rules;
            productType.State = "string";
            productType.MaxAllowedAmount = 0;
            productType.MaxAllowedFormula = "string";
            productType.IsAllowed = true;
            productType.MaxTerm = 0;
            string payload = JsonConvert.SerializeObject(createProvider, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<ProductTypesType_PostProductType_Response>(response);
            string ProductTypeIdPost = responseContent.Id;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient clientProvider = helper.SetUrl("product-service/providers");
            string Address = helper.GenerateDocName(5);
            ProvidersType_PostProvider_Request updateProvider = new ProvidersType_PostProvider_Request();
            updateProvider.Name = Name;
            updateProvider.Address = Address;
            ProductTypeItem_PostProvider_Request updateProductType = new ProductTypeItem_PostProvider_Request();
            List<ProductTypeItem_PostProvider_Request> productTypeItemsPost = new List<ProductTypeItem_PostProvider_Request> { updateProductType };
            updateProvider.ProductTypeItems = productTypeItemsPost;
            updateProductType.Id = ProductTypeId;
            string payloadProvider = JsonConvert.SerializeObject(updateProvider, Formatting.Indented);
            RestRequest requestProvider = helper.CreatePostRequest(payloadProvider, acessToken);
            IRestResponse responseProvider = helper.GetResponse(clientProvider, requestProvider);
            var responseContentGet = helper.GetContent<ProvidersType_PostProvider_Response>(responseProvider);
            string ProviderId = responseContentGet.Id;
            Assert.That(responseProvider.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient clientPost = helper.SetUrl("product-service/providers/" + ProviderId + "/productTypes/" + ProductTypeIdPost);
            RestRequest requestPost = helper.CreatePostRequestWithoutBody(acessToken);
            /// Act
            IRestResponse responsePost = helper.GetResponse(clientPost, requestPost);
            var responseContentPost = helper.GetContent<ProductTypesType_PostProductType_Response>(responsePost);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responsePost.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContentPost.Id, Is.EqualTo(ProviderId));
                Assert.That(responseContentPost.Name, Is.EqualTo(Name));
            });
        }
        [Test]
        public void ProductService_ProvidersType_PostByProvidersAndByProductTypes_NegativeScenario_InvalidId()
        {
            /// Arrange
            RestClient clientPost = helper.SetUrl("product-service/providers/" + ProductTypeId + "/productTypes/" + DealProductIdProductInvalid);
            RestRequest requestPost = helper.CreatePostRequestWithoutBody(acessToken);
            /// Act
            IRestResponse responsePost = helper.GetResponse(clientPost, requestPost);
            var responseContentGet = helper.GetContent<NegativeScenario_ProductService>(responsePost);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responsePost.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContentGet.Message, Is.EqualTo("Key: model : Message Product type " + DealProductIdProductInvalid + " is in valid\n"));
                Assert.That(responseContentGet.Code, Is.EqualTo("BadRequest"));
            });
        }
        [Test]
        public void ProductService_ProvidersType_DeleteByProvidersAndByProductTypes_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/producttypes");
            string Name = helper.GenerateDocName(5);
            ProductTypesType_PostProductType_Request createProvider = new ProductTypesType_PostProductType_Request();
            createProvider.Name = Name;
            Rule_PostProductType_Request productType = new Rule_PostProductType_Request();
            List<Rule_PostProductType_Request> rules = new List<Rule_PostProductType_Request> { productType };
            createProvider.Rules = rules;
            productType.State = "string";
            productType.MaxAllowedAmount = 0;
            productType.MaxAllowedFormula = "string";
            productType.IsAllowed = true;
            productType.MaxTerm = 0;
            string payload = JsonConvert.SerializeObject(createProvider, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<ProductTypesType_PostProductType_Response>(response);
            string ProductTypeIdPost = responseContent.Id;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            RestClient clientProvider = helper.SetUrl("product-service/providers");
            string Address = helper.GenerateDocName(5);
            ProvidersType_PostProvider_Request updateProvider = new ProvidersType_PostProvider_Request();
            updateProvider.Name = Name;
            updateProvider.Address = Address;
            ProductTypeItem_PostProvider_Request updateProductType = new ProductTypeItem_PostProvider_Request();
            List<ProductTypeItem_PostProvider_Request> productTypeItemsPost = new List<ProductTypeItem_PostProvider_Request> { updateProductType };
            updateProvider.ProductTypeItems = productTypeItemsPost;
            updateProductType.Id = ProductTypeId;
            string payloadProvider = JsonConvert.SerializeObject(updateProvider, Formatting.Indented);
            RestRequest requestProvider = helper.CreatePostRequest(payloadProvider);
            IRestResponse responseProvider = helper.GetResponse(clientProvider, requestProvider);
            var responseContentGet = helper.GetContent<ProvidersType_PostProvider_Response>(responseProvider);
            string ProviderId = responseContentGet.Id;
            Assert.That(responseProvider.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient clientDelete = helper.SetUrl("product-service/providers/" + ProviderId + "/productTypes/" + ProductTypeIdPost);
            RestRequest requestDelete = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse responseDelete = helper.GetResponse(clientDelete, requestDelete);
            /// Assert
            Assert.That(responseDelete.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void ProductService_ProvidersType_DeleteByProvidersAndByProductTypes_NegativeScenario_WithoutAddingProductTypeToProvider()
        {
            /// Arrange
            RestClient client = helper.SetUrl("product-service/producttypes");
            string Name = helper.GenerateDocName(5);
            ProductTypesType_PostProductType_Request createProvider = new ProductTypesType_PostProductType_Request();
            createProvider.Name = Name;
            Rule_PostProductType_Request productType = new Rule_PostProductType_Request();
            List<Rule_PostProductType_Request> rules = new List<Rule_PostProductType_Request> { productType };
            createProvider.Rules = rules;
            productType.State = "string";
            productType.MaxAllowedAmount = 0;
            productType.MaxAllowedFormula = "string";
            productType.IsAllowed = true;
            productType.MaxTerm = 0;
            string payload = JsonConvert.SerializeObject(createProvider, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload, acessToken);
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<ProductTypesType_PostProductType_Response>(response);
            string ProductTypeIdPost = responseContent.Id;
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient clientProvider = helper.SetUrl("product-service/providers");
            string Address = helper.GenerateDocName(5);
            ProvidersType_PostProvider_Request updateProvider = new ProvidersType_PostProvider_Request();
            updateProvider.Name = Name;
            updateProvider.Address = Address;
            ProductTypeItem_PostProvider_Request updateProductType = new ProductTypeItem_PostProvider_Request();
            List<ProductTypeItem_PostProvider_Request> productTypeItemsPost = new List<ProductTypeItem_PostProvider_Request> { updateProductType };
            updateProvider.ProductTypeItems = productTypeItemsPost;
            updateProductType.Id = ProductTypeId;
            string payloadProvider = JsonConvert.SerializeObject(updateProvider, Formatting.Indented);
            RestRequest requestProvider = helper.CreatePostRequest(payloadProvider, acessToken);
            IRestResponse responseProvider = helper.GetResponse(clientProvider, requestProvider);
            var responseContentGet = helper.GetContent<ProvidersType_PostProvider_Response>(responseProvider);
            string ProviderId = responseContentGet.Id;
            Assert.That(responseProvider.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            RestClient clientDelete = helper.SetUrl("product-service/providers/" + ProviderId + "/productTypes/" + ProductTypeIdPost);
            RestRequest requestDelete = helper.CreateDeleteRequest(acessToken);
            /// Act
            IRestResponse responseDelete = helper.GetResponse(clientDelete, requestDelete);
            var responseContentDel = helper.GetContent<NegativeScenario_ProductService>(responseDelete);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseDelete.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContentDel.Message, Is.EqualTo("Key: model : Message Provider " + ProviderId + " does not associate with product type " + ProductTypeIdPost + "\n"));
                Assert.That(responseContentDel.Code, Is.EqualTo("BadRequest"));
            });
        }
    }
}
