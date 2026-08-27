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
    new Expense("Lunch",  250, "Food");
    new Expense("Dinner",  450, "Food");
    new Expense("Taxi",  700, "Travel");
    new Expense("Internet",  999, "Utilities");
    new Expense("Electricity",  1800, "Utilities");
}