using wordle.ui.library.Modal;
using wordle.ui.library.Pages;
using static wordle.test.automation.Common.Helper;
using static wordle.test.automation.Common.Nomenclature;

namespace wordle.test.automation.Test.StepDefinitions
{
    [Binding]
    public class WordleStepDefinitions : TestBase
    {
        private string wordlePhrase = Wordle;

        [Given("I am on the Wordle Page")]
        public void GivenIamOnTheWordlePage()
        {
            WordlePage wordlePage = new WordlePage(Driver);
        }

        [When("I open the wordle page with phrase (.*)")]
        public void OpenWordlePageWithPhrase(string phrase)
        {
            Assert.IsTrue(phrase.Length == 5, $"Specified test phrase is less than 5 letters");
            Driver.Navigate().GoToUrl(BaseUrl + $"/?test={phrase}");
            wordlePhrase = phrase;
            // just using constructor here to wait for page
            WordlePage wordlePage = new WordlePage(Driver);
        }

        [When("I enter the phrase (.*)")]
        public void EnterPhrase(string phrase)
        {
            WordlePage wordlePage = new WordlePage(Driver);
            SendKeys(Driver, phrase);
            SendEnterKey(Driver);
            Thread.Sleep(1000);
        }

        [When("I enter the phrases (.*)")]
        public void EnterPhrases(string phrases)
        {
            List<string> phraseList = phrases.Split(", ").ToList();

            WordlePage wordlePage = new WordlePage(Driver);

            foreach (var phrase in phraseList)
            {
                SendKeys(Driver, phrase);
                SendEnterKey(Driver);
                Thread.Sleep(1000);
            }
        }

        [Then("The you win modal is displayed")]
        public void WinModalIsDisplayed()
        {
            WordleModal wordleModal = new WordleModal(Driver);
            Assert.IsTrue(wordleModal.IsWinModalDisplayed(), $"You win modal not found.");
        }

        [Then("The you win modal is not displayed")]
        public void WinModalIsNotDisplayed()
        {
            WordleModal wordleModal = new WordleModal(Driver);
            Assert.IsFalse(wordleModal.IsWinModalDisplayed(), $"You win modal was found but not expected.");
        }

        [Then("The you lose modal is displayed")]
        public void LoseModalIsDisplayed()
        {
            WordleModal wordleModal = new WordleModal(Driver);
            Assert.IsTrue(wordleModal.IsLoseModalDisplayed(), $"You lose modal not found.");
        }

        [Then("The you lose modal is not displayed")]
        public void LoseModalIsNotDisplayed()
        {
            WordleModal wordleModal = new WordleModal(Driver);
            Assert.IsFalse(wordleModal.IsLoseModalDisplayed(), $"You lose modal was found but not expected.");
        }

        [Then("no win/lose modal is displayed")]
        public void NoModalIsDisplayed()
        {
            WordleModal wordleModal = new WordleModal(Driver);
            Assert.IsFalse(wordleModal.IsModalDisplayed(), $"A win/lose modal was displayed.");
        }

        [Then("Row (.*) tiles should display the colors (.*) for phrase (.*)")]
        public void RowTilesShouldDisplayColors(int row, string tileColors, string phrase)
        {
            List<string> colors = tileColors.Split(", ").ToList();
            WordlePage wordlePage = new WordlePage(Driver);
            var tileList = wordlePage.GetTileDataByRow(row);

            int index = 0;

            foreach(var tile in tileList)
            {
                // verify what is displayed matches what we entered
                Assert.AreEqual(expected: phrase[index].ToString().ToLower(), actual: tile.Letter);
                // verify expected colors match displayed colors
                Assert.AreEqual(expected: colors[index].ToLower(), actual: tile.Color);

                // verify color codes are accurate to the actual wordle phrase
                int numOccurranceActualPhrase = GetNumOccurranceOfChar(wordlePhrase.ToLower(), char.Parse(tile.Letter));
                int numOccurranceEnteredPhrase = GetNumOccurranceOfChar(phrase.ToLower(), char.Parse(tile.Letter));

                switch (tile.Color)
                {
                    case "green":
                        Assert.AreEqual(expected: wordlePhrase[index].ToString().ToLower(), actual: tile.Letter);
                        break;
                    case "blue":
                        Assert.IsTrue(wordlePhrase.ToLower().Contains(tile.Letter), $"Tile marked blue for '{tile.Letter} but was not found in the wordle {wordlePhrase}");
                        break;
                    case "grey":
                        Assert.IsFalse(wordlePhrase.ToLower().Contains(tile.Letter) && numOccurranceEnteredPhrase <= numOccurranceActualPhrase, $"Tile marked grey for '{tile.Letter} but was found in wordle {wordlePhrase}");
                        break;
                }

                index++;
            }
        }        
    }
}
