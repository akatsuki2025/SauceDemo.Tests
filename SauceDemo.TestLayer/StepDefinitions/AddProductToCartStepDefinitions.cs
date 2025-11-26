namespace SauceDemo.TestLayer.StepDefinitions;

[Binding]
public class AddProductToCartStepDefinitions
{
    private readonly DashboardPage _dashboardPage;
    private readonly CartPage _cartPage;

    public AddProductToCartStepDefinitions()
    {
        _dashboardPage = new DashboardPage();
        _cartPage = new CartPage();
    }

    [When("the user adds {string} to the cart")]
    public void WhenTheUserAddsToTheCart(string productName)
    {
        _dashboardPage.AddProductToCart(productName);
    }

    [Then("the cart badge should display {string}")]
    public void ThenTheCartBadgeShouldDisplay(string expectedCount)
    {
        var badgeCount = _dashboardPage.GetCartBadgeCount();
        badgeCount.Should().Be(expectedCount, $"Cart badge should display {expectedCount} but it was {badgeCount}");
    }

    [Then("the cart should contain {string}")]
    public void ThenTheCartShouldContain(string productName)
    {
        _dashboardPage.ClickCartButton();
        _cartPage.IsProductInCart(productName).Should().BeTrue($"Cart should contain product '{productName}");
    }
}
