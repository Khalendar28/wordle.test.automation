# wordle.test.automation

Test Plan Outline
------

- Verify correct phrase results in You Win dialog
- Verify incorrect phrase after 6 tries results in You Win dialog
- Verify accuracy of display of entered phrase and color coded tiles and keypad
- Verify you cannot submit a phrase with less than 5 letters
- Verify you cannot type/submit more than 5 letters
- Verify you can enter and delete letters and be able to submit if the phrase meets requirements
- Verify you cannot enter special characters or numbers
- Verify you cannot enter the same phrase more than once
- Verify strings
- Verify default url uses randomized wordle phrase
- Verify you can override wordle phrase with specified test url
- Security testing (

Sample Test Case for Verifying You Lose Dialog
------

- Open wordle app page with test string specifying the word to use
- Enter varying words except for the specified word, varying matches in letters
- Verify the rows/tiles display letters matching what was entered
- Verify the rows/tiles display the correct color coding (assumption is that duplicate letters that exceed the what is in the word will be colored as grey)
- Verify that the You Lose modal is displayed after entering 6 incorrect words

Sample Test Case for Verifying You Win Dialog
------

- Open wordle app page with test string specifying the word to use
- Enter a word that does not match the specified word
- Verify the rows/tiles display letters matching what was entered
- Verify the rows/tiles display the correct color coding (assumption is that duplicate letters that exceed the what is in the word will be colored as grey)
- Verify no win or lose modal is displayed
- Enter the specified word
- Verify that the you win modal is displayed
