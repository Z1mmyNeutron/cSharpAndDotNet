namespace CapstoneFinalProject;

public interface IExpenseManager
{
    void AddExpense(Expense expense);
    bool RemoveExpense(Expense expense);
    List<Expense> GetExpenses();

    List<Expense> SearchExpenses(string keyword);
    List<Expense> SearchExpenses(decimal minAmount, decimal maxAmount);
    List<Expense> SearchExpenses(DateTime start, DateTime end);

    List<Expense> FilterByCategory(string category);
    List<Expense> SortByDate(bool ascending = true);
    List<Expense> SortByAmount(bool ascending = true);

    decimal CalculateTotalExpenses();
    decimal CalculateAverageExpense();
    Expense? GetHighestExpense();
    Expense? GetLowestExpense();
    Dictionary<string, decimal> GroupByCategory();

    Task SaveExpensesAsync(string filePath);
    Task LoadExpensesAsync(string filePath);
}
