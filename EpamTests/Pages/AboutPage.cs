using OpenQA.Selenium;
using EpamTests.Utils;
using SauceDemoTests.Utils;

namespace EpamTests.Pages
{
    public class AboutPage(IWebDriver driver)
    {
        private readonly IWebDriver _driver = driver;

        public static By DownloadButton => By.XPath("//a[contains(@class, 'button-ui-23') and contains(@href, 'EPAM_Corporate_Overview')]");

        public void ClickDownloadButton()
        {
            var downloadButtonElement = WaitHelper.WaitForElement(_driver, DownloadButton);
            
            downloadButtonElement?.Click();
            Thread.Sleep(Constants.Timeouts.FileDownloadWait);
        }
    }
}