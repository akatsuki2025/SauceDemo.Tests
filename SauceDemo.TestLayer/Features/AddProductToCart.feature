Feature: Add item to cart

As a user
I want to add products to my shopping cart
So that I can purchase them later

Background:
	Given The user is logged in with valid credentials

@parellel
Scenario Outline: Add a single product to the cart
	When the user adds "<ProductName>" to the cart
	Then the cart badge should display "1"
	And the cart should contain "<ProductName>"

	Examples:
    | ProductName                |
    | Sauce Labs Backpack        |
    | Sauce Labs Bike Light      |
    | Sauce Labs Bolt T-Shirt    |
	| Sauce Labs Fleece Jacket   |

@parallel
Scenario Outline: Add multiple products to the cart
    When the user adds "<Product1>" to the cart
    And the user adds "<Product2>" to the cart
    Then the cart badge should display "2"
    And the cart should contain "<Product1>"
    And the cart should contain "<Product2>"

    Examples:
        | Product1                 | Product2                |
        | Sauce Labs Backpack      | Sauce Labs Bike Light   |
        | Sauce Labs Bolt T-Shirt  | Sauce Labs Fleece Jacket|
        | Sauce Labs Backpack      | Sauce Labs Fleece Jacket|
