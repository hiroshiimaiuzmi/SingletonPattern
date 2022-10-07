namespace SingletonPattern;

public class Database
{
    private readonly string _connectionString;

    public Database(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task Connect(string client)
    {
        await Task.Delay(2500);
        Console.WriteLine($"{DateTime.UtcNow} - [{client}] Connected to Database.");
    }

    public async Task Disconnect()
    {
        await Task.Delay(2500);
        Console.WriteLine($"{DateTime.UtcNow} - Disconnected from Database.", ConsoleColor.Magenta);
    }
}