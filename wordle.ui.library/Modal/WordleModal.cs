using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace wordle.ui.library.Modal
{
    public class WordleModal
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IWebDriver driver;
        private WebDriverWait wait;

        public WordleModal(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
        }

        public IWebElement WordleModalBase
        {
            get
            {
                return driver.FindElement(By.CssSelector(".modal"));
            }
        }

        public IWebElement ModalHeader
        {
            get
            {
                return WordleModalBase.FindElement(By.TagName("h1"));
            }
        }

        public string GetModalHeader()
        {
            return ModalHeader.Text;
        }

        public bool IsModalDisplayed()
        {
            try
            {
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".modal")));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool IsWinModalDisplayed()
        {
            // todo get localized text
            if (IsModalDisplayed() && GetModalHeader().Equals("You Win!"))
            {
                return true;
            }

            return false;
        }

        public bool IsLoseModalDisplayed()
        {
            // note that there is a typo in the app "loose" instead of "lose", normally this should fail as we should expect proper spelling in text, but ignoring for the purpose of this exercise
            // todo get localized text
            if (IsModalDisplayed() && GetModalHeader().Equals("Sorry, you loose!"))
            {
                return true;
            }

            return false;
        }
    }
}
