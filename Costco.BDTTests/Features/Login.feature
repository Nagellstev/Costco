Feature: Login

In order to access my account
As a user 
I need to login

@Login
Scenario: Successful login
	Given I am on the main page
	When I click the sign in/register button
	And I enter credentials
	| Key      | Value      |
	| Username | tarasenko_vlad@inbox.ru |
	| Password | 145698Awd$   |
	And I click the sign in button
	Then I should be redirected to the main page

Scenario: Failed login with invalid credentials
	Given I am on the main page
	When I click the sign in/register button
	And I enter credentials
	| Key      | Value      |
	| Username | tarasenko_glad@inbox.ru |
	| Password | 12345678   |
	And I click the sign in button
	Then I should see 'The email address and/or password you entered are invalid' invalid credentials error message

Scenario: Failed login with empty password
	Given I am on the main page
	When I click the sign in/register button
	And I enter credentials
	| Key      | Value      |
	| Username | tarasenko_vlad@inbox.ru |
	| Password ||
	
	And I click the sign in button
	Then I sould see 'Password is required' error message