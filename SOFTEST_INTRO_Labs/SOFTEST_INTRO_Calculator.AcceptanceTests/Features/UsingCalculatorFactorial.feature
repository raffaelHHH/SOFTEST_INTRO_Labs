@Factorial
Feature: UsingCalculatorFactorial
 In order to calculate factorials
 As a mathematician
 I want to use my calculator for this

 Scenario: Calculate factorial of 5
 Given I have a calculator
 When I have entered 5 into the calculator and press factorial
 Then the factorial result should be 120

 Scenario: Factorial of zero equals one
 Given I have a calculator
 When I have entered 0 into the calculator and press factorial
 Then the factorial result should be 1

 Scenario: Reject out-of-range factorial
 Given I have a calculator
 When I have entered 21 into the calculator and press factorial
 Then factorial should be rejected