using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SauceDemoTests.Utils
{
    public static class WaitHelper
    {
        public static IWebElement WaitForElement(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            return wait.Until(drv =>
            {
                var element = drv.FindElement(locator);
                ScrollToElement(drv, element);
                return (element.Displayed && element.Enabled) ? element : null;
            });
        }

        public static void ScrollToElement(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            bool isInViewport = (bool)js.ExecuteScript(
                "var rect = arguments[0].getBoundingClientRect();" +
                "return (rect.top >= 0 && rect.bottom <= window.innerHeight);", element);

            if (!isInViewport)
            {
                js.ExecuteScript("arguments[0].scrollIntoView({ behavior: 'smooth', block: 'center' });", element);
            }
        }

    }
}
