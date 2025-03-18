using SauceDemoTests.Pages;
using SauceDemoTests.Utils;

namespace SauceDemoTests.Tests
{
    public class ShoppingTests : Base.TestBase
    {
        private CartPage cartPage;
        private CheckoutPage checkoutPage;

        [SetUp]
        public void TestSetup()
        {
            cartPage = new CartPage(driver);
            checkoutPage = new CheckoutPage(driver);

            loginPage.Login(TestConstants.ValidUsername, TestConstants.ValidPassword);
        }

        [Test]
        public void AddItemToCartAndCheckout()
        {
            dashboardPage.AddItemsToCart(TestConstants.itemNumber);
            dashboardPage.ProceedToCart();
            cartPage.ClickCheckout();

            checkoutPage.EnterCheckoutDetails(TestConstants.FirstName, TestConstants.LastName, TestConstants.ZipCode);
            checkoutPage.PlaceOrder();

            Assert.That(checkoutPage.IsOrderOverviewMessageVisible, Is.True, "Order was not completed successfully!");
        }
    }
}
