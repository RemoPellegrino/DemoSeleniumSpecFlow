using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSeleniumSpecflow.Pages
{
    internal class LoginPage 
        : PageObject
    {
        #region ElementDefinitions
        private IWebElement UsernameInput => driver.FindElement(By.CssSelector("input#user-name"));
        private IWebElement PasswordInput => driver.FindElement(By.CssSelector("input#password"));
        private IWebElement LoginButton => driver.FindElement(By.CssSelector("input#login-button"));
        private IWebElement ErrorField => driver.FindElement(By.CssSelector(".error-message-container>h3"));
        #endregion
        public LoginPage(IWebDriver driver)
            : base(driver)
        { }

        /// <summary>
        /// Try to login with a username and password
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>An error message if the login was unsuccessful</returns>
        internal string? Login(string username, string password)
        {
            UsernameInput.SendKeys(username);
            PasswordInput.SendKeys(password);
            LoginButton.Click();
            try
            {
                return ErrorField.Text;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }


        protected override void PageLoadStrategy()
        {
            _ = UsernameInput;
        }
    }
}
