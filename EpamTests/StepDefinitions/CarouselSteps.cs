using System;
using EpamTests.Pages;
using EpamTests.Tests;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace EpamTests.StepDefinitions
{
    [Binding]
    public class CarouselSteps : BaseTest
    {
        [When(@"I navigate to the Insights page")]
        public void WhenINavigateToTheInsightsPage()
        {
            HomePage.ClickInsightsMenu();
        }

        [When(@"I swipe the carousel (.*) times")]
        public void WhenISwipeTheCarousel(int times)
        {
            InsightsPage.SwipeCarousel(times);
        }

        [When(@"I click Read More on the active article")]
        public void WhenIClickReadMoreOnTheActiveArticle()
        {
            InsightsPage.ClickReadMoreButton();
        }

        [Then(@"the article title should be ""(.*)""")]
        public void ThenTheArticleTitleShouldBe(string expectedTitle)
        {
            var articlePage = new ArticlePage(driver);
            var actualTitle = articlePage.GetArticleTitle();

            Assert.That(actualTitle, Is.EqualTo(expectedTitle),
                $"Expected title: '{expectedTitle}', but got: '{actualTitle}'");
        }
    }
}