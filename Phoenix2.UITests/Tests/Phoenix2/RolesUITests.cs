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
    public class RolesUITests : Settings
    {
        private MicrosoftLoginPage microsoftloginpage;
        private RolesPage rolesPage;
        [SetUp]
        public void test()
        {
            microsoftloginpage = new MicrosoftLoginPage(driver);
            microsoftloginpage.LoginAsUser(Credentials.AdminLogin, Credentials.AdminPassword);
            rolesPage = new RolesPage(driver);
        }
        [Test]
        public void Roles_VerififyRolesPage_PositiveScenario()
        {
            rolesPage.NavigateTo();
            rolesPage.VerifiedRolesPage();
        }
        [Test]
        public void Roles_AddingNewRole_PositiveScenario()
        {
            rolesPage.NavigateTo();
            rolesPage.ClickOnCreateNewRoleButton();
            rolesPage.FillAllRequiredFields("TestLB");
            /// Bug
        }
        [Test]
        public void Roles_EditingRole_PositiveScenario()
        {
            string RoleName = rolesPage.GenerateRandomName(8);
            rolesPage.NavigateTo();
            rolesPage.VerifiedRolesPage();
            rolesPage.SelectRoleForEdit();
            rolesPage.EditData(RoleName);
            rolesPage.ClickSaveButton();
            rolesPage.CheckEditPopup();
        }
        [Test]
        public void Roles_EditingRole_NegativeScenario()
        {
            rolesPage.NavigateTo();
            rolesPage.VerifiedRolesPage();
            rolesPage.SelectRoleForEdit();
            rolesPage.NegativeEditData();
            rolesPage.ClickSaveButton();
            rolesPage.CheckEditPopup();
        }
        [Test]
        public void Roles_EditingRole_CancelButtonFunctionality()
        {
            rolesPage.NavigateTo();
            rolesPage.VerifiedRolesPage();
            rolesPage.SelectDataForEdit();
            rolesPage.RemoveData();
            rolesPage.ClickCanselButton();
            rolesPage.VerifySuccessfullyTest();
        }
        [Test]
        public void Roles_VerififyUsersTable_PositiveScenario()
        {
            rolesPage.NavigateTo();
            rolesPage.VerifiedRolesPage();
            rolesPage.VerifyUsersTable();
            rolesPage.SelectRecordFromAdminTable();
            rolesPage.VerifyRecorUsersTable();
        }
        [Test]
        public void Roles_DeletingRole_PositiveScenario()
        {
            rolesPage.NavigateTo();
            rolesPage.VerifiedRolesPage();
            rolesPage.SelectRecordForDelete();
            rolesPage.DeleteRecord();
            rolesPage.VerifyRecords();
        }
        [Test]
        public void Roles_VerifyRoleUserSectionPopUp()
        {
            rolesPage.NavigateTo();
            rolesPage.VerifiedRolesPage();
            rolesPage.SelectRecordFromAdminTable();
            rolesPage.ClickEditUsersButton();
            rolesPage.VerifiedRoleUserSectionPopUp();
        }
        [Test]
        public void Roles_RoleUserSectionPopUp_AddUserformCroupOfUserSection_PositiveScenario()
        {
            rolesPage.NavigateTo();
            rolesPage.VerifiedRolesPage();
            rolesPage.SelectRecordFromAdminTable();
            rolesPage.ClickEditUsersButton();
            rolesPage.AddUsersFromGroupsOfUsersSections();
            rolesPage.ClickSaveButton();
            rolesPage.VerifyRecords();
        }
        [Test]
        public void Roles_RoleUserSectionPopUp_AddUserformUserIndividuallySection_PositiveScenario()
        {
            rolesPage.NavigateTo();
            rolesPage.VerifiedRolesPage();
            rolesPage.SelectRecordFromAdminTable();
            rolesPage.ClickEditUsersButton();
            rolesPage.AddUsersFromUserIndividuallySections();
            rolesPage.ClickSaveButton();
            rolesPage.VerifyRecords();
        }
        [Test]
        public void Roles_RoleUserSectionPopUp_DeleteUserFromIndividuallySection_PositiveScenario()
        {
            rolesPage.NavigateTo();
            rolesPage.VerifiedRolesPage();
            rolesPage.SelectRecordFromAdminTable();
            rolesPage.ClickEditUsersButton();
            rolesPage.AddUsersFromUserIndividuallySections();
            rolesPage.DeleteUserFromIndividuallySections();
            rolesPage.ClickSaveButton();
            rolesPage.VerifyRecords();
        }
        [Test]
        public void Roles_RoleUserSectionPopUp_ExcludeUsersSection_PositiveScenario()
        {
            rolesPage.NavigateTo();
            rolesPage.VerifiedRolesPage();
            rolesPage.SelectRecordFromAdminTable();
            rolesPage.ClickEditUsersButton();
            rolesPage.AddExcludeUsersSections();
            rolesPage.ClickSaveButton();
            rolesPage.VerifyRecords();
        }
        [Test]
        public void Roles_RoleUserSectionPopUp_DeleteRecordFromExcludeUsersSection_PositiveScenario()
        {
            rolesPage.NavigateTo();
            rolesPage.VerifiedRolesPage();
            rolesPage.SelectRecord();
            rolesPage.ClickEditUsersButton();
            rolesPage.AddExcludeUsersSections();
            rolesPage.DeleteRecordFromExcludeSections();
            rolesPage.ClickSaveButton();
            rolesPage.VerifyRecords();
        }
    }
}
