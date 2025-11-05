# SauceDemo Automated Login Tests

## Overview

This solution provides automated tests for the login functionality of [SauceDemo](https://www.saucedemo.com/) using Selenium WebDriver, xUnit, and FluentAssertions. The tests are written in C# and follow the BDD approach with Reqnroll.

## Task description (direct copy)

Launch URL: https://www.saucedemo.com/

UC-1 Test Login form with empty credentials:
Type any credentials into "Username" and "Password" fields.
Clear the inputs.
Hit the "Login" button.
Check the error messages: "Username is required".

UC-2 Test Login form with credentials by passing Username:
Type any credentials in username.
Enter password.
Clear the "Password" input.
Hit the "Login" button.
Check the error messages: "Password is required".

UC-3 Test Login form with credentials by passing Username & Password:
Type credentials in username which are under Accepted username are sections.
Enter password as secret sauce.
Click on Login and validate the title “Swag Labs” in the dashboard.

Provide parallel execution, add logging for tests and use Data Provider to parametrize tests. Make sure that all tasks are supported by these 3 conditions: UC-1; UC-2; UC-3.
Please, add task description as README.md into your solution!

To perform the task use the various of additional options:
Test Automation tool: Selenium WebDriver;
Browsers: 1) Edge; 2) Firefox;
Locators: CSS;
Test Runner: xUnit;

[Optional] Patterns: 1) Abstract Factory; 2) Adapter; 3)Bridge;
[Optional] Test automation approach: BDD;
Assertions: FluentAssertions;
[Optional] Loggers: Log4Net.


## User Cases

### UC-1: Test Login Form with Empty Credentials
1. Type any credentials into the "Username" and "Password" fields.
2. Clear the inputs.
3. Hit the "Login" button.
4. Check the error message: **"Username is required"**.

### UC-2: Test Login Form with Credentials by Passing Username
1. Type any credentials in the username field.
2. Enter a password.
3. Clear the "Password" input.
4. Hit the "Login" button.
5. Check the error message: **"Password is required"**.

### UC-3: Test Login Form with Valid Credentials
1. Type a username from the "Accepted usernames" section.
2. Enter the password: **secret_sauce**.
3. Click "Login" and validate the dashboard title is **"Swag Labs"**.

## Features

- **Parallel Execution:** Tests are tagged and configured for parallel execution.
- **Logging:** [Optional] Integrate Log4Net for logging test execution.
- **Data Provider:** Tests are parameterized using xUnit's data provider features.
- **Test Automation Tool:** Selenium WebDriver.
- **Browsers Supported:** Edge, Firefox (update driver initialization as needed).
- **Locators:** CSS selectors.
- **Test Runner:** xUnit.
- **Assertions:** FluentAssertions.
- **BDD Approach:** Implemented with Reqnroll.
- **[Optional] Patterns:** Abstract Factory, Adapter, Bridge (can be applied for extensibility).

## Project Structure

- `SauceDemo.BusinessLayer/PageObjects/`  
  Contains Page Object Models for Login and Dashboard pages.
- `SauceDemo.TestLayer/StepDefinitions/`  
  Contains step definitions for BDD scenarios.
- `SauceDemo.TestLayer/Features/`  
  Contains feature files describing test scenarios in Gherkin syntax.

## How to Run

1. **Install dependencies:**  
   Restore NuGet packages for the solution.

2. **Configure WebDriver:**  
   By default, tests use ChromeDriver. To use Edge or Firefox, update the driver initialization in [`LoginFeatureStepDefinitions`](SauceDemo.TestLayer/StepDefinitions/LoginFeatureStepDefinitions.cs).

3. **Run Tests:**  
   Use the following command in the solution directory:
   ```sh
   dotnet test
   ```

4. **Parallel Execution:**  
   Tests are tagged for parallel execution by xUnit and Reqnroll.

## Logging

- [Optional] To enable logging, integrate Log4Net and configure it in the test project.

## Customization

- **Browser Support:**  
  Update the WebDriver initialization to support Edge or Firefox as needed.
- **Design Patterns:**  
  Apply Abstract Factory, Adapter, or Bridge patterns for extensibility and maintainability.

---

**Note:**  
All tests are implemented using BDD with Reqnroll, and assertions are made using FluentAssertions. For more details, see the step definitions in [`LoginFeatureStepDefinitions`](SauceDemo.TestLayer/StepDefinitions/LoginFeatureStepDefinitions.cs) and page objects in [`LoginPage`](SauceDemo.BusinessLayer/PageObjects/LoginPage.cs) and [`DashboardPage`](SauceDemo.BusinessLayer/PageObjects/DashboardPage.cs).