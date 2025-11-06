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

---

## Solution Structure

- **SauceDemo.BusinessLayer/PageObjects/**  
  Contains Page Object Models for Login and Dashboard pages.
- **SauceDemo.CoreLayer/Drivers/**  
  Implements browser abstraction and driver factories (Chrome, Edge, Firefox) using the Abstract Factory pattern.
- **SauceDemo.TestLayer/StepDefinitions/**  
  Contains step definitions for BDD scenarios.
- **SauceDemo.TestLayer/Features/**  
  Contains feature files describing test scenarios in Gherkin syntax.
- **SauceDemo.TestLayer/Support/**  
  Contains hooks for WebDriver and Log4Net configuration.
- **SauceDemo.TestLayer/log4net.config**  
  Log4Net configuration file for logging.

## Features

- **Logging:**  
  Log4Net is integrated and configured ([log4net.config](SauceDemo.TestLayer/log4net.config)), with hooks in [`Log4NetHooks`](SauceDemo.TestLayer/Support/Log4NetHooks.cs).
- **Test Automation Tool:**  
  Selenium WebDriver.
- **Browsers Supported:**  
  Chrome, Edge, Firefox (driver selection via [`WebDriverHooks`](SauceDemo.TestLayer/Support/WebDriverHooks.cs)).
- **Locators:**  
  CSS selectors.
- **Test Runner:**  
  xUnit.
- **Assertions:**  
  FluentAssertions.
- **BDD Approach:**  
  Implemented with Reqnroll.
- **Design Patterns:**  
  Abstract Factory is applied for driver creation.

## How to Run

1. **Install dependencies:**  
   Restore NuGet packages for the solution.

2. **Configure WebDriver:**  
   The browser is selected in [`WebDriverHooks`](SauceDemo.TestLayer/Support/WebDriverHooks.cs).  
   By default, tests use Firefox. To use Edge or Chrome, update the browser type in the hook.

3. **Run Tests:**  
   Use the following command in the solution directory:
   ```sh
   dotnet test
   ```

## Logging

- Log4Net is already integrated and configured.  
  See [`Log4NetHooks`](SauceDemo.TestLayer/Support/Log4NetHooks.cs) and [`log4net.config`](SauceDemo.TestLayer/log4net.config) for details.

## Customization

- **Browser Support:**  
  Change the browser type in [`WebDriverHooks`](SauceDemo.TestLayer/Support/WebDriverHooks.cs) to use Chrome, Edge, or Firefox.

---

**Note:**  
All tests are implemented using BDD with Reqnroll, and assertions are made using FluentAssertions. For more details, see the step definitions in [`LoginFeatureStepDefinitions`](SauceDemo.TestLayer/StepDefinitions/LoginFeatureStepDefinitions.cs) and page objects in [`LoginPage`](SauceDemo.BusinessLayer/PageObjects/LoginPage.cs) and [`DashboardPage`](SauceDemo.BusinessLayer/PageObjects/DashboardPage.cs).