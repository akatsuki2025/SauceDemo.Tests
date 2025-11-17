namespace SauceDemo.BusinessLayer.PageObjects;
using OpenQA.Selenium;

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

    /// <summary>
    /// Checks if the current page is the Login page by verifying key elements.
    /// </summary>
    /// <returns>True if at the Login page, otherwise false.</returns>
    public bool IsAt()
    {
        try
        {
            return WaitForElement(UsernameInput).Displayed &&
                   WaitForElement(PasswordInput).Displayed &&
                   WaitForElement(LoginButton).Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}