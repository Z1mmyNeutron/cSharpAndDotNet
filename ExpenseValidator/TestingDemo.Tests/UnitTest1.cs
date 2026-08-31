namespace TestingDemo.Tests;

public class ExpenseValidatorTests{
    [Theory]
    [InlineData(100, true)]
    [InlineData(0, false)]
    [InlineData(-50, false)]
    public void IsValidAmount_ReturnsExpectedResult(decimal amount, bool expected){
        ExpenseValidator validator = new();
        bool result = validator.IsValidAmount(amount);
        Assert.Equal(expected, result);
    }
}