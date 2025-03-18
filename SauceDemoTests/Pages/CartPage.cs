using OpenQA.Selenium;
namespace SauceDemoTests.Pages
{
    public class CartPage(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;
        private readonly By checkoutButton = By.Id("checkout");

        public void ClickCheckout()
        {
            driver.FindElement(checkoutButton).Click();
        }
    }
}
