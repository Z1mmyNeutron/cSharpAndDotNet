Console.WriteLine("Welcome to the Expense Tracker!");
string appName = "Expense Tracker";
int version = 1;


Console.WriteLine($"{appName} - version {version}");

Console.WriteLine("Enter your name");
string name = Console.ReadLine();
Console.WriteLine($"Hello {name}");
Console.Write("Enter your age:");
int age = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"Age: {age}");


Console.Write("Enter your monthly Budget");
double budget = Convert.ToDouble(Console.ReadLine());
Console.WriteLine($"Budget: {budget}");

Console.WriteLine();
Console.WriteLine("User Summary");
Console.WriteLine($"Name: {name}");
Console.WriteLine($"Age: {age}");
Console.WriteLine($"Monthly Budget: {budget:C}");
