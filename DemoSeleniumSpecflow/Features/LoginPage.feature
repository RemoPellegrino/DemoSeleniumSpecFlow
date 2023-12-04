Feature: LoginPage

A short summary of the feature

Scenario: Logging in with valid credentials
	Given the user is on the login page
	When the user tries to log into the page with username 'standard_user' and password 'secret_sauce'
	Then the user receives no errors
	And the user arrives in the products page
	
Scenario Outline: Logging in with invalid credentials
	Given the user is on the login page
	When the user tries to log into the page with username '<Username>' and password '<Password>'
	Then the user receives the error '<Expectederror>'
	Examples: 
	| Username      | Password | Expectederror                                                             |
	|               | abc      | Epic sadface: Username is required                                        |
	| abc           |          | Epic sadface: Password is required                                        |
	| standard_user | fubar    | Epic sadface: Username and password do not match any user in this service |