using OpenQA.Selenium;

namespace SauceDemo.BusinessLayer.PageObjects;

public class CartPage : BasePage
{
    public CartPage() : base()
    {
    }

    public bool IsProductInCart(string productName)
    {
        var productLocator = By.XPath($"//div[@class='inventory_item_name' and text()='{productName}']");
        try
        {
            return WaitForElement(productLocator).Displayed;
        }
        catch (NoSuchElementException)
        {
            return false;
        }
    }
}
