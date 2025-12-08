namespace SauceDemo.BusinessLayer.PageObjects;
using OpenQA.Selenium;

public class CartPage : BasePage
{
    public CartPage() : base()
    {
    }

    /// <summary>
    /// Checks if the specified product is present in the cart.
    /// </summary>
    /// <param name="productName">The name of the product to check.</param>
    /// <returns>True if the product is in the cart, otherwise false.</returns>
    public bool IsProductInCart(string productName)
    {
        var productLocator = By.XPath($"//div[@class='inventory_item_name' and text()='{productName}']");
        var elements = Driver.FindElements(productLocator);
        return elements.Count > 0 && elements[0].Displayed;
    }

    /// <summary>
    /// Removes the specified product from the cart.
    /// </summary>
    /// <param name="productName">The name of the product to remove.</param>
    public void RemoveProductFromCart(string productName)
    {
        var productId = ToProductId(productName);
        var removeButtonId = $"remove-{productId}";
        WaitForElement(By.Id(removeButtonId)).Click();
    }
}
