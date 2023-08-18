Feature: Locations

In order to get the delivery
As a user 
I need to set warehouse and delivery location

@Locations
Scenario: Set warehouse as My Warehouse
	Given I am on the locations page
	When I enter warehouse name in warehouse search field
	And I click 'Find a Warehouse'
	And I click 'Set as My Warehouse'
	Then New My Warehouse should be set

Scenario: View Store Details
	Given I am on the locations page
	When I enter warehouse name in warehouse search field
	And I click 'Find a Warehouse'
	And I click 'Store Details'
	Then Name and address on 'Store Details' should be equal to name and address on search page

Scenario: Change Delivery Location
	Given I am on the locations page
	When I click the delivery location
	And I enter ZIP code in the ZIP code field
	And I click 'Change Delivery Location'
	Then New Delivery Location should be set 