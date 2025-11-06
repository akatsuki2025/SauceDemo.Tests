using OpenQA.Selenium;

namespace SauceDemo.BusinessLayer.PageObjects
{
    public class DashboardPage : BasePage
    {
        private static readonly By DashboardTitle = By.ClassName("app_logo");

        public DashboardPage() : base() 
        { 
        }

        public string GetDashboardTitle()
        {
            return WaitForElement(DashboardTitle).Text;
        }
    }
}
