Console.Write("Enter your exam score: ");
int score = Convert.ToInt32(Console.ReadLine());

if (score >= 90)
{
    Console.WriteLine("Grade A");
}
else if (score >= 75)
{
    Console.WriteLine("Grade B");
}
else if (score >= 60)
{
    Console.WriteLine("Grade C");
}
else
{
    Console.WriteLine("Grade D");
}

Console.Write("Enter a day number (1-3): ");
int day = Convert.ToInt32(Console.ReadLine());

switch (day)
{
    case 1:
        Console.WriteLine("Monday");
        break;

    case 2:
        Console.WriteLine("Tuesday");
        break;

    case 3:
        Console.WriteLine("Wednesday");
        break;

    default:
        Console.WriteLine("Invalid day");
        break;
}

string dayName = day switch
{
    1 => "Monday",
    2 => "Tuesday",
    3 => "Wednesday",
    _ => "Invalid day"
};

Console.WriteLine(dayName);

Console.Write("Enter your age again: ");
int customerAge = Convert.ToInt32(Console.ReadLine());

string ticketType = customerAge switch
{
    < 13 => "Child Ticket",
    >= 13 and < 60 => "Adult Ticket",
    >= 60 => "Senior Citizen Ticket"
};

Console.WriteLine(ticketType);