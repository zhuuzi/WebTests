using OpenQA.Selenium;

namespace SauceDemoTests.Pages
{
    public class LoginPage(IWebDriver driver)
    {
        private readonly IWebDriver driver = driver;

        private readonly By usernameField = By.Id("user-name");
        private readonly By passwordField = By.Id("password");
        private readonly By loginButton = By.Id("login-button");
        private readonly By errorMessage = By.XPath("//*[contains(@class, 'error-message')]");

        public bool IsLoginPageVisible() => driver.FindElement(loginButton).Displayed;

        public void EnterUsername(string username) => driver.FindElement(usernameField).SendKeys(username);
        public void EnterPassword(string password) => driver.FindElement(passwordField).SendKeys(password);
        public void ClickLogin() => driver.FindElement(loginButton).Click();
        public void Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLogin();
        }

        public bool IsErrorDisplayed() => driver.FindElement(errorMessage).Displayed;
    }
}