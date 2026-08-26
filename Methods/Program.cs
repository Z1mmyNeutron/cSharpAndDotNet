// // void DisplayWelcomeMessage(){
// //     Console.WriteLine("Welcome to the methods demo!");
// // }

// void DisplayUser(string name){
//     Console.WriteLine($"Hello {name}");
// }

// DisplayUser("Christina");

// double CalculateTax(double amount){
//     return amount * .18;
// }
// CalculateTax(180);

// double tax = CalculateTax(1000);
// Console.WriteLine($"Tax: {tax}");

// void ShowWelcomeMessage(){
//     Console.WriteLine("Hello! Welcome!");
// };

// ShowWelcomeMessage();

// double CalculateTotal(double price, double tax){
//     return price + tax;
// };
// Console.WriteLine(CalculateTotal(25.99, 1.23));

// void DisplayMovie(string title){
//     Console.WriteLine(title);
// };

// void BookTicket(string movie, int seats = 1){
//     Console.WriteLine($"{movie} - {seats}");
// };

// void IncreaseScore(ref int score){
//     score += 10;
// };

// void IncreaseValue(ref int number){
//     number += 10;
//     Console.WriteLine($"Inside Method: {number}");
// }
// int score = 50;
// IncreaseValue(ref score);
// Console.WriteLine($"Outside Method: {score}");

// BookTicket("Inception");
// BookTicket(movie: "Avatar", seats: 3);
// DisplayMovie("Gattica");
// int.TryParse("100", out int result);

// //local scope- can only be used in the method
// void DisplayPrice(){
//     double price = 9.99;
// };

// //Block scope
// if(true){
//     string message = "Hello";
// }

// // Defining a method
// static double CalculateTotal(double price, int quantity)
// {
//     return price * quantity;
// }

// // Calling it
// double total = CalculateTotal(4.50, 3);
// Console.WriteLine($"Total: ${total:F2}");   // Total: $13.50

// // Value (default) — the method gets a copy, original is untouched
// void TryDiscount(double price)
// {
//     price = price * 0.9;   // only changes the local copy
// }

// // ref — the method can modify the caller's actual variable
// void ApplyDiscount(ref double price)
// {
//     price = price * 0.9;   // changes the original variable
// }

// // out — used when a method needs to return more than one value
// bool TryParseAmount(string input, out double amount)
// {
//     return double.TryParse(input, out amount);
// }

// // optional — has a default value if the caller doesn't supply one
// double CalculateTax(double amount, double rate = 0.08)
// {
//     return amount * rate;
// }

// // named — the caller specifies which parameter each value belongs to
// double tax = CalculateTax(amount: 100, rate: 0.05);

Category foodCategory = new Category("Food");
Expense lunchExpense = new Expense("Lunch", 250, foodCategory);
Console.WriteLine(lunchExpense.Title);
Console.WriteLine(lunchExpense.Amount);
Console.WriteLine(lunchExpense.Category.Name);

Category travelCategory = new Category("Travel");

Expense cabExpense = new Expense(
    "Airport cab",
    500,
    travelCategory
);

Console.WriteLine();
Console.WriteLine(cabExpense.Title);
Console.WriteLine(cabExpense.Amount);
Console.WriteLine(cabExpense.Category.Name);