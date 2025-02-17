using NUnit.Framework;
using OpenQA.Selenium;
using Phoenix2.UITests.Framework;
using Phoenix2.UITests.Pages;
using Phoenix2.UITests.Pages.DocGen2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Phoenix2.UITests.Tests.DocGen2Integration
{
    class DocGen2IntegrationTests:Settings
    {
        [Test]
        public void AddNewDocumentPositiveScenario()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnAddDocBtn();
            docGen2Page.EnterValidDocName();
            docGen2Page.ClickOnSelectFiles();
            docGen2Page.ChoosingValidPdfFile();
            docGen2Page.ClickOnOkPopup();
        }
        [Test]
        public void AddNewDocumentNegativeScenarioForSendingEmptyName()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnAddDocBtn();
            docGen2Page.ClickOnSelectFiles();
            docGen2Page.ChoosingValidPdfFile();
        }

        [Test]
        public void AddNewDocumentNegativeScenarioForSendingInvalidName()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnAddDocBtn();
            docGen2Page.EnterMoreThan128SymbolsInDocName();
            docGen2Page.ClickOnSelectFiles();
            docGen2Page.ChoosingValidPdfFile();
        }
        [Test]
        public void AddNewDocumentNegativeScenarioForSendingAlreadyExistingDocName()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnAddDocBtn();
            docGen2Page.EnterAlreadyExistingDocTypeName();
            docGen2Page.ClickOnSelectFiles();
            docGen2Page.ChoosingValidPdfFile();
        }
        
        [Test]
        public void AddNewDocumentNegativeScenarioForSendingTxtFile()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnAddDocBtn();
            docGen2Page.EnterValidDocName();
            docGen2Page.ClickOnSelectFiles();
            docGen2Page.ChoosingTxtFile();
        }

        [Test]
        public void AddNewDocumentNegativeScenarioForSendingMoreThan30MbFile()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnAddDocBtn();
            docGen2Page.EnterValidDocName();
            docGen2Page.ClickOnSelectFiles();
            docGen2Page.ChoosingInvalidPdfFile();
        }
        [Test]
        public void RenameDocPositiveScenario()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnRenameBtn();
            docGen2Page.RenameDocument();
            docGen2Page.ClickOnOkBtn();
            docGen2Page.ClickOnOkBtn();
        }
        [Test]
        public void RenameDocNegativeScenarioForEmptyDocName()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnRenameBtn();
            docGen2Page.ClickOnOkBtn();
            //Validation for this test is missing on the website  
        }
        [Test]
        public void RenameDocNegativeScenarioForNewDocNameMoreThan128char()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnRenameBtn();
            docGen2Page.RenameDocumentInvalidNewName();
            docGen2Page.ClickOnOkBtn();
            //Validation for this test is missing on the website  

        }
        [Test]
        public void RenameDocNegativeScenarioForSendingAlreadyExistingDocName()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnRenameBtn();
            docGen2Page.RenameDocWithAlreadyExistingDocName();
            docGen2Page.ClickOnOkBtn();
            //Validation for this test is missing on the website 
        }
        [Test] 
        public void DeleteDocumentPositiveScenario()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnDeleteBtn();
            docGen2Page.ClickOnDeleteConfirmBtn();
            //Validation for this test is missing on the website 
        }

        [Test]
        public void AddParentDocumentPositiveScenario()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnAddParentBtn();
            docGen2Page.AddNewParentDocName();
            docGen2Page.ClickOnPlusAddParentDocBtn();

        }
        [Test]
        public void AddParentDocNegativeScenarioSendingEmptyName()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnAddParentBtn();
            docGen2Page.ClickOnPlusAddParentDocBtn();
        }
        [Test]
        public void AddParentDocNegativeScenarioForSendingMorethan128charName()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnAddParentBtn();
            docGen2Page.AddInvalidParentDocName();
            docGen2Page.ClickOnPlusAddParentDocBtn();
            //Validation for this test is missing on the website 
        }
        [Test]
        public void AddParentDocNegativeScenarioForAlreadyExistingParentDocName()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnAddParentBtn();
            docGen2Page.AddAlreadyExistingParentName();
            docGen2Page.ClickOnPlusAddParentDocBtn();
            //Validation for this test is missing on the website 
        }
        [Test]
        public void AddChildDocPositiveScenario()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnParentDoc();
            docGen2Page.ClickOnAddChildButton();
            docGen2Page.EnterChildDocName();
            docGen2Page.ClickOnSelectFiles();
            docGen2Page.ChoosingValidPdfFile();
            
        }
        [Test]
        public void AddChildDocNegativeScenarioForSendingEmptyChildDocName()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnParentDoc();
            docGen2Page.ClickOnAddChildButton();
            docGen2Page.ClickOnSelectFiles();
            docGen2Page.ChoosingValidPdfFile();
            //Validation for this test is missing on the website
        }
        [Test]
        public void AddChildDocNegativeScenarioForSendingMoreThan128CharName()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnParentDoc();
            docGen2Page.ClickOnAddChildButton();
            docGen2Page.EnterInvalidChildDocName();
            docGen2Page.ClickOnSelectFiles();
            docGen2Page.ChoosingValidPdfFile();
            //Validation for this test is missing on the website
        }
        [Test]
        public void AddChildDocNegativeScenarioForSendingTxtFile()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnParentDoc();
            docGen2Page.ClickOnAddChildButton();
            docGen2Page.EnterInvalidChildDocName();
            docGen2Page.ClickOnSelectFiles();
            docGen2Page.ChoosingTxtFile();
            //Validation for this test is missing on the website

        }
        [Test]
        public void ViewChildDocumentConditionsPositiveScenario()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnParentDoc();
            docGen2Page.ValidateDocConditions();
        }
        [Test]
        public void AddChildDocumentConditionPositiveScenario()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.BaseAuth();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnParentDoc();
            docGen2Page.ClickOnAddConditionBtn();
            docGen2Page.AddCondition();
            docGen2Page.ClickOnSaveConditionsBtn();
        }
        [Test]
        public void AddSeveralChildDocumentConditionsPositiveScenario()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnParentDoc();
            docGen2Page.ClickOnAddConditionBtn();
            docGen2Page.AddCondition();
            docGen2Page.ClickOnAddConditionBtn();
            docGen2Page.AddCondition();
            docGen2Page.ClickOnSaveConditionsBtn();
        }
        [Test]
        public void RemoveChildConditionPositiveScenario()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnParentDoc();
            docGen2Page.ClickOnRemoveConditionBtn();
            docGen2Page.ClickOnSaveConditionsBtn();
        }
        [Test]
        public void EditChildConditionPositiveScenario()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnParentDoc();
            docGen2Page.EditCondition();
            docGen2Page.ClickOnSaveConditionsBtn(); 
        }
        [Test]
            public void ViewDocConditionsPositiveScenario()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnDocWithConditions();
            docGen2Page.ValidateDocConditions();
        }
        [Test]
        public void AddConditionPositiveScenario()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnDocWithConditions();
            docGen2Page.ClickOnAddConditionBtn();
            docGen2Page.AddCondition();
            docGen2Page.ClickOnSaveConditionsBtn();
        }
        [Test]
        public void AddSeveralConditionsPositiveScenario()

            {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnDocWithConditions();
            docGen2Page.ClickOnAddConditionBtn();
            docGen2Page.AddCondition();
            docGen2Page.ClickOnAddConditionBtn();
            docGen2Page.AddCondition();
            docGen2Page.ClickOnSaveConditionsBtn();
        }

        [Test]
        public void EditConditionPositiveScenario()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnDocWithConditions();
            docGen2Page.EditCondition();
            docGen2Page.ClickOnSaveConditionsBtn();
        }
        [Test]
        public void RemoveDocConditionPositiveScenario()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnDocWithConditions();
            docGen2Page.ClickOnRemoveConditionBtn();
            docGen2Page.ClickOnSaveConditionsBtn();
        }
        [Test]
        public void DocumentEditorAddFieldMappingPositiveScenario()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnEditBtn();
            docGen2Page.ClickOnAddFieldMappingBtn();
            docGen2Page.AddMappingField();
            docGen2Page.ClickOnAddFieldMappingBtn();
            docGen2Page.AddMappingField();
            docGen2Page.ClickOnSaveMappingsBtn();
            //Validation for this test is missing on the website
        }
        public void DocumentEditorAddFieldMappingNegativeScenarioWithoutSaving()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnEditBtn();
            docGen2Page.ClickOnAddFieldMappingBtn();
            docGen2Page.AddMappingField();
            docGen2Page.ClickOnAddFieldMappingBtn();
            docGen2Page.AddMappingField();
            //Validation for this test is missing on the website
        }
        [Test]
        public void DocumentEditorAddFieldMappingWithConditionsPositiveScenario()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnEditBtn();
            docGen2Page.ClickOnAddFieldMappingBtn();
            docGen2Page.AddMappingField();
            docGen2Page.ClickOnPlusConditionBtn();
            docGen2Page.AddConditionForMapping();
            docGen2Page.ClickOnSaveMappingsBtn();
            //Validation for this test is missing on the website
        }
        [Test]
        public void DocumentPreviewViewCopyFieldsPositiveScenario()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnCopyFieldsBtn();
            docGen2Page.ValidateCopyFieldsPopup();
        }
        [Test]
        public void DocumentPreviewNegativeScenarioForSendingEmptyDocType()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnCopyFieldsBtn();
            docGen2Page.ClickOnCopyBtn();
            docGen2Page.ValidateCopyFieldsPopup();
            //docGen2Page.ValidateToastMsg();
            //Validation for this test is missing on the website
        }
        [Test]
        public void DocumentPreviewCopyFieldsPositiveScenario()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnCopyFieldsBtn();
            docGen2Page.SelectingDocTypeForCopyFields();
            docGen2Page.ClickOnCopyBtn();
        }
        [Test]
        public void DocumentPreviewCopyFieldsPositiveScenarioForCopyingFieldsToAnotherLender()
        {
            var docGen2Page = new DocGen2Page(driver);
            docGen2Page.NavigateTo();
            docGen2Page.ChooseLender();
            docGen2Page.ClickOnCopyFieldsBtn();
            docGen2Page.SelectingLenderForCopyFields();
            docGen2Page.SelectingDocTypeForCopyFields();
            docGen2Page.ClickOnCopyBtn();
        }             
    }
}
