public class RecurringExpense : Expense{

    public string Frequency{get; set;}
    public RecurringExpense(
        string title,
        double amount,
        string frequency)
         : base(title, amount, "Recurring"){
            Frequency = frequency;
        }
        public override void PrintDetails(){
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Amount: {Amount}");
            Console.WriteLine($"Frequency: {Frequency}");
        }
    
}