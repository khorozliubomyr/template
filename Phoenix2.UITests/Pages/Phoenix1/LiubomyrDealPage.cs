﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;
using WindowsInput.Native;

namespace Phoenix2.UITests.Pages.Phoenix1
{
    class LiubomyrDealPage:BaseDriver
    {
        #region driver
        public LiubomyrDealPage(IWebDriver driver) : base(driver)
        {
            PageDriver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

        protected override string PageTitle => "Liubomyr Khoroz - Phoenix";
        protected override string PageUrl => "https://phoenixqa.ilendingdirect.com/ContactManagerNew?contactID=316851";
        InputSimulator sim = new InputSimulator();
        #endregion
        #region PATH
        private string _DocsBtn = "(//button[@id='btnGroupDrop1'])[2]";

        private string _DocGenDropdDown = "//a[normalize-space()='Doc Gen']";
        private string _DocGenCustomDropDown = "//a[normalize-space()='Custom Doc Gen']";
        private string _CustomDocGen2DocuSign = "//a[normalize-space()='Custom - Doc Gen & DocuSign']";
        private string _DocGenDocuSignDropDown = "//a[normalize-space()='Doc Gen & DocuSign']";

        private string _HamburgerMenu = "//a[@class='sidebar-toggle']";
        private string _DocGenVerification = "//span[contains(text(), 'Docs generated by Liubomyr Khoroz')]";
        private string _DealSavingMessage = "//div[@class='bootbox-body']";


        private string _SelectAllFromPopup = "//button[normalize-space()='Select All']";
        private string _GenerateBtn = "//button[normalize-space()='Generate']";

        private string _IntroLetterCheckBox = "fcc80d70-f0b0-4073-806a-5bb499cc53a8";
        private string _LoanAndSecAgrCheckBox = "0dcd2c2e-f1ca-4aee-9995-077b4d29dcc0";
        private string _CreditApplCheckBox = "79ae1cda-7ade-47b9-9eed-675092eb05b9";
        private string _CommentAboutDocGeneration = "(//div[contains(text(),'Docs generated by Liubomyr Khoroz')])[1]";
        private string _TitleDocGen2DropDown = "//a[normalize-space()='Title Doc Gen']";
        private string _OkBtn = "//button[normalize-space()='OK']";
        private string _NextStepBtn = "//div[@id='DWF_127551']//div//button[@type='button']";

        private string _NoTitleFound = "//div[contains(text(),'No Template found with name: ACU of Texas - Single')]";
        private string _ChooseDealForDocGenDocuSign = "//tbody/tr[3]/td[11]/a[1]";
        private string _ContinueBtnForDocGenDocuSign = "//button[normalize-space()='Continue']";
        private string _TitleAppDropDown= "//a[normalize-space()='Title App']";
        private string _TitleAuditDropDown = "//a[normalize-space()='Title Audit']";
        private string _TitleAuditSuccessPopup = "(//div[contains(text(),'TitleAudit docs generated by Liubomyr Khoroz')])";

        private string _ChooseDealForDocGenDocuSignWithoutTemplate = "//tbody/tr[1]/td[11]/a[1]";
        private string _VoidBtn= "//button[normalize-space()='Void']";
        private string _EmptyDocsPopup = "//div[normalize-space()='No Documents selected']";
        private string _YesBtn = "//button[normalize-space()='Yes']";
        #endregion

        #region ELEMENT
        private IWebElement DocsBtn => FindElementByXpath(_DocsBtn);
        private IWebElement DocGenDropDown=> FindElementByXpath(_DocGenDropdDown);
        private IWebElement HamburgerMenu => FindElementByXpath(_HamburgerMenu);
        private IWebElement DocGenVerification => FindElementByXpath(_DocGenVerification);
        private IWebElement DealSavingMessage => FindElementByXpath(_DealSavingMessage);
        private IWebElement DocGenCustomDropDown => FindElementByXpath(_DocGenCustomDropDown);
        private IWebElement SelectAllFromPopup => FindElementByXpath(_SelectAllFromPopup);
        private IWebElement GenerateBtn => FindElementByXpath(_GenerateBtn);
        private IWebElement IntroLetterCheckBox => FindElementById(_IntroLetterCheckBox);
        private IWebElement LoanAndSecAgrCheckBox => FindElementById(_LoanAndSecAgrCheckBox);
        private IWebElement CreditApplCheckBox => FindElementById(_CreditApplCheckBox);
        private IWebElement NoteAboutDocGeneration => FindElementByXpath(_CommentAboutDocGeneration);
        private IWebElement TitleDocGen2DropDown => FindElementByXpath(_TitleDocGen2DropDown);
        private IWebElement OkBtn => FindElementByXpath(_OkBtn);
        private IWebElement NextStepBtn => FindElementByXpath(_NextStepBtn);
        private IWebElement DocGenDocuSignDropDown => FindElementByXpath(_DocGenDocuSignDropDown);
        private IWebElement NoTitleFound => FindElementByXpath(_NoTitleFound);
        private IWebElement ChooseDealDocGenDocuSign => FindElementByXpath(_ChooseDealForDocGenDocuSign);
        private IWebElement ContinueBtnForDocGenDocuSign => FindElementByXpath(_ContinueBtnForDocGenDocuSign);
        private IWebElement TitleAppDropDown => FindElementByXpath(_TitleAppDropDown);
        private IWebElement TitleAuditDropDown => FindElementByXpath(_TitleAuditDropDown);
        private IWebElement TitleAuditSuccessPopup => FindElementByXpath(_TitleAuditSuccessPopup);
        private IWebElement CustomDocGen2DocuSign => FindElementByXpath(_CustomDocGen2DocuSign);
        private IWebElement ChooseDealWithoutTemplate => FindElementByXpath(_ChooseDealForDocGenDocuSignWithoutTemplate);
        private IWebElement VoidBtn => FindElementByXpath(_VoidBtn);
        private IWebElement EmptyDocsPopup => FindElementByXpath(_EmptyDocsPopup);
        private IWebElement YesBtn => FindElementByXpath(_YesBtn);
        #endregion
        #region METHOD
        public void ClickOnDocsBtn()
        {
            DocsBtn.Click();
        }
        public void ClickOnDocGenDropDownMenu()
        {
            DocGenDropDown.Click();
        }
        public void ClickOnHamburgerMenu()
        {
            HamburgerMenu.Click();
        }
        public void ValidateDocumentGeneration()    
        {
            string originalWindow = PageDriver.CurrentWindowHandle;
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//span[contains(text(), 'Docs generated by Liubomyr Khoroz')]")));
        }
        public void ValidateDealSavingMessage()
        {
            DealSavingMessage.Click();
        }
        public void ClickOnDoGenCustomDropDown()
        {
            DocGenCustomDropDown.Click();
        }
        public void ClickOnSelectAll()
        {
            SelectAllFromPopup.Click();
        }
        public void ClickOnGenerateBtn()
        {
            GenerateBtn.Click();
        }
        public void ValidateTabWithDocument() 
        {
            string originalWindow = PageDriver.CurrentWindowHandle;

            Wait.Until(wd => wd.WindowHandles.Count == 2);
        }
        public void ScrapTheText()
        {
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://phoenixdev.ilendingdirect.com/ContactManager/Details/?id=316851&showPartial=false&openTab=3&openDealID=1000682#");
            foreach (var item in doc.DocumentNode.SelectNodes("//a[@class='selected-doc-type-id']"))
            {
                Console.WriteLine(item.InnerText);
            }
        }
        public void ClickOnSeveralDocs()
        {
            Thread.Sleep(3000);
            sim.Keyboard.KeyPress(VirtualKeyCode.TAB);
            sim.Keyboard.KeyPress(VirtualKeyCode.TAB);
            sim.Keyboard.KeyPress(VirtualKeyCode.TAB);
            sim.Keyboard.KeyPress(VirtualKeyCode.SPACE);
            sim.Keyboard.KeyPress(VirtualKeyCode.TAB);
            sim.Keyboard.KeyPress(VirtualKeyCode.SPACE);
            sim.Keyboard.KeyPress(VirtualKeyCode.TAB);
            sim.Keyboard.KeyPress(VirtualKeyCode.SPACE);

            //IntroLetterCheckBox.Click();
            //LoanAndSecAgrCheckBox.Click();
            //CreditApplCheckBox.Click();     

        }
        public void ValidateDocGenComment()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_CommentAboutDocGeneration)));
        }
        public void ClickOnTitleDocGen2()
        {
            TitleDocGen2DropDown.Click();
        }
        public void ClickOnOkBtn()
        {
            OkBtn.Click();
        }
        public void WaitForNextStepBtn()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_NextStepBtn)));
        }
        public void ClickOnDocGenDocuSignDropDown()
        {
            DocGenDocuSignDropDown.Click();
        }
        public void NoTemplatePopupValidation()
        {
            NoTitleFound.Click();
        }
        public void ChooseDealForDocGenDocuSignGenerating()
        {
            ChooseDealDocGenDocuSign.Click();
        }
        public void ClickOnContinueBtn()
        {
            ContinueBtnForDocGenDocuSign.Click();
        }
        public void ClickOnTitleAppDropDown()
        {
            TitleAppDropDown.Click();
        }
        public void ClickOnTitleAuditDropDown()
        {
            TitleAuditDropDown.Click();
        }
        public void ValidateTitleAuditSuccessPopup()
        {
            TitleAuditSuccessPopup.Click();
        }
        public void ClickOnCustomDocGen2DocuSignDropDown()
        {
            CustomDocGen2DocuSign.Click();
        }
        public void ChooseDocuSignDealWithoutTemplate()
        {
            ChooseDealWithoutTemplate.Click();
        }
        public void ClickOnVoidBtn()
        {
            VoidBtn.Click();
        }
        public void ClickOnEmptyDocsPopup()
        {
            EmptyDocsPopup.Click();
        }
        public void ClickOnYesBtn()
        {
            YesBtn.Click();
        }
        #endregion
    }
}
