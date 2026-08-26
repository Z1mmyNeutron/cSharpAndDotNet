public class RecurringExpense : Expense{
    public string Frequency {get; set;}
    public RecurringExpense(
        string title,
        double amount,
        string frequency)
        : base(title, amount){
            Frequency = frequency;
        }

    }


