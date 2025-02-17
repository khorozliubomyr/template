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
    public class TeamManagerTestDev : Settings
    {
        private MicrosoftLoginPage microsoftloginpage;
        private TeamManagerPageDev teamManagerPageDev;
        [SetUp]
        public void test()
        {
            microsoftloginpage = new MicrosoftLoginPage(driver);
            microsoftloginpage.LoginAsUser(Credentials.AdminLogin, Credentials.AdminPassword);
            teamManagerPageDev = new TeamManagerPageDev(driver);
        }
        [Test]
        public void TeamsTab_VerifyTeamsTab()
        {
            teamManagerPageDev.NavigateTo();
            teamManagerPageDev.VerifyTeamsTab();
        }
        [Test]
        public void TeamsTab_VerifyDataOfSelectedTeamType()
        {
            teamManagerPageDev.NavigateTo();
            teamManagerPageDev.SelectTeamType();
            teamManagerPageDev.VerifyDataOfSelectedTeamType();
        }
        [Test]
        public void TeamsTab_EditNameOfTeam_PositiveScenario()
        {
            teamManagerPageDev.NavigateTo();
            teamManagerPageDev.SelectTeamType();
            teamManagerPageDev.ClickOnEditButton();
            teamManagerPageDev.MakeChangesInTeamName();
            teamManagerPageDev.ClickOnSaveButton();
            teamManagerPageDev.VerifyChenges();
        }
        [Test]
        public void TeamsTab_EditNameOfTeam_NegativeScenario_RemovingRequireField()
        {
            teamManagerPageDev.NavigateTo();
            teamManagerPageDev.SelectTeamType();
            teamManagerPageDev.ClickOnEditButton();
            teamManagerPageDev.MakeChangesInTeamName();
            teamManagerPageDev.RemoveRequiredField();
            teamManagerPageDev.VerifyPopUpChanges();
        }
        [Test]
        public void TeamsTab_AddNewTeam_PositiveScenario()
        {
            teamManagerPageDev.NavigateTo();
            teamManagerPageDev.SelectTeamType();
            teamManagerPageDev.ClickOnAddTeamButton();
            teamManagerPageDev.FillAllRequiredData();
            teamManagerPageDev.ClickOnSaveButtonOfCreateTeamPopUp();
            teamManagerPageDev.ClickOnSaveButtonOfTeamsTab();
            teamManagerPageDev.VerifyChenges();
        }
        [Test]
        public void TeamsTab_AddNewTeam_NegativeScenario_WithoutRequiredField()
        {
            teamManagerPageDev.NavigateTo();
            teamManagerPageDev.SelectTeamType();
            teamManagerPageDev.ClickOnAddTeamButton();
            teamManagerPageDev.FillDataWithoutTeamNameRequiredField();
            teamManagerPageDev.VerifyChangesInPopUp();
        }
        [Test]
        public void TeamsTab_DeleteTeam_PositiveScenario()
        {
            teamManagerPageDev.NavigateTo();
            teamManagerPageDev.SelectTeamType();
            teamManagerPageDev.SelectTeamForDelete();
            teamManagerPageDev.DeleteTeam();
            teamManagerPageDev.VerifyChenges();
        }
        [Test]
        public void TeamsTab_AddManager_PositiveScenario()
        {
            teamManagerPageDev.NavigateTo();
            teamManagerPageDev.SelectTeamType();
            teamManagerPageDev.AddNewManager();
            teamManagerPageDev.ClickOnSaveButtonOfTeamsTab();
            teamManagerPageDev.VerifyChenges();
        }
        [Test]
        public void TeamsTab_RemoveManagerFromManagersSection_PositiveScenario()
        {
            teamManagerPageDev.NavigateTo();
            teamManagerPageDev.SelectTeamType();
            teamManagerPageDev.RemoveManager();
            teamManagerPageDev.ClickOnSaveButtonOfTeamsTab();
            teamManagerPageDev.VerifyChenges();
        }
        [Test]
        public void TeamTypesTab_VerifyTeamTypesTab()
        {
            teamManagerPageDev.NavigateTo();
            teamManagerPageDev.NavigateToTeamTypeTab();
            teamManagerPageDev.VerifyTeamTypesTab();
        }
        [Test]
        public void TeamTypesTab_AddNewTeamTypes_PositiveScenario()
        {
            teamManagerPageDev.NavigateTo();
            teamManagerPageDev.NavigateToTeamTypeTab();
            teamManagerPageDev.ClickOnAddNewTeamTypesButton();
            teamManagerPageDev.FillDataInTeamTypeNameField();
            teamManagerPageDev.ClickOnSaveButtonOfTeamTypes();
            teamManagerPageDev.VerifyChenges();
        }
        [Test]
        public void TeamTypesTab_VerifyNewlyCreatedTeamTypesInTeamTypeDropDown()
        {
            teamManagerPageDev.NavigateTo();
            teamManagerPageDev.NavigateToTeamTypeTab();
            teamManagerPageDev.ClickOnAddNewTeamTypesButton();
            teamManagerPageDev.VerifyNewlyCreatedTeamType();
        }
        [Test]
        public void TeamTypesTab_AddNewTeamTypes_FunctionOfCancelButton()
        {
            teamManagerPageDev.NavigateTo();
            teamManagerPageDev.NavigateToTeamTypeTab();
            teamManagerPageDev.ClickOnAddNewTeamTypesButton();
            teamManagerPageDev.FillDataInTeamTypeNameField();
            teamManagerPageDev.ClickOnCancelButtonOfTeamTypes();
            teamManagerPageDev.VerifyTeamTypesTab();
        }
        [Test]
        public void TeamTypesTab_EditTeamTypes_PositiveScenario()
        {
            teamManagerPageDev.NavigateTo();
            teamManagerPageDev.NavigateToTeamTypeTab();
            teamManagerPageDev.SelectRecordInTeamTypesTable();
            teamManagerPageDev.ClickOnEditIcon();
            teamManagerPageDev.MakeChanges();
            teamManagerPageDev.ClickOnSaveButtonOfTeamTypesTab();
            teamManagerPageDev.VerifyChenges();
        }
        [Test]
        public void TeamTypesTab_EditTeamTypes_NegativeScenario_RemovingRequireField()
        {
            teamManagerPageDev.NavigateTo();
            teamManagerPageDev.NavigateToTeamTypeTab();
            teamManagerPageDev.SelectRecordInTeamTypesTable();
            teamManagerPageDev.ClickOnEditIcon();
            teamManagerPageDev.RemoveTeamTypeNameRequiredField();
            teamManagerPageDev.VerifyChangesInPopUp();
        }
        [Test]
        public void TeamTypesTab_DeleteTeamTypes_PositiveScenario()
        {
            teamManagerPageDev.NavigateTo();
            teamManagerPageDev.NavigateToTeamTypeTab();
            teamManagerPageDev.SelectRecordInTeamTypesTable();
            teamManagerPageDev.DeleteTeamTypes();
            teamManagerPageDev.VerifyChenges();
        }
        [Test]
        public void CopyTeamsTab_VerifyCopyTeamsTab()
        {
            teamManagerPageDev.NavigateTo();
            teamManagerPageDev.NavigateToCopyTeamsTab();
            teamManagerPageDev.VerifyCopyTeamsTab();
        }
        [Test]
        public void CopyTeamsTab_CopyTeams_PositiveScenario()
        {
            teamManagerPageDev.NavigateTo();
            teamManagerPageDev.NavigateToCopyTeamsTab();
            teamManagerPageDev.SelectPeriod();
            teamManagerPageDev.ClickOnCopyButton();
            teamManagerPageDev.VerifyChenges();
        }
        [Test]
        public void CopyTeamsTab_CopyTeams_NegativeScenario_WithoutRequiredFromReriodDropDown()
        {
            teamManagerPageDev.NavigateTo();
            teamManagerPageDev.NavigateToCopyTeamsTab();
            teamManagerPageDev.SelectDatadWithoutFromReriodDropDown();
            teamManagerPageDev.VerifyCopyButton();
        }
        [Test]
        public void CopyTeamsTab_CopyTeams_NegativeScenario_WithoutRequiredToReriodDropDown()
        {
            teamManagerPageDev.NavigateTo();
            teamManagerPageDev.NavigateToCopyTeamsTab();
            teamManagerPageDev.SelectDatadWithoutToReriodDropDown();
            teamManagerPageDev.VerifyCopyButton();
        }
        [Test]
        public void CopyTeamsTab_CopyTeams_NegativeScenario_WithSameDateforAllPeriod()
        {
            teamManagerPageDev.NavigateTo();
            teamManagerPageDev.NavigateToCopyTeamsTab();
            teamManagerPageDev.SelectSameDatedForAllDropDowns();
            teamManagerPageDev.ClickOnCopyButton();
            teamManagerPageDev.VerifyWarningPopUp();
        }
    }
}
