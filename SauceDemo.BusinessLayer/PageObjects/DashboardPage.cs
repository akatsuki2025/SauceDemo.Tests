using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo.BusinessLayer.PageObjects
{
    public class DashboardPage : BasePage
    {
        public DashboardPage(IWebDriver driver) : base(driver) { }

        public string GetDashboardTitle()
        {
            // The dashboard title is in a div with class 'app_logo'
            return driver.FindElement(By.ClassName("app_logo")).Text;
        }

        public override bool IsAt()
        {
            // Check if the dashboard title is displayed
            return driver.FindElement(By.ClassName("app_logo")).Displayed;
        }
    }
}
