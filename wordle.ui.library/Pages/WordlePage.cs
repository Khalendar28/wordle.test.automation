using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace wordle.ui.library.Pages
{
    public class WordlePage
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private IWebDriver driver;
        private WebDriverWait wait;

        public WordlePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("root")));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("keypad")));
        }

        public IWebElement WordleAppPageBase
        {
            get
            {
                return driver.FindElement(By.CssSelector("#root > div"));
            }
        }

        public IWebElement RowTable
        {
            get
            {
                return WordleAppPageBase.FindElement(By.CssSelector("div div"));
            }
        }

        public IWebElement KeyPad
        {
            get
            {
                return WordleAppPageBase.FindElement(By.ClassName("keypad"));
            }
        }

        public List<IWebElement> EntryRows
        {
            get
            {
                return RowTable.FindElements(By.CssSelector(".row")).ToList<IWebElement>();
            }
        }

        public IWebElement WordleModalBase
        {
            get
            {
                return WordleAppPageBase.FindElement(By.CssSelector(".modal"));
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

        public List<TileInfo> GetTileDataByRow(int row)
        {
            List<TileInfo> tileList = new List<TileInfo>();
            List<IWebElement> tiles = EntryRows[row].FindElements(By.CssSelector("div")).ToList<IWebElement>();

            foreach (var tile in tiles)
            {
                TileInfo tileInfo = new TileInfo(tile.Text, tile.GetAttribute("class"));
                tileList.Add(tileInfo);
            }

            return tileList;
        }

        public Dictionary<string, string> GetKeyPadData()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            List<IWebElement> keypad = KeyPad.FindElements(By.CssSelector("div")).ToList<IWebElement>();

            foreach(var key in keypad)
            {
                dict.Add(key.Text.ToLower(), key.GetAttribute("class"));
            }

            return dict;
        }
    }

    public class TileInfo
    {
        private string letter;
        private string color;

        public string Letter
        {
            get
            {
                return letter;
            }
        }

        public string Color
        {
            get
            {
                return color;
            }
        }

        public TileInfo(string letter, string color)
        {
            this.letter = letter.ToLower();
            this.color = color.ToLower();
        }
    }
}
