Feature: Locations

In order to get the delivery
As a customer 
I need to set warehouse and delivery location

@Locations
Scenario: Set warehouse as My Warehouse
	Given I go to the page 'warehouse-locations'
	When I enter 'Louisville' in warehouse search field
	And I click Find a Warehouse
	And I click Set as My Warehouse
	Then My Warehouse should be 'Louisville'

Scenario: View Store Details
	Given I go to the page 'warehouse-locations'
	When I enter 'Louisville' in warehouse search field
	And I click Find a Warehouse
	And I remember name and address on locations page
	And I click Store Details
	And I remember name and address on warehouse page
	Then Name and address should match on warehouse page and on locations page

Scenario: Change Delivery Location
	Given I go to the page 'warehouse-locations'
	When I click Delivery Location
	And I enter '12345' in the ZIP code field
	And I click Change Delivery Location
	Then Delivery Location should be '12345'