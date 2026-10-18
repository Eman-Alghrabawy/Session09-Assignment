namespace Session09.App.Services;

// Part 6 - Q11: Fine calculator for the library system (the class we will unit test).
public class FineCalculator
{
    public int Add(int a, int b) => a + b;

    public int Subtract(int a, int b) => a - b;

    public int Multiply(int a, int b) => a * b;

    public int Divide(int a, int b)
    {
        if (b == 0)
            throw new DivideByZeroException("Divisor cannot be zero.");

        return a / b;
    }
}
