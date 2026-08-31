namespace CapstoneFinalProject;

public class ExpenseManager : IExpenseManager
{
    private readonly List<Expense> expenses = new();

    public void AddExpense(Expense expense)
    {
        ArgumentNullException.ThrowIfNull(expense);
        expenses.Add(expense);
    }

    public bool RemoveExpense(Expense expense) => expenses.Remove(expense);

    public List<Expense> GetExpenses() => expenses;

    // Overload: search by keyword in title or category
    public List<Expense> SearchExpenses(string keyword)
    {
        if (string.IsNullOrWhiteSpace(keyword))
        {
            return new List<Expense>();
        }

        return expenses
            .Where(e => e.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                     || e.Category.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    // Overload: search by amount range
    public List<Expense> SearchExpenses(decimal minAmount, decimal maxAmount) =>
        expenses.Where(e => e.Amount >= minAmount && e.Amount <= maxAmount).ToList();

    // Overload: search by date range
    public List<Expense> SearchExpenses(DateTime start, DateTime end) =>
        expenses.Where(e => e.Date.Date >= start.Date && e.Date.Date <= end.Date).ToList();

    public List<Expense> FilterByCategory(string category) =>
        expenses.Where(e => e.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();

    public List<Expense> SortByDate(bool ascending = true) =>
        ascending ? expenses.OrderBy(e => e.Date).ToList() : expenses.OrderByDescending(e => e.Date).ToList();

    public List<Expense> SortByAmount(bool ascending = true) =>
        ascending ? expenses.OrderBy(e => e.Amount).ToList() : expenses.OrderByDescending(e => e.Amount).ToList();

    public decimal CalculateTotalExpenses() => expenses.Sum(e => e.Amount);

    public decimal CalculateAverageExpense() => expenses.Count == 0 ? 0m : expenses.Average(e => e.Amount);

    public Expense? GetHighestExpense() => expenses.OrderByDescending(e => e.Amount).FirstOrDefault();

    public Expense? GetLowestExpense() => expenses.OrderBy(e => e.Amount).FirstOrDefault();

    public Dictionary<string, decimal> GroupByCategory() =>
        expenses
            .GroupBy(e => e.Category)
            .ToDictionary(g => g.Key, g => g.Sum(e => e.Amount));

    public async Task SaveExpensesAsync(string filePath) =>
        await FileService.SaveExpensesAsync(expenses, filePath);

    public async Task LoadExpensesAsync(string filePath)
    {
        List<Expense> loaded = await FileService.LoadExpensesAsync(filePath);
        expenses.Clear();
        expenses.AddRange(loaded);
    }
}
