Feature: SearchTires

In order to find tires in Canada
As a user 
I need to change region to Canada, search tires and filter results

@SearchTires
Scenario: Search Tires
	Given I am on the main page
	When I choose the 'Canada' country
	And I press button Tires
	And I press button Search by size
	And I press button Accept all cookies
	And I choose '285' in Width menu
	And I choose '30' in Aspect menu
	And I choose '19' in Rim menu
	And I input 'M6B 3B1' to postal code line
	And I press button Find tires
	Then I should see window with selection of tire center