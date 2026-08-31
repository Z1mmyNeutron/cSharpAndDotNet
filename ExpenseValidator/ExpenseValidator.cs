public class ExpenseValidator
{
    public bool IsValidAmount(decimal amount)
    {
        return amount > 0;
    }
}
