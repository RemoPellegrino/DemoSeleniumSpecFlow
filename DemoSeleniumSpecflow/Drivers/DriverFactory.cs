using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSeleniumSpecflow.Drivers
{
    internal static class DriverFactory
    {
        internal static IWebDriver CreateChromeDriver()
        {
            return new ChromeDriver();
        }
    }
}
