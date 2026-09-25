@BasicMusa
Feature: UsingCalculatorBasicReliability
 In order to calculate the Basic Musa model's failures and intensities
 As a Software Quality Metric enthusiast
 I want to use my calculator to do this

 Scenario: Current failure intensity at t=0
 Given I have a calculator
 When I have entered 0.5 and 100 and 0 into the calculator and press current failure intensity
 Then the result should be 0.5

 Scenario: Expected cumulative failures at t=100
 Given I have a calculator
 When I have entered 0.5 and 100 and 100 into the calculator and press expected cumulative failures
 Then the result should be approximately 39.35