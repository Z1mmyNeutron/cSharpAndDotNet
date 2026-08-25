Console.WriteLine("Hello, World!");
while(true){
    Console.WriteLine("Console Menu");
    Console.WriteLine("1. Show the number using a for loop");
    Console.WriteLine("2. Show categories using a foreach loop");
    Console.WriteLine("3. skip even numbers using continue");
    Console.WriteLine("4. Exit");
    Console.Write("Choose an option: ");

    string choice = Console.ReadLine();
    Console.WriteLine();

    if(choice == "1"){
        Console.WriteLine("Numbers from 1-5: ");
        for(int i = 1; i <= 5; i++){
            Console.WriteLine(i);
        }
    }else if(choice == "2"){
        string[] categories = {"Food", "Travel", "Shopping", "Bills"};
        Console.WriteLine("Available Categories");
        foreach(string category in categories){
            Console.WriteLine(category);
        }
    }else if(choice == "3"){
        Console.WriteLine("Odd Numbers from 1 to 10: ");
        for(int i = 1; i <= 10; i++){
            if(i % 2 == 0){
                continue;
            }
            Console.WriteLine(i);
        }
    }else if(choice == "4"){
        Console.WriteLine("You selected option 4.");
        break;
    }else{
        Console.WriteLine("Invalid Option. Please try again.");
    }
    Console.WriteLine();

}