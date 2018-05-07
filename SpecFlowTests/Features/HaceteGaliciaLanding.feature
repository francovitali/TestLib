Feature: HaceteGaliciaLanding
	Take user data and sent to evaluator

@mytag
Scenario: Name should not accept numbers
    Given I navigate the landing
	When I write a number in the name field
	Then the field should be empty

Scenario: Name should accept letter chars
    Given I navigate the landing
	When I write letters in the name field
	Then the field should contain the letters

Scenario: Select female gender
    Given I navigate the landing
    When I choose the female gender
    Then the female gender should be checked
