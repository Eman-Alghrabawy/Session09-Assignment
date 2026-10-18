using Session09.App.Services;

namespace Session09.Tests;

// Part 6 - Q12: Unit tests for FineCalculator using xUnit and the AAA pattern (Arrange - Act - Assert).
public class FineCalculatorTests
{
    // xUnit creates a NEW instance of this class for every test,
    // so each test gets a fresh FineCalculator created in the constructor.
    private readonly FineCalculator _calculator;

    public FineCalculatorTests()
    {
        _calculator = new FineCalculator();
    }

    // ---------- Test 1: [Fact] + Assert.Equal ----------
    [Fact]
    public void Add_ShouldReturnCorrectSum()
    {
        // Arrange
        int a = 10;
        int b = 5;

        // Act
        int result = _calculator.Add(a, b);

        // Assert
        Assert.Equal(15, result);
    }

    // ---------- Test 2: [Fact] + Assert.NotEqual ----------
    [Fact]
    public void Add_ShouldReturnNotEqual()
    {
        // Arrange
        int a = 10;
        int b = 5;

        // Act
        int result = _calculator.Add(a, b);

        // Assert
        Assert.NotEqual(20, result);
    }

    // ---------- Test 3: [Fact] + Assert.Equal ----------
    [Fact]
    public void Subtract_ShouldReturnCorrectDifference()
    {
        // Arrange
        int a = 10;
        int b = 4;

        // Act
        int result = _calculator.Subtract(a, b);

        // Assert
        Assert.Equal(6, result);
    }

    // ---------- Test 4: [Theory] + 3 x [InlineData] + Assert.Equal (includes a negative-number case) ----------
    [Theory]
    [InlineData(2, 3, 6)]
    [InlineData(0, 5, 0)]
    [InlineData(-4, 3, -12)] // negative-number case
    public void Multiply_ShouldReturnCorrectResult(int a, int b, int expected)
    {
        // Arrange (inputs come from InlineData)

        // Act
        int result = _calculator.Multiply(a, b);

        // Assert
        Assert.Equal(expected, result);
    }

    // ---------- Test 5: [Theory] + 3 x [InlineData] + Assert.NotEqual ----------
    [Theory]
    [InlineData(2, 3, 7)]
    [InlineData(4, 5, 25)]
    [InlineData(-1, 6, 6)]
    public void Multiply_ShouldReturnNotEqual(int a, int b, int wrongValue)
    {
        // Arrange (inputs come from InlineData)

        // Act
        int result = _calculator.Multiply(a, b);

        // Assert
        Assert.NotEqual(wrongValue, result);
    }

    // ---------- Test 6: [Fact] + Assert.Throws<DivideByZeroException> ----------
    [Fact]
    public void Divide_ByZero_ShouldThrowException()
    {
        // Arrange
        int a = 10;
        int b = 0;

        // Act & Assert
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(a, b));
    }
}
