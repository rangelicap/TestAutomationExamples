using System;
using TechTalk.SpecFlow;
using TestAutomation.PageObjects;

namespace TestAutomation.StepDefinitions
{
    [Binding]
    public sealed class HomeSearchStepDefinitions
    {
        private readonly HomeSearchPageObject _homeSearchPageObject;

        public HomeSearchStepDefinitions(HomeSearchPageObject homeSearchPageObject)
        {
            _homeSearchPageObject = homeSearchPageObject ?? throw new ArgumentNullException(nameof(homeSearchPageObject));
        }

        [Given("the search home page is displayed")]
        public void SearchHomePageIsDisplayed()
        {
            if (!_homeSearchPageObject.HomeSearchPageIsDisplayed(3000))
                _homeSearchPageObject.NavigateToHome();
        }

        [When("the user clicks Search on the home page")]
        public void UserClicksSearch()
        {
            _homeSearchPageObject.ClickSearchButton();
        }
    }
}
