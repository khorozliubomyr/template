
using java.awt;
using java.awt.datatransfer;
using java.awt.@event;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Phoenix2.UITests.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WindowsInput.Native;
using WindowsInput;
using System.IO;
using NUnit.Framework;
using System.Net;

namespace Phoenix2.UITests.Pages.DocGen2
{
    class DocGen2Page : BaseDriver
    {
        #region driver
        public DocGen2Page(IWebDriver driver) : base(driver)
        {
            PageDriver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }
        InputSimulator sim = new InputSimulator();
        protected override string PageTitle => "";
        protected override string PageUrl => "https://docgen2:HotLikeTheBeachBoys703@dev-docgen-v2.azurewebsites.net/";


        #endregion

        #region PATH
        private string _Lender = "//span[contains(text(), 'Liubomyr Lender')]";//"//span[normalize-space()='Liubomyr Lender']";//"//div[. = 'Liubomyr Lender']";qwe
        private string _AddDocBtn = "btnAddDocument";
        private string _NewDocName = "txtNewDocType";
        private string _SelectFiles = "//div[. = 'Select files...']";
        private string FilePath = System.IO.Path.GetFullPath(@"Attachments\PdfSample.pdf");
        private string TxtFilePath = System.IO.Path.GetFullPath(@"Attachments\TxtSample.txt");
        private string InvalidPdfFilePath = System.IO.Path.GetFullPath(@"Attachments\PdfSampleForInvalidDocumentSize.pdf");
        private string _TestDoc= "//*[text()[contains(..,'Test')]]";
        private string _SuccessToast = "//div[@id='toast-container']/div/div";
        private string _RenameDocBtn = "btnEditDocName";
        private string _OkBtn = "//button[normalize-space()='OK']";
        private string _SucPopUpMessage = "//div[@class='modal-body']";
        private string _DeleteBtn = "btnDeleteDocument";
        private string _DeleteConfirmationBtn = "btnConfirmDeleteDocument";
        private string _AddParentDocBtn = "btnAddParentDocument";
        private string _PlusAddParentDocBtn="btnAddParentDoc";
        private string _NewParentDocTextField = "txtNewParentDoc";
        private string _ParentDoc = "//*[contains(text(), '(P) Parent')]";
        private string _AddChildBtn = "btnAddChildDocument";
        private string _ChildDocNameTextField = "txtNewChildDocType";
        private string _AddConditionBtn = "//button[normalize-space()='+ Condition']";
        private string _SelectConditionType = "//span[contains(text(),'Select Field...')]";
        private string _ConditionOperator = "//span[contains(text(),'=')]";
        private string _SaveConditionsBtn = "btnSaveDocConditions";
        private string _RemoveConditionBtn = "(//button[@type='button'][normalize-space()='×'])[2]";
        private string _BorrowerCondType = "//span[contains(text(),'Borrower - Annual/Yearly Gross Income')]";
        private string _ConditionOperatorForEdit = "//span[contains(text(),'<')]";
        private string _DocWithConditions="//li[contains(text(),'DocConditions')]";
        private string _ConditionTypeForVer = "//span[contains(text(),'Deal - Amount Financed (In Words)')]";
        private string _ConditionOperatorForVer = "//span[contains(text(),'<>')]";
        private string _EditBtn = "btnOpenDocEditor";
        private string _AddFieldMappingBtn = "//div[@id='docEditorToolbar']//button[1]";
        private string _SelectFieldMapping = "/html[1]/body[1]/div[4]/div[2]/div[1]/div[3]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/span[2]/span[1]/span[1]";
        private string _SaveMappingsBtn = "//div[@id='docEditorToolbar']//button[@id='btnSaveMappings']";
        private string _FieldMappingCheckBox = "/html[1]/body[1]/div[4]/div[2]/div[1]/div[3]/div[1]/div[1]/div[2]/div[2]/div[1]/div[1]/input[2]";
        private string _PlusConditionBrn = "/html[1]/body[1]/div[4]/div[2]/div[1]/div[3]/div[1]/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/button[1]";
        private string _ConditionTypeForMapping = "/html[1]/body[1]/div[4]/div[2]/div[1]/div[3]/div[1]/div[1]/div[2]/div[2]/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/span[1]/span[1]/span[1]";
        private string _CopyFieldsTo = "/html[1]/body[1]/content[1]/div[1]/section[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[1]/div[2]/div[1]/div[1]/div[1]/div[2]/div[1]/button[1]";
        private string _CopyFieldsPopUpMsg = "//div[contains(text(),'Liubomyr Lender - RenamedDoc_02.12.2021 10:39:44')]";
        private string _CopyBtn = "/html[1]/body[1]/div[5]/div[2]/div[1]/div[1]/div[5]/div[1]/button[1]";
        private string _AddDocTypeToastMessage = "/html[1]/body[1]/div[30]/div[1]/div[1]";
        private string _SelDocTypeForCopyFields = "/html[1]/body[1]/div[5]/div[2]/div[1]/div[1]/div[4]/div[1]/span[2]/span[1]/span[1]";
        private string _FailPopupForCopyFields = "/html[1]/body[1]/div[16]/div[1]/div[1]";
        private string _SelectLenderForCopyFields = "//*[@id='copyFieldsPopupContainer']/div/div[4]/div/span[1]/span/span[1]";//"/html[1]/body[1]/div[5]/div[2]/div[1]/div[1]/div[4]/div[1]/span[1]/span[1]/span[1]";
        private string _YesBtnForCopyField = "//button[normalize-space()='Yes']";
        #endregion

        #region ELEMENT

        private IWebElement Lender => FindElementByXpath(_Lender);
        private IWebElement AddDocBtn => FindElementById(_AddDocBtn);
        private IWebElement NewDocName => FindElementById(_NewDocName);
        private IWebElement SelectFiles => FindElementByXpath(_SelectFiles);
        private IWebElement TestDoc => FindElementByXpath(_TestDoc);
        private IWebElement SuccessToast => FindElementByXpath(_SuccessToast);
        private IWebElement RenameDocBtn => FindElementById(_RenameDocBtn);
        private IWebElement OkBtn => FindElementByXpath(_OkBtn);
        private IWebElement SucPopUpMessage => FindElementByXpath(_SucPopUpMessage);
        private IWebElement DeleteBtn => FindElementById(_DeleteBtn);
        private IWebElement DeleteConfirmationButton => FindElementById(_DeleteConfirmationBtn);
        private IWebElement AddParentDocBtn => FindElementById(_AddParentDocBtn);
        private IWebElement PlusAddParentDocBtn => FindElementById(_PlusAddParentDocBtn);
        private IWebElement NewParentDocTextField => FindElementById(_NewParentDocTextField);
        private IWebElement ParentDoc => FindElementByXpath(_ParentDoc);
        private IWebElement AddChildBtn => FindElementById(_AddChildBtn);
        private IWebElement ChildDocName => FindElementById(_ChildDocNameTextField);
        private IWebElement AddConditionBtn => FindElementByXpath(_AddConditionBtn);
        private IWebElement ConditionType => FindElementByXpath(_SelectConditionType);
        private IWebElement ConditionOperator => FindElementByXpath(_ConditionOperator);
        private IWebElement SaveConditionsBtn => FindElementById(_SaveConditionsBtn);
        private IWebElement RemoveConditionBtn => FindElementByXpath(_RemoveConditionBtn);
        private IWebElement BorrowerCondType => FindElementByXpath(_BorrowerCondType);
        private IWebElement ConditionOperatorForEdit => FindElementByXpath(_ConditionOperatorForEdit);
        private IWebElement DocWithConditions => FindElementByXpath(_DocWithConditions);
        private IWebElement ConditionTypeForVer => FindElementByXpath(_ConditionTypeForVer);
        private IWebElement ConditionOperatorForVer => FindElementByXpath(_ConditionOperatorForVer);
        private IWebElement EditBtn => FindElementById(_EditBtn);
        private IWebElement AddFieldMappingBtn => FindElementByXpath(_AddFieldMappingBtn);
        private IWebElement SelectFieldMapping => FindElementByXpath(_SelectFieldMapping);
        private IWebElement SaveMappingsBtn => FindElementByXpath(_SaveMappingsBtn);
        private IWebElement FieldMappingCheckBox => FindElementByXpath(_FieldMappingCheckBox);
        private IWebElement PlusConditionBtn => FindElementByXpath(_PlusConditionBrn);
        private IWebElement ConditionTypeForMapping => FindElementByXpath(_ConditionTypeForMapping);
        private IWebElement CopyFieldsTo => FindElementByXpath(_CopyFieldsTo);
        private IWebElement CopyFieldsPopUpMsg => FindElementByXpath(_CopyFieldsPopUpMsg);
        private IWebElement CopyBtn => FindElementByXpath(_CopyBtn);
        private IWebElement AddDocTypeToastMsg=> FindElementByXpath(_AddDocTypeToastMessage);
        private IWebElement SelDocTypeForCopyFields => FindElementByXpath(_SelDocTypeForCopyFields);
        private IWebElement FailPopupForCopyFields => FindElementByXpath(_FailPopupForCopyFields);
        private IWebElement SelectLenderForCopyFields => FindElementByXpath(_SelectLenderForCopyFields);
        private IWebElement YesBtnForCopyFields=>FindElementByXpath(_YesBtnForCopyField);
        #endregion


        #region METHOD
        public void BaseAuth()
        {
            sim.Keyboard.TextEntry("docgen2");
            sim.Keyboard.KeyPress(VirtualKeyCode.TAB);
            sim.Keyboard.TextEntry("HotLikeTheBeachBoys703");
            sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }
        public void ChooseLender() 
        {
            //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(Lender)).Click();
            Lender.Click();
        }

        public void ClickOnAddDocBtn()
        {
            AddDocBtn.Click();
        }

        public void EnterValidDocName() 
        {
            NewDocName.SendKeys("Test_" + DateTime.Now);
        }

        public void EnterMoreThan128SymbolsInDocName()
        {
            NewDocName.SendKeys("EnterMoreThan128SymbolsInDocName!@#EnterMoreThan128SymbolsInDocName!@#EnterMoreThan128SymbolsInDocNameEnterMoreThan128SymbolsInDocName!@#");
        }

        public void EnterAlreadyExistingDocTypeName()
        {
            NewDocName.SendKeys("Test");
        }

        public void ClickOnSelectFiles()
        {
            SelectFiles.Click();
        }

        public void ChoosingValidPdfFile()
        {
            sim.Keyboard.Sleep(3000);
            sim.Keyboard.TextEntry(FilePath);
            sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            //String script = "document.getElementsByClassName('k-button k-upload-button').value='" + "C:\\Users\\admin\\source\\repos\\Phoenix2.Tests\\Phoenix2.UITests\\Attachments\\PdfSample.pdf" + "';";
            //((IJavaScriptExecutor)PageDriver).ExecuteScript(script);
        }

        public void ChoosingTxtFile()
        {
            sim.Keyboard.Sleep(3000);
            sim.Keyboard.TextEntry(TxtFilePath);
            sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }
        
        public void ChoosingInvalidPdfFile()
        {
            sim.Keyboard.Sleep(5000);
            sim.Keyboard.TextEntry(InvalidPdfFilePath);
            sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }
        public void ClickOnOkPopup()
        {  
            SuccessToast.Click();
        }

        public void ClickOnRenameBtn()
        {
            RenameDocBtn.Click();
        }
        public void RenameDocument()
        {
            sim.Keyboard.Sleep(2000);
            sim.Keyboard.TextEntry("RenamedDoc_" + DateTime.Now);
        }
        public void RenameDocumentInvalidNewName()
        {
            sim.Keyboard.TextEntry("EnterMoreThan128SymbolsInDocName!@#EnterMoreThan128SymbolsInDocName!@#EnterMoreThan128SymbolsInDocNameEnterMoreThan128SymbolsInDocName!@#");
        }
        public void RenameDocWithAlreadyExistingDocName()
        {
            sim.Keyboard.TextEntry("Test");
        }
        public void ClickOnOkBtn()
        {
            OkBtn.Click();
        }
        public void ClickOnDeleteBtn()
        {
            DeleteBtn.Click();
        }
        public void ClickOnDeleteConfirmBtn()
        {
            DeleteConfirmationButton.Click();
        }
        public void ClickOnAddParentBtn()
        {
            AddParentDocBtn.Click();
        }
        public void ClickOnPlusAddParentDocBtn()
        {
            PlusAddParentDocBtn.Click();
        }
        public void AddNewParentDocName()
        {
            NewParentDocTextField.SendKeys("Parent_" + DateTime.Now);
        }
        public void AddInvalidParentDocName()
        {
            NewParentDocTextField.SendKeys("EnterMoreThan128SymbolsInDocName!@#EnterMoreThan128SymbolsInDocName!@#EnterMoreThan128SymbolsInDocNameEnterMoreThan128SymbolsInDocName!@#");
        }

        public void AddAlreadyExistingParentName()
        {
            NewParentDocTextField.SendKeys("Parent");
        }
        public void ClickOnParentDoc()
        {
            ParentDoc.Click();
        }

        public void ClickOnAddChildButton()
        {
            AddChildBtn.Click();
        }

        public void EnterChildDocName()
        {
            ChildDocName.SendKeys("Child_" + DateTime.Now);
        }
        public void EnterInvalidChildDocName()
        {
            ChildDocName.SendKeys("EnterMoreThan128SymbolsInDocName!@#EnterMoreThan128SymbolsInDocName!@#EnterMoreThan128SymbolsInDocNameEnterMoreThan128SymbolsInDocName!@#");
        }
        public void ClickOnAddConditionBtn()
        {
            AddConditionBtn.Click();
        }
        public void ValidateDocConditions()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ConditionTypeForVer));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(ConditionOperatorForVer));
        }
        public void AddCondition()
        {
            ConditionType.Click();
            for (int i = 0; i <= 4; i++)
            { sim.Keyboard.KeyPress(VirtualKeyCode.DOWN); }
            sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            ConditionOperator.Click();
            for (int i = 0; i <=2; i++)
            { sim.Keyboard.KeyPress(VirtualKeyCode.DOWN); }
            sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            sim.Keyboard.Sleep(1000);
            sim.Keyboard.KeyPress(VirtualKeyCode.TAB);
            sim.Keyboard.TextEntry("DocCondition" + DateTime.Now);
        }
        public void ClickOnSaveConditionsBtn()
        {
            SaveConditionsBtn.Click();
        }
        public void ClickOnRemoveConditionBtn()
        {
            RemoveConditionBtn.Click();
        }
        public void EditCondition()
        {
            BorrowerCondType.Click();
            sim.Keyboard.KeyPress(VirtualKeyCode.UP);
            sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            ConditionOperatorForEdit.Click();
            sim.Keyboard.KeyPress(VirtualKeyCode.DOWN);
            sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            sim.Keyboard.Sleep(1000);
            sim.Keyboard.KeyPress(VirtualKeyCode.TAB);
            sim.Keyboard.TextEntry("EditedCondition_" + DateTime.Now);
               
        }
        public void ClickOnDocWithConditions()
        {
            DocWithConditions.Click();
        }
        public void ClickOnEditBtn()
        {
            EditBtn.Click();
        }
        public void ClickOnAddFieldMappingBtn()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(AddFieldMappingBtn));
            AddFieldMappingBtn.Click();
        }

        public void ClickOnSaveMappingsBtn()
        {
            SaveMappingsBtn.Click();
        }
        public void AddMappingField()
        {
            SelectFieldMapping.Click();
            sim.Keyboard.KeyPress(VirtualKeyCode.DOWN);
            sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }

        public void ClickOnPlusConditionBtn()
        {
            PlusConditionBtn.Click();
        }
        public void AddConditionForMapping()
        {
            ConditionTypeForMapping.Click();
            sim.Keyboard.KeyPress(VirtualKeyCode.DOWN);
            sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            ConditionOperator.Click();
            sim.Keyboard.KeyPress(VirtualKeyCode.DOWN);
            sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
            sim.Keyboard.KeyPress(VirtualKeyCode.TAB);
            sim.Keyboard.TextEntry("Condition_" + DateTime.Now);
        }
        public void ClickOnCopyFieldsBtn()
        {
            CopyFieldsTo.Click();
        }
        public void ValidateCopyFieldsPopup()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(CopyFieldsPopUpMsg)); 
        }
        public void ClickOnCopyBtn()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementSelectionStateToBe(CopyBtn, false)); 
            CopyBtn.Click();
        }
        public void ValidateToastMsg()
        {
            AddDocTypeToastMsg.Click();
        }
        public void SelectingDocTypeForCopyFields()
        {   
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SelDocTypeForCopyFields));
            SelDocTypeForCopyFields.Click();
            sim.Keyboard.Sleep(3000);
            sim.Keyboard.KeyPress(VirtualKeyCode.DOWN);
            sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }
        public void SelectingLenderForCopyFields()
        {
            //Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(SelectLenderForCopyFields));
            //SelectLenderForCopyFields.Click();
            sim.Keyboard.Sleep(3000);
            sim.Keyboard.KeyPress(VirtualKeyCode.TAB);
            sim.Keyboard.KeyPress(VirtualKeyCode.DOWN);
            sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }
        public void ValidateFailPopupForCopyFields()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(FailPopupForCopyFields));
            FailPopupForCopyFields.Click();
        }
        public void ClickOnYesBtnForCopyFields()
        {
            YesBtnForCopyFields.Click();
        }   
        #endregion
    }
}

