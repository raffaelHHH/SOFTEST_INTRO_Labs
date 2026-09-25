using SOFTEST_INTRO_Calculator;
using NUnit.Framework;

namespace SOFTEST_INTRO_Calculator.UnitTests;

public class CalculatorTests
{
 private Calculator _calculator = null!;

 [SetUp]
 public void SetUp()
 {
 _calculator = new Calculator();
 }

 [Test]
 public void Add_TwoPositiveNumbers_ReturnsSum()
 {
 // Arrange: the calculator is created in SetUp.
 // Act
 double result = _calculator.Add(10, 20);
 // Assert
 Assert.That(result, Is.EqualTo(30));
 }
 [TestCase(0, 0, 0)]
[TestCase(0, 5, 5)]
[TestCase(-3, 8, 5)]
[TestCase(0.1, 0.2, 0.3)]
public void Add_RepresentativeInputs_ReturnsSum(
 double a, double b, double expected)
{
 double result = _calculator.Add(a, b);
 Assert.That(result, Is.EqualTo(expected).Within(1e-9));
}
 [Test]
public void Subtract_TwoPositiveNumbers_ReturnsDifference()
{
 double result = _calculator.Subtract(20, 10);
 Assert.That(result, Is.EqualTo(10));
}

[Test]
public void Multiply_TwoPositiveNumbers_ReturnsProduct()
{
 double result = _calculator.Multiply(5, 6);
 Assert.That(result, Is.EqualTo(30));
}
[TestCase(1, 2, 0.5)]
[TestCase(0, 15, 0)]
[TestCase(15, -3, -5)]
public void Divide_ValidInputs_ReturnsQuotient(
 double a, double b, double expected)
{
 double result = _calculator.Divide(a, b);
 Assert.That(result, Is.EqualTo(expected).Within(1e-9));
}

[TestCase(15, 0)]
[TestCase(0, 0)]
public void Divide_ZeroDivisor_ThrowsArgumentException(double a, double b)
{
 Assert.That(() => _calculator.Divide(a, b),
 Throws.TypeOf<ArgumentException>());
}
[Test]
public void Factorial_Zero_ReturnsOne()
{
 long result = _calculator.Factorial(0);
 Assert.That(result, Is.EqualTo(1L));
}
[TestCase(0, 1)]
[TestCase(1, 1)]
[TestCase(5, 120)]
[TestCase(20, 2432902008176640000)]
public void Factorial_ValidInputs_ReturnsCorrectValue(int n, long expected)
{
 long result = _calculator.Factorial(n);
 Assert.That(result, Is.EqualTo(expected));
}


[TestCase(-1)]
[TestCase(21)]
public void Factorial_OutOfRange_ThrowsArgumentOutOfRangeException(int n)
{
 Assert.That(() => _calculator.Factorial(n),
 Throws.TypeOf<ArgumentOutOfRangeException>());
}
[TestCase(3, 4, 6)]
[TestCase(0, 5, 0)]
[TestCase(5, 0, 0)]
public void TriangleArea_ValidInputs_ReturnsCorrectArea(double height, double width, double expected)
{
 double result = _calculator.TriangleArea(height, width);
 Assert.That(result, Is.EqualTo(expected).Within(1e-9));
}

[TestCase(-1, 5)]
[TestCase(5, -1)]
public void TriangleArea_NegativeDimension_ThrowsArgumentOutOfRangeException(double height, double width)
{
 Assert.That(() => _calculator.TriangleArea(height, width),
 Throws.TypeOf<ArgumentOutOfRangeException>());
}

[TestCase(1, 3.14159265359)]
[TestCase(0, 0)]
public void CircleArea_ValidInputs_ReturnsCorrectArea(double radius, double expected)
{
 double result = _calculator.CircleArea(radius);
 Assert.That(result, Is.EqualTo(expected).Within(1e-9));
}

[TestCase(-1)]
public void CircleArea_NegativeRadius_ThrowsArgumentOutOfRangeException(double radius)
{
 Assert.That(() => _calculator.CircleArea(radius),
 Throws.TypeOf<ArgumentOutOfRangeException>());
}
[TestCase(1000, 5, 200)]
[TestCase(500, 10, 50)]
public void CalculateMTBF_ValidInputs_ReturnsCorrectValue(double operatingTime, int failureCount, double expected)
{
 double result = _calculator.CalculateMTBF(operatingTime, failureCount);
 Assert.That(result, Is.EqualTo(expected).Within(1e-9));
}

[TestCase(-100, 5)]
[TestCase(100, -5)]
[TestCase(100, 0)]
public void CalculateMTBF_InvalidInputs_ThrowsArgumentException(double operatingTime, int failureCount)
{
 Assert.That(() => _calculator.CalculateMTBF(operatingTime, failureCount),
 Throws.TypeOf<ArgumentException>());
}

[TestCase(200, 50, 0.8)]
[TestCase(100, 100, 0.5)]
public void CalculateAvailability_ValidInputs_ReturnsCorrectValue(double mtbf, double mttr, double expected)
{
 double result = _calculator.CalculateAvailability(mtbf, mttr);
 Assert.That(result, Is.EqualTo(expected).Within(1e-9));
}

[TestCase(-1, 5)]
[TestCase(5, -1)]
[TestCase(0, 0)]
public void CalculateAvailability_InvalidInputs_ThrowsArgumentException(double mtbf, double mttr)
{
 Assert.That(() => _calculator.CalculateAvailability(mtbf, mttr),
 Throws.TypeOf<ArgumentException>());
}

[Test]
public void CurrentFailureIntensity_AtTauZero_ReturnsLambda0()
{
 double result = _calculator.CurrentFailureIntensity(0.5, 100, 0);
 Assert.That(result, Is.EqualTo(0.5).Within(1e-9));
}

[Test]
public void CurrentFailureIntensity_NormalExecutionTime_ReturnsExpectedValue()
{
 double result = _calculator.CurrentFailureIntensity(0.5, 100, 100);
 Assert.That(result, Is.EqualTo(0.3032653298563167).Within(1e-9));
}

[TestCase(0, 100, 10)]
[TestCase(-1, 100, 10)]
[TestCase(0.5, 0, 10)]
[TestCase(0.5, -1, 10)]
[TestCase(0.5, 100, -1)]
public void CurrentFailureIntensity_InvalidInputs_ThrowsArgumentException(double lambda0, double nu0, double tau)
{
 Assert.That(() => _calculator.CurrentFailureIntensity(lambda0, nu0, tau),
 Throws.TypeOf<ArgumentException>());
}

[Test]
public void ExpectedCumulativeFailures_AtTauZero_ReturnsZero()
{
 double result = _calculator.ExpectedCumulativeFailures(0.5, 100, 0);
 Assert.That(result, Is.EqualTo(0).Within(1e-9));
}

[Test]
public void ExpectedCumulativeFailures_NormalExecutionTime_ReturnsExpectedValue()
{
 double result = _calculator.ExpectedCumulativeFailures(0.5, 100, 100);
 Assert.That(result, Is.EqualTo(39.34693402873666).Within(1e-9));
}

[TestCase(0, 100, 10)]
[TestCase(-1, 100, 10)]
[TestCase(0.5, 0, 10)]
[TestCase(0.5, -1, 10)]
[TestCase(0.5, 100, -1)]
public void ExpectedCumulativeFailures_InvalidInputs_ThrowsArgumentException(double lambda0, double nu0, double tau)
{
 Assert.That(() => _calculator.ExpectedCumulativeFailures(lambda0, nu0, tau),
 Throws.TypeOf<ArgumentException>());
}
}