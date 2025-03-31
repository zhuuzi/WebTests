using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTests.Pages;
using EpamTests.Tests;
using TechTalk.SpecFlow;

namespace EpamTests.StepDefinitions
{
    [Binding]
    public class CarouselSteps : BaseTest
    {
        private string? expectedTitle;
        private string? actualTitle;

        [When(@"I navigate to the Insights page")]
        public void WhenINavigateToTheInsightsPage()
        {
            HomePage.ClickInsightsMenu();
        }

        [When(@"I swipe the carousel (.*) times")]
        public void WhenISwipeTheCarousel(int times)
        {
            InsightsPage.SwipeCarousel(times);
            expectedTitle = InsightsPage.GetArticleTitle();
        }

        [When(@"I click Read More on the active article")]
        public void WhenIClickReadMoreOnTheActiveArticle()
        {
            InsightsPage.ClickReadMoreButton();
            actualTitle = new ArticlePage(driver).GetArticleTitle();
        }

        [Then(@"the article title should match the carousel title")]
        public void ThenTheArticleTitleShouldMatch()
        {
            Assert.That(actualTitle, Is.EqualTo(expectedTitle), "Article title does not match the carousel title.");
        }
    }
}
