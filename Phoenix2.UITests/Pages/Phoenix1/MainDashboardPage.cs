using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix2.UITests.Pages
{
    class MainDashboardPage : BaseDriver
    {
        #region driver
        public MainDashboardPage(IWebDriver driver) : base(driver)
        {
            PageDriver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

        protected override string PageTitle => "Main Dashboard - Phoenix";
        protected override string PageUrl => "https://phoenixqa.ilendingdirect.com";
        #endregion
        #region PATH
        private string _Tools = "//*[@id='menu-333']/a";
        private string _LenderEditor="//*[@id='menu-262']/a";
        private string _MyLcQueuesTab = "//span[normalize-space()='My LC Queues']";
        private string _WorkingDealsTab = "//*[@id='menu-48']/a";
        #endregion

        #region ELEMENT
        private IWebElement MyLcQueuesTab => FindElementByXpath(_MyLcQueuesTab);
        private IWebElement ToolsTab => FindElementByXpath(_Tools);
        private IWebElement LenderEditorTab => FindElementByXpath(_LenderEditor);
        private IWebElement WorkingDealsTab => FindElementByXpath(_WorkingDealsTab);
        #endregion

        public void openLenderEditor()
        {
            LenderEditorTab.Click();
        }
        public void ClickOnMyLcQueuesTab()
        {
            MyLcQueuesTab.Click();
        }

        public void ClickOnWorkingDealsTab()
        {
            WorkingDealsTab.Click();
        }
        
        #region METHOD
        public void openTools()
        {
            ToolsTab.Click();
        }
        #endregion
    }
}
