using SauceDemoTests.Utils;


namespace SauceDemoTests.Tests
{
    public class DashboardTests : Base.TestBase
    {
        [SetUp]
        public void TestSetup()
        {
            loginPage.Login(TestConstants.ValidUsername, TestConstants.ValidPassword);
        }

        [Test]
        public void TestDashboardLoad()
        {
            Assert.That(dashboardPage.IsDashboardLoaded(), Is.True, "Dashboard did not load properly.");
        }

        [Test]
        public void TestCartIconVisible()
        {
            Assert.That(dashboardPage.IsCartVisible(), Is.True, "Cart icon is not visible.");
        }
    }
}
