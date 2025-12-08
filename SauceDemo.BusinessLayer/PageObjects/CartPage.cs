namespace SauceDemo.BusinessLayer.PageObjects;
using OpenQA.Selenium;

public class CartPage : BasePage
{
    public CartPage() : base()
    {
    }

    public bool IsProductInCart(string productName)
    {
        var productLocator = By.XPath($"//div[@class='inventory_item_name' and text()='{productName}']");
        var elements = Driver.FindElements(productLocator);
        return elements.Count > 0 && elements[0].Displayed;
    }

    public void RemoveProductFromCart(string productName)
    {
        var productId = ToProductId(productName);
        var removeButtonId = $"remove-{productId}";
        WaitForElement(By.Id(removeButtonId)).Click();
    }
}
