namespace ExpenseTrackerCapstone;

class Program
{
    static async Task Main(string[] args)
    {
        ExpenseManager manager = new();
        ExpenseValidator validator = new();

        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine("=== Expense Tracker ===");
            Console.WriteLine("1. Add Expense");
            Console.WriteLine("2. View Expenses");
            Console.WriteLine("3. Save Expenses");
            Console.WriteLine("4. Load Expenses");
            Console.WriteLine("5. Exit");
            Console.Write("Select an option: ");

            string? choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter title: ");
                        string title = Console.ReadLine() ?? string.Empty;

                        Console.Write("Enter amount: ");
                        double amount = Convert.ToDouble(Console.ReadLine());

                        Console.Write("Enter category: ");
                        string category = Console.ReadLine() ?? string.Empty;

                        if (validator.IsValidAmount(amount))
                        {
                            Expense expense = new(title, amount, category);
                            manager.AddExpense(expense);
                            Console.WriteLine("Expense added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Amount must be greater than zero.");
                        }
                        break;

                    case "2":
                        List<Expense> currentExpenses = manager.GetExpenses();

                        if (currentExpenses.Count == 0)
                        {
                            Console.WriteLine("No expenses found.");
                        }
                        else
                        {
                            foreach (Expense expense in currentExpenses)
                            {
                                Console.WriteLine($"{expense.Title} - {expense.Amount} - {expense.Category}");
                            }
                        }
                        break;

                    case "3":
                        await manager.SaveExpensesAsync();
                        Console.WriteLine("Expenses saved successfully.");
                        break;

                    case "4":
                        await manager.LoadExpensesAsync();
                        Console.WriteLine("Expenses loaded successfully.");
                        break;

                    case "5":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
