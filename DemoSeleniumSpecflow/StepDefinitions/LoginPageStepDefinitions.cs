using DemoSeleniumSpecflow.Drivers;
using DemoSeleniumSpecflow.Pages;
using OpenQA.Selenium;

namespace DemoSeleniumSpecflow.StepDefinitions
{
    [Binding]
    public class LoginPageStepDefinitions
    {
        private IWebDriver? driver = null;
        private string? loginErrors = null;
        [Given(@"the user is on the login page")]
        public void GivenTheUserIsOnTheLoginPage()
        {
            driver!.Url = "https://www.saucedemo.com/";
        }

        [When(@"the user tries to log into the page with username '([^']*)' and password '([^']*)'")]
        public void WhenTheUserTriesToLogIntoThePageWithUsernameAndPassword(string username, string password)
        {
            var page = new LoginPage(driver!);
            loginErrors = page.Login(username, password);
        }

        [Then(@"the user receives no errors")]
        public void ThenTheUserReceivesNoErrors()
        {
            loginErrors.Should().BeNull("No errors are expected");
        }

        [Then(@"the user receives the error '([^']*)'")]
        public void ThenTheUserReceivesTheError(string errorMessage)
        {
            loginErrors.Should().Be(errorMessage);
        }


        [Then(@"the user arrives in the products page")]
        public void ThenTheUserArrivesInTheProductsPage()
        {
            var action = () =>
            {
                _ = new ProductPage(driver!);
            };
            action.Should().NotThrow<Exception>();
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

        [Given(@"I am logged in")]
        public void GivenIAmLoggedIn()
        {
            driver!.Url = "https://www.saucedemo.com/";
            WhenTheUserTriesToLogIntoThePageWithUsernameAndPassword("standard_user", "secret_sauce");
        }

        [When(@"I search for a '([^']*)'")]
        public void WhenISearchForA(string p0)
        {
            
        }

        [Then(@"I can validate its info")]
        public void ThenICanValidateItsInfo(Table table)
        {
            throw new PendingStepException();
        }

        [Then(@"I can add it to my cart")]
        public void ThenICanAddItToMyCart()
        {
            throw new PendingStepException();
        }

        [Given(@"I add a few products to my cart")]
        public void GivenIAddAFewProductsToMyCart(Table table)
        {
            var productPage = new ProductPage(driver!);
            foreach(var row in table.Rows)
            {
                productPage.AddProductToBasket(row["Item"]);
            }
        }

        [Then(@"i can validate my product counter")]
        public void ThenICanValidateMyProductCounter()
        {
            throw new PendingStepException();
        }

    }
}
