namespace SauceDemo.CoreLayer.Drivers;
using OpenQA.Selenium;

public interface IWebDriverFactory
{
    IWebDriver CreateDriver();
}