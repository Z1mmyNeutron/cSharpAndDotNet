namespace ExpenseTrackerCapstone;

public class ExpenseValidator
{
    public bool IsValidAmount(double amount)
    {
        return amount > 0;
    }
}
