using FluentAssertions;
using log4net;

namespace SauceDemo.TestLayer.StepDefinitions
{
    /// <summary>
    /// Step definitions for the SauceDemo login feature.
    /// </summary>
    [Binding]
    public class LoginFeatureStepDefinitions
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(LoginFeatureStepDefinitions));
        private DashboardPage? _dashboardPage;
        private readonly LoginPage _loginPage = new LoginPage();

        private LoginPage LoginPage => _loginPage;
        private DashboardPage DashboardPage
        {
            get
            {
                if (_dashboardPage == null)
                {
                    Log.Info("Creating DashboardPage instance.");
                    _dashboardPage = new DashboardPage();
                }
                return _dashboardPage;
            }
        }

        [Given("The user is on the SauceDemo login page")]
        public void GivenTheUserIsOnTheSauceDemoLoginPage()
        {
            Log.Info("Navigating to SauceDemo login page.");
            LoginPage.NavigateTo("https://www.saucedemo.com/"); 
        }

        [Given(@"the user enters ""(.*)"" as username and ""(.*)"" as password")]
        public void GivenTheUserEntersAsUsernameAndAsPassword(string username, string password)
        {
            Log.Info($"Entering username: {username} and password: [HIDDEN]");
            LoginPage.EnterUsername(username);
            LoginPage.EnterPassword(password);
        }

        [Given("the user clears both fields")]
        public void GivenTheUserClearsBothFields()
        {
            Log.Info("Clearing both username and password fields.");
            LoginPage.ClearUsername();
            LoginPage.ClearPassword();
        }

        [Given("the user clears the password field")]
        public void GivenTheUserClearsThePasswordField()
        {
            Log.Info("Clearing password field.");
            LoginPage.ClearPassword();
        }

        [When("the user submits the login form")]
        public void WhenTheUserSubmitsTheLoginForm()
        {
            Log.Info("Submitting the login form.");
            LoginPage.ClickLogin();
        }

        [Then(@"the error message ""(.*)"" should be displayed")]
        public void ThenTheErrorMessageShouldBeDisplayed(string expectedMessage)
        {
            var actualMessage = LoginPage.GetErrorMessage();
            Log.Info($"Checking error message. Expected: '{expectedMessage}', Actual: '{actualMessage}'");
            actualMessage.Should().Contain(expectedMessage);
        }

        [Then("the dashboard title {string} should be displayed")]
        public void ThenTheDashboardTitleShouldBeDisplayed(string expectedTitle)
        {
            var actualTitle = DashboardPage.GetDashboardTitle();
            Log.Info($"Checking dashboard title. Expected: '{expectedTitle}', Actual: '{actualTitle}'");
            actualTitle.Should().Be(expectedTitle, "the dashboard title should match after successful login");
        }
    }
}