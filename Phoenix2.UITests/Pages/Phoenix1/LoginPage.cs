using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Text;
using System.Threading;


namespace Phoenix2.UITests.Pages.Login
{
    class LoginPage : BaseDriver
    {
        #region driver
        public LoginPage(IWebDriver driver) : base(driver)
        {
            PageDriver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

        protected override string PageTitle => "Log in - Phoenix";
        protected override string PageUrl => "https://phoenixqa.ilendingdirect.com/Account/Login?";
        #endregion

        #region PATH
        private string _usernameId = "UserName";
        private string _passwordId = "Password";
        private string _rememberMeId = "RememberMe";
        private string _loginPath = "//button[@value='Log in']";
        #endregion

        #region ELEMENT
        private IWebElement UsernameField => FindElementById(_usernameId);
        private IWebElement PasswordField => FindElementById(_passwordId);
        private IWebElement RememberMeCheckbox => FindElementById(_rememberMeId);
        private IWebElement LoginButton => FindElementByXpath(_loginPath);
        #endregion

        #region METHOD
        private void WriteUsername(string username)
        {
            UsernameField.SendKeys(username);
        }
        private void WritePassword(string password)
        {
            PasswordField.SendKeys(password);
        }
        private void CheckLoginScreen()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(_usernameId)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(_passwordId)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(_rememberMeId)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath(_loginPath)));

            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(UsernameField));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(PasswordField));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(RememberMeCheckbox));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(LoginButton));
        }
        private void SetRememberMe()
        {
            RememberMeCheckbox.Click();
        }
        private void ClickLogin()
        {
            LoginButton.Click();
        }
        public void LoginAsUser(string username, string password, bool rememberMe = false)
        {
            CheckLoginScreen();
            WriteUsername(username);
            WritePassword(password);
            if (rememberMe is true)
            {
                SetRememberMe();
            }
            ClickLogin();
        }
        #endregion

    }
}
