Feature: Logout feature

As a user
I want to be able to log out from the application
So that my session is securely ended

@UC-4 @parallel
Scenario: User logs out successfully
    Given The user is logged in with valid credentials
    When the user clicks the logout button
    Then the login page should be displayed