using FluentAssertions;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using SauceDemo.BusinessLayer.PageObjects;
using SauceDemo.CoreLayer.Drivers;
using System;

namespace SauceDemo.TestLayer.StepDefinitions
{
    [Binding]
    public class LoginFeatureStepDefinitions
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(LoginFeatureStepDefinitions));
        private readonly ScenarioContext _scenarioContext;

        private IWebDriver Driver => (IWebDriver)_scenarioContext["WebDriver"];
        private LoginPage LoginPage => new LoginPage(Driver);
        private DashboardPage? _dashboardPage;

        public LoginFeatureStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("The user is on the SauceDemo login page")]
        public void GivenTheUserIsOnTheSauceDemoLoginPage()
        {
            log.Info("Navigating to SauceDemo login page.");
            LoginPage.NavigateTo("https://www.saucedemo.com/"); 
        }

        [Given(@"the user enters ""(.*)"" as username and ""(.*)"" as password")]
        public void GivenTheUserEntersAsUsernameAndAsPassword(string username, string password)
        {
            log.Info($"Entering username: {username} and password: [HIDDEN]");
            LoginPage.EnterUsername(username);
            LoginPage.EnterPassword(password);
        }

        [Given("the user clears both fields")]
        public void GivenTheUserClearsBothFields()
        {
            log.Info("Clearing both username and password fields.");
            LoginPage.ClearUsername();
            LoginPage.ClearPassword();
            log.Debug("Checking that both fields are empty.");
            LoginPage.GetUsernameValue().Should().BeEmpty("Username field should be empty after clearing.");
            LoginPage.GetPasswordValue().Should().BeEmpty("Password field should be empty after clearing.");
        }

        [Given("the user clears the password field")]
        public void GivenTheUserClearsThePasswordField()
        {
            log.Info("Clearing password field.");
            LoginPage.ClearPassword();
        }

        [When("the user submits the login form")]
        public void WhenTheUserSubmitsTheLoginForm()
        {
            log.Info("Submitting the login form.");
            LoginPage.ClickLogin();
            _dashboardPage = new DashboardPage(Driver);
        }

        [Then(@"the error message ""(.*)"" should be displayed")]
        public void ThenTheErrorMessageShouldBeDisplayed(string expectedMessage)
        {
            var actualMessage = LoginPage.GetErrorMessage();
            log.Info($"Checking error message. Expected: '{expectedMessage}', Actual: '{actualMessage}'");
            actualMessage.Should().Contain(expectedMessage);
        }

        [Then("the dashboard title {string} should be displayed")]
        public void ThenTheDashboardTitleShouldBeDisplayed(string expectedTitle)
        {
            var actualTitle = _dashboardPage.GetDashboardTitle();
            log.Info($"Checking dashboard title. Expected: '{expectedTitle}', Actual: '{actualTitle}'");
            actualTitle.Should().Be(expectedTitle, "the dashboard title should match after successful login");
        }
    }
}
