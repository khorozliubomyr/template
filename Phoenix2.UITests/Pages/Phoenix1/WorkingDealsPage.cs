using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.UITests.Pages.Phoenix1
{
    class WorkingDealsPage:BaseDriver
    {
        #region driver
        public WorkingDealsPage(IWebDriver driver) : base(driver)
        {
            PageDriver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

        protected override string PageTitle => "Deals - Phoenix";
        protected override string PageUrl => "https://phoenixqa.ilendingdirect.com/DealManager/DealIndex?";
        #endregion

        #region PATH
        private string _DealLastName = "//td[normalize-space()='Khoroz']";

        #endregion

        #region ELEMENT
        private IWebElement DealLastName => FindElementByXpath(_DealLastName);
        #endregion

        #region METHOD
        public void ClickOnDeal()
        {   
            DealLastName.Click();
        }

        #endregion
    }
}
