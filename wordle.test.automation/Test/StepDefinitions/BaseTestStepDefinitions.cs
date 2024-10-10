using static wordle.test.automation.Common.Nomenclature;

namespace wordle.test.automation.Test.StepDefinitions
{
    [Binding]
    public class BaseTestStepDefinitions : TestBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BaseTestStepDefinitions()
        {

        }

        [BeforeScenario]
        public static void SetupTest()
        {
            if (String.IsNullOrEmpty(Wordle))
            {
                Driver.Navigate().GoToUrl(BaseUrl);
            }
            else
            {
                Driver.Navigate().GoToUrl(TestUrl);
            }
        }

        [AfterScenario]
        public static void Cleanup()
        {
            Driver?.Close();
            Driver?.Quit();
            Driver = null;
        }
    }
}
