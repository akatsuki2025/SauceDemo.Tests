namespace SauceDemo.BusinessLayer.PageObjects;
using OpenQA.Selenium;

public class DashboardPage : BasePage
{
    private static readonly By DashboardTitle = By.CssSelector(".app_logo");
    private static readonly By MenuButton = By.CssSelector("#react-burger-menu-btn");
    private static readonly By LogoutButton = By.CssSelector("#logout_sidebar_link");

    public DashboardPage() : base() 
    { 
    }

    public string GetDashboardTitle()
    {
        return WaitForElement(DashboardTitle).Text;
    }

    public void ClickLogout()
    {
        WaitForElement(MenuButton).Click();
        WaitForElement(LogoutButton).Click();
    }
}