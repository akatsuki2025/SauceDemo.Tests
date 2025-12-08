namespace SauceDemo.BusinessLayer.PageObjects;
using OpenQA.Selenium;

public class DashboardPage : BasePage
{
    private readonly HeaderComponent _headerComponent;

    public DashboardPage() : base() 
    {
        _headerComponent = new HeaderComponent(Driver, Wait);
    }

    public void AddProductToCart(string productName)
    {
        var productId = ToProductId(productName);
        WaitForElement(By.Id($"add-to-cart-{productId}")).Click();
    }

    public void RemoveProductFromDashboard(string productName)
    {
        var productId = ToProductId(productName);
        WaitForElement(By.Id($"remove-{productId}")).Click();
    }

    public string GetHeaderTitle() => _headerComponent.GetHeaderTitle();
    public void ClickLogout() => _headerComponent.ClickLogout();
    public string GetCartBadgeCount() => _headerComponent.GetCartBadgeCount();
    public void ClickCartButton() => _headerComponent.ClickCartButton();
    public bool IsCartBadgeVisible() => _headerComponent.IsCartBadgeVisible();
}