public class Expense : IPrintable{
    public string Title{get; set;}
    public double Amount{get; set;}

    public Expense(string title, double amount){
        Title = title;
        Amount = amount;
    }
    public virtual void PrintDetails(){
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Amount: {Amount}");
    }

}