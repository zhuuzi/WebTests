using OpenQA.Selenium;

namespace SauceDemoTests.Pages.Components
{
    public class SideBar(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;
        private readonly By logoutButton = By.XPath("//*[text()='Logout']");

        public void Logout()
        {
            driver.FindElement(logoutButton).Click();
        }
    }
}
