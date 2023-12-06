using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using TestAutomation.Drivers;

namespace TestAutomation.PageObjects
{
    public class CommonPageObject
    {
        private readonly BrowserDriverUtils _webDriver;
        public CommonPageObject(BrowserDriverUtils webDriver)
        {
            _webDriver = webDriver ?? throw new ArgumentNullException(nameof(webDriver));
        }

        private IWebElement HeaderLogo => _webDriver.WaitForElement(By.ClassName("header-logo"));
        private IWebElement LocationField => _webDriver.WaitForElement(By.Name("search-location"));
        private IWebElement CheckInDateButton => _webDriver.WaitForElement(By.CssSelector("aggredator-field-input app-aggredator-checkin-date.mod-selected"));
        private IWebElement CheckOutDateButton => _webDriver.WaitForElement(By.CssSelector("aggredator-field-input app-aggredator-checkout-date.mod-selected"));
        private IWebElement SelectDateButton(string month, string day, string year) => _webDriver.WaitForElement(By.XPath("")); //TODO: need to find date locator to select the correct date
        private IWebElement CalendarModal => _webDriver.WaitForElement(By.CssSelector("aggredator-dropdown-calendar.app-dropdown-calendar"));
        private IWebElement CalendarPreviousMonthButton => _webDriver.WaitForElement(By.CssSelector("aggredator-dropdown-month-control mod-prev.app-aggredator-navigation-previous-month"));
        private IWebElement CalendarNextMonthButton => _webDriver.WaitForElement(By.CssSelector("aggredator-dropdown-month-control mod-next.app-aggredator-navigation-next-month"));
        private IWebElement GuestsDropdownField => _webDriver.WaitForElement(By.ClassName("guests-picker-input"));
        private IWebElement GuestsDecreaseButton => _webDriver.WaitForElement(By.CssSelector("guests-picker-menu-category-controls-stepper.mod-decrease"));
        private IWebElement GuestsIncreaseButton => _webDriver.WaitForElement(By.CssSelector("guests-picker-menu-category-controls-stepper.mod-increase"));

        /// <summary>
        /// Navigates to the Campspot homepage
        /// </summary>
        public void NavigateToHome()
        {
            //Could alternatively navigate using the Url
            HeaderLogo.Click();
        }

        /// <summary>
        /// Enters the specified location into the Location field
        /// </summary>
        /// <param name="location">Location specified</param>
        public void EnterLocation(string location)
        {
            Console.WriteLine($"Entering location: {location}");
            LocationField.Clear();
            LocationField.SendKeys(location);
        }

        /// <summary>
        /// Gets list of location results populated by autocomplete on the search homepage
        /// </summary>
        /// <returns><see cref="IWebElement"/></returns>
        public ReadOnlyCollection<IWebElement> GetLocationSearchResults()
        {
            Console.WriteLine("Getting list of location results");
            return _webDriver.WaitForElements(By.CssSelector("ul.location-search-results.app-location-search-results"));
        }

        /// <summary>
        /// Selects the Check In date for the Dates field
        /// </summary>
        /// <param name="month">Month specified</param>
        /// <param name="day">Day specified</param>
        /// <param name="year">Year specified</param>
        public void SelectStartDate(string month, string day, string year)
        {
            Console.WriteLine($"Selecting start date: {month} {day}, {year}");
            //TODO: add logic to navigate through the calendar depending on what month and year are specified
            CheckInDateButton.Click();
            if(CalendarModal.Displayed)
                CheckInDateButton.Click();

            SelectDateButton(month, day, year);
        }

        /// <summary>
        /// Selects the Check Out date for the Dates field
        /// </summary>
        /// <param name="month">Month specified</param>
        /// <param name="day">Day specified</param>
        /// <param name="year">Year specified</param>
        public void SelectEndDate(string month, string day, string year)
        {
            Console.WriteLine($"Selecting end date: {month} {day}, {year}");
            //TODO: check out date should automatically be selected after selecting the start date
            //confirm that it is selected and select button if it isn't

            SelectDateButton(month, day, year);
        }

        /// <summary>
        /// Selects the number of specified guests
        /// </summary>
        /// <param name="guestType">Type of guest i.e. Adults, Children, Pets</param>
        /// <param name="numberOfGuests">Number of guests specified</param>
        public void SelectGuests(string guestType, string numberOfGuests)
        {
            Console.WriteLine($"Selecting {numberOfGuests} {guestType}");
            //TODO: add logic to decrease/increase guests based on the type and number of guests specified
            switch (guestType)
            {
                case "Adults":
                    break;
                case "Children":
                    break;
                case "Pets":
                    break;
            }
        }
    }
}
