using OpenQA.Selenium;

namespace DemoSeleniumSpecflow.Pages
{
    internal abstract class PageObject
    {
        protected readonly IWebDriver driver;
        /// <summary>
        /// Initializes the PageObject with a given driver
        /// </summary>
        /// <param name="driver">The driver to use the PageObject on</param>
        public PageObject(IWebDriver driver)
        {
            this.driver = driver;
            PageLoadStrategy();
        }
        /// <summary>
        /// Strategy to determine if the page has been loaded correctly
        /// </summary>
        protected abstract void PageLoadStrategy();
    }
}
