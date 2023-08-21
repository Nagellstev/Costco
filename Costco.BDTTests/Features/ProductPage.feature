Feature: ProductPage

A short summary of the feature

@ProductPage
Scenario: [Order 0 items]
	Given I opened the product page https://www.costco.com/kirkland-signature-ladies'-slub-tee%2c-2-pack.product.100670508.html
	And I want to order 0 items
	When I enter the desired amount to the product amount field
	And I press add to card button
	Then Error Quantity must be 1 or more to add to cart is displayed below the input field

Scenario: [Order more limited items than allowed]
	Given I opened the product page https://www.costco.com/macbook-air-13.3-inch---apple-m1-chip-8-core-cpu%2c-7-core-gpu---8gb-memory---256gb-ssd-space-gray.product.100688258.html
	And I see the maximum number of limited items I can order
	When I add 1 more to the desired amount
	And I enter the desired amount to the product amount field
	And I press add to card button
	And I press add to card button
	Then Error Item ... has a maximum order quantity of ... is displayed below the input field

Scenario: [Order 1000 items]
	Given I opened the product page https://www.costco.com/.product.6262016.html
	And I want to order 999 items
	When I enter the desired amount to the product amount field
	And I press plus stepper
	And I press add to card button
	Then Error Please enter no more than 3 characters is displayed in the input field
