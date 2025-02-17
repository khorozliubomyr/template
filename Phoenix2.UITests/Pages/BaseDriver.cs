using System;
using System.Net;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Phoenix2.UITests.Pages
{
    class BaseDriver
    {
        public IWebDriver PageDriver { get; set; }
        public WebDriverWait Wait { get; set; }
        protected virtual string PageTitle { get; }
        protected virtual string PageUrl { get; }
        protected virtual Actions Actions { get; }

        public BaseDriver(IWebDriver driver)
        {
            PageDriver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            Actions = new Actions(driver);
        }

        protected IWebElement FindElementById(string id)
        {
            return PageDriver.FindElement(By.Id(id));
        }
        protected IWebElement FindElementByElement(string linktext)
        {
            return PageDriver.FindElement(By.LinkText(linktext));
        }
        protected IWebElement FindElementByXpath(string xpath)
        {
            
            return PageDriver.FindElement(By.XPath(xpath));
        }

        protected static string SetValueToXpath(string xpath, string value)
        {
            string newXpath = String.Format(xpath, value);
            return newXpath;
        }

        public void NavigateTo()
        {   if (PageTitle == "")
            {
                PageDriver.Navigate().GoToUrl(PageUrl);
            }
            else
            {
                PageDriver.Navigate().GoToUrl(PageUrl);
                EnsurePageLoaded();
            }
            }


        public void EnsurePageLoaded(bool onlyCheckUrlStartsWithExpectedText = true)
        {
            bool urlIsCorrect;
            if (onlyCheckUrlStartsWithExpectedText)
            {
                urlIsCorrect = PageDriver.Url.StartsWith(PageUrl);
            }
            else
            {
                urlIsCorrect = PageDriver.Url == PageUrl;
            }

            bool pageHasLoaded = urlIsCorrect && (PageDriver.Title == PageTitle);
            if (!pageHasLoaded)
            {
                throw new Exception($"Failed to load page. Page URL = '{PageDriver.Url}' Page Source: \r\n {PageDriver.PageSource}");
            }

        
        }
        public string GenerateRandomName(int length)
        {

            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
           return str_build.ToString();
        }

        public string RandomDigits(int length)
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < length; i++)
                s = String.Concat(s, random.Next(10).ToString());
            return s;
        }
        public void SwitchTab()
        {
            var browserTabs = PageDriver.WindowHandles;
            PageDriver.SwitchTo().Window(browserTabs[1]);

            PageDriver.Close();
            PageDriver.SwitchTo().Window(browserTabs[0]);
        }

    }
}
