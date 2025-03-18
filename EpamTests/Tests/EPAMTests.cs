using EpamTests.Pages;
using EpamTests.Utils;

namespace EpamTests.Tests
{
    [TestFixture]
    public class EPAMTests : BaseTest
    {
        [Test]
        [TestCase(Constants.FilePaths.FileName)]
        public void ValidateFileDownload(string fileName)
        {
            // Arrange
            HomePage.ClickAboutMenu();

            // Act
            AboutPage.ClickDownloadButton();

            // Assert
            string filePath = Path.Combine(Constants.FilePaths.DownloadsPath, fileName);
            Assert.That(File.Exists(filePath), Is.True, $"File {fileName} was not downloaded.");
        }

        [Test]
        [TestCase(2)]
        [TestCase(3)]
        public void ValidateArticleTitleMatchesCarousel(int numberOfSwipes)
        {
            // Arrange
            HomePage.ClickInsightsMenu();
            InsightsPage.SwipeCarousel(numberOfSwipes);
            string? expectedTitle = InsightsPage.GetArticleTitle();

            // Act
            InsightsPage.ClickReadMoreButton();
            ArticlePage articlePage = new ArticlePage(driver);
            string? actualTitle = articlePage.GetArticleTitle();

            // Assert
            Assert.That(expectedTitle, Is.EqualTo(actualTitle), "Article title does not match the carousel title.");
        }
    }
}