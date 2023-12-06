using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using TestAutomation.Drivers;

namespace TestAutomation.PageObjects
{
    public class SearchResultsPageObject : CommonPageObject
    {
        private readonly BrowserDriverUtils _webDriver;

        public SearchResultsPageObject(BrowserDriverUtils webDriver) : base(webDriver)
        {
            _webDriver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
        }

        private IWebElement SearchResultsPage(int timeout) => _webDriver.WaitForElement(By.ClassName("app-search-results-page"), timeout);
        private IWebElement SearchResults => _webDriver.WaitForElement(By.CssSelector("search-results-list.app-search-results-list"));
        private IWebElement ResultsSearchButton => _webDriver.WaitForElement(By.CssSelector("search-form-submit-button.app-search-button"));

        /// <summary>
        /// Returns search results 
        /// </summary>
        /// <returns></returns>
        public ReadOnlyCollection<IWebElement> GetSearchResults()
        {
            Console.WriteLine("Getting search results");
            return _webDriver.WaitForElements(By.CssSelector("search-results-list.app-search-results-list"));
        }

        /// <summary>
        /// Validates whether the search results page is displayed
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns>true if displayed or false if not displayed</returns>
        public bool SearchResultsPageIsDisplayed(int timeout = 30000)
        {
            Console.WriteLine("Determining whether the search results page is displayed");
            return SearchResultsPage(timeout).Displayed;
        }
    }
}
