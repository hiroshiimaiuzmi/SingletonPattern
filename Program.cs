using SingletonPattern;

const string EastClientId = "US-East";
const string WestClientId = "US-West";
const string NorthClientId = "US-North";
const string SouthClientId = "US-South";

Console.WriteLine("🥦 Connecting to ingredients db...");

var eastClient = IngredientsDbConnectionPool.Instance;
var westClient = IngredientsDbConnectionPool.Instance;
var northClient = IngredientsDbConnectionPool.Instance;
var southClient = IngredientsDbConnectionPool.Instance;

await eastClient.Connect(EastClientId);
await westClient.Connect(WestClientId);
await northClient.Connect(NorthClientId);
await southClient.Connect(SouthClientId);

await northClient.Disconnect();
await southClient.Connect(SouthClientId);

await northClient.Disconnect();
await northClient.Disconnect();
await northClient.Disconnect();
await northClient.Disconnect();

Console.WriteLine("🥦  Session complete!");