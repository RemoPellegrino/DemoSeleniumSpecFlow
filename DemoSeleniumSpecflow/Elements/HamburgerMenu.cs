using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSeleniumSpecflow.Elements
{
    internal class HamburgerMenu
    {
        private readonly IWebElement parent;
        public HamburgerMenu(IWebDriver driver, By selector)
        {
            parent = driver.FindElement(selector);
        }

        public bool IsOpen()
        {
            throw new NotImplementedException();
        }
        public void ToggleOpen()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<string> GetLinks() 
        { 
            throw new NotImplementedException(); 
        }
        public void ClickLink(string link)
        {
            throw new NotSupportedException();
        }
    }
}
