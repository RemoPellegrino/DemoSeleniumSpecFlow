Feature: ProductsPage

A short summary of the feature

@tag1
Scenario Outline: Ordering
	Given the user is logged into the product page with username 'standard_user' and password 'secret_sauce'
	When the user choses to order by '<OrderingType>'
	Then the products are correctly ordered
	Examples: 
	| OrderingType        |
	| Price (low to high) |
	| Price (high to low) |
	| Name (Z to A)       |
	| Name (A to Z)       |
