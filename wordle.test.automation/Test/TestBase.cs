using OpenQA.Selenium;
using static wordle.test.automation.Common.Helper;
using static wordle.test.automation.Common.Nomenclature;

namespace wordle.test.automation.Test
{
    public class TestBase
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(type: System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static IWebDriver driver;

        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                {
                    driver = GetWebDriver(Browser);
                }

                return driver;
            }
            set
            {
                driver = value;
            }
        }

        public TestBase()
        {
            // todo
        }
    }
}
