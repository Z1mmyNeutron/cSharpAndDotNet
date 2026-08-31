using CapstoneFinalProject;

IExpenseManager manager = new ExpenseManager();

Dictionary<int, Category> categories = new()
{
    [1] = new Category(1, "Housing"),
    [2] = new Category(2, "Food"),
    [3] = new Category(3, "Transportation"),
    [4] = new Category(4, "Utilities"),
    [5] = new Category(5, "Entertainment"),
    [6] = new Category(6, "Other")
};

string dataFilePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Data", "expenses.json"));
decimal monthlyBudget = 0m;
bool running = true;

DisplayWelcome();

while (running)
{
    DisplayMenu();
    string? choice = Console.ReadLine();

    try
    {
        switch (choice)
        {
            case "1":
                AddExpense();
                break;
            case "2":
                ViewExpenses();
                break;
            case "3":
                SearchExpensesMenu();
                break;
            case "4":
                FilterByCategoryMenu();
                break;
            case "5":
                ViewSummary();
                break;
            case "6":
                await SaveExpensesAsync();
                break;
            case "7":
                await LoadExpensesAsync();
                break;
            case "8":
                running = false;
                Console.WriteLine("Thank you for using the Expense Tracker. Goodbye!");
                break;
            default:
                Console.WriteLine("Invalid selection. Please choose a number between 1 and 8.");
                break;
        }
    }
    catch (InvalidExpenseException ex)
    {
        Console.WriteLine($"Invalid expense: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An unexpected error occurred: {ex.Message}");
    }
    finally
    {
        if (running)
        {
            Console.WriteLine();
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}

// ---------------- Local functions ----------------

void DisplayWelcome()
{
    Console.WriteLine("==================================================");
    Console.WriteLine("           C# EXPENSE TRACKER APPLICATION        ");
    Console.WriteLine("==================================================");
    Console.WriteLine("Track your spending, manage categories, and stay");
    Console.WriteLine("on top of your budget, all from the command line.");
    Console.WriteLine();

    Console.Write("Enter your monthly budget (or press Enter to skip): ");
    string? input = Console.ReadLine();
    if (decimal.TryParse(input, out decimal budget) && budget > 0)
    {
        monthlyBudget = budget;
        Console.WriteLine($"Monthly budget set to {monthlyBudget:C}.");
    }
    else
    {
        Console.WriteLine("No budget set. You can still track expenses.");
    }

    Console.WriteLine();
}

void DisplayMenu()
{
    Console.WriteLine();
    Console.WriteLine("---------------- MAIN MENU ----------------");
    Console.WriteLine("1. Add Expense");
    Console.WriteLine("2. View Expenses");
    Console.WriteLine("3. Search Expenses");
    Console.WriteLine("4. Filter by Category");
    Console.WriteLine("5. View Summary");
    Console.WriteLine("6. Save Expenses");
    Console.WriteLine("7. Load Expenses");
    Console.WriteLine("8. Exit");
    Console.Write("Select an option (1-8): ");
}

void AddExpense()
{
    Console.WriteLine();
    Console.WriteLine("--- Add New Expense ---");

    Console.Write("Title: ");
    string title = Console.ReadLine() ?? string.Empty;

    decimal amount = ReadValidAmount("Amount: ");
    string category = ReadCategory();
    DateTime date = ReadValidDate("Date (MM/DD/YYYY), or press Enter for today: ");

    Console.Write("Has this been paid already? (y/n): ");
    bool isPaid = (Console.ReadLine() ?? string.Empty).Trim().ToLower() is "y" or "yes";

    Console.Write("Is this a recurring expense? (y/n): ");
    bool isRecurring = (Console.ReadLine() ?? string.Empty).Trim().ToLower() is "y" or "yes";

    Expense expense;
    if (isRecurring)
    {
        Console.Write("Frequency (e.g., Weekly, Monthly): ");
        string frequency = Console.ReadLine() is { Length: > 0 } freq ? freq : "Monthly";
        DateTime nextDue = ReadValidDate("Next due date (MM/DD/YYYY): ");
        expense = new RecurringExpense(title, amount, category, date, frequency, nextDue, isPaid);
    }
    else
    {
        expense = new Expense(title, amount, category, date, isPaid);
    }

    manager.AddExpense(expense);

    Console.WriteLine();
    Console.WriteLine("Expense added successfully:");
    Console.WriteLine(expense.DisplayInfo());
}

string ReadCategory()
{
    Console.WriteLine("Categories:");
    foreach (KeyValuePair<int, Category> kvp in categories.OrderBy(c => c.Key))
    {
        Console.WriteLine($"  {kvp.Key}. {kvp.Value.Name}");
    }

    Console.Write("Select a category number, or type a new category name: ");
    string? input = Console.ReadLine();

    if (int.TryParse(input, out int id) && categories.TryGetValue(id, out Category? existing))
    {
        return existing.Name;
    }

    if (!string.IsNullOrWhiteSpace(input))
    {
        int newId = categories.Keys.Count == 0 ? 1 : categories.Keys.Max() + 1;
        categories[newId] = new Category(newId, input.Trim());
        return input.Trim();
    }

    return "Other";
}

decimal ReadValidAmount(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        if (decimal.TryParse(input, out decimal amount) && amount > 0)
        {
            return amount;
        }
        Console.WriteLine("Invalid amount. Please enter a positive number.");
    }
}

DateTime ReadValidDate(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            return DateTime.Today;
        }
        if (DateTime.TryParse(input, out DateTime date))
        {
            return date;
        }
        Console.WriteLine("Invalid date. Please use MM/DD/YYYY format.");
    }
}

void ViewExpenses()
{
    Console.WriteLine();
    Console.WriteLine("--- All Expenses ---");
    List<Expense> all = manager.GetExpenses();

    if (all.Count == 0)
    {
        Console.WriteLine("No expenses recorded yet.");
        return;
    }

    foreach (Expense expense in all.OrderBy(e => e.Date))
    {
        Console.WriteLine(expense.DisplayInfo());
    }

    Console.WriteLine($"\nTotal: {all.Count} expense(s), {manager.CalculateTotalExpenses():C}");
}

void SearchExpensesMenu()
{
    Console.WriteLine();
    Console.WriteLine("--- Search Expenses ---");
    Console.WriteLine("1. By keyword (title/category)");
    Console.WriteLine("2. By amount range");
    Console.WriteLine("3. By date range");
    Console.Write("Choose a search type: ");
    string? type = Console.ReadLine();

    List<Expense> results;
    switch (type)
    {
        case "1":
            Console.Write("Enter keyword: ");
            string keyword = Console.ReadLine() ?? string.Empty;
            results = manager.SearchExpenses(keyword);
            break;
        case "2":
            decimal min = ReadValidAmount("Minimum amount: ");
            decimal max = ReadValidAmount("Maximum amount: ");
            results = manager.SearchExpenses(min, max);
            break;
        case "3":
            DateTime start = ReadValidDate("Start date: ");
            DateTime end = ReadValidDate("End date: ");
            results = manager.SearchExpenses(start, end);
            break;
        default:
            Console.WriteLine("Invalid search type.");
            return;
    }

    DisplayResults(results);
}

void FilterByCategoryMenu()
{
    Console.WriteLine();
    string category = ReadCategory();
    List<Expense> results = manager.FilterByCategory(category);
    DisplayResults(results);
}

void DisplayResults(List<Expense> results)
{
    if (results.Count == 0)
    {
        Console.WriteLine("No matching expenses found.");
        return;
    }

    foreach (Expense expense in results)
    {
        Console.WriteLine(expense.DisplayInfo());
    }

    Console.WriteLine($"\n{results.Count} result(s) found.");
}

void ViewSummary()
{
    Console.WriteLine();
    Console.WriteLine("--- Expense Summary ---");

    List<Expense> all = manager.GetExpenses();
    if (all.Count == 0)
    {
        Console.WriteLine("No expenses recorded yet.");
        return;
    }

    ExpenseSummary summary = new(
        all.Count,
        manager.CalculateTotalExpenses(),
        manager.CalculateAverageExpense(),
        manager.GetHighestExpense(),
        manager.GetLowestExpense());

    Console.WriteLine($"Number of Expenses: {summary.Count}");
    Console.WriteLine($"Total Expenses:     {summary.Total:C}");
    Console.WriteLine($"Average Expense:    {summary.Average:C}");
    Console.WriteLine($"Highest Expense:    {(summary.Highest is { } h ? $"{h.Title} ({h.Amount:C})" : "N/A")}");
    Console.WriteLine($"Lowest Expense:     {(summary.Lowest is { } l ? $"{l.Title} ({l.Amount:C})" : "N/A")}");

    if (monthlyBudget > 0)
    {
        BudgetSummary budgetSummary = new(monthlyBudget, summary.Total);
        string status = budgetSummary.Remaining >= 0 ? "under budget" : "OVER budget";
        Console.WriteLine($"Monthly Budget:     {budgetSummary.MonthlyBudget:C}");
        Console.WriteLine($"Remaining Budget:   {budgetSummary.Remaining:C} ({status})");
    }

    Console.WriteLine();
    Console.WriteLine("Spending by Category:");
    foreach (KeyValuePair<string, decimal> kvp in manager.GroupByCategory().OrderByDescending(c => c.Value))
    {
        Console.WriteLine($"  {kvp.Key,-15}: {kvp.Value,10:C}");
    }
}

async Task SaveExpensesAsync()
{
    await manager.SaveExpensesAsync(dataFilePath);
}

async Task LoadExpensesAsync()
{
    await manager.LoadExpensesAsync(dataFilePath);
    Console.WriteLine($"{manager.GetExpenses().Count} expense(s) currently loaded.");
}
