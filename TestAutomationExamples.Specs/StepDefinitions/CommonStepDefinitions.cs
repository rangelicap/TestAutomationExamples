using System;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TestAutomation.PageObjects;

namespace TestAutomation.StepDefinitions
{
    [Binding]
    public sealed class CommonStepDefinitions
    {
        private readonly CommonPageObject _commonPageObject;

        public CommonStepDefinitions(CommonPageObject basePageObject)
        {
            _commonPageObject = basePageObject ?? throw new ArgumentNullException(nameof(basePageObject));
        }

        [When("the user enters the location (.*)")]
        public void UserEntersTheLocation(string location)
        {
            _commonPageObject.EnterLocation(location);
        }

        [Given("the reservation form is filled out")]
        [When("the user fills out the reservation form")]
        public void UserFillsOutTheReservationForm(Table reservationInfoTable)
        {
            foreach (var reservationInfo in reservationInfoTable.Rows)
            {
                if (!string.IsNullOrEmpty(reservationInfo["Location"]))
                    _commonPageObject.EnterLocation(reservationInfo["Location"]);

                if (!string.IsNullOrEmpty(reservationInfo["StartDate"]))
                {
                    var startDateArray = reservationInfo["StartDate"].Split(',');
                    _commonPageObject.SelectStartDate(startDateArray[0].Replace(" ", ""), startDateArray[1].Replace(" ", ""), startDateArray[2].Replace(" ", ""));
                }

                if (!string.IsNullOrEmpty(reservationInfo["EndDate"]))
                {
                    var endDateArray = reservationInfo["EndDate"].Split(',');
                    _commonPageObject.SelectEndDate(endDateArray[0].Replace(" ", ""), endDateArray[1].Replace(" ", ""), endDateArray[2].Replace(" ", ""));
                }

                if (!string.IsNullOrEmpty(reservationInfo["Guests"]))
                {
                    var guestsArray = reservationInfo["Guests"].Split(',');
                    _commonPageObject.SelectGuests(guestsArray[0], guestsArray[1]);
                }
            }
        }

        [Then(@"autocomplete populates the cities and state that match the search string entered")]
        public void ThenAutocompletePopulatesTheCitiesAndStateThatMatchTheSearchStringEntered(Table locationInfoTable)
        {
            var locationResults = _commonPageObject.GetLocationSearchResults();
            foreach (var locationResult in locationInfoTable.Rows)
            {
                Assert.True(locationResults.Any(results => results.Text.Contains(locationResult[0])), $"{locationResult[0]} was not found in the list of location results.");
            }
        }

    }
}
