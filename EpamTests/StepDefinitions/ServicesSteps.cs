using System;
using EpamTests.Pages;
using EpamTests.Tests;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace EpamTests.StepDefinitions
{
    [Binding]
    public class ServicesSteps : BaseTest
    {
        private ServicePage ServicePage => new ServicePage(driver);

        [When(@"I navigate to the ""(.*)"" section")]
        public void WhenINavigateToTheSection(string section)
        {
            if (section == "Services")
            {
                HomePage.HoverOverServicesMenu();
            }
        }

        [When(@"I select the service category ""(.*)""")]
        public void WhenISelectServiceCategory(string category)
        {
            HomePage.SelectServiceCategory(category);
        }

        [Then(@"the page title should be ""(.*)""")]
        public void ThenThePageTitleShouldBe(string expectedTitle)
        {
            var actualTitle = ServicePage.GetPageTitle();
            Assert.That(actualTitle, Does.Contain(expectedTitle), $"Expected title '{expectedTitle}' but got '{actualTitle}'");
        }

        [Then(@"the section ""(.*)"" should be visible")]
        public void ThenTheSectionShouldBeVisible(string sectionText)
        {
            var isVisible = ServicePage.IsRelatedExpertiseSectionVisible();
            Assert.That(isVisible, Is.True, $"Section '{sectionText}' is not visible on the page.");
        }
    }
}
