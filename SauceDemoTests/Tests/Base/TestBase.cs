using OpenQA.Selenium;
using SauceDemoTests.Utils;
using SauceDemoTests.Drivers;
using SauceDemoTests.Pages;
using Microsoft.Extensions.Configuration;


namespace SauceDemoTests.Tests.Base
{
    public class TestBase
    {
        protected IWebDriver driver;
        public LoginPage loginPage;
        public DashboardPage dashboardPage;

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
            driver.Navigate().GoToUrl(TestConstants.LoginUrl);
            loginPage = new LoginPage(driver);
            dashboardPage = new DashboardPage(driver);
        }

        [TearDown]
        public void Teardown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
