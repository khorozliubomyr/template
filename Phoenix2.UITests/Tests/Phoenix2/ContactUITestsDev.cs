using NUnit.Framework;
using Phoenix2.UITests.Framework;
using Phoenix2.UITests.Pages.Phoenix2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Phoenix2.UITests.Tests.Phoenix2
{
    public class ContactUITestsDev : Settings
    {
        private MicrosoftLoginPage microsoftloginpage;
        private ContactPageDev contactUITestsDev;
        [SetUp]
        public void test()
        {
            microsoftloginpage = new MicrosoftLoginPage(driver);
            microsoftloginpage.LoginAsUser(Credentials.AdminLogin, Credentials.AdminPassword);
            contactUITestsDev = new ContactPageDev(driver);
        }
        [Test]
        public void ContactTab_VerifyContactTab_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.VerifyContactPage();
        }
        [Test]
        public void ContactTab_EditPerconalInformation_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.EditMiddleName();
            contactUITestsDev.ClickOnSaveButton();
            contactUITestsDev.VerifyChanges();
        }
        [Test]
        public void ContactTab_EditPerconalInformation_NegativeScenario_DeleteRequiredField()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.ClearFirstName();
            contactUITestsDev.ClickOnNextField();
            contactUITestsDev.ClickOnSaveButton();
            contactUITestsDev.VerifyRequiredHint();
        }
        [Test]
        public void ContactTab_AddingAllPerconalInformation_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.AddInfoForEditing();
            contactUITestsDev.ClickOnSaveButton();
            contactUITestsDev.VerifyChanges();
        }
        [Test]
        public void ContactTab_AddressSection_AddNewAddress_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.ClickOnAddNewAddress();
            contactUITestsDev.FillAllFieldForAddressInfo();
            contactUITestsDev.CilckOnSaveAddressButton();
            contactUITestsDev.VerifyChanges();
        }
        [Test]
        public void ContactTab_AddressSection_AddNewAddress_NegativeScenario_WithoutRequiredField()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.ClickOnAddNewAddress();
            contactUITestsDev.FillWithoutRequiredField();
            contactUITestsDev.CilckOnSaveAddressButton();
            contactUITestsDev.VerifyWarningPopUp();
        }
        [Test]
        public void ContactTab_AddressSection_EditAddress_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.SelectRecordForEdit();
            contactUITestsDev.MakeChanges();
            contactUITestsDev.CilckOnSaveAddressButton();
            contactUITestsDev.VerifyChanges();
        }
        [Test]
        public void ContactTab_AddressSection_EditAddress_NegativeScenario_DeleteRequiredField()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.SelectRecordForEdit();
            contactUITestsDev.DeleteRequiredField();
            contactUITestsDev.CilckOnSaveAddressButton();
            contactUITestsDev.VerifyWarningPopUp();
        }
        [Test]
        public void ContactTab_AddressSection_DeleteAddress_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.DeleteRecordFormAddressSection();
            contactUITestsDev.VerifyChanges();
        }
        [Test]
        public void ContactTab_EmploymentSection_AddNewEmployment_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.ClickOnAddNewEmploymentButton();
            contactUITestsDev.FillAllFieldForAddingNewEmployment();
            contactUITestsDev.CilckOnSaveEmploymentButton();
            contactUITestsDev.VerifyChanges();
        }
        [Test]
        public void ContactTab_EmploymentSection_AddNewEmployment_NegativeScenario_WithoutRequiredField()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.ClickOnAddNewEmploymentButton();
            contactUITestsDev.FillWithoutRequiredFieldsEmploymentSection();
            contactUITestsDev.CilckOnSaveEmploymentButton();
            contactUITestsDev.VerifyWarningPopUp();
        }
        [Test]
        public void ContactTab_EmploymentSection_EditEmployment_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.SelectRecordForEditEmploymentSection();
            contactUITestsDev.MakeChangesForEmploymentSection();
            contactUITestsDev.VerifyChanges();
        }
        [Test]
        public void ContactTab_EmploymentSection_EditEmployment_NegativeScenario_DeleteRequiredField()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.SelectRecordForEditEmploymentSection();
            contactUITestsDev.RemoveRequiredFieldForEmploymentSection();
            contactUITestsDev.VerifyWarningPopUp();
        }
        [Test]
        public void ContactTab_EmploymentSection_DeleteEmployment_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.DeleteRecordFormEmploymentSection();
            contactUITestsDev.VerifyChanges();
        }
        [Test]
        public void ContactTab_OtherIncomesSection_AddNewOtherIncome_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.ClickOnAddNewOtherIncomeButton();
            contactUITestsDev.FillAllFieldForAddingNewOtherIncome();
            contactUITestsDev.CilckOnSaveOtherIncomeButton();
            contactUITestsDev.VerifyChanges();
        }
        [Test]
        public void ContactTab_OtherIncomesSection_AddNewOtherIncome_NegativeScenario_WithoutRequiredField()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.ClickOnAddNewOtherIncomeButton();
            contactUITestsDev.FillwithoutRequiredFieldForAddingNewOtherIncome();
            contactUITestsDev.CilckOnSaveOtherIncomeButton();
            contactUITestsDev.VerifyWarningPopUp();
        }
        [Test]
        public void ContactTab_OtherIncomesSection_EditOtherIncome_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.SelectRecordForEditOtherIncomeSection();
            contactUITestsDev.MakeChangesForOtherIncomeSection();
            contactUITestsDev.CilckOnSaveAddressButton();
            contactUITestsDev.VerifyChanges();
        }
        [Test]
        public void ContactTab_OtherIncomesSection_EditOtherIncome_NegativeScenario_DeleteRequiredField()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.SelectRecordForEditOtherIncomeSection();
            contactUITestsDev.RemoveRequiredFieldForOtherIncomeSection();
            contactUITestsDev.CilckOnSaveAddressButton();
            contactUITestsDev.VerifyWarningPopUp();
        }
        [Test]
        public void ContactTab_OtherIncomesSection_DeleteOtherIncomes_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.DeleteRecordFormOtherIncomesSection();
            contactUITestsDev.VerifyChanges();
        }
        [Test]
        public void ContactTab_ReferenceSection_AddNewReference_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.ClickOnAddNewReferenceButton();
            contactUITestsDev.FillAllFieldForAddingNewReference();
            contactUITestsDev.CilckOnSaveOtherIncomeButton();
            contactUITestsDev.VerifyChanges();
        }
        [Test]
        public void ContactTab_ReferenceSection_AddNewReference_NegativeScenario_WithoutRequiredField()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.ClickOnAddNewReferenceButton();
            contactUITestsDev.FillwithoutReuiredFieldForAddingNewReference();
            contactUITestsDev.CilckOnSaveOtherIncomeButton();
            contactUITestsDev.VerifyWarningPopUp();
        }
        [Test]
        public void ContactTab_ReferenceSection_EditReference_NegativeScenario_DeleteRequiredField()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.SelectRecordForEditReferenceSection();
            contactUITestsDev.RemoveRequiredFieldForReferenceSection();
            contactUITestsDev.CilckOnSaveAddressButton();
            contactUITestsDev.VerifyWarningPopUp();
        }
        [Test]
        public void ContactTab_ReferenceSection_DeleteReference_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.DeleteRecordFormReferenceSection();
            contactUITestsDev.VerifyChanges();
        }
        [Test]
        public void ContactTab_CoApplicantPopUp_VerifyCoApplicantPopUp_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.ClickOnAddCoaplicantButton();
            contactUITestsDev.VerifyCoAplicantPopUp();
        }
        [Test]
        public void ContactTab_CoApplicantPopUp_AddNewCoApplicantPopUp_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.ClickOnAddCoaplicantButton();
            contactUITestsDev.FillAllRequiredFieldForCoAplicant();
            contactUITestsDev.CilckOnSaveButtonCoAplicant();
            contactUITestsDev.VerifyChanges();
            contactUITestsDev.VerifyCoAplicantPopUp();
        }
        [Test]
        public void ContactTab_CoApplicantPopUp_AddNewCoApplicantPopUp_NegativeScenario_WithoutRequiredField()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.ClickOnAddCoaplicantButton();
            contactUITestsDev.FillallDataWithoutFirstNameForCoAplicant();
            contactUITestsDev.CilckOnSaveButtonCoAplicant();
            contactUITestsDev.VerifyRequiredHint();
        }
        [Test]
        public void ContactTab_CoApplicantPopUp_EditCoApplicantPopUp_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.SelectRecordForEditCoaplicant();
            contactUITestsDev.VerifyCoAplicantPopUp();
            contactUITestsDev.MakeSomeForEditCoaplicant();
            contactUITestsDev.CilckOnSaveButtonCoAplicant();
            contactUITestsDev.VerifyChanges();
        }
        [Test]
        public void ContactTab_CoApplicantPopUp_EditCoApplicantPopUp_NegativeScenario_DeleteRequiredField()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.SelectRecordForEditCoaplicant();
            contactUITestsDev.VerifyCoAplicantPopUp();
            contactUITestsDev.RemoveRequiredFieldForCoaplicant();
            contactUITestsDev.CilckOnSaveButtonCoAplicant();
            contactUITestsDev.VerifyRequiredHint();
        }
        [Test]
        public void ContactTab_CoApplicantPopUp_DeleteCoApplicantPopUp_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.DeleteRecordFormCoApplicantSection();
            contactUITestsDev.VerifyChanges();
        }
        [Test]
        public void ContactTab_ContactUserSection_AddingCommentToContactUserSection_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.VerifyContactUsersSection();
            contactUITestsDev.ClickOnAddCommentButton();
            contactUITestsDev.VerifyChanges();
        }
        [Test]
        public void AssetTab_VerifyAssetPage_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.NavigateToAssetsTab();
            contactUITestsDev.VerifyAssetTab();
        }
        [Test]
        public void AssetTab_AddAsset_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.NavigateToAssetsTab();
            contactUITestsDev.FillAllRequiredFieldForCreateAsset();
            contactUITestsDev.ClickOnSaveAssetButton();
            contactUITestsDev.VerifyChanges();
        }
        [Test]
        public void AssetTab_AddAsset_NegativeScenario_WithoutRequiredField()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.NavigateToAssetsTab();
            contactUITestsDev.FillWithoutLienHolderRequiredField();
            contactUITestsDev.ClickOnSaveAssetButton();
            contactUITestsDev.VerifyRequiredHintOfAssetTab();
        }
        [Test]
        public void AssetTab_EditAsset_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.NavigateToAssetsTab();
            contactUITestsDev.SelectRecordForEditOfAssetTab();
            contactUITestsDev.MakeSoneChengesForAssetTab();
            contactUITestsDev.ClickOnSaveAssetButton();
            contactUITestsDev.VerifyChanges();
        }
        [Test]
        public void AssetTab_EditAsset_NegativeScenario_DeleteRequiredField()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.NavigateToAssetsTab();
            contactUITestsDev.SelectRecordForEditOfAssetTab();
            contactUITestsDev.RemoveOdmeterRequiredField();
            contactUITestsDev.ClickOnSaveAssetButton();
            contactUITestsDev.VerifyRequiredHintOfAssetTabForOdmeterField();
        }
        [Test]
        public void LeadsTab_VerifyLeadsPage_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.NavigateToLeadsTab();
            contactUITestsDev.VerifyLeadsTab();
        }
        [Test]
        public void LeadsTab_VerifyAddNewLeadPopUp_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.NavigateToLeadsTab();
            contactUITestsDev.ClickOnAddNewLeadButton();
            contactUITestsDev.VerifyAddNewLeadPopUp();
        }
        [Test]
        public void LeadsTab_AddNewLead_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.NavigateToLeadsTab();
            contactUITestsDev.ClickOnAddNewLeadButtonOfLeadTab();
            contactUITestsDev.FillAllRequiredDataForCreateNewLead();
            contactUITestsDev.ClickOnSaveLeadButton();
            contactUITestsDev.VerifyChanges();
        }
        [Test]
        public void LeadsTab_AddNewLead_NegativeScenario_WithoutRequiredField()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.NavigateToLeadsTab();
            contactUITestsDev.ClickOnAddNewLeadButton();
            contactUITestsDev.FillDatawithoutRequiredAssetField();
            contactUITestsDev.ClickOnSaveLeadButton();
            contactUITestsDev.VerifyRequiredHintOfLeadTab();
        }
        [Test]
        public void FielsTab_VerifyFilesPage_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.NavigateToFilesTab();
            contactUITestsDev.VerifyFilesTab();
        }
        [Test]
        public void FielsTab_VerifyFilesTable_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.NavigateToFilesTab();
            contactUITestsDev.SelectRecordInAssetDropDown();
            contactUITestsDev.VerifyFilesTable();
        }
        [Test]
        public void FielsTab_EditFiles_PositiveScenario_ChangeTypeOfFiles()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.NavigateToFilesTab();
            contactUITestsDev.SelectRecordInAssetDropDown();
            contactUITestsDev.ChangeTypeInSelectedFile();
            contactUITestsDev.VerifyChangesFilesTab();
        }
        [Test]
        public void FielsTab_VerifySTIPSReviewPopUpOfFilesTab_PositiveScenario()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.NavigateToFilesTab();
            contactUITestsDev.SelectRecordInAssetDropDown();
            contactUITestsDev.ClickOnFileName();
            contactUITestsDev.VerifySTIPSReviewPopUp();
        }
        [Test]
        public void FielsTab_EditSTIPSPopUpOfFilesTab_PositiveScenario_ChangeStatus()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.NavigateToFilesTab();
            contactUITestsDev.SelectRecordInAssetDropDown();
            contactUITestsDev.ClickOnFileName();
            contactUITestsDev.ChangeStatusOfSTIPS();
            contactUITestsDev.VerifyChangesSTIPSReviewPopUp();
        }
        [Test]
        public void FielsTab_STIPSPopUpOfFilesTab_VerifyIfKBBBookoutSheetOpenedInNewTab()
        {
            contactUITestsDev.NavigateTo();
            contactUITestsDev.SelectContactInAllContactPage();
            contactUITestsDev.NavigateToFilesTab();
            contactUITestsDev.SelectRecordInAssetDropDown();
            contactUITestsDev.ClickOnFileName();
            contactUITestsDev.ClickOnOpenInNewWindowButton();
            contactUITestsDev.VerifyIfNewTabIsOpened();
        }
    }
}
