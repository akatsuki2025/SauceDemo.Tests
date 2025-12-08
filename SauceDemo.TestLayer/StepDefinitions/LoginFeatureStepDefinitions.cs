namespace SauceDemo.TestLayer.StepDefinitions;
using FluentAssertions;
using log4net;

/// <summary>
/// Step definitions for the SauceDemo login feature.
/// </summary>
[Binding]
public class LoginFeatureStepDefinitions : BaseStepDefinitions
{
    private static readonly ILog Log = LogManager.GetLogger(typeof(LoginFeatureStepDefinitions));
    private readonly LoginPage _loginPage;
    private readonly DashboardPage _dashboardPage;

    public LoginFeatureStepDefinitions(LoginPage loginPage, DashboardPage dashboardPage)
    {
        _loginPage = loginPage;
        _dashboardPage = dashboardPage;
    }

    [Given("The user is on the SauceDemo login page")]
    public void GivenTheUserIsOnTheSauceDemoLoginPage()
    {
        Log.Info("Navigating to SauceDemo login page.");
        _loginPage.NavigateTo(BaseUrl); 
    }

    [Given(@"the user enters ""(.*)"" as username and ""(.*)"" as password")]
    public void GivenTheUserEntersAsUsernameAndAsPassword(string username, string password)
    {
        Log.Info($"Entering username: {username} and password: [HIDDEN]");
        _loginPage.EnterUsername(username);
        _loginPage.EnterPassword(password);
    }

    [Given("the user clears both fields")]
    public void GivenTheUserClearsBothFields()
    {
        Log.Info("Clearing both username and password fields.");
        _loginPage.ClearUsername();
        _loginPage.ClearPassword();
    }

    [Given("the user clears the password field")]
    public void GivenTheUserClearsThePasswordField()
    {
        Log.Info("Clearing password field.");
        _loginPage.ClearPassword();
    }

    [When("the user submits the login form")]
    public void WhenTheUserSubmitsTheLoginForm()
    {
        Log.Info("Submitting the login form.");
        _loginPage.ClickLogin();
    }

    [Then(@"the error message ""(.*)"" should be displayed")]
    public void ThenTheErrorMessageShouldBeDisplayed(string expectedMessage)
    {
        var actualMessage = _loginPage.GetErrorMessage();
        Log.Info($"Checking error message. Expected: '{expectedMessage}', Actual: '{actualMessage}'");
        actualMessage.Should().Contain(expectedMessage);
    }

    [Then("the dashboard title {string} should be displayed")]
    public void ThenTheDashboardTitleShouldBeDisplayed(string expectedTitle)
    {
        var actualTitle = _dashboardPage.GetHeaderTitle();
        Log.Info($"Checking dashboard title. Expected: '{expectedTitle}', Actual: '{actualTitle}'");
        actualTitle.Should().Be(expectedTitle, "the dashboard title should match after successful login");
    }
}