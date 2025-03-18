using OpenQA.Selenium;

namespace EpamTests.Pages
{
    public class ArticlePage(IWebDriver driver)
    {
        private readonly IWebDriver _driver = driver;
        private static By ArticleTitleLocator => By.XPath("//*[@class='font-size-80-33'][.//text()]");

        public string? GetArticleTitle()
        {
            var titleElement = _driver.FindElement(ArticleTitleLocator);
            return titleElement?.Text.Trim();
        }
    }
}
