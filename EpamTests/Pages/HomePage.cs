using OpenQA.Selenium;

namespace EpamTests.Pages
{
    public class HomePage(IWebDriver driver)
    {
        private readonly IWebDriver _driver = driver;

        private static By AboutMenu => By.XPath("//a[contains(@class, 'top-navigation__item-link') and text()='About']");
        private static By InsightsMenu => By.XPath("//a[contains(@class, 'top-navigation__item-link') and text()='Insights']");
        private static By CookieAcceptButton = By.XPath("//*[@id='onetrust-accept-btn-handler']");

        public void NavigateTo(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void ClickAboutMenu()
        {
            _driver.FindElement(AboutMenu).Click();
        }

        public void ClickInsightsMenu()
        {
            _driver.FindElement(InsightsMenu).Click();
        }

        public void AcceptCookies()
        {
            _driver.FindElement(CookieAcceptButton).Click();
        }
    }
}