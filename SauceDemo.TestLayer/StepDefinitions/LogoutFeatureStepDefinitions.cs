using FluentAssertions;
using log4net;
using Reqnroll;
using System;

namespace SauceDemo.TestLayer.StepDefinitions
{
    [Binding]
    public class LogoutFeatureStepDefinitions
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

        [Given("The user is logged in with valid credentials")]
        public void GivenTheUserIsLoggedInWithValidCredentials()
        {
            Log.Info("Logging in with valid credentials.");
            LoginPage.NavigateTo("https://www.saucedemo.com/");
            LoginPage.EnterUsername("standard_user");
            LoginPage.EnterPassword("secret_sauce");
            LoginPage.ClickLogin();
            DashboardPage.GetDashboardTitle().Should().Be("Swag Labs");
        }

        [When("the user clicks the logout button")]
        public void WhenTheUserClicksTheLogoutButton()
        {
            Log.Info("Clicking the logout button.");
            DashboardPage.ClickLogout();
        }

        [Then("the login page should be displayed")]
        public void ThenTheLoginPageShouldBeDisplayed()
        {
            Log.Info("Verifying that the login page is displayed.");
            var isLoginDisplayed = LoginPage.IsAt();
            isLoginDisplayed.Should().BeTrue("The login page should be displayed after logout");
        }
    }
}
