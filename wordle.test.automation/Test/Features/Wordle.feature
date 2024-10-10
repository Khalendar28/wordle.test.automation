Feature: Wordle

A short summary of the feature

@tag1
Scenario: Entering six incorrect phrases results in you lose dialog
	When I open the wordle page with phrase phase
	And I enter the phrases ghost, ihesa, qhnse, ahmsc, whmsy, lhhse
	Then Row 0 tiles should display the colors grey, green, grey, green, grey for phrase ghost
	And Row 1 tiles should display the colors grey, green, blue, green, blue for phrase ihesa
	And Row 2 tiles should display the colors grey, green, grey, green, green for phrase qhnse
	And Row 3 tiles should display the colors blue, green, grey, green, grey for phrase ahmsc
	And Row 4 tiles should display the colors grey, green, grey, green, grey for phrase whmsy
	And Row 5 tiles should display the colors grey, green, grey, green, green for phrase lhhse
	And The you lose modal is displayed

Scenario: Entering correct phrase results in you win dialog
	When I open the wordle page with phrase goose
	And I enter the phrase phone
	Then Row 0 tiles should display the colors grey, grey, green, grey, green for phrase phone
	But no win/lose modal is displayed
	When I enter the phrase goose
	Then Row 1 tiles should display the colors green, green, green, green, green for phrase goose
	And The you win modal is displayed
