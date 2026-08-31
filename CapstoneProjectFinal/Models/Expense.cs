namespace CapstoneFinalProject;
public class Expense{

    public string Title{get; set;}
    public double Amount{get; set;}
    public string Category{get; set;}
    public DateTime Day{get; set;}

    public Expense(string title, double amount, string category, DateTime day){
        Title = title;
        Amount = amount;
        Category = category;
        Day = day;

    }

}