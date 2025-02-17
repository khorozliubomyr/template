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

namespace Phoenix2.UITests.Tests.DocumentGeneration
{
    class DocumentGeneration : Settings
    {
        [Test]
        public void DocGenGenerationPositiveScenario()
        {
            var loginPage = new LoginPage(driver);
            var workinDealsPage = new WorkingDealsPage(driver);
            var mainDashboard = new MainDashboardPage(driver);
            var liubomyrDealPage = new LiubomyrDealPage(driver);
            loginPage.NavigateTo();
            loginPage.LoginAsUser(Credentials.AdminLogin, Credentials.AdminPassword);
            mainDashboard.EnsurePageLoaded();
            mainDashboard.ClickOnMyLcQueuesTab();
            mainDashboard.ClickOnWorkingDealsTab();
            workinDealsPage.ClickOnDeal();
            liubomyrDealPage.ClickOnHamburgerMenu();
            Thread.Sleep(10000);
            liubomyrDealPage.ClickOnDocsBtn();
            liubomyrDealPage.ClickOnDocGenDropDownMenu();
            liubomyrDealPage.ValidateTabWithDocument();
        }
        [Test]
        public void NotificationAboutPdfGeneration()
        {
            var loginPage = new LoginPage(driver);
            var workinDealsPage = new WorkingDealsPage(driver);
            var mainDashboard = new MainDashboardPage(driver);
            var liubomyrDealPage = new LiubomyrDealPage(driver);
            loginPage.NavigateTo();
            loginPage.LoginAsUser(Credentials.AdminLogin, Credentials.AdminPassword);
            mainDashboard.EnsurePageLoaded();
            mainDashboard.ClickOnMyLcQueuesTab();
            mainDashboard.ClickOnWorkingDealsTab();
            workinDealsPage.ClickOnDeal();
            liubomyrDealPage.ClickOnHamburgerMenu();
            Thread.Sleep(10000);
            liubomyrDealPage.ClickOnDocsBtn();
            liubomyrDealPage.ClickOnDocGenDropDownMenu();
            liubomyrDealPage.ValidateDealSavingMessage();
        }
        [Test]
        public void DocGenCustomPdfDocGenerationPositiveScenarioForAllDocFields()
        {
            var loginPage = new LoginPage(driver);
            var workinDealsPage = new WorkingDealsPage(driver);
            var mainDashboard = new MainDashboardPage(driver);
            var liubomyrDealPage = new LiubomyrDealPage(driver);
            loginPage.NavigateTo();
            loginPage.LoginAsUser(Credentials.AdminLogin, Credentials.AdminPassword);
            mainDashboard.EnsurePageLoaded();
            mainDashboard.ClickOnMyLcQueuesTab();
            mainDashboard.ClickOnWorkingDealsTab();
            workinDealsPage.ClickOnDeal();
            liubomyrDealPage.ClickOnHamburgerMenu();
            Thread.Sleep(10000);
            liubomyrDealPage.ClickOnDocsBtn();
            liubomyrDealPage.ClickOnDoGenCustomDropDown();
            liubomyrDealPage.ClickOnSelectAll();
            liubomyrDealPage.ClickOnGenerateBtn();
            liubomyrDealPage.ValidateTabWithDocument();
        }
        [Test]
        public void DocGen2CustomPdfDocGenerationPositiveScenarioPositiveScenarioForSeveralDocFields()
        {
            var loginPage = new LoginPage(driver);
            var workinDealsPage = new WorkingDealsPage(driver);
            var mainDashboard = new MainDashboardPage(driver);
            var liubomyrDealPage = new LiubomyrDealPage(driver);
            loginPage.NavigateTo();
            loginPage.LoginAsUser(Credentials.AdminLogin, Credentials.AdminPassword);
            mainDashboard.EnsurePageLoaded();
            mainDashboard.ClickOnMyLcQueuesTab();
            mainDashboard.ClickOnWorkingDealsTab();
            workinDealsPage.ClickOnDeal();
            liubomyrDealPage.ClickOnHamburgerMenu();
            Thread.Sleep(10000);
            liubomyrDealPage.ClickOnDocsBtn();
            liubomyrDealPage.ClickOnDoGenCustomDropDown();
            liubomyrDealPage.ClickOnSeveralDocs();
            liubomyrDealPage.ClickOnGenerateBtn();
            liubomyrDealPage.ValidateTabWithDocument();
        }

        [Test]
        public void DocGen2CustomPdfDocGenerationNotificationAboutPdfGeneration()
        {
            var loginPage = new LoginPage(driver);
            var workinDealsPage = new WorkingDealsPage(driver);
            var mainDashboard = new MainDashboardPage(driver);
            var liubomyrDealPage = new LiubomyrDealPage(driver);
            loginPage.NavigateTo();
            loginPage.LoginAsUser(Credentials.AdminLogin, Credentials.AdminPassword);
            mainDashboard.EnsurePageLoaded();
            mainDashboard.ClickOnMyLcQueuesTab();
            mainDashboard.ClickOnWorkingDealsTab();
            workinDealsPage.ClickOnDeal();
            liubomyrDealPage.ClickOnHamburgerMenu();
            Thread.Sleep(10000);
            liubomyrDealPage.ClickOnDocsBtn();
            liubomyrDealPage.ClickOnDoGenCustomDropDown();
            liubomyrDealPage.ClickOnSelectAll();
            liubomyrDealPage.ClickOnGenerateBtn();
            liubomyrDealPage.ValidateDealSavingMessage();
        }

        [Test]
        public void DocGen2CustomPdfDocGenerationSeveralDocumentsCreationNotificationValidation()
        {
            var loginPage = new LoginPage(driver);
            var workinDealsPage = new WorkingDealsPage(driver);
            var mainDashboard = new MainDashboardPage(driver);
            var liubomyrDealPage = new LiubomyrDealPage(driver);
            loginPage.NavigateTo();
            loginPage.LoginAsUser(Credentials.AdminLogin, Credentials.AdminPassword);
            mainDashboard.EnsurePageLoaded();
            mainDashboard.ClickOnMyLcQueuesTab();
            mainDashboard.ClickOnWorkingDealsTab();
            workinDealsPage.ClickOnDeal();
            liubomyrDealPage.ClickOnHamburgerMenu();
            Thread.Sleep(10000);
            liubomyrDealPage.ClickOnDocsBtn();
            liubomyrDealPage.ClickOnDoGenCustomDropDown();
            liubomyrDealPage.ClickOnSeveralDocs();
            liubomyrDealPage.ClickOnGenerateBtn();
            liubomyrDealPage.ValidateDealSavingMessage();
        }
        [Test]
        public void DocGen2CustomDealCommentGeneration()
        {
            var loginPage = new LoginPage(driver);
            var workinDealsPage = new WorkingDealsPage(driver);
            var mainDashboard = new MainDashboardPage(driver);
            var liubomyrDealPage = new LiubomyrDealPage(driver);
            loginPage.NavigateTo();
            loginPage.LoginAsUser(Credentials.AdminLogin, Credentials.AdminPassword);
            mainDashboard.EnsurePageLoaded();
            mainDashboard.ClickOnMyLcQueuesTab();
            mainDashboard.ClickOnWorkingDealsTab();
            workinDealsPage.ClickOnDeal();
            liubomyrDealPage.ClickOnHamburgerMenu();
            Thread.Sleep(10000);
            liubomyrDealPage.ClickOnDocsBtn();
            liubomyrDealPage.ClickOnDoGenCustomDropDown();
            liubomyrDealPage.ClickOnSeveralDocs();
            liubomyrDealPage.ClickOnGenerateBtn();
            liubomyrDealPage.ValidateDocGenComment();
        }
        [Test]
        public void DocGen2CustomPdfDocGenerationNegativeScenarioWithoutChosingAnyDocument()
        {
            var loginPage = new LoginPage(driver);
            var workinDealsPage = new WorkingDealsPage(driver);
            var mainDashboard = new MainDashboardPage(driver);
            var liubomyrDealPage = new LiubomyrDealPage(driver);
            loginPage.NavigateTo();
            loginPage.LoginAsUser(Credentials.AdminLogin, Credentials.AdminPassword);
            mainDashboard.EnsurePageLoaded();
            mainDashboard.ClickOnMyLcQueuesTab();
            mainDashboard.ClickOnWorkingDealsTab();
            workinDealsPage.ClickOnDeal();
            liubomyrDealPage.ClickOnHamburgerMenu();
            Thread.Sleep(10000);
            liubomyrDealPage.ClickOnDocsBtn();
            liubomyrDealPage.ClickOnDoGenCustomDropDown();
            liubomyrDealPage.ClickOnGenerateBtn();
            liubomyrDealPage.ClickOnEmptyDocsPopup();
        }
        [Test]
        public void TitleDocGenPdfDocGenerationPositiveScenario()
        {
            var loginPage = new LoginPage(driver);
            var workinDealsPage = new WorkingDealsPage(driver);
            var mainDashboard = new MainDashboardPage(driver);
            var liubomyrDealPage = new LiubomyrDealPage(driver);
            loginPage.NavigateTo();
            loginPage.LoginAsUser(Credentials.AdminLogin, Credentials.AdminPassword);
            mainDashboard.EnsurePageLoaded();
            mainDashboard.ClickOnMyLcQueuesTab();
            mainDashboard.ClickOnWorkingDealsTab();
            workinDealsPage.ClickOnDeal();
            liubomyrDealPage.ClickOnHamburgerMenu();
            liubomyrDealPage.WaitForNextStepBtn();
            Thread.Sleep(10000);
            liubomyrDealPage.ClickOnDocsBtn();
            liubomyrDealPage.ClickOnTitleDocGen2();
            liubomyrDealPage.ClickOnYesBtn();
            liubomyrDealPage.ValidateTabWithDocument();
        }
        [Test]
        public void DocGenDocuSignGenerationOfThePdfDocPositiveScenario()
        {
            var loginPage = new LoginPage(driver);
            var workinDealsPage = new WorkingDealsPage(driver);
            var mainDashboard = new MainDashboardPage(driver);
            var liubomyrDealPage = new LiubomyrDealPage(driver);
            loginPage.NavigateTo();
            loginPage.LoginAsUser(Credentials.AdminLogin, Credentials.AdminPassword);
            mainDashboard.EnsurePageLoaded();
            mainDashboard.ClickOnMyLcQueuesTab();
            mainDashboard.ClickOnWorkingDealsTab();
            workinDealsPage.ClickOnDeal();
            liubomyrDealPage.ClickOnHamburgerMenu();
            liubomyrDealPage.WaitForNextStepBtn();
            Thread.Sleep(10000);
            liubomyrDealPage.ClickOnDocsBtn();
            liubomyrDealPage.ClickOnDocGenDocuSignDropDown();
            liubomyrDealPage.ClickOnVoidBtn();
            liubomyrDealPage.ValidateTabWithDocument();
        }
        [Test]
        public void DocGenDocuSignGenerationOfThePdfDocNegativeScenarioForMissingTemplate()
        {
            var loginPage = new LoginPage(driver);
            var workinDealsPage = new WorkingDealsPage(driver);
            var mainDashboard = new MainDashboardPage(driver);
            var liubomyrDealPage = new LiubomyrDealPage(driver);
            loginPage.NavigateTo();
            loginPage.LoginAsUser(Credentials.AdminLogin, Credentials.AdminPassword);
            mainDashboard.EnsurePageLoaded();
            mainDashboard.ClickOnMyLcQueuesTab();
            mainDashboard.ClickOnWorkingDealsTab();
            workinDealsPage.ClickOnDeal();
            liubomyrDealPage.ClickOnHamburgerMenu();
            liubomyrDealPage.WaitForNextStepBtn();
            Thread.Sleep(10000);
            liubomyrDealPage.ClickOnDocsBtn();
            liubomyrDealPage.ClickOnDocGenDocuSignDropDown();
            liubomyrDealPage.ClickOnVoidBtn();
            liubomyrDealPage.ValidateTabWithDocument();
        }
        [Test]
        public void TitleAppGenerationOfThePdfDocPositiveScenario()
        {
            var loginPage = new LoginPage(driver);
            var workinDealsPage = new WorkingDealsPage(driver);
            var mainDashboard = new MainDashboardPage(driver);
            var liubomyrDealPage = new LiubomyrDealPage(driver);
            loginPage.NavigateTo();
            loginPage.LoginAsUser(Credentials.AdminLogin, Credentials.AdminPassword);
            mainDashboard.EnsurePageLoaded();
            mainDashboard.ClickOnMyLcQueuesTab();
            mainDashboard.ClickOnWorkingDealsTab();
            workinDealsPage.ClickOnDeal();
            liubomyrDealPage.ClickOnHamburgerMenu();
            liubomyrDealPage.WaitForNextStepBtn();
            Thread.Sleep(10000);
            liubomyrDealPage.ClickOnDocsBtn();
            liubomyrDealPage.ClickOnTitleAppDropDown();
            liubomyrDealPage.ValidateTabWithDocument();
        }
        [Test]
        public void TitleAuditGenerationPositiveScenario()
        {
            var loginPage = new LoginPage(driver);
            var workinDealsPage = new WorkingDealsPage(driver);
            var mainDashboard = new MainDashboardPage(driver);
            var liubomyrDealPage = new LiubomyrDealPage(driver);
            loginPage.NavigateTo();
            loginPage.LoginAsUser(Credentials.AdminLogin, Credentials.AdminPassword);
            mainDashboard.EnsurePageLoaded();
            mainDashboard.ClickOnMyLcQueuesTab();
            mainDashboard.ClickOnWorkingDealsTab();
            workinDealsPage.ClickOnDeal();
            liubomyrDealPage.ClickOnHamburgerMenu();
            liubomyrDealPage.WaitForNextStepBtn();
            Thread.Sleep(10000);
            liubomyrDealPage.ClickOnDocsBtn();
            liubomyrDealPage.ClickOnTitleAuditDropDown();
            liubomyrDealPage.ClickOnOkBtn();
            //liubomyrDealPage.ValidateTabWithDocument();
        }
        [Test]
        public void CustomDocGenDocuSignPdfDocumentGenerationPositiveScenarioForAllFields()
        {

            var loginPage = new LoginPage(driver);
            var workinDealsPage = new WorkingDealsPage(driver);
            var mainDashboard = new MainDashboardPage(driver);
            var liubomyrDealPage = new LiubomyrDealPage(driver);
            loginPage.NavigateTo();
            loginPage.LoginAsUser(Credentials.AdminLogin, Credentials.AdminPassword);
            mainDashboard.EnsurePageLoaded();
            mainDashboard.ClickOnMyLcQueuesTab();
            mainDashboard.ClickOnWorkingDealsTab();
            workinDealsPage.ClickOnDeal();
            liubomyrDealPage.ClickOnHamburgerMenu();
            liubomyrDealPage.WaitForNextStepBtn();
            Thread.Sleep(10000);
            liubomyrDealPage.ClickOnDocsBtn();
            liubomyrDealPage.ClickOnCustomDocGen2DocuSignDropDown();
            liubomyrDealPage.ClickOnSelectAll();
            liubomyrDealPage.ClickOnGenerateBtn();
            liubomyrDealPage.ClickOnVoidBtn();
            liubomyrDealPage.ValidateTabWithDocument();
        }
        [Test]
        public void CustomDocGen2DocuSignPdfDocumentGenerationPositiveScenarioForSeveralFields()
        {

            var loginPage = new LoginPage(driver);
            var workinDealsPage = new WorkingDealsPage(driver);
            var mainDashboard = new MainDashboardPage(driver);
            var liubomyrDealPage = new LiubomyrDealPage(driver);
            loginPage.NavigateTo();
            loginPage.LoginAsUser(Credentials.AdminLogin, Credentials.AdminPassword);
            mainDashboard.EnsurePageLoaded();
            mainDashboard.ClickOnMyLcQueuesTab();
            mainDashboard.ClickOnWorkingDealsTab();
            workinDealsPage.ClickOnDeal();
            liubomyrDealPage.ClickOnHamburgerMenu();
            liubomyrDealPage.WaitForNextStepBtn();
            Thread.Sleep(10000);
            liubomyrDealPage.ClickOnDocsBtn();
            liubomyrDealPage.ClickOnCustomDocGen2DocuSignDropDown();
            liubomyrDealPage.ClickOnSeveralDocs();
            liubomyrDealPage.ClickOnGenerateBtn();
            liubomyrDealPage.ClickOnVoidBtn();
            liubomyrDealPage.ValidateTabWithDocument();
        }
        [Test]
        public void CustomDocGenDocuSignPdfDocumentGenerationPositiveScenarioForEmptyDocFields()
        {

            var loginPage = new LoginPage(driver);
            var workinDealsPage = new WorkingDealsPage(driver);
            var mainDashboard = new MainDashboardPage(driver);
            var liubomyrDealPage = new LiubomyrDealPage(driver);
            loginPage.NavigateTo();
            loginPage.LoginAsUser(Credentials.AdminLogin, Credentials.AdminPassword);
            mainDashboard.EnsurePageLoaded();
            mainDashboard.ClickOnMyLcQueuesTab();
            mainDashboard.ClickOnWorkingDealsTab();
            workinDealsPage.ClickOnDeal();
            liubomyrDealPage.ClickOnHamburgerMenu();
            liubomyrDealPage.WaitForNextStepBtn();
            Thread.Sleep(10000);
            liubomyrDealPage.ClickOnDocsBtn();
            liubomyrDealPage.ClickOnCustomDocGen2DocuSignDropDown();
            liubomyrDealPage.ClickOnGenerateBtn();
            liubomyrDealPage.ClickOnEmptyDocsPopup();

        }
    }
}
