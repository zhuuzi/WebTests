using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace EpamTests.Pages
{
    public class HomePage(IWebDriver driver)
    {
        private readonly IWebDriver _driver = driver;

        private static By AboutMenu => By.XPath("//a[contains(@class, 'top-navigation__item-link') and text()='About']");
        private static By InsightsMenu => By.XPath("//a[contains(@class, 'top-navigation__item-link') and text()='Insights']");
        private static By CookieAcceptButton = By.XPath("//*[@id='onetrust-accept-btn-handler']");
        private static By ServicesMenu => By.XPath("//a[contains(@class, 'top-navigation__item-link') and text()='Services']");
        private static By ServiceCategory(string category) =>
            By.XPath($"//a[contains(@class, 'top-navigation__sub-link') and contains(text(), '{category}')]");

        public void ClickServicesMenu() => _driver.FindElement(ServicesMenu).Click();

        public void HoverOverServicesMenu()
        {
            var servicesMenu = _driver.FindElement(ServicesMenu);
            var actions = new Actions(_driver);
            actions.MoveToElement(servicesMenu).Perform();
        }

        public void SelectServiceCategory(string category)
        {
            _driver.FindElement(ServiceCategory(category)).Click();
        }

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