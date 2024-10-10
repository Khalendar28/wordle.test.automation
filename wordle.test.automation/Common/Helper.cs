using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using WebDriverManager.DriverConfigs.Impl;


namespace wordle.test.automation.Common
{
    public static class Helper
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static IWebDriver GetWebDriver(string requestedBrowser = "chrome")
        {
            IWebDriver driver;

            switch(requestedBrowser.ToLower())
            {
                case "chrome":
                default:
                    {
                        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver();
                        break;
                    }
            }

            return driver;
        }

        public static void SendKeys(IWebDriver driver, string keys)
        {
            new Actions(driver).SendKeys(keys).Perform();
        }

        public static void SendEnterKey(IWebDriver driver)
        {
            new Actions(driver).SendKeys(Keys.Enter).Perform();
        }

        public static void SendBackspaceKey(IWebDriver driver)
        {
            new Actions(driver).SendKeys(Keys.Backspace).Perform();
        }

        public static int GetNumOccurranceOfChar(string str, char c)
        {
            return str.Split(c).Length - 1;
        }
    }
}
