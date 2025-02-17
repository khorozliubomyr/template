using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Phoenix2.APITests.Tests;

namespace Phoenix2.APITests
{
    class Credentials
    {
        ///Document Service input data
        public const string lenderCode = "GYS";        
        public const string Id = "bc118b8b-714c-4041-9d9a-fee543a3492a";
        public const string LenderId = "43";
        public const string GuidLenderId = "245627bf-68d2-4c1b-abfc-1f6e2bf49b8e";
        public const string DocumentTypeId = "d8efb406-0fee-4960-972e-4c62fd095a4e";
        public const string ParitionKey = "baee054e-58e9-4cff-a4f5-69335b2ac5ec";
        public const string FileName = "DocGen/Lenders/GYS/d8efb406-0fee-4960-972e-4c62fd095a4e/55001_v10.pdf";
        public const string filePath = "DocGen/Lenders/Bl/4cfb3adb-083d-4ecb-bba2-520a37731ffa/Uygm92AYNg_";
        public const string dealId = "325825";
        public const string userId= "198";
        public const string documentGenerationType = "Lender";
        public const string DealProductId = "string";
        public const string StipTypeName = "Lbteststring";
        public const string StipTypeId = "dc971b9e-d737-4fb3-97f3-cd8fa5ee2798";
        public const string StipTypeIdForDelete = "513d205a-b672-43ce-bbe5-c109f994476a";
        public const string StorageFilesId = "5f556edc-cdbd-4067-ab90-700d10ad5e78";
        public const string StorageFilesContainer = "assets";
        public const string StorageFilesPath = "General/Nada_20220324110850.pdf";
        public const string documentGeneratedType = "1";
        public const string InvalidDocumentGeneratedType = "5";
        public const string InvalidStorageFilesPath = "Invaliddd/Nada_20220324110850.pdf";
        public const string InvalidFileName = "DocGen/Lenders/Bl/be419144-c0e7-4155-9ac5-12e1211671b6/InvalidFileName.pdf";
        public const string InvalidLenderCode = "12312";
        public const string InvalidLenderId = "bb058eaf-5c09-4688-8f13-0704e0c9cdf4";
        public const string InvalidDocumentTypeId = "bb058eaf-5c09-4688-8f13-0704e0c9cdf4";
        public const string InvalidId = "245627bf-68d2-4c1b-abfc-1f6e2bf49b8e";
        public const string InvalidDealId = "1111111111";
        public const string InvalidDealId500 = "1111111as";
        public const string InvalidNumericId = "123";
        public const string DocumentSetType = "LP";
        public const string InvalidDocumentSetType = "InvalidDoc";
        public const string LenderCodeForDocSet = "BL";
        public const string DocumentGroup = "Lender";
        public const string InvalidDocumentGroup = "LenderTest";
        public const string DocSetType = "LP";
        public const string InvalidDocSetType = "LPa";
        public const string DocSetId = "eab44457-ae8b-4446-90a7-bd7575bfa6ed";
        public const string DocSetIdDocumentTypeId = "b4f164d0-60a3-4019-bfce-60e9cf47e782";
        public const string InvalidDocGroup = "InvalidDocGroup";
        public const string PdfFileInBase64 = "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Oi8vd3d3LnczLm9yZy8xOTk5LzAyLzIyLXJkZi1zeW50YXgtbnMjJz4KPHJkZjpEZXNjcmlwdGlvbiByZGY6YWJvdXQ9JzkzOEI4MkU2LTEwRkYtNjM5RS1DMTlDLTY2MkFEOURBOTBFOScgeG1sbnM6cGRmPSdodHRwOi8vbnMuYWRvYmUuY29tL3BkZi8xLjMvJz48cGRmOktleXdvcmRzPjwvcGRmOktleXdvcmRzPjxwZGY6UHJvZHVjZXI+TmVldmlhIERvY3VtZW50IENvbnZlcnRlciBQcm8gdjcuMi4wLjEzMSAoaHR0cDovL25lZXZpYS5jb20pPC9wZGY6UHJvZHVjZXI+PC9yZGY6RGVzY3JpcHRpb24+CjxyZGY6RGVzY3JpcHRpb24gcmRmOmFib3V0PSc5MzhCODJFNi0xMEZGLTYzOUUtQzE5Qy02NjJBRDlEQTkwRTknIHhtbG5zOnhtcD0naHR0cDovL25zLmFkb2JlLmNvbS94YXAvMS4wLyc+PHhtcDpNb2RpZnlEYXRlPjIwMjEtMDktMTRUMTQ6NTE6MTkrMDM6MDA8L3htcDpNb2RpZnlEYXRlPjx4bXA6Q3JlYXRlRGF0ZT4yMDIxLTA5LTE0VDE0OjUxOjE4KzAzOjAwPC94bXA6Q3JlYXRlRGF0ZT48eG1wOk1ldGFkYXRhRGF0ZT4yMDIxLTA5LTE0VDE0OjUxOjE4KzAzOjAwPC94bXA6TWV0YWRhdGFEYXRlPjx4bXA6Q3JlYXRvclRvb2w+TmVldmlhIERDIFBybyAtIE9wZW5PZmZpY2UgcGFyc2VyPC94bXA6Q3JlYXRvclRvb2w+PC9yZGY6RGVzY3JpcHRpb24+CjxyZGY6RGVzY3JpcHRpb24gcmRmOmFib3V0PSc5MzhCODJFNi0xMEZGLTYzOUUtQzE5Qy02NjJBRDlEQTkwRTknIHhtbG5zOmRjPSdodHRwOi8vcHVybC5vcmcvZGMvZWxlbWVudHMvMS4xLyc+PGRjOmZvcm1hdD5hcHBsaWNhdGlvbi9wZGY8L2RjOmZvcm1hdD48ZGM6ZGVzY3JpcHRpb24+PHJkZjpBbHQ+PHJkZjpsaSB4bWw6bGFuZz0neC1kZWZhdWx0Jz48L3JkZjpsaT48L3JkZjpBbHQ+PC9kYzpkZXNjcmlwdGlvbj48ZGM6Y3JlYXRvcj48cmRmOlNlcT48cmRmOmxpPjwvcmRmOmxpPjwvcmRmOlNlcT48L2RjOmNyZWF0b3I+PGRjOnRpdGxlPjxyZGY6QWx0PjxyZGY6bGkgeG1sOmxhbmc9J3gtZGVmYXVsdCc+PC9yZGY6bGk+PC9yZGY6QWx0PjwvZGM6dGl0bGU+PC9yZGY6RGVzY3JpcHRpb24+CjxyZGY6RGVzY3JpcHRpb24gcmRmOmFib3V0PSc5MzhCODJFNi0xMEZGLTYzOUUtQzE5Qy02NjJBRDlEQTkwRTknIHhtbG5zOnhtcE1NPSdodHRwOi8vbnMuYWRvYmUuY29tL3hhcC8xLjAvbW0vJz48eG1wTU06RG9jdW1lbnRJRD51dWlkOkU4Q0Q0MDlELTM3NzktQjk4QS0xMTlCLUQ4NDE5MjNCRTFBQjwveG1wTU06RG9jdW1lbnRJRD48eG1wTU06SW5zdGFuY2VJRD51dWlkOjkzOEI4MkU2LTEwRkYtNjM5RS1DMTlDLTY2MkFEOURBOTBFOTwveG1wTU06SW5zdGFuY2VJRD48L3JkZjpEZXNjcmlwdGlvbj4KCjwvcmRmOlJERj4KPC94OnhtcG1ldGE+CiAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgIAogICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAgICAKPD94cGFja2V0IGVuZD0ndyc/PgplbmRzdHJlYW0KZW5kb2JqCnhyZWYKMCAxMwowMDAwMDAwMDAwIDY1NTM1IGYgCjAwMDAwMDAwMTUgMDAwMDAgbiAKMDAwMDAwMDE2OSAwMDAwMCBuIAowMDAwMDAwMjIyIDAwMDAwIG4gCjAwMDAwMDA1MDMgMDAwMDAgbiAKMDAwMDAwMDUzNCAwMDAwMCBuIAowMDAwMDAwNzM3IDAwMDAwIG4gCjAwMDAwMDA5MzggMDAwMDAgbiAKMDAwMDAwMTI3OSAwMDAwMCBuIAowMDAwMDE2NTkyIDAwMDAwIG4gCjAwMDAwMTY3MzUgMDAwMDAgbiAKMDAwMDAxNjgxNSAwMDAwMCBuIAowMDAwMDE2ODcxIDAwMDAwIG4gCnRyYWlsZXIKPDwKL1NpemUgMTMKL1Jvb3QgMTAgMCBSCi9JbmZvIDkgMCBSCi9JRFs8MUUxQUNDQUI0NUFFNUQ3QjgzMURCRkRFNUYwQjZDOTM+PDkxODAxRjlEQkExOTI5NDQ5ODM3NzY5RTlBRDMyRTIyPl0KPj4Kc3RhcnR4cmVmCjE4NjQ5CiUlRU9GCg==";
        public const string assetId = "1221";
        public const string IdStip = "39c7e079-3796-43a1-8b53-f41d7b0297e8";
        public const string InvalidIdStip = "39c7e079-3796-43a1-8b53-f41d7b0000e8";
        public const string InvalidContactId = "9115244";


        ///Product service input data
        public static string DealId = "4363";
        public static string UserId = "1";
        public static string LenderCode = "6";
        public static bool IsDealCalculator = true;
        public static string ContractDate = "2022-03-04T13:52:39.278Z";
        public static string Mileage = "111";
        public static string TermMonth = "12";
        public static string LenderName = "Bl";

        public static string LeadId = "1503988";
        public static string DealIdProduct = "2849645";
        public static string productTypeName = "Gap";
        public static string productTypeId = "e0c4160c-34a3-4261-938c-1eefd3308f3c";
        public static string providerName = "Nac";
        public static string ProviderId = "6a7af2e2-4515-456e-97eb-1b5f83aa6506";
        public static string DealProductIdProduct = "ed7c5fcb-9d93-457a-bb19-40e6a55cab13";
        public static string PlanId = "4074";
        public static string RateId = "49401326";

        public static string lenderCodeProduct = "FLAG";
        public static string ProductTypeNameLender = "Gap";
        public static string ProductTypeIdProduct = "edead4c7-fe5d-4257-ad3f-eaf045ee8bca";
        public static string ProviderNameLender = "Sefi";
        public static string ProviderIdLender = "6a7af2e2-4515-456e-97eb-1b5f83aa6506";
        public static string DealCalculatorLeadProductId = "67d77052-f2ab-4b13-a269-37e81ab8ae22";
        public static string ProductTypeId = "e0c4160c-34a3-4261-938c-1eefd3308f3c";

        public static string DealProductIdProductInvalid = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
        public static string DealIdProductInvalid = "111111";


        ///Lender service input data
        public const string NumericId = "9";
        public const string LenderServiceId = "baf36426-31c7-44e1-8f3d-6059fe257614";
        public const string LenderServiceLenderCode = "Da";
        public const string NameLenderService = "DATCU";
        public const string PostCodeLenderService = "76202";
        public const string ContactId = "91152";
        public const string ContactIdLenderService = "a097a77c-57dd-4de6-942c-d2ca94b64651";
        public const string CardIdForDelete = "ba2f8c49-dd58-4116-81cb-9f79a1fc21ea";
        public const string CardId = "ad2174de-68ed-40ab-af6a-c171c1efb591";
        public const string CardIdInvalid = "ad2174de-68ed-40ab-af6a-c171c1efb000";
        public const string TierId = "73f75c3f-ebd3-44e4-9bef-4b728026939b";
        public const string TierIdInvalid = "73f75c3f-ebd3-44e4-9bef-4b728000000b";
        public const string TierConditionId = "24d2c282-929d-427b-8357-fa75265e3083";
        public const string TierConditionIdforupdate = "e343017a-6bfb-4dd5-82ef-405df23b11b9";
        public const string docFeeStateExclusionsID = "767d5853-1be2-4eae-81d4-fe26e59c8672";
        public const string formulaID = "51c9e2e4-ca6f-47df-9e11-117974363324";
        public const string Bureau = "ExpV9";
        public const string LenderDocumentsId = "9e1f90a4-9ebb-40c3-ab79-0ba5a6d5226a";
        public const string CardtiersId = "fe3ee57b-be39-4af3-9afb-2795d687b333";
        public const string LenderCreditRuleId = "77c3c961-4218-4d8c-af24-638cb0972b1e";
        public const string LenderCreditRuleIdInvalid = "00c3c961-4218-4d8c-af24-638cb0000b1e";
        public const string InvalidState = "XXX";

        ///Contact service input data
        public const string GuidContactId = "0936e7bf-d8af-4672-8569-0e5967e6bcf8";
        public const string CoApplicantId = "5ba819b3-23d6-4465-af78-c255da8f4e78";
        public const string SSN = "+1ASO+SGXOBYzhdn+7d1h46TPvtzrfZWtQubna2x9UrQEXTcwc2XiBCLa+b3PpWL";
        public const string InvalidGuidContactId = "0006e7bf-d8af-4672-8569-0e5967e6bcf8";
        public const string InvalidCoContactId = "0006e7bf-d8af-4672-0000-0e5967e6bcf8";

        ///User service input data
        public static string UserServiceId = "06982f5a-ae3e-47e4-ad9d-2770817b7320";
        public static string officeLocationId = "1ece17a1-2e63-408b-aaeb-d9e90d67f328";
        public static string invalidOfficeLocationId = "1ece17a1-2e63-408b-aaeb-d9e90d67f777";
        public static string UserServiceRoleId = "7686f396-faf6-4c9c-9a0b-b9aadd2e449a";
        public static string UserServiceRoleAssignmentId = "3a3ce76c-7d77-47c1-9282-667fefbebe60";
        public static string AssignmentUserId = "55ab7d6e-79ac-481c-94d2-2d1141e91a08";
        public static string AssignmentRoleId = "3b6b90dd-3076-4f95-80dd-fd3d0945c279";
        public static string UserServiceTEAMId = "5371eea8-d374-4355-ac1a-cccff8c229ed";
        public static string teamTypeId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
        public static string periodId = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
        public static string teamId = "7c8393f5-786d-450b-a2ee-9ae5b7d013a3";
        public static string teamMemberTypeId = "7c8393f5-786d-450b-a2ee-9ae5b7d013a3";
        public static string TeamTypeId = "942f86e0-283f-4be8-b4b6-fa50f57b0a08";
        public static string UsersId = "6d41e71d-80d9-466e-a277-376be67455ba";


        ///Asset service input data
        public const string AssetId = "3b035937-848c-4ad4-b704-f22fc921b4ce";
        public const string invalidAssetId = "3b000000-848c-4ad4-b704-f22fc921b4ce";
        public const string AssetContactId = "316448";
        public const string invalidAssetContactId = "111111";
        public const string AssetLeadId = "c19b5951-1d0a-48b4-ada4-649a4be94812";
        public const string AssetLeadIdInval = "c19b5951-1d0a-48b4-ada4-649a4be00000";
        public const string vinNumber = "1FMCU9J93JUB98016";
        public const string InvalidvinNumber = "0FFFF0F00FFF000000";
        public const string mileage = "46143";
        public const string zipCode = "33136";
        public const string AssetdealId = "323920";
        public const string AssetUserId = "198";
        public const string ModelYear = "2015";
        public const string ModelYearInvalid = "2035";
        public const string Make = "NISSAN";
        public const string MakeInvalid = "Make";
        public const string MakeId = "4";
        public const string MakeIdInvalid = "11";
        public const string Model = "Altima";
        public const string ModelInvalid = "BMW";
        public const string ModelId = "38";
        public const string ModelIdInvalid = "121212";
        public const string YearId = "2010";
        public const string YearIdInvalid = "2040";
        public const string AssetValuationType = "Nada";
        public const string AssetValuationTypeInvalid = "Test";
        public const string AssetStickerType = "1";
        public const string AssetStickerTypeInvalid = "Test";

        ///Payment service input data
        public const string ExpiryDate = "02/2023";
        public const string IdPayment = "06a7af49-b3cb-4c52-bd13-b93f398ed0c7";
        public const string DownPaymentId = "b292b681-93df-4799-89a0-6ece5380c8f5";
        public const string DownPaymentOnDeal = "1";
        public const string CreditCardNumber = "4263982640269299";
        public const string HolderName = "Param";
        public const string Cvv = "837";
        public const string Amount = "100";
        public const string CashDown = "2";
        public const string Notes = "Test";
        public const string contactIdPayment = "59d968a3-7d52-42ba-a1c1-5d8c6303630e";
        public const string DealIdPayment = "f8ec1bf6-9ee7-4cfb-835b-bf608221ffcd";
        public const string ContactCreditCardId = "8f664587-0dc8-4695-871b-67cdcc0bebc8";

        public const string InvalidCreditCardNumber = "1111";
        public const string InvalidCvv = "1";
        public const string InvalidAmount = "0";
        public const string InvalidDownPaymentId = "1eb5c7ca-648a-4233-a8df-c0be0e0000cc";
        public const string InvalidDealIdPayment = "3fa85f64-5717-4562-b3fc-2c963f66afa5";
        public const string InvalidContactlIdPayment = "68f5aea0-7eb6-4c02-9484-00c000000ab7";
        public const string InvalidIdPayment = "bfe62bcc-d7b5-4bd2-98e3-fa502e000000";

        ///Lead service input data
        public const string contactIdLeadInvalid = "0a000000-000a-0aa0-a000-a00aa000b0aa";
        public const string contactIdLead = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
        public const string LeadIdLead = "3fa85f64-5717-4562-b3fc-2c963f66afa6";
        public const string contactIdLeadPut = "4e873367-87d0-4616-b54b-c1122bb338bc";
        public const string IdLeadPut = "bb188031-528d-4038-8bdf-fd289f07b7f1";
        public const string primarySourceId = "9e22daf4-d8ad-4d2f-bd06-f9b40a9a32f4";
        public const string originalLeadId = "bb188031-528d-4038-8bdf-fd289f07b7f1";

        public const string leadId = "68f5aea8-7eb6-4c42-9484-59c547927ab7";
        public const string leadIdInvaild = "68f5aea0-7eb6-4c02-9484-00c000000ab7";
        public const string ContactIdLeadNotes = "79f88ec8-bc06-4352-8cdf-0f5e3a8d381f";
        public const string leadNoteIdInvalid = "a559d303-eddf-4b08-9093-c9fcaf18a6e3";

        ///Configuration service input data
        public const string IdConfiguration = "0ac1dfaa-dcee-4f88-a237-ac6efb9b4f3f";
        public const string ConfigurationGroup = "CU_FILTER";
        public const string tokenName = "AUTOFI";
        public const string value = "Wr";
        public const string WorkflowId = "3fa85f00-1111-2222-b3fc-2c000f66afa6";
        public const string StepId = "3fa85f99-2222-1111-b3fc-2c777f66afa6";
        public const string ConfigurationSubGroupInvalid = "Test123";
        public const string IdConfigurationInvalid = "0ac0aaaa-eeee-0f00-a000-ac0efb0b0f0f";
        public const string ConfigurationGroupInvalid = "12qw12";
        public const string tokenNameInvalid = "12op34";

        /// Workflow service input data
        public const string WorkflowServiceId = "1b506f25-44c5-43f4-8745-a8a4b05d5f56";
        public const string CurrentWorkflofStepId = "1b506f25-44c5-43f4-8745-a8a4b05d5f56";
        public const string TargetWorkflowStepId = "1b506f25-44c5-43f4-8745-a8a4b05d5f56";
        public const string InvalidWorkflowId = "3fa85f00-1111-2222-b3fc-2c000f66afa6";

        /// Workflow service input data
        public const string DealServiceDealId = "c7777bec-136f-4c90-9904-387ae3ce7459";
        public const string DealServiceLeadId = "34bab06d-96d5-453a-bbb2-7963a67db2a2";
        public const string DealServiceContactId = "000a51f1-eae2-4352-b2b9-eb954d50b80d";
        public const string DealServiceNumericId = "49546";


        public const string DealServiceInvalidDealId = "3fa85f00-1111-2222-b3fc-2c000f66afa6";

        ///Autorization data
        public static string Scope = TestContext.Parameters["Scope"];
        public static string ClientId = TestContext.Parameters["ClientId"];
        public static string ClientSecret = TestContext.Parameters["ClientSecret"];
        public static string TenantId = TestContext.Parameters["TenantId"];
        public static string Audiences = TestContext.Parameters["Audiences"];
    }
}
