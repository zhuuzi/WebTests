using OpenQA.Selenium;
using EpamTests.Pages;
using SauceDemoTests.Drivers;
using EpamTests.Utils;
using Microsoft.Extensions.Configuration;

namespace EpamTests.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;
        protected HomePage HomePage;
        protected AboutPage AboutPage;
        protected InsightsPage InsightsPage;

        [SetUp]
        public void Setup()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            string browser = configuration["Browser"] ?? "chrome";
            bool headless = configuration.GetValue<bool>("Headless");

            driver = WebDriverManager.GetDriver(browser, headless); 
            driver.Navigate().GoToUrl(Constants.Urls.EpamUrl);

            HomePage = new HomePage(driver);
            AboutPage = new AboutPage(driver);
            InsightsPage = new InsightsPage(driver);
            HomePage.AcceptCookies();
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}