using NUnit.Framework;
using Reqnroll;
using SOFTEST_INTRO_Calculator.AcceptanceTests.Support;

namespace SOFTEST_INTRO_Calculator.AcceptanceTests.StepDefinitions;

[Binding]
public sealed class UsingCalculatorBasicReliabilitySteps
{
    private readonly CalculatorContext _context;

    public UsingCalculatorBasicReliabilitySteps(CalculatorContext context)
        => _context = context;

    [When("I have entered {double} and {double} and {double} into the calculator and press current failure intensity")]
    public void WhenIHaveEnteredAndPressCurrentFailureIntensity(double lambda0, double nu0, double tau)
    {
        _context.Result = _context.Calculator.CurrentFailureIntensity(lambda0, nu0, tau);
    }

    [When("I have entered {double} and {double} and {double} into the calculator and press expected cumulative failures")]
    public void WhenIHaveEnteredAndPressExpectedCumulativeFailures(double lambda0, double nu0, double tau)
    {
        _context.Result = _context.Calculator.ExpectedCumulativeFailures(lambda0, nu0, tau);
    }

    // The Basic Musa outputs are irrational (Math.Exp) and quoted in Gherkin rounded to 2 dp,
    // so they need a coarser tolerance than the exact-arithmetic "the result should be {double}" step.
    [Then("the result should be approximately {double}")]
    public void ThenTheResultShouldBeApproximately(double expected)
    {
        Assert.That(_context.Result, Is.EqualTo(expected).Within(0.005));
    }
}
