public class Expense{
    public string Title{get; set;}
    public double Amount{get; set;}
    public string Category{get; set;}

    public Expense(){
        Title = string.Empty;
        Category = string.Empty;
    }
    public Expense(string title, double amount, string category){
        Title = title;
        Amount = amount;
        Category = category;
    }

}