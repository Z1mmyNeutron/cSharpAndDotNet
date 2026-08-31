using System.Text.Json;

List<Expense> expenses = new()
{
    new Expense("Lunch", 350, "Food"),
    new Expense("Taxi", 450, "Travel"),
    new Expense("Internet Bill", 999, "Utilities"),
};

await SaveExpensesAsync(expenses);

List<Expense>? loadedExpenses = await LoadExpensesAsync();

if (loadedExpenses is not null)
{
    Console.WriteLine();
    Console.WriteLine("Expenses loaded from JSON");

    foreach (Expense expense in loadedExpenses)
    {
        Console.WriteLine(
            $"{expense.Title} - {expense.Amount} - {expense.Category}"
        );
    }
}

async Task SaveExpensesAsync(List<Expense> expenses)
{
    string jsonData = JsonSerializer.Serialize(expenses);

    await File.WriteAllTextAsync("expenses.json", jsonData);

    Console.WriteLine("Expenses saved successfully");
}

async Task<List<Expense>?> LoadExpensesAsync()
{
    string jsonData = await File.ReadAllTextAsync("expenses.json");

    return JsonSerializer.Deserialize<List<Expense>>(jsonData);
}


// using(StreamWriter writer = new StreamWriter("expenses.txt")){
//     foreach(Expense expense in expenses){
//         writer.WriteLine($"{expense.Title}, {expense.Amount}, {expense.Category}");
//     }
// }

// Console.WriteLine("Expenses written to text file");

// Console.WriteLine();
// Console.WriteLine("Reading from the text file");
// using(StreamReader reader = new StreamReader("expenses.txt")){
//     string? line;
//     while((line = reader.ReadLine()) is not null){
//         Console.WriteLine(line);
//     }
// }
// string jsonData = JsonSerializer.Serialize(expenses);
// File.WriteAllText("expenses.json", jsonData);

// string savedJson = File.ReadAllText("expenses.json");
// List<Expense>? loadedExpenses = JsonSerializer.Deserialize<List<Expense>>(savedJson);
// Console.WriteLine();
// Console.WriteLine("Expenses loaded from JSON");
// if(loadedExpenses is not null){
//     foreach(Expense expense in loadedExpenses){
//         Console.WriteLine($"{expense.Title} - {expense.Amount} - {expense.Category}");
//     }
// }