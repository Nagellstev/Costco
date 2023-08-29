Feature: Product page shopping cart

As a customer I want to be able place a product to the cart so I can proceed to the checkout

@ProductPage

Rule: "Number of items in cart can be between 1 and 999"

Scenario: [Order 0 items]
	Given I go to the page 'kirkland-signature-ladies'-slub-tee%2c-2-pack.product.100670508.html'
	When I enter '0' to the product amount field
	And I press add to cart button
	Then Error 'Quantity must be 1 or more to add to cart' is displayed below the input field

Scenario: [Order 1000 items]
	Given I go to the page 'charmin-ultra-soft-bath-tissue%2c-2-ply%2c-205-sheets%2c-30-rolls.product.100847281.html'
	When I enter '999' to the product amount field
	And I press plus stepper
	And I press add to cart button
	Then Error 'Please enter no more than 3 characters' is displayed in the input field

Rule: "Special limited items can be added only in quantities not exceeding the amount designated in propotional text"

	Scenario: [Order more limited items than allowed]
	Given I go to the page 'macbook-air-13.3-inch---apple-m1-chip-8-core-cpu%2c-7-core-gpu---8gb-memory---256gb-ssd-space-gray.product.100688258.html'
	When I locate the promo text with number of limited items
	And I enter maximum number of limited items plus one to the product amount field
	And I press add to cart button
	Then Maximum order quantity error is displayed below the input field