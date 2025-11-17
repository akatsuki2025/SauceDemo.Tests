namespace SauceDemo.TestLayer.StepDefinitions;
using FluentAssertions;
using log4net;

[Binding]
public class LogoutFeatureStepDefinitions : BaseStepDefinitions
{
    private static readonly ILog Log = LogManager.GetLogger(typeof(LogoutFeatureStepDefinitions));
    private readonly LoginPage _loginPage;
    private readonly DashboardPage _dashboardPage;

    public LogoutFeatureStepDefinitions()
    {
        _loginPage = new LoginPage();
        _dashboardPage = new DashboardPage();
    }

    [Given("The user is logged in with valid credentials")]
    public void GivenTheUserIsLoggedInWithValidCredentials()
    {
        Log.Info("Logging in with valid credentials.");
        try
        {
            _loginPage.NavigateTo(BaseUrl);
            _loginPage.EnterUsername(Environment.GetEnvironmentVariable("SAUCE_USERNAME") ?? "standard_user");
            _loginPage.EnterPassword(Environment.GetEnvironmentVariable("SAUCE_PASSWORD") ?? "secret_sauce");
            _loginPage.ClickLogin();

            Log.Info("Verifying successful login.");
            _dashboardPage.GetDashboardTitle().Should().Be("Swag Labs");
        }
        catch (Exception ex)
        {
            Log.Error("Login failed.", ex);
            throw;
        }
    }

    [When("the user clicks the logout button")]
    public void WhenTheUserClicksTheLogoutButton()
    {
        Log.Info("Clicking the logout button.");
        _dashboardPage.ClickLogout();
    }

    [Then("the login page should be displayed")]
    public void ThenTheLoginPageShouldBeDisplayed()
    {
        Log.Info("Verifying that the login page is displayed.");
        var isLoginDisplayed = _loginPage.IsAt();
        isLoginDisplayed.Should().BeTrue("The login page should be displayed after logout");
    }
}