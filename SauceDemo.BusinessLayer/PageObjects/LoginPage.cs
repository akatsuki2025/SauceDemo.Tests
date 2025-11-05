using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo.BusinessLayer.PageObjects
{
    public class LoginPage : BasePage
    {
        private readonly By UsernameInput = By.CssSelector("#user-name");
        private readonly By PasswordInput = By.CssSelector("#password");
        private readonly By LoginButton = By.CssSelector("#login-button");
        private readonly By ErrorMessage = By.CssSelector("h3[data-test='error']");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public override bool IsAt()
        {
            throw new NotImplementedException();
        }

        public void EnterUsername(string username)
        {
            driver.FindElement(UsernameInput).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            driver.FindElement(PasswordInput).SendKeys(password);
        }

        public void ClearUsername()
        {
            var element = driver.FindElement(UsernameInput);
            element.Clear();
            element.SendKeys(" ");      // Send a space
            element.SendKeys(Keys.Backspace); // Remove the space
        }

        public void ClearPassword()
        {
            var element = driver.FindElement(PasswordInput);
            element.Clear();
            element.SendKeys(" ");      // Send a space
            element.SendKeys(Keys.Backspace); // Remove the space
        }

        public string GetUsernameValue()
        {
            return driver.FindElement(UsernameInput).GetAttribute("value");
        }

        public string GetPasswordValue()
        {
            return driver.FindElement(PasswordInput).GetAttribute("value");
        }

        public void ClickLogin()
        {
            driver.FindElement(LoginButton).Click();
        }

        public string GetErrorMessage()
        {
            try
            {
                return driver.FindElement(ErrorMessage).Text;
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
            }
        }
    }
}
