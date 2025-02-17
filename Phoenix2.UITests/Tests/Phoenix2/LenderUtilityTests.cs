using com.sun.net.httpserver;
using NUnit.Framework;
using Phoenix2.UITests.Framework;
using Phoenix2.UITests.Pages;
using Phoenix2.UITests.Pages.Login;
using Phoenix2.UITests.Pages.Phoenix1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Phoenix2.UITests.Pages.Phoenix2;

namespace Phoenix2.UITests.Tests.Phoenix2LenderUtility
{
    [TestFixture]
    public class LenderUtilityTests : Settings
    {
        private MicrosoftLoginPage microsoftloginpage;
        private LenderUtilityPage lenderUtilityPage;
        [SetUp]
        public void test()
        {
            microsoftloginpage = new MicrosoftLoginPage(driver);
            microsoftloginpage.LoginAsUser(Credentials.AdminLogin, Credentials.AdminPassword);
            lenderUtilityPage = new LenderUtilityPage(driver);
        }
        [Test]
        public void LenderUtility_GeneralTab_AddLender_PositiveScenario()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.ClickAddNewLender();
            lenderUtilityPage.FillAllRequiredFields("Data");
            lenderUtilityPage.SelectDataFromDropdowns();
            lenderUtilityPage.ClickOnCheckBoxs();
            lenderUtilityPage.ClickSaveButton();
            lenderUtilityPage.CheckLenderCreatedSuccessfullyPopup();
        }
        [Test]
        public void LenderUtility_GeneralTab_AddLender_NegativeScenario_WithExistingName()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.ClickAddNewLender();
            lenderUtilityPage.FillAllRequiredFields("Data");
            lenderUtilityPage.SelectDataFromDropdowns();
            lenderUtilityPage.ClickOnCheckBoxs();
            lenderUtilityPage.ClickSaveButton();
            lenderUtilityPage.CheckWarningPopup();
        }
        [Test]
        public void LenderUtility_GeneralTab_AddLender_NegativeScenario_WithoutRequiredField()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.ClickAddNewLender();
            lenderUtilityPage.FillWithoutRequiredField("Data");
            lenderUtilityPage.SelectDataFromDropdowns();
            lenderUtilityPage.ClickOnCheckBoxs();
            lenderUtilityPage.ClickSaveButton();
            lenderUtilityPage.CheckCodeIsRequiredwarningmessage();
        }
        [Test]
        public void LenderUtility_GeneralTab_EditingLender_PositiveScenario()
        {
            string Address=lenderUtilityPage.GenerateRandomName(8);
            Console.WriteLine(Address);
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.EditData(Address);
            lenderUtilityPage.ClickSaveButton();
            lenderUtilityPage.CheckSavedSuccessfullypopup();
        }
        [Test]
        public void LenderUtility_GeneralTab_EditingLender_NegativeScenario()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.CleanData("");
            lenderUtilityPage.ClickSaveButton();
            lenderUtilityPage.CheckAddressIsRequiredwarningmessage();
        }
        [Test]
        public void LenderUtility_RateCardsTab_AddCards_PositiveScenario()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnRateCardsTab();
            lenderUtilityPage.ClickOnFromDateDropDown();
            lenderUtilityPage.ClickToDateDropDownDropDown();
            lenderUtilityPage.CheckardCreatedSuccessfullypopup();
        }
        [Test]
        public void LenderUtility_RateCardsTab_EditCard_PositiveScenario()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnRateCardsTab();
            lenderUtilityPage.EditRecordInCardsTab();
            lenderUtilityPage.VerifyEditCard();
        }
        [Test]
        public void LenderUtility_RateCardsTab_DeleteCards_PositiveScenario()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnRateCardsTab();
            lenderUtilityPage.DeleteRecordInCardsTab();
            lenderUtilityPage.VerifyDeleteCard();
        }
        [Test]
        public void LenderUtility_RateCardsTab_AddTiers_PositiveScenario()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnRateCardsTab();
            lenderUtilityPage.ClickOnAddNewTierButton();
            lenderUtilityPage.FillDataForTierFields();
            lenderUtilityPage.ClickSaveTierBtn();
            lenderUtilityPage.VerifyCreation();
        }
        [Test]
        public void LenderUtility_RateCardsTab_EditTier_PositiveScenario()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnRateCardsTab();
            lenderUtilityPage.EditRecordInTiersTab();
            lenderUtilityPage.VerifyEditTiers();
        }
        [Test]
        public void LenderUtility_RateCardsTab_DeliteTier_PositiveScenario()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnRateCardsTab();
            lenderUtilityPage.DeleteRecordInTiersTab();
            lenderUtilityPage.VerifyDeleteTier();
        }
        [Test]
        public void LenderUtility_RateCardsTab_AddCondition_PositiveScenario()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnRateCardsTab();
            lenderUtilityPage.ClickOnAddNewConditionButton();
            lenderUtilityPage.FillDataForConditionFields();
            lenderUtilityPage.ClickSaveConditionBtn();
            lenderUtilityPage.VerifyCreateCondition();
        }
        [Test]
        public void LenderUtility_RateCardsTab_EditCondition_PositiveScenario()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnRateCardsTab();
            lenderUtilityPage.EditRecordInConditionTab();
            lenderUtilityPage.VerifyEditCondition();
        }
        [Test]
        public void LenderUtility_IncsAndExcs_VerifyTab()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnIncsAndExcsTab();
            lenderUtilityPage.CheckIncsandExcsTab();
        }
        [Test]
        public void LenderUtility_IncsAndExcs_AddZips_PositiveScenario()
        {
            string Zip = lenderUtilityPage.RandomDigits(5);
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnIncsAndExcsTab();
            lenderUtilityPage.FillInZip(Zip);
            lenderUtilityPage.ClickSaveButton();
            lenderUtilityPage.VerifyAddIncsAndExcs();
        }
        [Test]
        public void LenderUtility_IncsAndExcs_AddInvalidZips_NegativeScenario()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnIncsAndExcsTab();
            lenderUtilityPage.FillInvalidZip();
            lenderUtilityPage.ClickSaveButton();
            lenderUtilityPage.VerifyWarningMessageForAddIncsAndExcs();
        }
        [Test]
        public void LenderUtility_IncsAndExcs_EditDataForIncsAndExcsTad_PositiveScenario()
        {
            string Zip = lenderUtilityPage.RandomDigits(5);
            string Contact = lenderUtilityPage.RandomDigits(5);
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnIncsAndExcsTab();
            lenderUtilityPage.ChangeZip(Zip);
            lenderUtilityPage.ChangeContact(Contact);
            lenderUtilityPage.ClickOnStateCodeCheckBox();
            lenderUtilityPage.ClickSaveButton();
            lenderUtilityPage.VerifyAddIncsAndExcs();
        }
        [Test]
        public void LenderUtility_Assets_EditDataForAssetsTab_PositiveScenario()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectLenderWithDataForAssetsTad();
            lenderUtilityPage.ClickOnAssetsTab();
            lenderUtilityPage.ClickOnAssetTypeNameCheckBox();
            lenderUtilityPage.ClickSaveButton();
            lenderUtilityPage.VerifyEditsPopup();
        }
        [Test]
        public void LenderUtility_DocFees_AddDocFee_PositiveScenario()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnDocFeesTab();
            lenderUtilityPage.ClickOnAddNewDocFeeButton();
            lenderUtilityPage.FillDataForDocFee();
            lenderUtilityPage.ClickSaveButton();
            lenderUtilityPage.VerifyAddDocFeePopup();
        }
        [Test]
        public void LenderUtility_DocFees_AddDocFee_NegativeScenario()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnDocFeesTab();
            lenderUtilityPage.ClickOnAddNewDocFeeButton();
            lenderUtilityPage.FillInvalidDataForDocFee();
            lenderUtilityPage.ClickSaveButton();
            lenderUtilityPage.VerifyAddDocFeeWarningPopup();
        }
        [Test]
        public void LenderUtility_DocFees_EditDocFee_PositiveScenario()
        {
            string Description = lenderUtilityPage.RandomDigits(5);
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnDocFeesTab();
            lenderUtilityPage.EditRecordInDocFeeTable(Description);
            lenderUtilityPage.ClickSaveButton();
            lenderUtilityPage.VerifyEditDocFeeWarningPopup();
        }
        [Test]
        public void LenderUtility_DocFees_DeleteDocFee_PositiveScenario()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnDocFeesTab();
            lenderUtilityPage.DeleteRecordInDocFees();
            lenderUtilityPage.VerifyDeleteDocFeeWarningPopup();
        }
        [Test]
        public void LenderUtility_DocFees_AddAdditionalDocFee_PositiveScenario()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnDocFeesTab();
            lenderUtilityPage.ClickOnAddNewAdditionalDocFeeButton();
            lenderUtilityPage.FillDataForAdditionalDocFee();
            lenderUtilityPage.ClickSaveButton();
            lenderUtilityPage.VerifyAddAdditionalDocFeePopup();
        }
        [Test]
        public void LenderUtility_DocFees_EditAdditionalDocFee_PositiveScenario()
        {
            string Description = lenderUtilityPage.RandomDigits(5);
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnDocFeesTab();
            lenderUtilityPage.EditRecordInAdditionalDocFeeTable(Description);
            lenderUtilityPage.ClickSaveButton();
            lenderUtilityPage.VerifyEditAdditionalDocFeeWarningPopup();
        }
        [Test]
        public void LenderUtility_DocFees_DeleteAdditionalDocFee_PositiveScenario()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnDocFeesTab();
            lenderUtilityPage.DeleteRecordInAdditionalDocFees();
            lenderUtilityPage.VerifyDeleteAdditionalDocFeeWarningPopup();
        }
        [Test]
        public void LenderUtility_ExcludedProducts_AddExcludedProduct_PositiveScenario()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnExcludedProductsTab();
            lenderUtilityPage.ClickOnAddNewExcludedProductButton();
            lenderUtilityPage.FillDataForExcludedProduct();
            lenderUtilityPage.ClickSaveButton();
            lenderUtilityPage.VerifyAddExcludedProductPopup();
        }
        [Test]
        public void LenderUtility_ExcludedProducts_EditExcludedProduct_PositiveScenario()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnExcludedProductsTab();
            lenderUtilityPage.EditRecordInExcludedProduct();
            lenderUtilityPage.ClickSaveButton();
            lenderUtilityPage.VerifyEditExcludedProductPopup();
        }
        [Test]
        public void LenderUtility_ExcludedProducts_DeleteExcludedProduct_PositiveScenario()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnExcludedProductsTab();
            lenderUtilityPage.DeleteRecordInExcludedProduct();
            lenderUtilityPage.VerifyEditExcludedProductPopup();
        }
        [Test]

        public void LenderUtility_CreaditRules_AddCreaditRules_PositiveScenario()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnCreditRulesTab();
            lenderUtilityPage.ClickOnAddNewCreditRuleButton();
            lenderUtilityPage.FillDataForCreditRule();
            lenderUtilityPage.ClickSaveButton();
            lenderUtilityPage.VerifyAddcreditRuleProductPopup();
        }
        [Test]
        public void LenderUtility_CreaditRules_EditCreaditRules_PositiveScenario()
        {
            string Value = lenderUtilityPage.RandomDigits(5);
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnCreditRulesTab();
            lenderUtilityPage.EditRecordInCreditRule(Value);
            lenderUtilityPage.ClickSaveButton();
            lenderUtilityPage.VerifyEditCreditRuleProductPopup();
        }
        [Test]
        public void LenderUtility_CreaditRules_DeleteCreaditRules_PositiveScenario()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnCreditRulesTab();
            lenderUtilityPage.DeleteRecordInCreditRule();
            lenderUtilityPage.VerifyCreditRuleProductPopup();
        }
        [Test]
        public void LenderUtility_Formulas_AddFormula_PositiveScenario()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnFormulasTab();
            lenderUtilityPage.ClickOnAddNewFormulaButton();
            lenderUtilityPage.FillDataForFormula();
            lenderUtilityPage.ClickSaveButton();
            lenderUtilityPage.VerifyAddFormulaPopup();
        }
        [Test]
        public void LenderUtility_Formulas_EditFormula_PositiveScenario()
        {
            string Expression = lenderUtilityPage.RandomDigits(5);
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnFormulasTab();
            lenderUtilityPage.EditRecordInFormula(Expression);
            lenderUtilityPage.ClickSaveButton();
            lenderUtilityPage.VerifyEditFormulasProductPopup();
        }
        [Test]
        public void LenderUtility_Formulas_DeleteFormula_PositiveScenario()
        {
            lenderUtilityPage.NavigateTo();
            lenderUtilityPage.SelectDataFromLenderDropdown();
            lenderUtilityPage.ClickOnFormulasTab();
            lenderUtilityPage.DeleteRecordInFormula();
            lenderUtilityPage.VerifyDeleteFormulaProductPopup();
        }
    }
}
