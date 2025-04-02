using EpamTests.Pages;
using EpamTests.Utils;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using SauceDemoTests.Drivers;
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
        public void SetupBeforeScenario() => Setup();

        [SetUp]
        public void SetupForNUnit() => Setup();

        private void Setup()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
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

        [TearDown]
        [AfterScenario]
        public void Teardown()
        {
            driver?.Quit();
            driver?.Dispose();
            driver = null;
        }
    }
}
