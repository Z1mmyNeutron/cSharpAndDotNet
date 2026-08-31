namespace TestingDemo.Tests;

public class ExpenseValidatorTests{
    [Fact]
    public void IsValidAmount_ReturnsTrue_ForPositiveAmount(){
        ExpenseValidator validator = new();
        bool result = validator.IsValidAmount(100);
        Assert.True(result);
    }
}