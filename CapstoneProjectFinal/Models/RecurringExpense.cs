namespace CapstoneFinalProject;

public class RecurringExpense : Expense
{
    public string Frequency { get; set; }
    public DateTime NextDueDate { get; set; }

    public RecurringExpense(string title, decimal amount, string category, DateTime date,
        string frequency, DateTime nextDueDate, bool isPaid = true)
        : base(title, amount, category, date, isPaid)
    {
        Frequency = frequency;
        NextDueDate = nextDueDate;
    }

    public override string DisplayInfo() =>
        $"{base.DisplayInfo()} | Recurring: {Frequency,-8} | Next Due: {NextDueDate:MM/dd/yyyy}";
}
