using System.Text.Json;

namespace CapstoneFinalProject;

public static class FileService
{
    private static readonly JsonSerializerOptions Options = new()
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true
    };

    public static async Task SaveExpensesAsync(List<Expense> expenses, string filePath)
    {
        try
        {
            string? directory = Path.GetDirectoryName(filePath);
            if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string json = JsonSerializer.Serialize(expenses, Options);
            await File.WriteAllTextAsync(filePath, json);
            Console.WriteLine($"Expenses saved successfully to {filePath}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving expenses: {ex.Message}");
        }
    }

    public static async Task<List<Expense>> LoadExpensesAsync(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("No saved expense file found. Starting with an empty list.");
            return new List<Expense>();
        }

        try
        {
            Console.WriteLine("Loading expenses...");
            string json = await File.ReadAllTextAsync(filePath);

            if (string.IsNullOrWhiteSpace(json))
            {
                Console.WriteLine("Expense file is empty. Starting with an empty list.");
                return new List<Expense>();
            }

            List<Expense>? expenses = JsonSerializer.Deserialize<List<Expense>>(json, Options);
            Console.WriteLine("Expenses loaded successfully.");
            return expenses ?? new List<Expense>();
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"The expense file appears to be corrupted and could not be read: {ex.Message}");
            return new List<Expense>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading expenses: {ex.Message}");
            return new List<Expense>();
        }
    }
}
