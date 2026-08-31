using System.Text.Json;

namespace ExpenseTrackerCapstone;

public class ExpenseManager
{
    private List<Expense> expenses = new();

    private const string FilePath = "expenses.json";

    public void AddExpense(Expense expense)
    {
        expenses.Add(expense);
    }

    public List<Expense> GetExpenses()
    {
        return expenses;
    }

    public async Task SaveExpensesAsync()
    {
        string jsonData = JsonSerializer.Serialize(expenses, new JsonSerializerOptions { WriteIndented = true });

        await File.WriteAllTextAsync(FilePath, jsonData);
    }

    public async Task LoadExpensesAsync()
    {
        if (File.Exists(FilePath))
        {
            string jsonData = await File.ReadAllTextAsync(FilePath);

            List<Expense>? loadedExpenses = JsonSerializer.Deserialize<List<Expense>>(jsonData);

            if (loadedExpenses is not null)
            {
                expenses = loadedExpenses;
            }
        }
    }
}
