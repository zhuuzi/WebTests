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
        private static IWebDriver? _driver;

        public static IWebDriver GetDriver(string browser = "chrome", bool headless = false)
        {
            if (_driver == null)
            {
                switch (browser.ToLower())
                {
                    case "chrome":
                        var chromeOptions = new ChromeOptions();
                        if (headless) chromeOptions.AddArgument("--headless");
                        _driver = new ChromeDriver(chromeOptions);
                        break;

                    case "firefox":
                        var firefoxOptions = new FirefoxOptions();
                        if (headless) firefoxOptions.AddArgument("--headless");
                        _driver = new FirefoxDriver(firefoxOptions);
                        break;

                    case "edge":
                        var edgeOptions = new EdgeOptions();
                        if (headless) edgeOptions.AddArgument("--headless");
                        _driver = new EdgeDriver(edgeOptions);
                        break;

                    default:
                        throw new ArgumentException($"Unsupported browser: {browser}");
                }

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Timeouts.ImplicitWait);
                _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(Timeouts.PageLoadTimeout);
                _driver.Manage().Window.Maximize();
            }
            return _driver;
        }

        public static void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }
    }
}