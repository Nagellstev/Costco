Feature: Zaqaria

In order to find tires in Canada
As a user 
I need to change region to Canada, search tires and filter results

@Zaqaria
Scenario: Search Tires
	#Given I am on the main page
	#When I change region to 'Ca'
	#Steps above depends on Vasilii's test
	Given I opened the product page https://www.costco.ca/
	When I press button Tires
	And I press button Search by size
	And I press button Accept all cookies
	And I choose '215' in Width menu
	And I choose '60' in Aspect menu
	And I choose '17' in Rim menu
	And I input 'M6B 3B1' to postal code line
	And I press button Find tires
	Then I should see window with selection of tire center