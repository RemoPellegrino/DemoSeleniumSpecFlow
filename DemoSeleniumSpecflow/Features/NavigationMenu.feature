Feature: Navigation Menu

A short summary of the feature

Scenario: State of the Navigation Menu
	Given the user is logged into the product page with username 'standard_user' and password 'secret_sauce'
	Then the Navigation menu is closed

Scenario: Opening the menu
	Given the user is logged into the product page with username 'standard_user' and password 'secret_sauce'
	When the user clicks on the menu button
	Then the navigation menu is opened

Scenario: Content of the menu
	Given the user is logged into the product page with username 'standard_user' and password 'secret_sauce'
	When the user clicks on the menu button
	Then the following navigation options are available
	| NavigationItems |
	| All Items       |
	| About           |
	| Logout          |
	| Reset App State |