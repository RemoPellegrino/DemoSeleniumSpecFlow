using OpenQA.Selenium;

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
            return parent.FindElement(By.CssSelector(".bm-menu-wrap")).GetAttribute("aria-hidden") is not "true";
        }
        public void ToggleOpen()
        {
            if(IsOpen())
            {
                parent.FindElement(By.CssSelector(".bm-cross-button")).Click();
            }
            else
            {
                parent.FindElement(By.CssSelector(".bm-burger-button")).Click();
            }
        }
        public IEnumerable<string> GetItems() 
        {
            return parent                               // Starting from parent
                .FindElements(By.CssSelector("nav>a"))  // Find the elements which contain the navigation items
                .Select(x => x.Text);                   // Select their text-value
        }
        public void ClickLink(string link)
        {
            parent
                .FindElements(By.CssSelector("nav>a"))
                .Single(x => x.Text == link)
                .Click();
        }
    }
}
