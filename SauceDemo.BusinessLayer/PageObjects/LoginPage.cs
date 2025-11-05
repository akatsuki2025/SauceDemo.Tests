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

        public LoginPage() : base()
        {
        }

        public void EnterUsername(string username)
        {
            var element = WaitForElement(UsernameInput);
            element.Clear();
            element.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            var element = WaitForElement(PasswordInput);
            element.Clear();
            element.SendKeys(password);
        }

        public void ClearUsername()
        {
            var element = WaitForElement(UsernameInput);
            element.Clear();
        }

        public void ClearPassword()
        {
            var element = WaitForElement(PasswordInput);
            element.Clear();
        }

        public void ClickLogin()
        {
            WaitForElement(LoginButton).Click();
        }

        public string GetErrorMessage()
        {
            try
            {
                return WaitForElement(ErrorMessage).Text;
            }
            catch (NoSuchElementException)
            {
                return string.Empty;
            }
        }
    }
}
