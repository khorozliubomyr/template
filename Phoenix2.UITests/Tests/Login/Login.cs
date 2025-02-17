using NUnit.Framework;
using Phoenix2.UITests.Framework;
using Phoenix2.UITests.Pages.Login;
using Phoenix2.UITests.Pages;
using System.Threading;

namespace UITests.Tests.Login
{
    class Login : Settings
    {
        [Test]
        public void UserShouldBeAbleToLogin() //DevOps # 
        {   //first test
            var loginPage = new LoginPage(driver);
            var mainDashboard = new MainDashboardPage(driver);

            loginPage.NavigateTo();
            loginPage.LoginAsUser(Credentials.AdminLogin, Credentials.AdminPassword);

            mainDashboard.EnsurePageLoaded();
            mainDashboard.openTools();
        }
    }
}
