Console.WriteLine("Interactive Console Calculator!");
Console.WriteLine();

Console.WriteLine("Enter the First Number: ");
double firstNumber = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Enter the Second Number: ");
double secondNumber = Convert.ToDouble(Console.ReadLine());

double sum = firstNumber + secondNumber;
double difference = firstNumber - secondNumber;
double product = firstNumber * secondNumber;
double quotient = firstNumber / secondNumber;

Console.WriteLine($"\n Calculation Results: \n Addition: {sum:F2} \n Subtraction: {difference:F2} \n Multiplication: {product:F2} \n Division: {quotient:F2}");

Console.Write("\n Enter an Expense Amount: ");
string? input = Console.ReadLine();

if (decimal.TryParse(input, out decimal amount)){
    Console.WriteLine($"You entered: {amount:F2}.");

}else{
    Console.WriteLine("That wasn't a valid number.");
}