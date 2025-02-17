using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Phoenix2.UITests.Framework
{
    public class Settings
    {
        protected static IWebDriver driver;

        [SetUp]
        public void Init()
        {
            Console.WriteLine("Settings");
            switch (Credentials.TestingMode)
            {
                case "UI":
                    ChromeOptions options = new ChromeOptions();
                    options.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
                    options.AddArguments("--no-sandbox");
                    options.AddArguments("enable-automation");
                    options.AddArguments("--disable-dev-shm-usage");
                    options.AddArguments("--disable-gpu");
                    options.AddArguments("--disable-features=VizDisplayCompositor");
                    options.PageLoadStrategy = PageLoadStrategy.Normal;
                    driver = new ChromeDriver(options);

                    driver.Manage().Window.Maximize();

                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(50);
                    driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);
                    break;

                case "headless":
                    ChromeOptions headlessOptions = new ChromeOptions();
                    headlessOptions.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);

                    string downloadPath = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
                    headlessOptions.AddUserProfilePreference("download.default_directory", downloadPath);

                    headlessOptions.AddArguments("--window-size=1920,1080");
                    headlessOptions.AddArguments("--disable-gpu");
                    headlessOptions.AddArguments("--disable-extensions");
                    headlessOptions.AddArguments("--proxy-server='direct://'");
                    headlessOptions.AddArguments("--proxy-bypass-list=*");
                    headlessOptions.AddArguments("--start-maximized");
                    headlessOptions.AddArguments("--no-sandbox");
                    headlessOptions.AddArguments("--allow-insecure-localhost");
                    headlessOptions.AddArguments("--headless");

                    driver = new ChromeDriver(headlessOptions);

                    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                    driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(50);
                    driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(30);
                    break;
            }
        }

        [TearDown]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
