namespace CapstoneFinalProject;

public record ExpenseSummary(int Count, decimal Total, decimal Average, Expense? Highest, Expense? Lowest);

public record BudgetSummary(decimal MonthlyBudget, decimal TotalSpent)
{
    public decimal Remaining => MonthlyBudget - TotalSpent;
}
