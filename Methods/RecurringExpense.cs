public class RecurringExpense : Expense{
    public string Frequency {get; set;}
    public RecurringExpense(
        string title,
        double amount,
        string frequency,
        Category category)
        : base(title, amount, category){
            Frequency = frequency;
        }

        public override void PrintDetails(){
            Console.WriteLine($"Title: {Title}");
            Console.WriteLine($"Amount: {Amount}");
            Console.WriteLine($"Frequency: {Frequency}");
        }

    }


