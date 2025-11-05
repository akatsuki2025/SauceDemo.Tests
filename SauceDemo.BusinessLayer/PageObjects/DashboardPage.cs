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
        private static readonly By DashboardTitle = By.ClassName("app_logo");

        public DashboardPage() : base() 
        { }

        public string GetDashboardTitle()
        {
            return WaitForElement(DashboardTitle).Text;
        }
    }
}
