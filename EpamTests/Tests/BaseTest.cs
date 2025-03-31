using OpenQA.Selenium;
using EpamTests.Pages;
using SauceDemoTests.Drivers;
using EpamTests.Utils;
using Microsoft.Extensions.Configuration;
using TechTalk.SpecFlow;

namespace EpamTests.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected HomePage HomePage;
        protected AboutPage AboutPage;
        protected InsightsPage InsightsPage;

        [BeforeScenario]
        public void Setup()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Force load
                .Build();

            string browser = configuration["Browser"];
            bool headless = configuration.GetValue<bool>("Headless");

            driver = WebDriverManager.GetDriver(browser ?? "chrome", headless);
            driver.Navigate().GoToUrl(Constants.Urls.EpamUrl);

            HomePage = new HomePage(driver);
            AboutPage = new AboutPage(driver);
            InsightsPage = new InsightsPage(driver);
            HomePage.AcceptCookies();
        }


        [AfterScenario]
        public void Teardown()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
            }
        }

    }
}