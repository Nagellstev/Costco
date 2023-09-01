Feature: Login

In order to access my account
As a user 
I need to login

@Login
Scenario: Successful login
	Given I am on the main page
	When I click the sign in/register button
	And I enter 'tarasenko_vlad@inbox.ru' in username field
	And I enter '145698Awd$' in password field
	And I click the sign in button
	Then I should be redirected to the main page

Scenario: Failed login with invalid credentials
	Given I am on the main page
	When I click the sign in/register button
	And I enter 'tarasenko_glad@inbox.ru' in username field
	And I enter '14569887' in password field
	And I click the sign in button
	Then I should see 'The email address and/or password you entered are invalid' invalid credentials error message

Scenario: Failed login with empty password
	Given I am on the main page
	When I click the sign in/register button
	And I enter 'tarasenko_vlad@inbox.ru' in username field
	And I enter '' in password field
	And I click the sign in button
	Then I sould see 'Password is required' error message