using BoDi;
using TechTalk.SpecFlow;
using TestAutomation.Drivers;

namespace TestAutomation.Hooks
{
    [Binding]
    public class TestHooks
    {
        private readonly IObjectContainer _objectContainer;
        private static BrowserDriverUtils _browserDriver;
        private const string HomepageUrl = "https://development-9-prototype.campspot.com/";

        public TestHooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenarioSetup()
        {
            _browserDriver = new BrowserDriverUtils();
            _objectContainer.RegisterInstanceAs(_browserDriver);

            if (_browserDriver.Driver.Url != HomepageUrl)
            {
                _browserDriver.Driver.Url = HomepageUrl;
            }
        }

        [AfterScenario]
        public void AfterScenarioTearDown()
        {
            _browserDriver?.Dispose();
        }
    }
}
