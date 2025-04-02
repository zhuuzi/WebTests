using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpamTests.Pages;
using EpamTests.Tests;
using EpamTests.Utils;
using TechTalk.SpecFlow;

namespace EpamTests.StepDefinitions
{
    [Binding]
    public class EpamDownloadSteps : BaseTest
    {
        [When(@"I navigate to the About page")]
        public void WhenINavigateToTheAboutPage()
        {
            HomePage.ClickAboutMenu();
        }

        [When(@"I click the download button")]
        public void WhenIClickTheDownloadButton()
        {
            AboutPage.ClickDownloadButton();
        }

        [Then(@"the file ""(.*)"" should be downloaded")]
        public void ThenTheFileShouldBeDownloaded(string fileName)
        {
            var downloadedFilePath = Path.Combine(Constants.FilePaths.DownloadsPath, fileName);
            Assert.That(File.Exists(downloadedFilePath), Is.True, $"File {fileName} was not downloaded.");
        }
    }
}
