using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WindowsInput;

namespace Phoenix2.UITests.Pages.Phoenix2
{
    class TeamManagerPageDev : BaseDriver
    {
        #region driver
        public TeamManagerPageDev(IWebDriver driver) : base(driver)
        {
            PageDriver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }
        InputSimulator sim = new InputSimulator();
        protected override string PageTitle => "Phoenix 2.0";
        protected override string PageUrl => "https://dev-api-v2.ilendingdirect.com/admin-tools/team-manager?tab=0";
        #endregion

        #region PATH
        private string _teamsTab = "//button[text()='Teams']";
        private string _teamTypesTab = "//button[text()='Team Types']";
        private string _copyTeamsTab = "//button[text()='Copy Teams']";
        private string _savedButton = "//button[text()='Saved']";
        private string _addTeamButton = "//*[@data-testid='AddIcon']";
        private string _periodDropDown = "(//*[@aria-haspopup='listbox'])[1]";
        private string _dataOfPeriodDropDown = "(//*[@role='option'])[2]";
        private string _teamTypeDropDown = "(//*[@aria-haspopup='listbox'])[2]";
        private string _dataOfTeamTypeDropDown = "(//li[text()='TestLB'])[1]";
        private string _managerSection = "//*[@placeholder='Select Managers']";
        private string _searchAgentsField = "(//*[@class='sc-cCsOjp sc-dPyBCJ ijvhXg PvSEE MuiOutlinedInput-input MuiInputBase-input'])[2]";
        private string _unassignedAgentsSection = "//*[@data-rbd-droppable-id='unassigned']";
        private string _editButtonOfTeam = "//button[text()='Edit']";
        private string _teamNameFieldOfCreateTeamPopUp = "//*[@role='dialog']//*[@class='sc-cCsOjp sc-dPyBCJ ijvhXg PvSEE MuiOutlinedInput-input MuiInputBase-input']";
        private string _saveButtonOfCreateTeamPopUp = "//button[text()='Save']";
        private string _saveButtonOfTeamPopUp = "//*[@role='dialog']//button[text()='Save']";
        private string _deleteTeamButtonOfTeamPopUp = "//*[@role='dialog']//button[text()='Delete Team']";
        private string _confirmButton = "//*[@role='dialog']//button[text()='Confirm']";
        private string _directorSectionOfTeam = "//div[@data-rbd-droppable-id='0_Director']//li";
        private string _lieutenantSectionOfTeam = "//*[@data-rbd-droppable-id='0_Lieutenant']";
        private string _memberSectionOfTeam = "//*[@data-rbd-droppable-id='0_Member']";
        private string _successfulyPopup = "//div[contains(text(),'Successfully')]";
        private string _periodDropDownOfCreateTeamPopUp = "(//*[@role='dialog']//*[@aria-haspopup='listbox'])[1]";
        private string _deleteIconForManagerSection = "(//*[@data-testid='CancelIcon'])[1]";
        private string _recordInUnassignedAgentsSection = "(//li[@class='sc-bjUoiL ghxyHs MuiListItem-root MuiListItem-gutters sc-cqYYBx fUpYvE'])[1]";


        private string _addTeamTypeButton = "//button[text()='Add Team Type']";
        private string _teamTypeTable = "//*[@class='sc-fWjsSh jRXoFh MuiDataGrid-main']";
        private string _teamTypeNameField = "//*[@role='dialog']//*[@class='sc-cCsOjp sc-dPyBCJ ijvhXg PvSEE MuiOutlinedInput-input MuiInputBase-input']";
        private string _cancelButton = "//button[text()='Cancel']";
        private string _recordForEditOfTeamTypesTable = "(//div[contains(text(),'TestTeam')])[1]";
        private string _editIcon = "(//div[contains(text(),'TestTeam')])[1]/following::*[name()='svg'][2]";
        private string _deleteIcon = "(//div[contains(text(),'TestTeam')])[1]/following::*[name()='svg'][1]";

        private string _copyButton = "//button[text()='Copy']";
        private string _fromPeriodDropDown = "(//*[@aria-haspopup='listbox'])[1]";
        private string _dataOfFromPeriodDropDown = "(//*[@role='option'])[4]";
        private string _toPeriodDropDown = "(//*[@aria-haspopup='listbox'])[2]";
        private string _dataOfToPeriodDropDown = "(//*[@role='option'])[2]";
        private string _copyFailedPopUpMessage = "//div[contains(text(),'Copy Failed')]";

        #endregion

        #region ELEMENT
        private IWebElement TeamsTab => FindElementByXpath(_teamsTab);
        private IWebElement TeamTypesTab => FindElementByXpath(_teamTypesTab);
        private IWebElement CopyTeamsTab => FindElementByXpath(_copyTeamsTab);
        private IWebElement SavedButton => FindElementByXpath(_savedButton);
        private IWebElement AddTeamButton => FindElementByXpath(_addTeamButton);
        private IWebElement PeriodDropDown => FindElementByXpath(_periodDropDown);
        private IWebElement DataOfPeriodDropDown => FindElementByXpath(_dataOfPeriodDropDown);
        private IWebElement TeamTypeDropDown => FindElementByXpath(_teamTypeDropDown);
        private IWebElement DataOfTeamTypeDropDown => FindElementByXpath(_dataOfTeamTypeDropDown);
        private IWebElement ManagerSection => FindElementByXpath(_managerSection);
        private IWebElement SearchAgentsField => FindElementByXpath(_searchAgentsField);
        private IWebElement UnassignedAgentsSection => FindElementByXpath(_unassignedAgentsSection);
        private IWebElement EditButtonOfTeam => FindElementByXpath(_editButtonOfTeam);
        private IWebElement TeamNameFieldOfCreateTeamPopUp => FindElementByXpath(_teamNameFieldOfCreateTeamPopUp);
        private IWebElement SaveButtonOfCreateTeamPopUp => FindElementByXpath(_saveButtonOfCreateTeamPopUp);
        private IWebElement SaveButtonOfTeamPopUp => FindElementByXpath(_saveButtonOfTeamPopUp);
        private IWebElement DeleteTeamButtonOfTeamPopUp => FindElementByXpath(_deleteTeamButtonOfTeamPopUp);
        private IWebElement ConfirmButton => FindElementByXpath(_confirmButton);
        private IWebElement DirectorSectionOfTeam => FindElementByXpath(_directorSectionOfTeam);
        private IWebElement LieutenantSectionOfTeam => FindElementByXpath(_lieutenantSectionOfTeam);
        private IWebElement MemberSectionOfTeam => FindElementByXpath(_memberSectionOfTeam);
        private IWebElement SuccessfulyPopup => FindElementByXpath(_successfulyPopup);
        private IWebElement PeriodDropDownOfCreateTeamPopUp => FindElementByXpath(_periodDropDownOfCreateTeamPopUp);
        private IWebElement DeleteIconForManagerSection => FindElementByXpath(_deleteIconForManagerSection);
        private IWebElement RecordInUnassignedAgentsSection => FindElementByXpath(_recordInUnassignedAgentsSection);

        private IWebElement AddTeamTypeButton => FindElementByXpath(_addTeamTypeButton);
        private IWebElement TeamTypeTable => FindElementByXpath(_teamTypeTable);
        private IWebElement TeamTypeNameField => FindElementByXpath(_teamTypeNameField);
        private IWebElement CancelButton => FindElementByXpath(_cancelButton);
        private IWebElement RecordForEditOfTeamTypesTable => FindElementByXpath(_recordForEditOfTeamTypesTable);
        private IWebElement EditIcon => FindElementByXpath(_editIcon);
        private IWebElement DeleteIcon => FindElementByXpath(_deleteIcon);

        private IWebElement CopyButton => FindElementByXpath(_copyButton);
        private IWebElement FromPeriodDropDown => FindElementByXpath(_fromPeriodDropDown);
        private IWebElement DataOfFromPeriodDropDown => FindElementByXpath(_dataOfFromPeriodDropDown);
        private IWebElement ToPeriodDropDown => FindElementByXpath(_toPeriodDropDown);
        private IWebElement DataOfToPeriodDropDown => FindElementByXpath(_dataOfToPeriodDropDown);
        private IWebElement CopyFailedPopUpMessage => FindElementByXpath(_copyFailedPopUpMessage);
        #endregion

        #region METHOD
        public void NavigateTo()
        {
            if (PageTitle == "")
            {
                PageDriver.Navigate().GoToUrl(PageUrl);
            }
            else
            {
                PageDriver.Navigate().GoToUrl(PageUrl);
                EnsurePageLoaded();
            }
        }
        /// 'Teams' Tab
        public void VerifyTeamsTab()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_teamsTab)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_teamTypesTab)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_copyTeamsTab)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_savedButton)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_addTeamButton)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_periodDropDown)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_teamTypeDropDown)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_managerSection)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_searchAgentsField)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_unassignedAgentsSection)));
        }
        public void SelectTeamType()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_periodDropDown)));
            PeriodDropDown.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_dataOfPeriodDropDown)));
            DataOfPeriodDropDown.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_teamTypeDropDown)));
            TeamTypeDropDown.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_dataOfTeamTypeDropDown)));
            DataOfTeamTypeDropDown.Click();
        }
        public void AddNewManager()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_managerSection)));
            ManagerSection.Click();
            ManagerSection.SendKeys("Tes");
            ManagerSection.SendKeys(Keys.Enter);
            ManagerSection.SendKeys(Keys.Down);
            ManagerSection.SendKeys(Keys.Enter);
        }
        public void RemoveManager()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_deleteIconForManagerSection)));
            DeleteIconForManagerSection.Click();
        }
        public void VerifyDataOfSelectedTeamType()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_directorSectionOfTeam)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_lieutenantSectionOfTeam)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_memberSectionOfTeam)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_editButtonOfTeam)));
        }
        public void ClickOnEditButton()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_editButtonOfTeam)));
            EditButtonOfTeam.Click();
        }
        public void ClickOnSaveButton()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_saveButtonOfTeamPopUp)));
            SaveButtonOfTeamPopUp.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_saveButtonOfCreateTeamPopUp)));
            SaveButtonOfCreateTeamPopUp.Click();
        }
        public void MakeChangesInTeamName()
        {
            string Number = RandomDigits(2);
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_teamNameFieldOfCreateTeamPopUp)));
            TeamNameFieldOfCreateTeamPopUp.Click();
            for (int i = 0; i < 9; i++)
            {
                TeamNameFieldOfCreateTeamPopUp.SendKeys(Keys.Backspace);
            }
            TeamNameFieldOfCreateTeamPopUp.SendKeys("Team" + Number);
        }
        public void VerifyChenges()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_successfulyPopup)));
        }
        public void RemoveRequiredField()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_teamNameFieldOfCreateTeamPopUp)));
            TeamNameFieldOfCreateTeamPopUp.Click();
            for (int i = 0; i < 9; i++)
            {
                TeamNameFieldOfCreateTeamPopUp.SendKeys(Keys.Backspace);
            }
        }
        public void VerifyPopUpChanges()
        {
            bool isEnabled = Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_saveButtonOfCreateTeamPopUp))).Enabled;
            Assert.That(isEnabled, Is.EqualTo(false));
        }
        public void ClickOnAddTeamButton()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_addTeamButton)));
            AddTeamButton.Click();
        }
        public void FillAllRequiredData()
        {
            string Number = RandomDigits(2);
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_teamNameFieldOfCreateTeamPopUp)));
            TeamNameFieldOfCreateTeamPopUp.Click();
            TeamNameFieldOfCreateTeamPopUp.SendKeys("TestTeam" + Number);
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_periodDropDownOfCreateTeamPopUp)));
            PeriodDropDownOfCreateTeamPopUp.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_dataOfPeriodDropDown)));
            DataOfPeriodDropDown.Click();
        }
        public void ClickOnSaveButtonOfCreateTeamPopUp()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_saveButtonOfTeamPopUp))).Click();
            SaveButtonOfTeamPopUp.SendKeys(Keys.Enter);
        }
        public void ClickOnSaveButtonOfTeamsTab()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_saveButtonOfCreateTeamPopUp)));
            SaveButtonOfCreateTeamPopUp.Click();
        }
        public void FillDataWithoutTeamNameRequiredField()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_periodDropDownOfCreateTeamPopUp)));
            PeriodDropDownOfCreateTeamPopUp.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_dataOfPeriodDropDown)));
            DataOfPeriodDropDown.Click();
        }
        public void VerifyChangesInPopUp()
        {
            bool isEnabled = Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_saveButtonOfTeamPopUp))).Enabled;
            Assert.That(isEnabled, Is.EqualTo(false));
        }
        public void SelectTeamForDelete()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_editButtonOfTeam)));
            EditButtonOfTeam.Click();
        }
        public void DeleteTeam()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_deleteTeamButtonOfTeamPopUp)));
            DeleteTeamButtonOfTeamPopUp.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_confirmButton)));
            ConfirmButton.Click();
        }
        /// 'Team Types' Tab
        public void NavigateToTeamTypeTab()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_teamTypesTab)));
            TeamTypesTab.Click();
        }
        public void VerifyTeamTypesTab()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_teamsTab)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_teamTypesTab)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_copyTeamsTab)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_addTeamTypeButton)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_teamTypeTable)));
        }
        public void ClickOnAddNewTeamTypesButton()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_addTeamTypeButton)));
            AddTeamTypeButton.Click();
        }
        public void VerifyNewlyCreatedTeamType()
        {
            string Number = RandomDigits(2);
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_teamTypeNameField)));
            TeamTypeNameField.Click();
            TeamTypeNameField.SendKeys("TestTeam" + Number);
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_saveButtonOfCreateTeamPopUp)));
            SaveButtonOfCreateTeamPopUp.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_successfulyPopup)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_teamsTab)));
            TeamsTab.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_teamTypeDropDown)));
            TeamTypeDropDown.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("(//li[text()='TestTeam" + Number + "'])[1]")));

        }
        public void FillDataInTeamTypeNameField()
        {
            string Number = RandomDigits(2);
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_teamTypeNameField)));
            TeamTypeNameField.Click();
            TeamTypeNameField.SendKeys("TestTeam" + Number);
        }
        public void ClickOnSaveButtonOfTeamTypes()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_saveButtonOfCreateTeamPopUp)));
            SaveButtonOfCreateTeamPopUp.Click();
        }
        public void ClickOnCancelButtonOfTeamTypes()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_cancelButton)));
            CancelButton.Click();
        }
        public void SelectRecordInTeamTypesTable()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_recordForEditOfTeamTypesTable)));
            RecordForEditOfTeamTypesTable.Click();
        }
        public void ClickOnEditIcon()
        {
            EditIcon.Click();
        }
        public void MakeChanges()
        {
            string Number = RandomDigits(2);
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_teamTypeNameField)));
            TeamTypeNameField.Click();
            for (int i = 0; i < 19; i++)
            {
                TeamTypeNameField.SendKeys(Keys.Backspace);
            }
            TeamTypeNameField.SendKeys("TestTeamTypes " + Number);
        }
        public void ClickOnSaveButtonOfTeamTypesTab()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_saveButtonOfCreateTeamPopUp)));
            SaveButtonOfCreateTeamPopUp.Click();
        }
        public void RemoveTeamTypeNameRequiredField()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_teamTypeNameField)));
            TeamTypeNameField.Click();
            for (int i = 0; i < 19; i++)
            {
                TeamTypeNameField.SendKeys(Keys.Backspace);
            }
        }
        public void DeleteTeamTypes()
        {
            DeleteIcon.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_confirmButton)));
            ConfirmButton.Click();
        }
        /// 'Copy Teams' Tab
        public void NavigateToCopyTeamsTab()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_copyTeamsTab)));
            CopyTeamsTab.Click();
        }
        public void VerifyCopyTeamsTab()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_teamsTab)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_teamTypesTab)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_copyTeamsTab)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_fromPeriodDropDown)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_toPeriodDropDown)));
            bool isEnabled = Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_copyButton))).Enabled;
            Assert.That(isEnabled, Is.EqualTo(false));
        }
        public void SelectPeriod()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_fromPeriodDropDown)));
            FromPeriodDropDown.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_dataOfFromPeriodDropDown)));
            DataOfFromPeriodDropDown.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_toPeriodDropDown)));
            ToPeriodDropDown.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_dataOfToPeriodDropDown)));
            DataOfToPeriodDropDown.Click();
        }
        public void ClickOnCopyButton()
        {
            bool isEnabled = Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_copyButton))).Enabled;
            Assert.That(isEnabled, Is.EqualTo(true));
            CopyButton.Click();
        }
        public void SelectDatadWithoutFromReriodDropDown()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_toPeriodDropDown)));
            ToPeriodDropDown.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_dataOfToPeriodDropDown)));
            DataOfToPeriodDropDown.Click();
        }
        public void SelectDatadWithoutToReriodDropDown()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_fromPeriodDropDown)));
            FromPeriodDropDown.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_dataOfFromPeriodDropDown)));
            DataOfFromPeriodDropDown.Click();
        }
        public void SelectSameDatedForAllDropDowns()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_fromPeriodDropDown)));
            FromPeriodDropDown.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_dataOfFromPeriodDropDown)));
            DataOfFromPeriodDropDown.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_toPeriodDropDown)));
            ToPeriodDropDown.Click();
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath(_dataOfToPeriodDropDown)));
            DataOfFromPeriodDropDown.Click();
        }
        public void VerifyCopyButton()
        {
            bool isEnabled = Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_copyButton))).Enabled;
            Assert.That(isEnabled, Is.EqualTo(false));
        }
        public void VerifyWarningPopUp()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_copyFailedPopUpMessage)));

        }
        #endregion
    }
}
