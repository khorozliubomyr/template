
using Newtonsoft.Json;
using NUnit.Framework;
using Phoenix2.APITests.DTO;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static Phoenix2.APITests.Credentials;
using System.Configuration;
using Phoenix2.APITests.DTO.DocumentServiceDTO;
using Phoenix2.APITests.Framework;

namespace Phoenix2.APITests.Tests
{
    class DocumentService
    {
        private APIHelper<string> helper;
        [SetUp]
        public void APIHelper()
        {
            helper = new APIHelper<string>();
        }
        [Test]
        public void DocumentService_DocumentType_LenderDocumentTypesDocuments_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + lenderCode + "/document-types/" + DocumentTypeId + "/documents");
            RestRequest request = helper.UploadFile(@"Attachments/PdfSample.pdf");
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DocumentType_LenderDocumentTypesDocuments_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.IsActive, Is.EqualTo(true));
            });
        }
        [Test]
        [TestCase(DocumentTypeId, InvalidLenderCode)]
        [TestCase(InvalidDocumentTypeId, lenderCode)]
        [TestCase(InvalidDocumentTypeId, InvalidLenderCode)]
        public void DocumentService_DocumentType_LenderDocumentTypesDocuments_NegativeScenario(string DocumentTypeId, string LenderCode)
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + DocumentTypeId + "/document-types/" + LenderCode + "/documents");
            RestRequest request = helper.UploadFile(@"Attachments/PdfSample.pdf");
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
        [Test]
        public void DocumentService_DocumentType_LenderDocumentTypesDocuments_WithoutFile()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + lenderCode + "/document-types/" + DocumentTypeId + "/documents");
            RestRequest request = new RestRequest(Method.POST);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DocumentService_Document_NegativeResponse>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Title, Is.EqualTo("One or more validation errors occurred."));
                Assert.That(responseContent.Status, Is.EqualTo("400"));
            });
        }
        [Test]
        public void DocumentService_DocumentType_LenderDocumentTypesDocuments_NegativeScenario_IncorrectFile_TxtExtension()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + lenderCode + "/document-types/" + DocumentTypeId + "/documents");
            RestRequest request = helper.UploadFile(@"Attachments/TxtSample.txt");
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DocumentService_Document_NegativeResponse>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Message, Is.EqualTo("Key: model : Message Uploading file with extension: '.txt' is not allowed\n"));
                Assert.That(responseContent.Code, Is.EqualTo("BadRequest"));
            });
        }
        [Test]
        public void DocumentService_DocumentType_LenderDocumentTypesDocuments_NegativeScenario_IncorrectFile_DocExtension()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + lenderCode + "/document-types/" + DocumentTypeId + "/documents");
            RestRequest request = helper.UploadFile(@"Attachments/DocSample.doc");
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DocumentService_Document_NegativeResponse>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseContent.Message, Is.EqualTo("Key: model : Message Uploading file with extension: '.doc' is not allowed\n"));
                Assert.That(responseContent.Code, Is.EqualTo("BadRequest"));
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
            });
        }
        [Test]
        public void DocumentService_DocumentType_LenderDocumentTypesDocuments_NegativeScenario_IncorrectFile_MoreThan30Mb()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + lenderCode + "/document-types/" + DocumentTypeId + "/documents");
            RestRequest request = helper.UploadFile(@"Attachments/PdfSampleForInvalidDocumentSize.pdf");
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DocumentService_Document_NegativeResponse>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Title, Is.EqualTo("One or more validation errors occurred."));
            });
        }
        [Test]
        public void DocumentService_DocumentType_GetLenderDocumentTypesDocuments_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + lenderCode + "/document-types/" + DocumentTypeId + "/documents");
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        [TestCase(lenderCode, InvalidDocumentTypeId)]
        [TestCase(InvalidLenderCode, DocumentTypeId)]
        [TestCase(InvalidLenderCode, InvalidDocumentTypeId)]
        public void DocumentService_DocumentType_GetLenderDocumentTypesDocuments_NegativeScenario(string LenderCode, string DocumentTypeId)
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + LenderCode + "/document-types/" + DocumentTypeId + "/documents");
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DocumentType_GetLenderDocumentTypesDocuments_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.DocumentService.Domain.Entities.DocumentType with id '" + DocumentTypeId + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void DocumentService_DocumentType_DocumentsFiles_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/documents/files");
            RestRequest request = helper.CreateGetRequest();
            request.AddParameter("FileName", FileName);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DocumentType_DocumentsFiles_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Path, Is.EqualTo(FileName));
                Assert.That(responseContent.Type, Is.EqualTo("PDF"));
            });
        }

        [Test]
        public void DocumentService_DocumentType_DocumentsFiles_NegativeScenario_InvalidFileName()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/documents/files");
            RestRequest request = helper.CreateGetRequest();
            request.AddParameter("FileName", InvalidFileName);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DocumentType_DocumentsFiles_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Blob with name: " + InvalidFileName + " in container documents not found."));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void DocumentService_DocumentType_DocumentsGenerate_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/documents/generate");
            DocumentType_DocumentsGenerate_RequestBody generateDocument = new DocumentType_DocumentsGenerate_RequestBody()
            {
                DealId = DealId,
                UserId = "198",
                DocumentGenerationType = "Lender",
                IgnoreProducts = true,
                FilterDocumentTypeIds = new List<string> { "33e5fc65-4ae2-4d41-9d38-4125e9c1fd1a" }
            };
            string payload = JsonConvert.SerializeObject(generateDocument, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DocumentType_DocumentsGenerate_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.IsTrue(responseContent.FilePath.Contains("DocGen/GeneratedDocuments/4363/Deal4363_Lender_Da"));
            });
        }
        [Test]
        public void DocumentService_DocumentType_DocumentsGenerate_NegativeScenario_InvalidDealId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/documents/generate");
            DocumentType_DocumentsGenerate_RequestBody generateDocument = new DocumentType_DocumentsGenerate_RequestBody()
            {
                DealId = InvalidDealId,
                UserId = userId,
                DocumentGenerationType = documentGenerationType,
                IgnoreProducts = true,
                FilterDocumentTypeIds = new List<string> { "string" }
            };
            string payload = JsonConvert.SerializeObject(generateDocument, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DocumentType_DocumentsGenerate_Response_NegativeScenario>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void DocumentService_DocumentType_DocumentTypes_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/documents/" + dealId + "/documenttypes?documentGeneratedType=1");
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        [TestCase(InvalidDealId, documentGeneratedType)]
        [TestCase(dealId, InvalidDocumentGeneratedType)]
        [TestCase(InvalidDealId, InvalidDocumentGeneratedType)]
        public void DocumentService_DocumentType_DocumentTypes_NegativeScenario(string DealId, string DocumentGeneratedType)
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/documents/" + DealId + "/documenttypes?documentGeneratedType=" + DocumentGeneratedType);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DocumentType_DocumentTypes_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void DocumentService_DocumentType_Generated_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/documents/" + DealId + "/generated");
            RestRequest request = helper.CreateGetRequest();
            request.AddParameter("documentGeneratedType", "1");
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        [TestCase(InvalidDealId, documentGeneratedType)]
        [TestCase(dealId, InvalidDocumentGeneratedType)]
        [TestCase(InvalidDealId, InvalidDocumentGeneratedType)]
        public void DocumentService_DocumentType_Generated_NegativeScenario(string DealId, string DocumentGeneratedType)
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/documents/" + DealId + "/generated?documentGeneratedType=" + DocumentGeneratedType);
            RestRequest request = helper.CreateGetRequest();
            request.AddParameter("documentGeneratedType", "1");
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DocumentType_Generated_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }
        [Test]
        public void DocumentService_DocumentType_CloneFields_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/document-types/" + DocumentTypeId + "/documents/" + Id + "/clone-fields");
            string payload = helper.Serialize
                (new
                {
                    ToDocumentTypeId = "1ed8eecf-00f2-40ff-a020-58fe8e088afb",
                    ToDocumentId = "08e69abc-94b3-41d7-bb9f-bc6792e4d26d",
                    IncludeDocusignFields = false

                });
            RestRequest request = helper.CreatePostRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        [TestCase(Id, InvalidDocumentTypeId)]
        [TestCase(InvalidId, DocumentTypeId)]
        [TestCase(InvalidId, InvalidDocumentTypeId)]
        public void DocumentService_DocumentType_CloneFields_NegativeScenario(string Id, string DocumentTypeId)
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/document-types/" + DocumentTypeId + "/documents/" + Id + "/clone-fields");
            string payload = helper.Serialize
                (new
                {
                    ToDocumentTypeId = "f8496b44-7d39-4ed0-a276-36ad3a0a4689",
                    ToDocumentId = "51374503-9963-4df6-970d-0dd5ae64f6ee",
                    IncludeDocusignFields = true

                });
            RestRequest request = helper.CreatePostRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
        [Test]
        public void DocumentService_DocumentType_CloneFields_NegativeScenario_InvalidRequestBody()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/document-types/" + DocumentTypeId + "/documents/" + Id + "/clone-fields");
            string payload = helper.Serialize
                (new
                {
                    ToDocumentTypeId = "f8496b44-7d39-4ed0-a276-36ad3a0a4111",
                    ToDocumentId = "51374503-9963-4df6-970d-0dd5ae64f111",
                    IncludeDocusignFields = true

                });
            RestRequest request = helper.CreatePostRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
        [Test]
        public void DocumentService_DocumentType_LenderDocumentsTypesDocumentsVersion_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + lenderCode + "/document-types/" + DocumentTypeId + "/documents/" + Id + "/activate");
            RestRequest request = new RestRequest(Method.POST);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        [TestCase(lenderCode, Id, InvalidDocumentTypeId)]
        [TestCase(lenderCode, InvalidId, DocumentTypeId)]
        [TestCase(InvalidLenderCode, Id, DocumentTypeId)]
        [TestCase(InvalidLenderCode, InvalidId, InvalidDocumentTypeId)]
        public void DocumentService_DocumentType_LenderDocumentsTypesDocumentsVersion_NegativeScenario(string LenderCode, string Id, string DocumentTypeId)
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + LenderCode + "/document-types/" + Id + "/documents/" + DocumentTypeId + "/activate");
            RestRequest request = new RestRequest(Method.POST);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void DocumentService_DocumentType_DocumentTypesDocument_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/document-types/" + DocumentTypeId + "/document");
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DocumentType_DocumentTypesDocument_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(responseContent.Id, Is.EqualTo("bc118b8b-714c-4041-9d9a-fee543a3492a"));
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            });
        }
        [Test]
        public void DocumentService_DocumentType_DocumentTypesDocument_NegativeScenario_InvalidDocumentTypeId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/document-types/" + InvalidDocumentTypeId + "/document");
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DocumentType_DocumentTypesDocument_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
                Assert.That(responseContent.Message, Is.EqualTo("Document Type with " + InvalidDocumentTypeId + " guid is not found"));
            });
        }

        [Test]
        public void DocumentService_DocumentType_PutDocumentTypesDocument_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/document-types/" + DocumentTypeId + "/documents/" + Id);
            DocumentType_PutDocumentTypesDocument_Request documentTypes = new DocumentType_PutDocumentTypesDocument_Request();
            Field_PutDocumentTypesDocument_Request field = new Field_PutDocumentTypesDocument_Request();
            field.PdfField = "string";
            field.MappedFieldId = "string";
            field.TextValue = "string";
            Condition_PutDocumentTypesDocument_Request condition = new Condition_PutDocumentTypesDocument_Request();
            condition.MappedFieldId = "string";
            condition.ConditionType = "Equal";
            condition.Value = "string";
            condition.ValueType = "Text";
            List<Condition_PutDocumentTypesDocument_Request> conditions = new List<Condition_PutDocumentTypesDocument_Request> { condition };
            field.Conditions = conditions;
            DocusignField_PutDocumentTypesDocument_Request docusignField = new DocusignField_PutDocumentTypesDocument_Request();
            docusignField.X = 0;
            docusignField.Y = 0;
            docusignField.Width = 0;
            docusignField.Height = 0;
            docusignField.Page = 0;
            docusignField.TextValue = "string";
            docusignField.Conditions = conditions;
            List<Field_PutDocumentTypesDocument_Request> fields = new List<Field_PutDocumentTypesDocument_Request> { field };
            documentTypes.Fields = fields;
            List<DocusignField_PutDocumentTypesDocument_Request> docusignFields = new List<DocusignField_PutDocumentTypesDocument_Request> { docusignField };
            documentTypes.DocusignFields = docusignFields;
            string payload = JsonConvert.SerializeObject(documentTypes, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void DocumentService_DocumentType_GetDocumentsTitledocgenindex_PositiveScenario()
        {
            /// Arrange
            RestClient PostClient = helper.SetUrl("document-service/documents/" + dealId + "/titledocgenindex");
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(PostClient, request);
            var responseContent = helper.GetContent<DocumentType_GetDocumentsTitledocgenindex_Response>(response);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(responseContent.DealId, Is.EqualTo(dealId));
        }
        [Test]
        public void DocumentService_DocumentType_GetDocumentsTitledocgenindex_NegativeScenario_InvalidDealId()
        {
            /// Arrange
            RestClient PostClient = helper.SetUrl("document-service/documents/" + InvalidDealId + "/titledocgenindex");
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(PostClient, request);
            var responseContent = helper.GetContent<DocumentType_GetDocumentsTitledocgenindex_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Title document generation index not found for " + InvalidDealId));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void DocumentService_DocumentType_PostDocumentsTitledocgenindex_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/documents/titledocgenindex");
            DocumentType_PostDocumentsTitledocgenindex_Request titleDocgenIndex = new DocumentType_PostDocumentsTitledocgenindex_Request();
            titleDocgenIndex.DealId = dealId;
            titleDocgenIndex.TitleDocGeneration = true;
            Item_PostDocumentsTitledocgenindex_Request item = new Item_PostDocumentsTitledocgenindex_Request();
            item.DocumentName = "string";
            item.IsReceived = true;
            Comment_PostDocumentsTitledocgenindex_Request comment = new Comment_PostDocumentsTitledocgenindex_Request();
            comment.Comment = "string";
            comment.CreatedById = "string";
            comment.CreatedDate = DateTime.Now;
            List<Item_PostDocumentsTitledocgenindex_Request> items = new List<Item_PostDocumentsTitledocgenindex_Request> { item };
            titleDocgenIndex.Items = items;
            titleDocgenIndex.Comment = comment;
            string payload = JsonConvert.SerializeObject(titleDocgenIndex, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DocumentType_PostDocumentsTitledocgenindex_Request>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.DealId, Is.EqualTo(dealId));
            });
        }

        [Test]
        public void DocumentService_DocumentSetType_DocumentByLenderCode_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/documentset/" + LenderCodeForDocSet + "/" + DocumentSetType);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DocumentSetType_DocumentByLenderCode_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.LenderCode, Is.EqualTo(LenderCodeForDocSet));
                Assert.That(responseContent.DocumentSetType, Is.EqualTo(DocumentSetType));
            });
        }
        [Test]
        [TestCase(LenderCodeForDocSet, InvalidDocumentSetType)]
        [TestCase(InvalidLenderCode, DocumentSetType)]
        [TestCase(InvalidLenderCode, InvalidDocumentSetType)]
        public void DocumentService_DocumentSetType_DocumentByLenderCode_NegativeScenario(string LenderCode, string DocumentSetType)
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/documentset/" + LenderCode + "/" + DocumentSetType);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<TypeStipType_GetStipType_Response_NegativeScenario>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void DocumentService_DocumentSetType_DocumentSetByDocumentGroup_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/documentsetbydocumentgroup/" + DocumentGroup + "/" + LenderCodeForDocSet + "/" + DocSetType);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }
        [Test]
        [TestCase(DocumentGroup, LenderCodeForDocSet, InvalidDocSetType)]
        [TestCase(InvalidDocumentGroup, LenderCodeForDocSet, DocSetType)]
        [TestCase(InvalidDocumentGroup, InvalidLenderCode, InvalidDocSetType)]
        public void DocumentService_DocumentSetType_DocumentSetByDocumentGroup_NegativeScenario(string DocumentGroup, string LenderCode, string DocSetType)
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/documentsetbydocumentgroup/" + DocumentGroup + "/" + LenderCode + "/" + DocSetType);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<TypeStipType_GetStipType_Response_NegativeScenario>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Code, Is.EqualTo("BadRequest"));
            });
        }

        [Test]
        public void DocumentService_DocumentSetType_GetDocument_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/documentset/" + DocSetId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }
        [Test]
        public void DocumentService_DocumentSetType_PostDocumentset_PositiveScenario()
        {
            /// Arrange
            string name = helper.GenerateDocName(2);
            RestClient client = helper.SetUrl("document-service/documentset/" + name);
            DocumentSetType_PostDocumentset_Request documentSetType = new DocumentSetType_PostDocumentset_Request();
            documentSetType.DocumentSetType = DocSetType;
            DocumentTypeForCreateAsync_PostDocumentset_Request documentType = new DocumentTypeForCreateAsync_PostDocumentset_Request();
            documentType.DocumentTypeId = "string";
            documentType.OrderNumber = 0;
            List<DocumentTypeForCreateAsync_PostDocumentset_Request> documentTypes = new List<DocumentTypeForCreateAsync_PostDocumentset_Request> { documentType };
            documentSetType.DocumentTypes = documentTypes;
            string payload = JsonConvert.SerializeObject(documentSetType, Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void DocumentService_DocumentSetType_PutDocumentset_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/documentset/" + lenderCode);
            DocumentSetType_PutDocumentset_Request documentSetType = new DocumentSetType_PutDocumentset_Request();
            documentSetType.DocumentSetId = DocSetId;
            documentSetType.IsDeleted = true;
            DocumentType_PutDocumentset_Request documentType = new DocumentType_PutDocumentset_Request();
            documentType.DocumentTypeId = "string";
            documentType.OrderNumber = 0;
            List<DocumentType_PutDocumentset_Request> documentTypes = new List<DocumentType_PutDocumentset_Request> { documentType };
            documentSetType.DocumentTypes = documentTypes;
            string payload = JsonConvert.SerializeObject(documentSetType, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }


        [Test]
        public void DocumentService_TypeDocumentType_GetLendersDocumentTypes_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + lenderCode + "/document-types");
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void DocumentService_TypeDocumentType_GetLendersDocumentTypes_NegativeScenario_InvalidLenderCode()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service//lenders/" + InvalidLenderCode + "/document-types");
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
        [Test]
        public void DocumentService_TypeDocumentType_PostLendersDocumentTypes_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + lenderCode + "/document-types");
            RestRequest request = helper.UploadFile(@"Attachments/PdfSample.pdf");
            string DocTypeName = helper.GenerateDocName(10);
            request.AddParameter("LenderId", "6");
            request.AddParameter("DocumentTypeName", DocTypeName);
            request.AddParameter("DirectoryName", "string1");
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<TypeDocumentType_PostLendersDocumentTypes_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.LenderCode, Is.EqualTo(lenderCode));
                Assert.That(responseContent.DirectoryName, Is.EqualTo("string1"));
            });
        }
        [Test]
        public void DocumentService_TypeDocumentType_PostLendersDocumentTypes_PositiveScenario_WithEmptyDirectoryName()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + lenderCode + "/document-types");
            RestRequest request = helper.UploadFile(@"Attachments/PdfSample.pdf");
            string DocTypeName = helper.GenerateDocName(10);
            request.AddParameter("LenderId", "6");
            request.AddParameter("DocumentTypeName", DocTypeName);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<TypeDocumentType_PostLendersDocumentTypes_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Name, Is.EqualTo(DocTypeName));
                Assert.That(responseContent.LenderCode, Is.EqualTo(lenderCode));
            });
        }
        [Test]
        public void DocumentService_TypeDocumentType_PostLendersDocumentTypes_NegativeScenario_ForAlreadyExistingDocType()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + lenderCode + "/document-types");
            RestRequest request = helper.UploadFile(@"Attachments/PdfSample.pdf");
            request.AddParameter("LenderId", "6");
            request.AddParameter("DocumentTypeName", "q");
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void DocumentService_TypeDocumentType_PostLendersDocumentTypes_NegativeScenario_IncorrectFile_TxtExtension()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + lenderCode + "/document-types");
            RestRequest request = helper.UploadFile(@"Attachments/TxtSample.txt");
            string DocTypeName = helper.GenerateDocName(10);
            request.AddParameter("LenderId", "6");
            request.AddParameter("DocumentTypeName", DocTypeName);
            request.AddParameter("DirectoryName", "string1");
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void DocumentService_TypeDocumentType_PostLendersDocumentTypes_NegativeScenario_IncorrectFile_DocExtension()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + lenderCode + "/document-types");
            RestRequest request = helper.UploadFile(@"Attachments/DocSample.doc");
            string DocTypeName = helper.GenerateDocName(10);
            request.AddParameter("LenderId", "6");
            request.AddParameter("DocumentTypeName", DocTypeName);
            request.AddParameter("DirectoryName", "string1");
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
        [Test]
        public void DocumentService_TypeDocumentType_PostLendersDocumentTypes_NegativeScenario_IncorrectFile_MoreThan30MbFile()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + lenderCode + "/document-types");
            RestRequest request = helper.UploadFile(@"Attachments/PdfSampleForInvalidDocumentSize.pdf");
            string DocTypeName = helper.GenerateDocName(10);
            request.AddParameter("LenderId", "6");
            request.AddParameter("DocumentTypeName", DocTypeName);
            request.AddParameter("DirectoryName", "string1");
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
        [Test]
        public void DocumentService_TypeDocumentType_DeleteLenderDocumentTypes_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + lenderCode + "/document-types");
            TypeDocumentType_DeleteLenderDocumentTypes_Request bulkDelet = new TypeDocumentType_DeleteLenderDocumentTypes_Request()
            {
                Ids = new List<string> { "db025ab4-8a5f-4fc5-a62a-1280d52cb5a5" }
            };
            string payload = JsonConvert.SerializeObject(bulkDelet, Formatting.Indented);
            RestRequest request = helper.CreateDeleteRequestWithBody(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        public void DocumentService_TypeDocumentType_DeleteLenderDocumentTypes_NegativeScenario_InvalidLenderCode()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + InvalidLenderCode + "/document-types");
            TypeDocumentType_DeleteLenderDocumentTypes_Request bulkDelet = new TypeDocumentType_DeleteLenderDocumentTypes_Request()
            {
                Ids = new List<string> { "db025ab4-8a5f-4fc5-a62a-1280d52cb5a5" }
            };
            string payload = JsonConvert.SerializeObject(bulkDelet, Formatting.Indented);
            RestRequest request = helper.CreateDeleteRequestWithBody(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }
        [Test]
        public void DocumentService_TypeDocumentType_GetLenderDocumentTypesById_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + lenderCode + "/document-types/" + DocumentTypeId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<TypeDocumentType_GetLenderDocumentTypesById_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Id, Is.EqualTo(DocumentTypeId));
                Assert.That(responseContent.LenderCode, Is.EqualTo(lenderCode));
            });
        }
        [Test]
        [TestCase(lenderCode, InvalidDocumentTypeId)]
        [TestCase(InvalidLenderCode, DocumentTypeId)]
        [TestCase(InvalidLenderCode, InvalidDocumentTypeId)]
        public void DocumentService_TypeDocumentType_GetLenderDocumentTypesById_NegativeScenario(string LenderCode, string Id)
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + LenderCode + "/document-types/" + Id);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
        [Test]
        public void DocumentService_TypeDocumentType_PatchLenderDocumentTypesById_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + lenderCode + "/document-types/" + DocumentTypeId);
            string DocName = helper.GenerateDocName(10);
            TypeDocumentType_PatchLenderDocumentTypesById_Request updateDocType = new TypeDocumentType_PatchLenderDocumentTypesById_Request()
            {
                DocumentTypeName = DocName
            };
            string payload = JsonConvert.SerializeObject(updateDocType, Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
        [Test]
        [TestCase(InvalidDocumentTypeId, lenderCode)]
        [TestCase(DocumentTypeId, InvalidLenderCode)]
        [TestCase(InvalidDocumentTypeId, InvalidLenderCode)]
        public void DocumentService_TypeDocumentType_PatchLenderDocumentTypesById_NegativeScenario(string LenderCode, string Id)
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + LenderCode + "/document-types/" + Id);
            string DocName = helper.GenerateDocName(10);
            string payload = helper.Serialize
            (new
            {
                DocumentTypeName = DocName
            });
            RestRequest request = helper.CreatePatchRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void DocumentService_TypeDocumentType_Version_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + lenderCode + "/document-types/" + DocumentTypeId + "/version");
            RestRequest request = helper.UploadFile(@"Attachments/PdfSample.pdf");
            request.AddParameter("IsSeparateForBacon", true);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<TypeDocumentType_GetLenderDocumentTypesById_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Id, Is.EqualTo(DocumentTypeId));
                Assert.That(responseContent.LenderCode, Is.EqualTo(lenderCode));
            });
        }

        [Test]
        [TestCase(InvalidDocumentTypeId, lenderCode)]
        [TestCase(DocumentTypeId, InvalidLenderCode)]
        [TestCase(InvalidDocumentTypeId, InvalidLenderCode)]
        public void DocumentService_TypeDocumentType_Version_NegativeScenario(string LenderCode, string Id)
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + LenderCode + "/document-types/" + Id + "/version");
            RestRequest request = helper.UploadFile(@"Attachments/PdfSample.pdf");
            request.AddParameter("IsSeparateForBacon", true);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void DocumentService_TypeDocumentType_ActiveDocument_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + lenderCode + "/document-types/" + DocumentTypeId + "/d8efb406-0fee-4960-972e-4c62fd095a4e");
            RestRequest request = helper.CreatePatchRequestWithoutBody();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void DocumentService_TypeDocumentType_Directory_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + lenderCode + "/document-types/directory");
            TypeDocumentType_Directory_Request bulkUpdataDirectory = new TypeDocumentType_Directory_Request();
            List<string> ids = new List<string> { DocumentTypeId };
            bulkUpdataDirectory.Ids = ids;
            bulkUpdataDirectory.NewDirectoryName = "string";
            string payload = JsonConvert.SerializeObject(bulkUpdataDirectory, Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void DocumentService_TypeDocumentType_Directory_NegativeScenario_InvalidIds()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + lenderCode + "/document-types/directory");
            TypeDocumentType_Directory_Request bulkUpdataDirectory = new TypeDocumentType_Directory_Request();
            List<string> ids = new List<string> { "9d9c8b9b-c9a2-4a6f-8916-00e8996632e0" };
            bulkUpdataDirectory.Ids = ids;
            bulkUpdataDirectory.NewDirectoryName = "string";
            string payload = JsonConvert.SerializeObject(bulkUpdataDirectory, Formatting.Indented);
            RestRequest request = helper.CreatePatchRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void DocumentService_TypeDocumentType_DocumentConditions_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + lenderCode + "/document-types/" + DocumentTypeId + "/document-conditions");
            TypeDocumentType_DocumentConditions_RequestBody documentConditions = new TypeDocumentType_DocumentConditions_RequestBody()
            {
                MappedFieldId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                @operator = "Equal",
                Value = "string",
                ValueType = "Text"
            };
            List<object> value = new List<object> { documentConditions };
            string payload = JsonConvert.SerializeObject(value, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        [TestCase(InvalidDocumentTypeId, lenderCode)]
        [TestCase(DocumentTypeId, InvalidLenderCode)]
        [TestCase(InvalidDocumentTypeId, InvalidLenderCode)]
        public void DocumentService_TypeDocumentType_DocumentConditions_NegativeScenario(string Id, string LenderCode)
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + Id + "/document-types/" + LenderCode + "/document-conditions");
            TypeDocumentType_DocumentConditions_RequestBody documentConditions = new TypeDocumentType_DocumentConditions_RequestBody()
            {
                MappedFieldId = "3fa85f64-5717-4562-b3fc-2c963f66afa6",
                @operator = "Equal",
                Value = "string",
                ValueType = "Text"
            };
            List<object> value = new List<object> { documentConditions };
            string payload = JsonConvert.SerializeObject(value, Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void DocumentService_TypeDocumentType_DirectoryDocumentType_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/lenders/" + lenderCode + "/document-types/3fa85f64-5717-4562-b3fc-2c963f66afa6");
            RestRequest request = helper.CreateDeleteRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void DocumentService_TypeDocumentType_DocumentTypeByDocumentGroup_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/documentypebydocumentgroup/Lender");
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void DocumentService_TypeDocumentType_DocumentTypeByDirectory_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/documentypebydirectory/Paint%20Creek%20Membership%20Form");
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void DocumentService_ESignatureType_Send_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/esignature/documents/send");
            ESignatureType_Send_Request sendDocument = new ESignatureType_Send_Request()
            {
                DealId = 0,
                UserId = 0,
                IsCustomDocuSign = true,
                DocumentGenerationType = documentGenerationType,
                ShouldSendToCoBorrowerForCustomDocuSign = true
            };
            string payload = JsonConvert.SerializeObject(sendDocument, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void DocumentService_ESignatureType_Upload_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/esignature/documents/upload");
            ESignatureType_Upload_Request uploadDocument = new ESignatureType_Upload_Request();
            uploadDocument.DealId = 0;
            List<int> dealDocumentIds = new List<int> { 0 };
            uploadDocument.DealDocumentIds = dealDocumentIds;
            uploadDocument.UserId = "string";
            string payload = JsonConvert.SerializeObject(uploadDocument, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void DocumentService_ESignatureType_Process_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/esignature/documents/process");
            ESignatureType_Process_Request processEnvelope = new ESignatureType_Process_Request();
            DocuSignEnvelopeInformation_Process_Request docuSignEnvelopeInformation = new DocuSignEnvelopeInformation_Process_Request();
            docuSignEnvelopeInformation.EnvelopeGuid = "string";
            docuSignEnvelopeInformation.Status = "string";
            Recipient_Process_Request recipient = new Recipient_Process_Request();
            recipient.RecipientId = "string";
            recipient.Status = "string";
            recipient.RoutingOrder = "string";
            List<Recipient_Process_Request> recipients = new List<Recipient_Process_Request> { recipient };
            docuSignEnvelopeInformation.Recipients = recipients;
            processEnvelope.DocuSignEnvelopeInformation = docuSignEnvelopeInformation;
            string payload = JsonConvert.SerializeObject(processEnvelope, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void DocumentService_ESignatureType_Validate_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/esignature/documents/" + dealId + "/validate");
            RestRequest request = helper.CreatePostRequestWithoutBody();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void DocumentService_ESignatureType_ValidateEnvelopel_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/esignature/documents/" + dealId + "/validateforenvelope");
            RestRequest request = helper.CreatePostRequestWithoutBody();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void DocumentService_ESignatureType_Void_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/esignature/documents/" + dealId + "/void");
            RestRequest request = helper.CreatePostRequestWithoutBody();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void DocumentService_ESignatureType_Envelope_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/esignature/documents/envelope?envelopeId=1");
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void DocumentService_MappedFieldType_GetMappedFields_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/mapped-fields");
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void DocumentService_MappedFieldType_PostMappedFields_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/mapped-fields");
            MappedFieldType_PostMappedFields_Request createMapped = new MappedFieldType_PostMappedFields_Request()
            {
                FieldName = "string",
                FieldType = "Text",
                FieldCategory = "string",
                Fillable = true,
                OldId = 0
            };
            List<object> value = new List<object> { createMapped };
            string payload = JsonConvert.SerializeObject(value, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePostRequest(payload);
            /// Act            
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void DocumentService_MappedFieldType_PutMappedFields_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/mapped-fields");
            MappedFieldType_PutMappedFields_Request updateMapped = new MappedFieldType_PutMappedFields_Request()
            {
                Id = "9bf5c724-7924-48e9-a322-10c77a1373e5",
                FieldName = "string",
                FieldType = "Text",
                FieldCategory = "string",
                Fillable = true,
                OldId = 0
            };
            string payload = JsonConvert.SerializeObject(updateMapped, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void DocumentService_MappedFieldType_PutMappedFields_NegativeScenario_InvalidId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/mapped-fields");
            MappedFieldType_PutMappedFields_Request updateMapped = new MappedFieldType_PutMappedFields_Request()
            {
                Id = InvalidLenderId,
                FieldName = "string",
                FieldType = "Text",
                FieldCategory = "string",
                Fillable = true,
                OldId = 0
            };
            string payload = JsonConvert.SerializeObject(updateMapped, Newtonsoft.Json.Formatting.Indented);
            RestRequest request = helper.CreatePutRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<TypeStipType_GetStipType_Response_NegativeScenario>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
                Assert.That(responseContent.Message, Is.EqualTo("MappedFieldID " + InvalidLenderId + " does not exists"));
                Assert.That(responseContent.Code, Is.EqualTo("BadRequest"));
            });
        }

        [Test]
        public void DocumentService_StipType_UploadFile_PositiveScenario()
        {
            /// Arrange
            string Name = helper.GenerateDocName(3);
            RestClient client = helper.SetUrl("document-service/stips/fileUpload");
            RestRequest request = helper.UploadFile(@"Attachments/Lbtst.pdf");
            request.AddParameter("DealId", "325825");
            request.AddParameter("StipType", "a4f21dea-91fd-47e4-a53e-b362d496222a");
            request.AddParameter("ContactId", "91152");
            request.AddParameter("AssetId", "1234");
            request.AddParameter("BorrowerCoBorrowerType", "Borrower");
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<DocumentType_DocumentsFiles_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Path, Is.EqualTo(FileName));
                Assert.That(responseContent.Type, Is.EqualTo("PDF"));
            });
        }
        [Test]
        public void DocumentService_StipType_Deals_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/stips/deals/" + dealId + "?contactId=" + ContactId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<StipType_Deals_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.ContactId, Is.EqualTo(ContactId));
                Assert.That(responseContent.DealId, Is.EqualTo(dealId));
            });
        }
        [Test]
        public void DocumentService_StipType_Deals_NegativeScenario_InvalidDealId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/stips/deals/" + InvalidDealId + "?contactId=" + ContactId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<StipType_Deals_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.ContactId, Is.EqualTo(ContactId));
                Assert.That(responseContent.DealId, Is.EqualTo(dealId));
            });
        }

        [Test]
        public void DocumentService_StipType_Contacts_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/stips/contacts/" + ContactId + "?assetId=" + assetId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<StipType_Contacts_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.ContactId, Is.EqualTo(ContactId));
            });
        }
        [Test]
        public void DocumentService_StipType_Contacts_NegativeScenario_InvalidContactId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/stips/contacts/" + InvalidDealId + "?assetId=" + assetId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<StipType_Contacts_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            { 
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.ContactId, Is.EqualTo(ContactId));
            });
        }

        [Test]
        public void DocumentService_StipType_GetStip_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/stips/" + IdStip + "?contactId=" + ContactId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<StipType_GetStip_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Id, Is.EqualTo(IdStip));
                Assert.That(responseContent.ContactId, Is.EqualTo(ContactId));
                Assert.That(responseContent.DealId, Is.EqualTo(dealId));
                Assert.That(responseContent.StipTypeId, Is.EqualTo("f0f89fdb-7c86-4eb3-a58b-6c61ee87af82"));
            });
        }
        [Test]
        [TestCase(IdStip, InvalidContactId)]
        [TestCase(InvalidIdStip, ContactId)]
        [TestCase(InvalidIdStip, InvalidContactId)]
        public void DocumentService_StipType_GetStip_NegativeScenario(string Id, string ContactId)
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/stips/" + Id + "?contactId=" + ContactId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<StipType_GetStip_NegativeResponse>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Entity type of Phoenix2.DocumentService.Domain.Entities.Stips.ContactStip with id '" + Id + "' not found"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void DocumentService_StipType_PutStip_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/stips/" + IdStip + "?contactId=" + ContactId);
            RestRequest request = helper.CreatePutRequestWithoutBody();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<StipType_GetStip_NegativeResponse>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            });
        }

        [Test]
        public void DocumentService_StipType_Download_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/stips/download/" + dealId + "?contactId=" + ContactId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
        [Test]
        public void DocumentService_StipType_Download_NegativeScenario_InvalidDealId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/stips/download/" + InvalidDealId + "?contactId=" + ContactId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void DocumentService_StipType_DocumentsReview_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/stips/review-documents?ContactId=" + ContactId + "&AssetId=" + assetId + "&DealId=" + dealId + "&CoBorrowerId=3fa85f64-5717-4562-b3fc-2c963f66afa6");
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void DocumentService_TypeStipType_GetStipType_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/stipTypes");
            RestRequest request = helper.CreateGetRequest();
            request.AddParameter("name", StipTypeName);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void DocumentService_TypeStipType_GetStipType_NegativeScenario_InvalidName()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/stipTypes");
            RestRequest request = helper.CreateGetRequest();
            request.AddParameter("name", InvalidNumericId);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<TypeStipType_GetStipType_Response_NegativeScenario>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Stip Type not found with Name " + InvalidNumericId));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void DocumentService_TypeStipType_PostStipType_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/stipTypes");
            string payload = helper.Serialize
            (new
            {
                Name = StipTypeName,
                RelatedToEntity = "Contact",
                IsRequired = true,
                IsRequiredFromCoBorrower = true,
                WillComeFromCustomer = true,
                IsReviewable = true,
                Note = "string"
            });
            RestRequest request = helper.CreatePostRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<TypeStipType_PostStipType_Response>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
                Assert.That(responseContent.Name, Is.EqualTo(StipTypeName));
            });
        }

        [Test]
        public void DocumentService_TypeStipType_PutStipType_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/stipTypes");
            string payload = helper.Serialize
            (new
            {
                Id = "926c86bc-a622-496a-a634-552ed0789ae4",
                Name = "Driver's License - Front Side",
                RelatedToEntity = "Contact",
                IsRequired = true,
                IsRequiredFromCoBorrower = true,
                WillComeFromCustomer = true,
                IsReviewable = true,
                Note = "string"
            });
            RestRequest request = helper.CreatePutRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

        [Test]
        public void DocumentService_TypeStipType_PutStipType_NegativeScenario_InvalidId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/stipTypes");
            string payload = helper.Serialize
            (new
            {
                Id = InvalidLenderId,
                Name = StipTypeName,
                RelatedToEntity = "Contact",
                IsRequired = true,
                IsRequiredFromCoBorrower = true,
                WillComeFromCustomer = true,
                IsReviewable = true,
                Note = "string"
            });
            RestRequest request = helper.CreatePutRequest(payload);
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<TypeStipType_GetStipType_Response_NegativeScenario>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("StipTypeID " + InvalidLenderId + " does not exists"));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void DocumentService_TypeStipType_DeleteStipType_PositiveScenario()
        {
            /// Arrange
            RestClient PostClient = helper.SetUrl("document-service/stipTypes");
            string payload = helper.Serialize
            (new
            {
                Name = StipTypeName,
                RelatedToEntity = "Contact",
                IsRequired = true,
                IsRequiredFromCoBorrower = true,
                WillComeFromCustomer = true,
                IsReviewable = true,
                Note = "string"
            });
            RestRequest request = helper.CreatePostRequest(payload);
            IRestResponse response = helper.GetResponse(PostClient, request);
            var responseContent = helper.GetContent<TypeStipType_PostStipType_Response>(response);
            string StiptypeName = responseContent.Name;

            RestClient Deleteclient = helper.SetUrl("document-service/stipTypes?name=" + StiptypeName);
            RestRequest DeleteRequest = helper.CreateDeleteRequest();
            /// Act
            IRestResponse DeleteResponse = helper.GetResponse(Deleteclient, DeleteRequest);
            /// Assert
            Assert.That(DeleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }


        [Test]
        public void DocumentService_TypeStipType_StipTypeById_PositiveScenario()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/stipTypes?name=string");
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            /// Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void DocumentService_TypeStipType_StipTypeById_NegativeScenario_InvalidId()
        {
            /// Arrange
            RestClient client = helper.SetUrl("document-service/stipTypes/" + InvalidLenderId);
            RestRequest request = helper.CreateGetRequest();
            /// Act
            IRestResponse response = helper.GetResponse(client, request);
            var responseContent = helper.GetContent<TypeStipType_GetStipType_Response_NegativeScenario>(response);
            /// Assert
            Assert.Multiple(() =>
            {
                Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
                Assert.That(responseContent.Message, Is.EqualTo("Stip Type not found with id " + InvalidLenderId));
                Assert.That(responseContent.Code, Is.EqualTo("NotFound"));
            });
        }

        [Test]
        public void DocumentService_TypeStipType_DeleteStipTypeById_PositiveScenario()
        {
            /// Arrange
            RestClient PostClient = helper.SetUrl("document-service/stipTypes");
            string payload = helper.Serialize
            (new
            {
                Name = StipTypeName,
                RelatedToEntity = "Contact",
                IsRequired = true,
                IsRequiredFromCoBorrower = true,
                WillComeFromCustomer = true,
                IsReviewable = true,
                Note = "string"
            });
            RestRequest request = helper.CreatePostRequest(payload);
            IRestResponse response = helper.GetResponse(PostClient, request);
            var responseContent = helper.GetContent<TypeStipType_PostStipType_Response>(response);
            string StiptypeId = responseContent.Id;

            RestClient Deleteclient = helper.SetUrl("document-service/stipTypes/" + StiptypeId);
            RestRequest DeleteRequest = helper.CreateDeleteRequest();
            /// Act
            IRestResponse DeleteResponse = helper.GetResponse(Deleteclient, DeleteRequest);
            /// Assert
            Assert.That(DeleteResponse.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }

    }
}
