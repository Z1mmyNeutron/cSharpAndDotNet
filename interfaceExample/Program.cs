// Expense lunchExpense = new Expense("Lunch", 250);
// lunchExpense.PrintDetails();

// RecurringExpense netflixSubscription = new RecurringExpense("Netflix", 499, "Monthly");
// netflixSubscription.PrintDetails();

// Expense expense = new RecurringExpense("Netflix", 499, "Monthly");
// expense.PrintDetails();

// IPrintable printableExpense = new RecurringExpense("Internet Bill", 999, "Monthly");
// printableExpense.PrintDetails();


// List<Expense> expenses = new List<Expense>();
// expenses.Add(new Expense("Lunch", 250, "Food"));
// expenses.Add(new Expense("Taxi", 450, "Travel"));
// expenses.Add(new Expense("Internet Bill", 999, "Utilities"));

// Console.WriteLine("Expense List: ");
// foreach(Expense expense in expenses){
//     Console.WriteLine($"{expense.Title} - {expense.Amount} - {expense.Category}");
// }


// Dictionary<string, string> categoryDescription = new Dictionary<string, string>();
// categoryDescription.Add("Food", "Daily Meals");
// categoryDescription.Add("Travel", "Transportation expenses");
// categoryDescription.Add("Utilities", "Monthly household bills");
// Console.WriteLine();
// Console.WriteLine(categoryDescription["Travel"]);
// Console.WriteLine(categoryDescription["Food"]);
// Console.WriteLine(categoryDescription["Utilities"]);

// Func<Expense, bool> isHighValueExpense = expense => expense.Amount > 500;
// Console.WriteLine();
// Console.WriteLine(isHighValueExpense(expenses[0]));
// Console.WriteLine(isHighValueExpense(expenses[2]));

// Action<Expense> displayExpense = expense => {
//     Console.WriteLine($"{expense.Title} - {expense.Amount}");

// };
// Console.WriteLine();
// foreach(Expense expense in expenses){
//     displayExpense(expense);
// }
List<Expense> expenses = new(){
    new Expense("Lunch",  250, "Food"),
    new Expense("Dinner",  450, "Food"),
    new Expense("Taxi",  700, "Travel"),
    new Expense("Internet",  999, "Utilities"),
    new Expense("Electricity",  1800, "Utilities")
};

//where
var isHighValueExpenses = expenses.Where(expense => expense.Amount > 500);
Console.WriteLine("High Value Expenses");
foreach(Expense expense in isHighValueExpenses){
    Console.WriteLine($"{expense.Title} - {expense.Amount}");
}

//select
var expenseTitles = expenses.Select(expense => expense.Title);
Console.WriteLine();
Console.WriteLine("Expense Titles");
foreach(string title in expenseTitles){
    Console.WriteLine(title);
}

//OrderBy()

var sortedExpenses = expenses.OrderBy(expense => expense.Amount);
Console.WriteLine();
Console.WriteLine("Expenses sorted by Amount");
foreach(Expense expense in sortedExpenses){
    Console.WriteLine($"{expense.Title} - {expense.Amount}");
}

//Group by
var groupedExpenses = expenses.GroupBy(expense => expense.Category);
foreach(var group in groupedExpenses){
    Console.WriteLine($"\nCategory: {group.Key}");
    foreach(Expense expense in group){
        Console.WriteLine($"{expense.Title} - {expense.Amount}");
    }
}

//sum
double totalExpense = expenses.Sum(expense => expense.Amount);
Console.WriteLine();
Console.WriteLine($"Total Expense: {totalExpense}");

//first()
Expense firstExpense = expenses.First();
Console.WriteLine();
Console.WriteLine($"First Expense: {firstExpense.Title}");

//toList
List<Expense> utilityExpense = expenses.Where(expense => expense.Category == "Utilities").ToList();
Console.WriteLine();
Console.WriteLine("Utility Expenses");

foreach(Expense expense in utilityExpense){
    Console.WriteLine($"{expense.Title} - {expense.Amount}");
}