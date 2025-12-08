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

    public string GetHeaderTitle()
    {
        return _wait.Until(ExpectedConditions.ElementIsVisible(HeaderTitle)).Text;
    }

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

    public bool IsCartBadgeVisible()
    {
        var elements = _driver.FindElements(CartBadge);
        return elements.Count > 0 && elements[0].Displayed;
    }

    public void ClickLogout()
    {
        _wait.Until(ExpectedConditions.ElementIsVisible(MenuButton)).Click();
        _wait.Until(ExpectedConditions.ElementIsVisible(LogoutButton)).Click();
    }
}
