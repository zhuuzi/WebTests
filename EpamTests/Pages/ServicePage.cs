using OpenQA.Selenium;

namespace EpamTests.Pages
{
    public class ServicePage(IWebDriver driver)
    {
        private readonly IWebDriver _driver = driver;

        private static By RelatedExpertiseSection => By.XPath("//*[contains(text(), 'Our Related Expertise')]");

        public string GetPageTitle()
        {
            return _driver.Title;
        }

        public bool IsRelatedExpertiseSectionVisible()
        {
            try
            {
                return _driver.FindElement(RelatedExpertiseSection).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
