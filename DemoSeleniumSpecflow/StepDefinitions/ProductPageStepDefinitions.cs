using DemoSeleniumSpecflow.Drivers;
using DemoSeleniumSpecflow.Pages;
using OpenQA.Selenium;

namespace DemoSeleniumSpecflow.StepDefinitions
{
    [Binding]
    public class ProductPageStepDefinitions
    {
        private IWebDriver? driver = null;
        private ProductPage? productPage = null;
        private string? orderingType = null;
        [Given(@"the user is logged into the product page with username '([^']*)' and password '([^']*)'")]
        public void GivenTheUserIsLoggedIntoTheProductPageWithUsernameAndPassword(string username, string password)
        {
            driver!.Url = "https://www.saucedemo.com/";
            var loginPage = new LoginPage(driver!);
            loginPage.Login(username, password);
            productPage = new ProductPage(driver!);
        }

        [When(@"the user choses to order by '([^']*)'")]
        public void WhenTheUserChosesToOrderBy(string orderingType)
        {
            this.orderingType = orderingType;
            productPage!.SetOrdering(orderingType);
        }

        [Then(@"the products are correctly ordered")]
        public void ThenTheProductsAreCorrectlyOrdered()
        {
            var listFromPage = productPage!.GetItems().ToList();

            var orderedList = productPage!.GetItems().ToList();
            switch (orderingType)
            {
                case "Name (A to Z)":
                    orderedList = orderedList.OrderBy(x => x.Name).ToList();
                    break;
                case "Name (Z to A)":
                    orderedList = orderedList.OrderByDescending(x => x.Name).ToList();
                    break;
                case "Price (low to high)":
                    orderedList = orderedList.OrderBy(x => x.Price).ToList();
                    break;
                case "Price (high to low)":
                    orderedList = orderedList.OrderByDescending(x => x.Price).ToList();
                    break;
                default: throw new ArgumentException();
            }

            listFromPage.Should().BeEquivalentTo(orderedList, options => options.WithStrictOrdering());
        }
        [AfterScenario]
        public void CleanUpDriver()
        {
            driver?.Dispose();
        }
        [BeforeScenario]
        public void SetUpDriver()
        {
            driver = DriverFactory.CreateChromeDriver();
        }

    }
}
