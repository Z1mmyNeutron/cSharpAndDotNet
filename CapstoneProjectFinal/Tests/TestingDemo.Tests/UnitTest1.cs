using CapstoneFinalProject;

namespace TestingDemo.Tests;

public class ExpenseManagerTests
{
    private static ExpenseManager CreateManagerWithSampleData()
    {
        var manager = new ExpenseManager();
        manager.AddExpense(new Expense("Groceries", 50m, "Food", new DateTime(2026, 1, 5)));
        manager.AddExpense(new Expense("Electric Bill", 120m, "Utilities", new DateTime(2026, 1, 10)));
        manager.AddExpense(new Expense("Movie Night", 30m, "Entertainment", new DateTime(2026, 1, 15)));
        manager.AddExpense(new Expense("Rent", 800m, "Housing", new DateTime(2026, 1, 1)));
        return manager;
    }

    [Fact]
    public void AddExpense_IncreasesExpenseCount()
    {
        var manager = new ExpenseManager();

        manager.AddExpense(new Expense("Coffee", 5m, "Food", DateTime.Today));

        Assert.Single(manager.GetExpenses());
    }

    [Fact]
    public void AddExpense_ThrowsInvalidExpenseException_WhenTitleIsEmpty()
    {
        Assert.Throws<InvalidExpenseException>(() =>
            new Expense(string.Empty, 10m, "Food", DateTime.Today));
    }

    [Fact]
    public void AddExpense_ThrowsInvalidExpenseException_WhenAmountIsNotPositive()
    {
        Assert.Throws<InvalidExpenseException>(() =>
            new Expense("Snack", 0m, "Food", DateTime.Today));
    }

    [Fact]
    public void AddExpense_ThrowsInvalidExpenseException_WhenCategoryIsEmpty()
    {
        Assert.Throws<InvalidExpenseException>(() =>
            new Expense("Snack", 5m, string.Empty, DateTime.Today));
    }

    [Fact]
    public void CalculateTotalExpenses_ReturnsSumOfAllAmounts()
    {
        var manager = CreateManagerWithSampleData();

        decimal total = manager.CalculateTotalExpenses();

        Assert.Equal(1000m, total);
    }

    [Fact]
    public void CalculateAverageExpense_ReturnsCorrectAverage()
    {
        var manager = CreateManagerWithSampleData();

        decimal average = manager.CalculateAverageExpense();

        Assert.Equal(250m, average);
    }

    [Fact]
    public void CalculateAverageExpense_ReturnsZero_WhenNoExpenses()
    {
        var manager = new ExpenseManager();

        decimal average = manager.CalculateAverageExpense();

        Assert.Equal(0m, average);
    }

    [Fact]
    public void SearchExpenses_ByKeyword_ReturnsMatchingExpenses()
    {
        var manager = CreateManagerWithSampleData();

        var results = manager.SearchExpenses("electric");

        Assert.Single(results);
        Assert.Equal("Electric Bill", results[0].Title);
    }

    [Fact]
    public void SearchExpenses_ByAmountRange_ReturnsExpensesWithinRange()
    {
        var manager = CreateManagerWithSampleData();

        var results = manager.SearchExpenses(20m, 100m);

        Assert.Equal(2, results.Count);
        Assert.Contains(results, e => e.Title == "Groceries");
        Assert.Contains(results, e => e.Title == "Movie Night");
    }

    [Fact]
    public void SearchExpenses_ByDateRange_ReturnsExpensesWithinRange()
    {
        var manager = CreateManagerWithSampleData();

        var results = manager.SearchExpenses(new DateTime(2026, 1, 1), new DateTime(2026, 1, 5));

        Assert.Equal(2, results.Count);
    }

    [Fact]
    public void FilterByCategory_ReturnsOnlyMatchingCategory()
    {
        var manager = CreateManagerWithSampleData();

        var results = manager.FilterByCategory("Food");

        Assert.Single(results);
        Assert.Equal("Groceries", results[0].Title);
    }

    [Fact]
    public void FilterByCategory_IsCaseInsensitive()
    {
        var manager = CreateManagerWithSampleData();

        var results = manager.FilterByCategory("food");

        Assert.Single(results);
    }

    [Fact]
    public void GetHighestExpense_ReturnsExpenseWithLargestAmount()
    {
        var manager = CreateManagerWithSampleData();

        var highest = manager.GetHighestExpense();

        Assert.NotNull(highest);
        Assert.Equal("Rent", highest!.Title);
    }

    [Fact]
    public void GetLowestExpense_ReturnsExpenseWithSmallestAmount()
    {
        var manager = CreateManagerWithSampleData();

        var lowest = manager.GetLowestExpense();

        Assert.NotNull(lowest);
        Assert.Equal("Movie Night", lowest!.Title);
    }

    [Fact]
    public void GroupByCategory_SumsAmountsPerCategory()
    {
        var manager = CreateManagerWithSampleData();
        manager.AddExpense(new Expense("Takeout", 25m, "Food", DateTime.Today));

        var grouped = manager.GroupByCategory();

        Assert.Equal(75m, grouped["Food"]);
    }

    [Fact]
    public void RemoveExpense_RemovesFromCollection()
    {
        var manager = new ExpenseManager();
        var expense = new Expense("Coffee", 5m, "Food", DateTime.Today);
        manager.AddExpense(expense);

        bool removed = manager.RemoveExpense(expense);

        Assert.True(removed);
        Assert.Empty(manager.GetExpenses());
    }

    [Fact]
    public void RecurringExpense_DisplayInfo_IncludesFrequencyAndNextDueDate()
    {
        var recurring = new RecurringExpense(
            "Streaming Subscription", 15m, "Entertainment", DateTime.Today,
            "Monthly", DateTime.Today.AddMonths(1));

        string display = recurring.DisplayInfo();

        Assert.Contains("Recurring: Monthly", display);
    }
}
