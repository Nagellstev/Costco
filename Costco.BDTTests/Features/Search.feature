Feature: Search

In order to find goods
As a user 
I need to search and filter results

@Search
Scenario: Search Existing Item
	Given I am on the main page
	When I input 'vitamin' to the search field and submit my search query
	Then I should see header above found goods containing 'vitamin'

Scenario: Search Existing Item And Sort By Parameters
	Given I am on the main page
	When I input 'vitamin' to the search field and submit my search query
	And I get total quantity of found goods
	And I filter search results by price '$0 to $25'
	And I get total quantity of filtered goods
	Then Total quantity of found goods sould be greater then total quantity of filtered goods

Scenario: Search Senseless Line
	Given I am on the main page
	When I input 'qwerty' to the search field and submit my search query
	Then I should see message containing 'we were not able to find a match'

