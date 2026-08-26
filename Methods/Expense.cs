public class Expense{
    public string Title{get; set;}
    public double Amount{get; set;}
    public Category Category{get; set;}

    public Expense(string title, double amount, Category category){
        Title = title;
        Amount = amount;
        Category = category;
    }
}
