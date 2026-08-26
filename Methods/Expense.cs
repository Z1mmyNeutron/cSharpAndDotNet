public class Expense : IPrintable{
    public string Title{get; set;}
    public double Amount{get; set;}
    public Category Category{get; set;}

    public Expense(string title, double amount, Category category){
        Title = title;
        Amount = amount;
        Category = category;
    }
    public virtual void PrintDetails(){
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Amountt: {Amount}");
    }
}
