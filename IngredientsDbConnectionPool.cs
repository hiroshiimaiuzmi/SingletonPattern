namespace SingletonPattern;

public class IngredientsDbConnectionPool
{
    private readonly Database _database;
    private int _openConnections = 0;

    private IngredientsDbConnectionPool(Database database)
    {
        _database = database;
    }

    private static readonly Lazy<IngredientsDbConnectionPool> _instance
        = new(() =>
        {
            var database = new Database("database");
            return new IngredientsDbConnectionPool(database);
        });

    public static IngredientsDbConnectionPool Instance => _instance.Value;

    public async Task Connect(string client)
    {
        if (_openConnections >= 4)
        {
            Console.WriteLine("ERROR - Cannot acquire new connection. " +
                            $"Max connections of 4 " +
                            "is met or exceeded.");

            return;
        }

        _openConnections++;
        Console.WriteLine($"Added connection to pool from: {client}");
        await _database.Connect(client);
    }

    public async Task Disconnect()
    {
        if (_openConnections <= 0)
        {
            Console.WriteLine("There are no connections to close.");
            return;
        }

        _openConnections--;
        Console.WriteLine($"Released connection. Now managing ({_openConnections}) open connections.");
        await _database.Disconnect();
    }
}