using TechTalk.SpecFlow;
using EpamTests.Utils;
using System.IO;
using EpamTests.Pages;
using EpamTests.Tests;

[Binding]
public class CommonSteps : BaseTest
{
    [Given(@"I am on the EPAM homepage")]
    public void GivenIAmOnTheEPAMHomepage()
    {
        driver.Navigate().GoToUrl(Constants.Urls.EpamUrl);
    }

    [Given(@"I accept cookies")]
    public void GivenIAcceptCookies()
    {
        HomePage.AcceptCookies();
    }
}
