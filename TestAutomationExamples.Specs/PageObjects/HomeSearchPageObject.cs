using System;
using OpenQA.Selenium;
using TestAutomation.Drivers;

namespace TestAutomation.PageObjects
{
    public class HomeSearchPageObject : CommonPageObject
    {
        private readonly BrowserDriverUtils _webDriver;
        public HomeSearchPageObject(BrowserDriverUtils webDriver): base(webDriver)
        {
            _webDriver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
        }

        private IWebElement HomeSearchPage(int timeout) => _webDriver.WaitForElement(By.ClassName("home"), timeout);
        private IWebElement HomeSearchButton => _webDriver.WaitForElement(By.CssSelector("button.home-hero-search-form-submit-button.app-search-button"));

        private IWebElement LocationSearchResults => _webDriver.WaitForElement(By.CssSelector("ul.location-search-results.app-location-search-results"));

        /// <summary>
        /// Executes search on the home page
        /// </summary>
        public void ClickSearchButton()
        {
            Console.WriteLine("Clicking the Search button.");
            HomeSearchButton.Click();
        }

        /// <summary>
        /// Validates whether the home search page is displayed
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns>true if displayed or false if not displayed</returns>
        public bool HomeSearchPageIsDisplayed(int timeout = 30000)
        {
            Console.WriteLine("Determining whether the homepage is displayed");
            return HomeSearchPage(timeout).Displayed;
        }
    }
}
