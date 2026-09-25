@Addition
Feature: UsingCalculatorAddition
 In order to avoid mistakes
 As a calculator user
 I want to be told the sum of two numbers

 Scenario: Add two numbers
 Given I have a calculator
 When I have entered 50 and 70 into the calculator and press add
 Then the result should be 120

 Scenario Outline: Add various numbers
 Given I have a calculator
 When I have entered <value1> and <value2> into the calculator and press add
 Then the result should be <value3>

 Examples:
 | value1 | value2 | value3 |
 | 0 | 5 | 5 |
 | -3 | 8 | 5 |
 | 10 | 20 | 30 |