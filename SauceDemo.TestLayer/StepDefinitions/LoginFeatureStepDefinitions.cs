using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using SauceDemo.BusinessLayer.PageObjects;
using SauceDemo.CoreLayer.Drivers;
using System;

namespace SauceDemo.TestLayer.StepDefinitions
{
    [Binding]
    public class LoginFeatureStepDefinitions : IDisposable
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private DashboardPage _dashboardPage;

        [BeforeScenario]
        public void Setup()
        {
            var factory = DriverFactory.GetFactory(BrowserType.Firefox); // or Chrome/Edge
            _driver = factory.CreateDriver();
            _loginPage = new LoginPage(_driver);
        }

        [Given("The user is on the SauceDemo login page")]
        public void GivenTheUserIsOnTheSauceDemoLoginPage()
        {
            _loginPage.NavigateTo("https://www.saucedemo.com/"); 
        }

        [Given(@"the user enters ""(.*)"" as username and ""(.*)"" as password")]
        public void GivenTheUserEntersAsUsernameAndAsPassword(string username, string password)
        {
            _loginPage.EnterUsername(username);
            _loginPage.EnterPassword(password);
        }

        [Given("the user clears both fields")]
        public void GivenTheUserClearsBothFields()
        {
            _loginPage.ClearUsername();
            _loginPage.ClearPassword();
            _loginPage.GetUsernameValue().Should().BeEmpty("Username field should be empty after clearing.");
            _loginPage.GetPasswordValue().Should().BeEmpty("Password field should be empty after clearing.");
        }

        [Given("the user clears the password field")]
        public void GivenTheUserClearsThePasswordField()
        {
            _loginPage.ClearPassword();
        }

        [When("the user submits the login form")]
        public void WhenTheUserSubmitsTheLoginForm()
        {
            _loginPage.ClickLogin();
            _dashboardPage = new DashboardPage(_driver);
        }

        [Then(@"the error message ""(.*)"" should be displayed")]
        public void ThenTheErrorMessageShouldBeDisplayed(string expectedMessage)
        {
            var actualMessage = _loginPage.GetErrorMessage();
            actualMessage.Should().Contain(expectedMessage);
        }

        [Then("the dashboard title {string} should be displayed")]
        public void ThenTheDashboardTitleShouldBeDisplayed(string expectedTitle)
        {
            _dashboardPage.GetDashboardTitle().Should().Be(expectedTitle, "the dashboard title should match after successful login");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }

        public void Dispose()
        {
            _driver?.Dispose();
        }
    }
}
