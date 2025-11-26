namespace SauceDemo.BusinessLayer.PageObjects;
using OpenQA.Selenium;

public class DashboardPage : BasePage
{
    private static readonly By DashboardTitle = By.CssSelector(".app_logo");
    private static readonly By MenuButton = By.CssSelector("#react-burger-menu-btn");
    private static readonly By LogoutButton = By.CssSelector("#logout_sidebar_link");
    private static readonly By CartBadge = By.ClassName("shopping_cart_badge");
    private static readonly By CartButton = By.ClassName("shopping_cart_link");

    public DashboardPage() : base() 
    { 
    }

    public string GetDashboardTitle()
    {
        return WaitForElement(DashboardTitle).Text;
    }

    public void ClickLogout()
    {
        WaitForElement(MenuButton).Click();
        WaitForElement(LogoutButton).Click();
    }

    public void AddProductToCart(string productName)
    {
        var productId = productName.ToLower().Replace(" ", "-");
        WaitForElement(By.Id($"add-to-cart-{productId}")).Click();
    }

    public string GetCartBadgeCount()
    {
        try
        {
            return WaitForElement(CartBadge).Text;
        }
        catch (NoSuchElementException)
        {
            return "0";
        }
    }

    public void ClickCartButton()
    {
        WaitForElement(CartButton).Click();
    }
}