Console.WriteLine("Hello, World!");
// Console.WriteLine("Hello, World!");
// Console.WriteLine("Exploring the C# WorkSpace");
// Console.WriteLine("Writing a line");
// string studentName = "Christina";
// Console.WriteLine($"hello {studentName}");

string day = "Monday";

switch(day){
    case "Monday":
        Console.WriteLine("Start of the Week");
        break;
    case "Friday":
        Console.WriteLine("End of the Week");
        break;
    default:
        Console.WriteLine("Regular Day");
        break;
}
string role = "Admin";

//switch expression
string access = role switch{
    "Admin" => "Full Access",
    "Manager" => "Limited Access",
    _ => "Guest access"
};

//pattern matching basics
object value = 25;
switch(value){
    case int number:
        Console.WriteLine($"Number: {number}");
        break;
};

//for loop- when number of repitions is known
for(int i = 1; i <= 5; i++){
    Console.WriteLine(i);
};

// int balance = 5;
// //while loop- when as long as the condition is true
// while(balance > 0){
//     Console.WriteLine("Processing...");
// };
//do while- runs at least once before checking the condition
// bool isValidPin = false;
// do{
//     Console.WriteLine("Enter Pin");

// }
// while(!isValidPin);

//for each loop- collections and printing each thing in a list
string[] movies = {
    "Inception", "The Oddessy", "Avatar", "Interstellar"
};
foreach(string movie in movies){
    Console.WriteLine(movie);
};
//break immediately exists a loop
for(int i = 1; i <= 10; i++){
    
    if(i==5){
        break;
    }
    if(i == 3){
        continue;
    }
    Console.WriteLine(i);
};

Console.Write("Enter your age: ");
int age = Convert.ToInt32(Console.ReadLine());
if(age >= 18){
    Console.WriteLine("You are eligible to vote.");
}else{
    Console.WriteLine("You are not eligible to vote.");
}