using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SauceDemo.BusinessLayer.PageObjects;

public class HeaderComponent
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;
    private static readonly By HeaderTitle = By.CssSelector(".app_logo");
    private static readonly By CartBadge = By.ClassName("shopping_cart_badge");
    private static readonly By CartButton = By.ClassName("shopping_cart_link");
    private static readonly By MenuButton = By.CssSelector("#react-burger-menu-btn");
    private static readonly By LogoutButton = By.CssSelector("#logout_sidebar_link");

    public HeaderComponent(IWebDriver driver, WebDriverWait wait)
    {
        _driver = driver ?? throw new ArgumentNullException(nameof(driver));
        _wait = wait ?? throw new ArgumentNullException(nameof(wait));
    }

    /// <summary>
    /// Gets the title text displayed in the header.
    /// </summary>
    /// <returns>The header title text.</returns>
    public string GetHeaderTitle()
    {
        return _wait.Until(ExpectedConditions.ElementIsVisible(HeaderTitle)).Text;
    }

    /// <summary>
    /// Gets the number displayed in the cart badge.
    /// Returns "0" if the badge is not present.
    /// </summary>
    /// <returns>The cart badge count as a string.</returns>
    public string GetCartBadgeCount()
    {
        try
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(CartBadge)).Text;
        }
        catch (NoSuchElementException)
        {
            return "0";
        }
    }

    public void ClickCartButton()
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(CartButton)).Click();
    }

    /// <summary>
    /// Checks if the cart badge is visible.
    /// </summary>
    /// <returns>True if the cart badge is visible, otherwise false.</returns>
    public bool IsCartBadgeVisible()
    {
        var elements = _driver.FindElements(CartBadge);
        return elements.Count > 0 && elements[0].Displayed;
    }

    /// <summary>
    /// Opens the menu and clicks the logout button.
    /// </summary>
    public void ClickLogout()
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(MenuButton)).Click();
        _wait.Until(ExpectedConditions.ElementIsVisible(LogoutButton)).Click();
    }
}
