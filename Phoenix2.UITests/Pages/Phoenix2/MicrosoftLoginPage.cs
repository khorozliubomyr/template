using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Text;
using System.Threading;
using WindowsInput;
using WindowsInput.Native;

namespace Phoenix2.UITests.Pages.Phoenix2
{

    class MicrosoftLoginPage : BaseDriver 
    {

        #region driver
        public MicrosoftLoginPage(IWebDriver driver) : base(driver)
        {
            PageDriver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }
        InputSimulator sim = new InputSimulator();
        protected override string PageTitle => "Phoenix 2.0";
        protected override string PageUrl => "https://qa-api-v2.ilendingdirect.com/";
        #endregion

        #region PATH
        private string _userId = "i0116";
        private string _nextButton = "idSIButton9";
        private string _passwordId = "i0118";
        private string _yesButton = "idSIButton9";
        private string _loginButton = "idSIButton9";
        #endregion

        #region ELEMENT
        private IWebElement UsernameField => FindElementById(_userId);
        private IWebElement NextButton => FindElementById(_nextButton);
        private IWebElement PasswordField => FindElementById(_passwordId);
        private IWebElement LoginButton => FindElementById(_loginButton);
        private IWebElement YesButton => FindElementById(_yesButton);
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
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(_userId)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(_nextButton)));

            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(UsernameField));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(NextButton));
        }
        private void CheckPasswordScreen()
        {
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(_passwordId)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(_loginButton)));

            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(_passwordId)));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(PasswordField));
            Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(LoginButton));
        }
        private void ClickYesButton()
        {
            YesButton.Click();
        }
        private void ClickNextButton()
        {
            NextButton.Click();
            sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }
        private void ClickLogin()
        {
            LoginButton.Click();
        }
        public void LoginAsUser(string username, string password)
        {
            NavigateTo();
            CheckLoginScreen();
            WriteUsername(username);
            ClickNextButton();
            CheckPasswordScreen();
            WritePassword(password);
            ClickLogin();
            ClickYesButton();
        }
        #endregion
    }
}

