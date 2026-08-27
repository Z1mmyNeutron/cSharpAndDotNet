// Expense lunchExpense = new Expense("Lunch", 250);
// lunchExpense.PrintDetails();

// RecurringExpense netflixSubscription = new RecurringExpense("Netflix", 499, "Monthly");
// netflixSubscription.PrintDetails();

// Expense expense = new RecurringExpense("Netflix", 499, "Monthly");
// expense.PrintDetails();

IPrintable printableExpense = new RecurringExpense("Internet Bill", 999, "Monthly");
printableExpense.PrintDetails();