using OpenQA.Selenium;

namespace SauceDemoTests.Pages
{
    public class CheckoutPage(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;

        private readonly By nameField = By.Id("first-name");
        private readonly By lastNameField = By.Id("last-name");
        private readonly By postalCodeField = By.Id("postal-code");
        private readonly By continueButton = By.Id("continue");
        private readonly By orderOverviewMessage = By.XPath("//*[text()='Checkout: Overview']");

        public void EnterCheckoutDetails(string name, string address, string postalCode)
        {
            driver.FindElement(nameField).SendKeys(name);
            driver.FindElement(lastNameField).SendKeys(address);
            driver.FindElement(postalCodeField).SendKeys(postalCode);
        }

        public void PlaceOrder()
        {
            driver.FindElement(continueButton).Click();
        }

        public bool IsOrderOverviewMessageVisible() => driver.FindElement(orderOverviewMessage).Displayed;
    }
}