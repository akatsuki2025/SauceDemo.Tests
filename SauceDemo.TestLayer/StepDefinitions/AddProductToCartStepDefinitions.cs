namespace SauceDemo.TestLayer.StepDefinitions;
using log4net;

[Binding]
public class AddProductToCartStepDefinitions
{
    private static readonly ILog Log = LogManager.GetLogger(typeof(AddProductToCartStepDefinitions));
    private readonly DashboardPage _dashboardPage;
    private readonly CartPage _cartPage;

    public AddProductToCartStepDefinitions(DashboardPage dashboardPage, CartPage cartPage)
    {
        _dashboardPage = dashboardPage;
        _cartPage = cartPage;
    }

    [When("the user adds {string} to the cart")]
    public void WhenTheUserAddsToTheCart(string productName)
    {
        Log.Info($"Adding product '{productName}' to the cart.");
        _dashboardPage.AddProductToCart(productName);
    }

    [Then("the cart badge should display {string}")]
    public void ThenTheCartBadgeShouldDisplay(string expectedCount)
    {
        try
        {
            var badgeCount = _dashboardPage.GetCartBadgeCount();
            Log.Info($"Checking cart badge. Expected: '{expectedCount}', Actual: '{badgeCount}'.");
            badgeCount.Should().Be(expectedCount, $"Cart badge should display '{expectedCount}' but it was '{badgeCount}'");
        }
        catch (Exception ex)
        {
            Log.Error("Error checking cart badge.", ex);
            throw;
        }
    }

    [Then("the cart should contain {string}")]
    public void ThenTheCartShouldContain(string productName)
    {
        try
        {
            Log.Info($"Verifying cart contains product '{productName}'.");
            _dashboardPage.ClickCartButton();
            _cartPage.IsProductInCart(productName).Should().BeTrue($"Cart should contain product '{productName}'");
        }
        catch (Exception ex)
        {
            Log.Error($"Error verifying cart contains product '{productName}'.", ex);
            throw;
        }
    }

    [When("the user removes {string} from the cart page")]
    public void WhenTheUserRemovesFromTheCartPage(string productName)
    {
        Log.Info($"Navigating to cart page to remove product '{productName}'.");
        _dashboardPage.ClickCartButton();
        Log.Info($"Removing product '{productName}' from the cart page.");
        _cartPage.RemoveProductFromCart(productName);
    }

    [Then("the cart badge should not be visible")]
    public void ThenTheCartBadgeShouldNotBeVisible()
    {
        try
        {
            Log.Info("Checking that the cart badge is not visible.");
            _dashboardPage.IsCartBadgeVisible().Should().BeFalse("Cart badge should not be visible");
        }
        catch (Exception ex)
        {
            Log.Error("Error checking cart badge visibility.", ex);
            throw;
        }
    }

    [Then("the cart should not contain {string}")]
    public void ThenTheCartShouldNotContain(string productName)
    {
        try
        {
            Log.Info($"Verifying cart does not contain product '{productName}'.");
            _dashboardPage.ClickCartButton();
            _cartPage.IsProductInCart(productName).Should().BeFalse($"Cart should not contain product '{productName}'");
        }
        catch (Exception ex)
        {
            Log.Error($"Error verifying cart does not contain product '{productName}'.", ex);
            throw;
        }
    }

    [When("the user removes {string} from the dashboard page")]
    public void WhenTheUserRemovesFromTheDashboardPage(string productName)
    {
        Log.Info($"Removing product '{productName}' from the dashboard page.");
        _dashboardPage.RemoveProductFromDashboard(productName);
    }

    [When("the user navigates to the cart page")]
    public void WhenTheUserNavigatesToTheCartPage()
    {
        Log.Info("Navigating to the cart page.");
        _dashboardPage.ClickCartButton();
    }
}
