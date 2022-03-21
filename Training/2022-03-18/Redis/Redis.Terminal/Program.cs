// See https://aka.ms/new-console-template for more information


using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

IConfigurationRoot configuration;

Configure();

ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection"));

IDatabase database = connection.GetDatabase();

IServer server = connection.GetServer(connection.GetEndPoints()[0]);


while (true)
{
    Console.WriteLine("Enter command");

    string command = Console.ReadLine();

    switch (command)
    {
        case "list":
            ListKeys();
            break;
        case "get":
            GetData();
            break;
        case "set":
            SetData();
            break;
        case "del":
            DelData();
            break;
        case "e":
            Environment.Exit(Environment.ExitCode);
            break;
    }
}


void ListKeys()
{
    IEnumerable<RedisKey> keys = server.Keys();


    foreach (RedisKey redisKey in keys)
    {
        Console.WriteLine(redisKey);
    }

}

void SetData()
{
    Console.WriteLine("Enter key");
    string key = Console.ReadLine();

    Console.WriteLine("Enter value");
    string value = Console.ReadLine();

    bool isSuccess = database.StringSet(key, value);

    Console.WriteLine($"Data status : {isSuccess}");
}

void GetData()
{
    Console.WriteLine("Enter key");
    string key = Console.ReadLine();
    
    RedisValue value = database.StringGet(key);

    Console.WriteLine($"Data : {value}");
}


void DelData()
{
    Console.WriteLine("Enter key");
    string key = Console.ReadLine();

    bool isSuccess = database.KeyDelete(key);

    Console.WriteLine($"Data status : {isSuccess}");
}

void Configure()
{
    configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
        .AddJsonFile("appsettings.json", false)
        .Build();

    ServiceCollection serviceCollection = new ServiceCollection();

    serviceCollection.AddSingleton(configuration);

    IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

}