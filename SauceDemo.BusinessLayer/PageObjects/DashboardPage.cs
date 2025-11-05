using OpenQA.Selenium;

namespace SauceDemo.BusinessLayer.PageObjects
{
    /// <summary>
    /// Represents the dashboard page and provides methods to interact with its elements.
    /// </summary>
    public class DashboardPage : BasePage
    {
        private static readonly By DashboardTitle = By.ClassName("app_logo");

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardPage"/> class.
        /// </summary>
        public DashboardPage() : base() 
        { 
        }

        /// <summary>
        /// Gets the dashboard title text.
        /// </summary>
        /// <returns>The dashboard title as a string.</returns>
        public string GetDashboardTitle()
        {
            return WaitForElement(DashboardTitle).Text;
        }
    }
}
