public class Expense{
    public string Title{get; set;}
    public double Amount{get; set;}
    public string Category{get; set;}

    public Expense(string title, double amount, string category){
        Title = title;
        Amount = amount;
        Category = category;
    }
}