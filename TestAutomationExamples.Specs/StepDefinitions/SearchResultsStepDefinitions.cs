using System;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestAutomation.PageObjects;

namespace TestAutomation.StepDefinitions
{
    [Binding]
    public sealed class SearchResultsStepDefinitions
    {
        private readonly SearchResultsPageObject _searchResultsPageObject;

        public SearchResultsStepDefinitions(SearchResultsPageObject searchResultsPageObject)
        {
            _searchResultsPageObject = searchResultsPageObject ?? throw new ArgumentNullException(nameof(searchResultsPageObject));
        }

        [Then("the correct search results are displayed on the page")]
        public void CorrectSearchResultsAreDisplayedOnThePage(Table searchResultsTable)
        {
            
            var searchResults = _searchResultsPageObject.GetSearchResults();
            foreach (var searchResult in searchResultsTable.Rows)
            {
                Assert.True(searchResults.Any(results => results.Text.Contains(searchResult[0])), $"{searchResult[0]} was not found in the list of search results.");
            }
        }

        [Then("the search results page is displayed")]
        public void SearchResultsPageIsDisplayed()
        {
            var searchResultsPageIsDisplayed = _searchResultsPageObject.SearchResultsPageIsDisplayed();
            Assert.True(searchResultsPageIsDisplayed, "The search results page was not displayed");
        }
    }
}
