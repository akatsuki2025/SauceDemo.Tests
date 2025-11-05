Feature: Login feature

As a user
I want to be able to log in with different credentials
So that I can access the application or receive helpful error messages if the credentials are incorrect

Background: 
	Given The user is on the SauceDemo login page

@UC-1 @parallel
Scenario Outline: Login with empty credentials
	And the user enters "<username>" as username and "<password>" as password
	And the user clears both fields
	When the user submits the login form
	Then the error message "Username is required" should be displayed

	Examples: 
	| username | password    |
	| anyuser  | anypassword |

@UC-2 @parallel
Scenario Outline: Login with missing password
	And the user enters "<username>" as username and "<password>" as password
	And the user clears the password field
	When the user submits the login form
	Then the error message "Password is required" should be displayed

	Examples: 
	| username | password    |
	| anyuser  | anypassword |

@UC-3 @parallel
Scenario Outline: Login with valid credentials
	And the user enters "<username>" as username and "secret_sauce" as password
	When the user submits the login form
	Then the dashboard title "Swag Labs" should be displayed

	Examples: 
	| username                |
	| standard_user           |
	| problem_user            |
	| performance_glitch_user |
	| error_user              |
	| visual_user             |