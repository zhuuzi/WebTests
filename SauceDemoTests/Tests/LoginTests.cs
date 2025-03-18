using SauceDemoTests.Utils;

namespace SauceDemoTests.Tests
{
    public class LoginTests : Base.TestBase
    {
        [Test]
        [TestCase(TestConstants.ValidUsername, TestConstants.ValidPassword, TestName = "ValidLogin")]
        public void TestLogin(string username, string password)
        {
            loginPage.Login(username, password);
            Assert.That(dashboardPage.IsDashboardLoaded(), Is.True);
        }

        [Test]
        [TestCase(TestConstants.InvalidUsername, TestConstants.InvalidPassword, TestName = "InvalidLogin")]
        [TestCase(TestConstants.ValidUsername, TestConstants.InvalidPassword, TestName = "WrongPassword")]
        [TestCase("", "", TestName = "EmptyCredentials")]
        public void TestInvalidLogin(string username, string password)
        {
            loginPage.Login(username, password);
            Assert.That(loginPage.IsErrorDisplayed(), Is.True, "Login should have failed, but it didn't.");
        }

        [Test]
        public void TestLogout()
        {
            loginPage.Login(TestConstants.ValidUsername, TestConstants.ValidPassword);
            dashboardPage.Logout();
            Assert.That(loginPage.IsLoginPageVisible(), Is.True, "Logout failed.");
        }
    }
}
