
void ShowWelcomeMessage(){
    Console.WriteLine("Hello! Welcome!");
};

ShowWelcomeMessage();

double CalculateTotal(double price, double tax){
    return price + tax;
};
Console.WriteLine(CalculateTotal(25.99, 1.23));

void DisplayMovie(string title){
    Console.WriteLine(title);
};

void BookTicket(string movie, int seats = 1){
    Console.WriteLine($"{movie} - {seats}");
};

void IncreaseScore(ref int score){
    score += 10;
};

BookTicket("Inception");
BookTicket(movie: "Avatar", seats: 3);
DisplayMovie("Gattica");
int.TryParse("100", out int result);

//local scope- can only be used in the method
void DisplayPrice(){
    double price = 9.99;
};

//Block scope
if(true){
    string message = "Hello";
}