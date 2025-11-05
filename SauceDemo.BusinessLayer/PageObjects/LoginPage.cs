using OpenQA.Selenium;

namespace SauceDemo.BusinessLayer.PageObjects
{
    /// <summary>
    /// Represents the login page and provides methods to interact with its elements.
    /// </summary>
    public class LoginPage : BasePage
    {
        private readonly By UsernameInput = By.CssSelector("#user-name");
        private readonly By PasswordInput = By.CssSelector("#password");
        private readonly By LoginButton = By.CssSelector("#login-button");
        private readonly By ErrorMessage = By.CssSelector("h3[data-test='error']");

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
        public LoginPage() : base()
        {
        }

        public void EnterUsername(string username)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(username);
            var element = WaitForElement(UsernameInput);
            element.Clear();
            element.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            ArgumentNullException.ThrowIfNullOrWhiteSpace(password);
            var element = WaitForElement(PasswordInput);
            element.Clear();
            element.SendKeys(password);
        }

        public void ClearUsername()
        {
            ClearField(UsernameInput);
        }

        public void ClearPassword()
        {
            ClearField(PasswordInput);
        }

        public void ClickLogin()
        {
            WaitForElement(LoginButton).Click();
        }

        /// <summary>
        /// Gets the error message displayed on the login page, if any.
        /// </summary>
        /// <returns>The error message text, or an empty string if no error is displayed.</returns>
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
