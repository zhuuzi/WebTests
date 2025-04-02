using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using SauceDemoTests.Utils;

namespace SauceDemoTests.Drivers
{
    public static class WebDriverManager
    {
        public static IWebDriver GetDriver(string browser = "chrome", bool headless = false)
        {
            IWebDriver driver;
            switch (browser.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    if (headless) chromeOptions.AddArgument("--headless");
                    driver = new ChromeDriver(chromeOptions);
                    break;

                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    if (headless) firefoxOptions.AddArgument("--headless");
                    driver = new FirefoxDriver(firefoxOptions);
                    break;

                case "edge":
                    var edgeOptions = new EdgeOptions();
                    if (headless) edgeOptions.AddArgument("--headless");
                    driver = new EdgeDriver(edgeOptions);
                    break;

                default:
                    throw new ArgumentException($"Unsupported browser: {browser}");
            }

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Timeouts.ImplicitWait);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Timeouts.PageLoadTimeout);
            driver.Manage().Window.Maximize();

            return driver;
        }
    }
}