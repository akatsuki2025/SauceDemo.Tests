using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo.TestLayer.StepDefinitions
{
    public abstract class BaseStepDefinitions
    {
        protected readonly string BaseUrl;

        protected BaseStepDefinitions()
        {
            BaseUrl = Environment.GetEnvironmentVariable("BASE_URL") ?? "https://www.saucedemo.com/";
        }
    }
}
