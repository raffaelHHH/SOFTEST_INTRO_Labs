namespace SOFTEST_INTRO_Calculator;

public class Calculator
{
 public double Add(double a, double b) => a + b;
 public double Subtract(double a, double b) => a - b;
 public double Multiply(double a, double b) => a * b;
 // Starter version: complete the zero-divisor rule in section 5.
public double Divide(double a, double b)
{
 if (b == 0)
 {
 throw new ArgumentException("Cannot divide by zero");
 }
 return a / b;
} public double DoOperation(double a, double b, string op)
 {
 return op switch
 {
 "a" => Add(a, b),
 "s" => Subtract(a, b),
 "m" => Multiply(a, b),
 "d" => Divide(a, b),
 _ => throw new ArgumentException("Unknown operation.")
 };
 }

 public long Factorial(int n)
{
 if (n < 0 || n > 20)
 {
 throw new ArgumentOutOfRangeException(nameof(n), "Input must be between 0 and 20");
 }
 
 long result = 1;
 for (int i = 2; i <= n; i++)
 {
 result *= i;
 }
 return result;
}
public double TriangleArea(double height, double width)
{
 if (height < 0 || width < 0)
 {
 throw new ArgumentOutOfRangeException("Dimensions must be non-negative");
 }
 return (height * width) / 2;
}

public double CircleArea(double radius)
{
 if (radius < 0)
 {
 throw new ArgumentOutOfRangeException(nameof(radius), "Radius must be non-negative");
 }
 return Math.PI * radius * radius;
}

public double CalculateMTBF(double operatingTime, int failureCount)
{
 if (operatingTime <= 0 || failureCount <= 0)
 {
 throw new ArgumentException("Operating time and failure count must be positive");
 }
 return operatingTime / failureCount;
}

public double CalculateAvailability(double mtbf, double mttr)
{
 if (mtbf < 0 || mttr < 0 || (mtbf + mttr) <= 0)
 {
 throw new ArgumentException("MTBF and MTTR must be non-negative and sum must be positive");
 }
 return mtbf / (mtbf + mttr);
}

public double CurrentFailureIntensity(double lambda0, double nu0, double tau)
{
 if (lambda0 <= 0 || nu0 <= 0 || tau < 0)
 {
 throw new ArgumentException("Lambda0 and nu0 must be positive, tau must be non-negative");
 }
 return lambda0 * Math.Exp(-lambda0 * tau / nu0);
}

public double ExpectedCumulativeFailures(double lambda0, double nu0, double tau)
{
 if (lambda0 <= 0 || nu0 <= 0 || tau < 0)
 {
 throw new ArgumentException("Lambda0 and nu0 must be positive, tau must be non-negative");
 }
 return nu0 * (1 - Math.Exp(-lambda0 * tau / nu0));
}

public double GenMagicNum(
int choice, string path, IFileReader fileReader)
{
ArgumentNullException.ThrowIfNull(fileReader);
if (choice < 0)
{
throw new ArgumentOutOfRangeException(nameof(choice));
}
string[] magicStrings = fileReader.Read(path);
if (choice >= magicStrings.Length)
{
throw new ArgumentOutOfRangeException(nameof(choice));
}
double magicNumber = double.Parse(magicStrings[choice]);
return 2 * Math.Abs(magicNumber);
}

}