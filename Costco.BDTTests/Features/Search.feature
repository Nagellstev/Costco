Feature: Search

In order to find goods
As a user 
I need to search and filter results

@Search
Scenario: SearchExistingItem
	Given I am on the main page
	When I input name of existing item to the search field
	Then I should see header containing name of existing item which was inputted on the previous step

Scenario: SearchExistingItemAndSortByParameters
	Given I am on the main page
	When I input name of existing item to the search field
	And I get total quantity of found goods
	And I filter search results by price
	And I get total quantity of filtered goods
	Then Total quantity of found goods sould be greater then total quantity of filtered goods

Scenario: SearchSenselessLine
	Given I am on the main page
	When I input senseless line to the search field
	Then I should see header containing "we were not able to find a match"

