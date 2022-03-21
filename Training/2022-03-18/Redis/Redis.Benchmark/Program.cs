using System.Text.Json;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Redis.Benchmark;

using StackExchange.Redis;



//Configure program to use appsettings.json for configurations
Configure();

// Prepare Redis data
PrepareRedis();

//Run Benchmark
BenchmarkRunner.Run<RedisVsSQL>();


/// <summary>
/// Fetch data from SQL and add to Redis to run Benchmark
/// </summary>
void PrepareRedis()
{
    Console.WriteLine("Retrieving Data");

    List<Reseller> resellers = SQLHelper.GetResellers();

    using ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(CommonHelper.Configuration.GetConnectionString("RedisConnection"));

    IDatabase database = connection.GetDatabase();
    
    Console.WriteLine("Reseller Count : " + resellers.Count);

    for (var index = 1; index <= resellers.Count; index++)
    {
        Reseller reseller = resellers[index-1];
        //database.KeyDelete($"Reseller:{reseller.ResellerCode}");

        byte[] byteData = JsonSerializer.SerializeToUtf8Bytes(reseller, RedisVsSQL.options);
        byte[] compressData = CompressHelper.Compress(byteData);


        database.StringSet($"Reseller:{reseller.ResellerKey}", byteData
            );

        database.StringSet($"ResellerCompress:{reseller.ResellerKey}", compressData
        );

        if (index % 200 == 0)
            Thread.Sleep(10000);
    }

    Console.WriteLine("Individual Items Finish");

    var data = JsonSerializer.SerializeToUtf8Bytes(resellers, RedisVsSQL.options);
    byte[] compressAllData = CompressHelper.Compress(data);

    database.StringSet($"Reseller:All", data);
    database.StringSet($"ResellerCompress:All", compressAllData);
    Console.WriteLine("All Items Finish");
}

/// <summary>
/// Configure IConfigurationRoot to use appsettings.json
/// </summary>
void Configure()
{
    CommonHelper.Configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetParent(AppContext.BaseDirectory)!.FullName)
        .AddJsonFile("appsettings.json", false)
        .Build();

    ServiceCollection serviceCollection = new();

    serviceCollection.AddSingleton(CommonHelper.Configuration);

    IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

}