using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestAutomation.Drivers
{
    /// <summary>
    /// Manages browser instance
    /// </summary>
    public class BrowserDriverUtils
    {
        private bool _isDisposed;
        public const int DefaultTimeout = 30000;

        public BrowserDriverUtils()
        {
            CreateChromeWebDriver();
        }
        public IWebDriver Driver { get; private set; }

        /// <summary>
        /// Creates an instance of the Chrome WebDriver
        /// </summary>
        /// <returns><see cref="IWebElement"/></returns>
        private IWebDriver CreateChromeWebDriver()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();

            var chromeOptions = new ChromeOptions();

            Driver = new ChromeDriver(chromeDriverService, chromeOptions);
            Driver.Manage().Window.Maximize();

            return Driver;
        }

        /// <summary>
        /// Disposes the Selenium web driver (closes the browser)
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            Driver.Quit();
            _isDisposed = true;
        }

        /// <summary>
        /// Searches for an element up to the max time specified
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="timeout"></param>
        /// <returns><see cref="IWebElement"/></returns>
        public IWebElement WaitForElement(By locator, int timeout = DefaultTimeout)
        {
            IWebElement element = null;
            var wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(timeout))
            {
                PollingInterval = TimeSpan.FromMilliseconds(500),
                Message = "Element was not found."
            };
            wait.IgnoreExceptionTypes(typeof(WebDriverException));

            wait.Until(d =>
            {
                element = d.FindElement(locator);
                return element != null;
            });

            return element;
        }

        /// <summary>
        /// Searches for elements up to the max time specified
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="timeout"></param>
        /// <returns><see cref="IWebElement"/></returns>
        public ReadOnlyCollection<IWebElement> WaitForElements(By locator, int timeout = DefaultTimeout)
        {
            ReadOnlyCollection<IWebElement> element = null;
            var wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(timeout))
            {
                PollingInterval = TimeSpan.FromMilliseconds(500),
                Message = "Element was not found."
            };
            wait.IgnoreExceptionTypes(typeof(WebDriverException));

            wait.Until(d =>
            {
                element = d.FindElements(locator);
                return element != null;
            });

            return element;
        }
    }
}