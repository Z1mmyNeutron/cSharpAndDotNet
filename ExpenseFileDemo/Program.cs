using System.Text.Json;

List<Expense> expenses = new(){
    new Expense("Lunch", 350, "Food"),
    new Expense("Taxi", 450, "Travel"),
    new Expense("Internet Bill", 999, "Utilities"),
};
using(StreamWriter writer = new StreamWriter("expenses.txt")){
    foreach(Expense expense in expenses){
        writer.WriteLine($"{expense.Title}, {expense.Amount}, {expense.Category}");
    }
}

Console.WriteLine("Expenses written to text file");

Console.WriteLine();
Console.WriteLine("Reading from the text file");
using(StreamReader reader = new StreamReader("expenses.txt")){
    string? line;
    while((line = reader.ReadLine()) is not null){
        Console.WriteLine(line);
    }
}
string jsonData = JsonSerializer.Serialize(expenses);
File.WriteAllText("expenses.json", jsonData);

string savedJson = File.ReadAllText("expenses.json");
List<Expense>? loadedExpenses = JsonSerializer.Deserialize<List<Expense>>(savedJson);
Console.WriteLine();
Console.WriteLine("Expenses loaded from JSON");
if(loadedExpenses is not null){
    foreach(Expense expense in loadedExpenses){
        Console.WriteLine($"{expense.Title} - {expense.Amount} - {expense.Category}");
    }
}