using OpenQA.Selenium;

namespace EpamTests.Pages
{
    public class InsightsPage(IWebDriver driver)
    {
        private readonly IWebDriver _driver = driver;

        private static By CarouselNextButton => By.XPath("//div[contains(@class, 'media-content')]//button[contains(@class, 'slider__right-arrow')]");
        private static By CarouselArticleTitle => By.XPath("//div[contains(@class, 'media-content')]//div[contains(@class, 'owl-item') and contains(@class, 'active')]//span[@class='font-size-60'][.//text()]");
        private static By ReadMoreButton => By.XPath("//div[contains(@class, 'media-content')]//div[contains(@class, 'owl-item') and contains(@class, 'active')]//a[contains(@class, 'custom-link') and contains(text(), 'Read More')]");

        public void SwipeCarousel(int times)
        {
            for (int i = 0; i < times; i++)
            {
                _driver.FindElement(CarouselNextButton).Click();
                Thread.Sleep(1000);
            }
        }

        public string? GetArticleTitle()
        {
            return _driver.FindElement(CarouselArticleTitle).Text.Trim();
        }

        public void ClickReadMoreButton()
        {
            _driver.FindElement(ReadMoreButton).Click();
        }
    }
}