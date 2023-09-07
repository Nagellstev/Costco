Feature: Localization

As a customer I want to order to any supported country and use any supported language

@Localization
Scenario: Change country and language
	Given I am on the main page
	When I choose the 'Canada' country
	And I choose the 'Français' language
	Then URL should be 'https://www.costco.ca/' and country should be 'CA' and language should be 'FR'
