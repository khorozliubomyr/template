using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsInput;

namespace Phoenix2.UITests.Pages.Phoenix2
{
    class RolesPage : BaseDriver
    {
        #region driver
        public RolesPage(IWebDriver driver) : base(driver)
        {
            PageDriver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }
        InputSimulator sim = new InputSimulator();
        protected override string PageTitle => "Phoenix 2.0";
        protected override string PageUrl => "https://qa-api-v2.ilendingdirect.com/admin-tools/roles";
        #endregion

        #region PATH
        private string _adminRolesTable = "//*[@aria-rowindex='2']";
        private string _userTable = "//*[text()='No Rows']";
        private string _createNewRoleButton = "//*[text()='Create New Role']";
        private string _editUserButton = "//*[text()='Edit Users']";
        private string _roleNameField = "(//*[@class='MuiDataGrid-row MuiDataGrid-row--editable']//*[@data-field='options'])[1]";
        private string _fieldForEditing = "(//*[@data-field='name']//div[@class='MuiDataGrid-cellContent'])[1]";
        private string _editIcon = "(//*[@data-action='edit-row'])[1]";
        private string _roleNameEditField = "//*[@data-field='name']//*[@class='sc-cCsOjp ijvhXg MuiInputBase-input']";
        private string _saveButton = "//*[text()='Save']";
        private string _nextButtonRolesPage = "(//*[@title='Go to next page'])[1]";
        private string _canselButton = "//*[text()='Cancel']";
        private string _usersTable = "//*[@class='sc-iqGgem MuiDataGrid-virtualScrollerContent']";
        private string _recordsInUserTable = "//*[@data-id='0']";
        private string _deleteIconAdminTable = "//div[@class='sc-eVQfli gogzNX MuiDataGrid-virtualScrollerRenderZone']//div[1]//div[1]//button[1]";
        private string _confirmButtonForDeleting = "//button[normalize-space()='Confirm']";
        private string _successfulyPopup = "//div[contains(text(),'Successfully')]";
        private string _selectGroupsUsersForSection = "(//*[@class='sc-dIouRR eIAlRi MuiTypography-root MuiTypography-body1 sc-hIpXjV iHqkvL'])[1]";
        private string _finalUserSetSection = "(//*[@class='sc-dIouRR eIAlRi MuiTypography-root MuiTypography-body1 sc-hIpXjV iHqkvL'])[2]";
        private string _allUsersCheckBox = "(//input[@type='checkbox'])[1]";
        private string _addUserInduviduallyDropDown = "//*[@id=':rt:']";
        private string _recordfromAddUserInduviduallyDropDown = "//ul[@role='listbox']//li[1]";
        private string _excludeUsersDropDown = "//*[@id=':rv:']";
        private string _deleteIconAddUserIndividualy = "(//*[@role='dialog']//*[@stroke='currentColor'])[1]";
        #endregion

        #region ELEMENT
        /// General
        private IWebElement AdminRolesTable => FindElementByXpath(_adminRolesTable);
        private IWebElement UserTable => FindElementByXpath(_userTable);
        private IWebElement CreateNewRoleButton => FindElementByXpath(_createNewRoleButton);
        private IWebElement EditUserButton => FindElementByXpath(_editUserButton);
        private IWebElement RoleNameField => FindElementByXpath(_roleNameField);
        private IWebElement FieldForEditing => FindElementByXpath(_fieldForEditing);
        private IWebElement EditIcon => FindElementByXpath(_editIcon);
        private IWebElement RoleNameEditField => FindElementByXpath(_roleNameEditField);
        private IWebElement SaveButton => FindElementByXpath(_saveButton);
        private IWebElement SuccessfulyPopup => FindElementByXpath(_successfulyPopup);
        private IWebElement NextButtonRolesPage => FindElementByXpath(_nextButtonRolesPage);
        private IWebElement CanselButton => FindElementByXpath(_canselButton);
        private IWebElement UsersTable => FindElementByXpath(_usersTable);
        private IWebElement RecordsInUserTable => FindElementByXpath(_recordsInUserTable);
        private IWebElement DeleteIconAdminTable => FindElementByXpath(_deleteIconAdminTable);
        private IWebElement ConfirmButtonForDeleting => FindElementByXpath(_confirmButtonForDeleting);
        private IWebElement SelectGroupsUsersForSection => FindElementByXpath(_selectGroupsUsersForSection);
        private IWebElement FinalUserSetSection => FindElementByXpath(_finalUserSetSection);
        private IWebElement AllUsersCheckBox => FindElementByXpath(_allUsersCheckBox);
        private IWebElement AddUserInduviduallyDropDown => FindElementByXpath(_addUserInduviduallyDropDown);
        private IWebElement RecordfromAddUserInduviduallyDropDown => FindElementByXpath(_recordfromAddUserInduviduallyDropDown);
        private IWebElement ExcludeUsersDropDown => FindElementByXpath(_excludeUsersDropDown);
        private IWebElement DeleteIconAddUserIndividualy => FindElementByXpath(_deleteIconAddUserIndividualy);


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
        public void VerifiedRolesPage()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_adminRolesTable)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_userTable)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_createNewRoleButton)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_editUserButton)));
        }
        public void ClickOnCreateNewRoleButton()
        {
            CreateNewRoleButton.Click();
        }
        public void FillAllRequiredFields(string Data)
        {
            RoleNameField.SendKeys("TestLB");
        }
        public void SelectRoleForEdit()
        {
            RoleNameField.Click();
            EditIcon.Click();
        }
        public void EditData(string Data)
        {
            RoleNameEditField.Clear();
            RoleNameEditField.SendKeys(Data);
        }
        public void NegativeEditData()
        {
            RoleNameEditField.Clear();
        }
        public void ClickSaveButton()
        {
            SaveButton.Click();
        }
        public void ClickCanselButton()
        {
            CanselButton.Click();
        }
        public void CheckEditPopup()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_successfulyPopup)));
        }
        public void SelectDataForEdit()
        {
            NextButtonRolesPage.Click();
            FieldForEditing.Click();
        }
        public void RemoveData()
        {
            EditIcon.Click();
            RoleNameEditField.Clear();
        }
        public void VerifySuccessfullyTest()
        {
            FieldForEditing.Click();
        }
        public void VerifyUsersTable()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_usersTable)));
        }
        public void SelectRecordFromAdminTable()
        {
            RoleNameField.Click();
        }
        public void VerifyRecorUsersTable()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_recordsInUserTable)));
        }
        public void SelectRecordForDelete()
        {
            NextButtonRolesPage.Click();
            FieldForEditing.Click();
        }
        public void DeleteRecord()
        {
            DeleteIconAdminTable.Click();
            ConfirmButtonForDeleting.Click();
        }
        public void VerifyRecords()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_successfulyPopup)));
        }
        public void ClickEditUsersButton()
        {
            EditUserButton.Click();
        }
        public void VerifiedRoleUserSectionPopUp()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_saveButton)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_selectGroupsUsersForSection)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_finalUserSetSection)));
        }
        public void AddUsersFromGroupsOfUsersSections()
        {
            AllUsersCheckBox.Click();
        }
        public void AddUsersFromUserIndividuallySections()
        {
            AddUserInduviduallyDropDown.Click();
            RecordfromAddUserInduviduallyDropDown.Click();
        }
        public void DeleteUserFromIndividuallySections()
        {
            Actions.MoveToElement(DeleteIconAddUserIndividualy).Click().Build().Perform();
        }
        public void AddExcludeUsersSections()
        {
            ExcludeUsersDropDown.Click();
            RecordfromAddUserInduviduallyDropDown.Click();
        }
        public void DeleteRecordFromExcludeSections()
        {
            Actions.MoveToElement(DeleteIconAddUserIndividualy).Click().Build().Perform();
        }
        public void SelectRecord()
        {
            NextButtonRolesPage.Click();
            FieldForEditing.Click();
        }
        #endregion
    }
}
