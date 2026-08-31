namespace CapstoneFinalProject;

public class Expense
{
    private string title = string.Empty;
    private decimal amount;
    private string category = string.Empty;

    public string Title
    {
        get => title;
        set => title = string.IsNullOrWhiteSpace(value)
            ? throw new InvalidExpenseException("Expense title cannot be empty.")
            : value.Trim();
    }

    public decimal Amount
    {
        get => amount;
        set => amount = value > 0
            ? value
            : throw new InvalidExpenseException("Expense amount must be greater than zero.");
    }

    public string Category
    {
        get => category;
        set => category = string.IsNullOrWhiteSpace(value)
            ? throw new InvalidExpenseException("Expense category cannot be empty.")
            : value.Trim();
    }

    public DateTime Date { get; set; }
    public bool IsPaid { get; set; }

    public Expense(string title, decimal amount, string category, DateTime date, bool isPaid = true)
    {
        Title = title;
        Amount = amount;
        Category = category;
        Date = date;
        IsPaid = isPaid;
    }

    public virtual string DisplayInfo() =>
        $"{Date:MM/dd/yyyy} | {Title,-20} | {Category,-15} | {Amount,10:C} | {(IsPaid ? "Paid" : "Unpaid")}";

    public override string ToString() => DisplayInfo();
}
