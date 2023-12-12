using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSeleniumSpecflow.Pages
{
    internal class ProductPage
        : PageObject
    {
        #region ElementDefinitions
        private IWebElement ProductSortContainer => driver.FindElement(By.CssSelector("select.product_sort_container"));
        #endregion
        public ProductPage(IWebDriver driver) : base(driver)
        {
        }

        protected override void PageLoadStrategy()
        {
            _ = ProductSortContainer;
        }

        /// <summary>
        /// Sets the ordering for the products page
        /// </summary>
        /// <param name="ordering">Option name of the ordeering</param>
        public void SetOrdering(string ordering)
        {
            ProductSortContainer.Click();

            ProductSortContainer
                .FindElements(By.CssSelector("option"))
                .Single(e => string.Equals(ordering, e.Text, StringComparison.CurrentCultureIgnoreCase))
                .Click();
        }
        /// <summary>
        /// Gets all the items in order of display
        /// </summary>
        /// <returns>A tuple with a name and a price of the item</returns>
        public IEnumerable<(string Name, double Price)> GetItems()
        {
            return driver
                .FindElements(By.CssSelector(".inventory_item"))
                .Select(e =>
                {
                    var name = e.FindElement(By.CssSelector(".inventory_item_label>a>div")).Text;
                    var price = double.Parse(e.FindElement(By.CssSelector(".inventory_item_price")).Text.Replace("$",""));
                    return (name, price);
                });
        }

        public void AddProductToBasket(string name)
        {
            driver
                .FindElements(By.CssSelector("#inventory_container .inventory_item"))
                .First(iWe => iWe.FindElement(By.CssSelector(".inventory_item_name ")).Text == name)
                .FindElement(By.CssSelector("button"))
                .Click();

        }
    }
}
