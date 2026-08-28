Expense lunchExpense = new("Lunch", 250, "Food");
Expense updatedExpense = lunchExpense with{Amount = 300};

Expense internetExpense = new("Internet", 999, "Utilities");

object expense = updatedExpense;
if(expense is Expense currentExpense){
    Console.WriteLine();
    Console.WriteLine("Pattern Match using is ");
    Console.WriteLine($"{currentExpense.Title} - {currentExpense.Amount}");
}

string expenseCategory = updatedExpense.Amount switch{
    < 500 => "Low Expense",
    >= 500 and < 1000 => "Medium Expense",
    _=> "High Expense"
};


// Console.WriteLine("Expense Details");
// Console.WriteLine(lunchExpense);
// Console.WriteLine();
// Console.WriteLine(internetExpense);
// Console.WriteLine();
// Console.WriteLine(updatedExpense);
// Console.WriteLine();
// Console.WriteLine($"Expense Category: {expenseCategory}");

// string? notes = null;

// Console.WriteLine();
// Console.WriteLine("Expense Notes");
// if(notes is not null){
//     Console.WriteLine(notes);
// }else{
//     Console.WriteLine("No notes available");
// }
try
{
    Console.Write("Enter Expense amount: ");

    string? input = Console.ReadLine();

    if (input is null)
    {
        Console.WriteLine("No input provided");
        return;
    }

    int amount = int.Parse(input);
    if(amount <= 0){
        throw new InvalidExpenseException("Expense amount must be greater than zero");
    }

    Console.WriteLine($"Expense amount: {amount}");
}
catch(InvalidExpenseException ex){
    Console.WriteLine(ex.Message);

}
catch (FormatException)
{
    Console.WriteLine("Please enter a valid numeric value");
}