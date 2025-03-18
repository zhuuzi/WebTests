using OpenQA.Selenium;
using SauceDemoTests.Pages.Components;

namespace SauceDemoTests.Pages
{
    public class DashboardPage(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;
        private readonly By welcomeMessage = By.XPath("//*[@class='title' and text()='Products']");
        private readonly By cartIcon = By.Id("shopping_cart_container");
        private readonly By sideMenuButton = By.Id("react-burger-menu-btn");
        private readonly By addToCartButtons = By.XPath("//div[@class='inventory_list']//button[contains(@data-test, 'add-to-cart')]");

        private readonly SideBar sideBar = new(driver);

        public bool IsDashboardLoaded() => driver.FindElement(welcomeMessage) != null;
        public bool IsCartVisible() => driver.FindElement(cartIcon) != null;
        public void OpenSideMenu() => driver.FindElement(sideMenuButton).Click();

        public void Logout()
        {
            OpenSideMenu();
            sideBar.Logout();
        }

        public void AddItemsToCart(int itemCount)
        {
            var buttons = driver.FindElements(addToCartButtons);
            int count = 0;

            foreach (var button in buttons)
            {
                if (count >= itemCount) break;
                button.Click();
                count++;
            }
        }

        public void ProceedToCart()
        {
            driver.FindElement(cartIcon).Click();
        }
    }
}
