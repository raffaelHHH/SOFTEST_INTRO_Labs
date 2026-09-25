@Availability
Feature: UsingCalculatorAvailability
 In order to calculate MTBF and Availability
 As someone who struggles with maths
 I want to be able to use my calculator to do this

 Scenario: Calculating MTBF
 Given I have a calculator
 When I have entered 1000 and 5 into the calculator and press MTBF
 Then the result should be 200

 Scenario: Calculating Availability
 Given I have a calculator
 When I have entered 200 and 50 into the calculator and press Availability
 Then the result should be 0.8

 Scenario: Calculating Availability from named values
 Given I have a calculator
 And the reliability values are
 | MTBF | MTTR |
 | 90 | 10 |
 When I calculate Availability from these values
 Then the result should be 0.9