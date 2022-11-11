using System.Text.Json;
using System.Text.Json.Serialization;

using AdventureWork.Models;

using BenchmarkDotNet.Attributes;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Redis.Benchmark;

[HtmlExporter]
public class RedisVsSQL
{
    private ConnectionMultiplexer connection;
    private IDatabase database;

    public static JsonSerializerOptions options = new()
    {
        ReferenceHandler = ReferenceHandler.IgnoreCycles
    };
    public int[] resellerIds;

    public RedisVsSQL()
    {
        Configure();
        connection = ConnectionMultiplexer.Connect(CommonHelper.Configuration.GetConnectionString("RedisConnection"));
        database = connection.GetDatabase();
        using AdventureWorksDW2017Context context = new(CommonHelper.Configuration);

        resellerIds = context.DimResellers.Take(SQLHelper.TotalCount).Select(re => re.ResellerKey).ToArray();
    }

    #region One Element

    [Benchmark]
    public void RedisOneElement()
    {
        RedisValue redisValue = database.StringGet($"Reseller:{resellerIds[0]}");
        ReadOnlySpan<byte> byteArray = (byte[])redisValue;
        Reseller reseller = JsonSerializer.Deserialize<Reseller>(byteArray, options);
    }

    [Benchmark]
    public void RedisOneElementWithCompression()
    {
        RedisValue redisValue = database.StringGet($"ResellerCompress:{resellerIds[0]}");
        byte[] byteArray = (byte[])redisValue;
        byte[] decompressedData = CompressHelper.Decompress(byteArray);

        Reseller reseller = JsonSerializer.Deserialize<Reseller>(decompressedData, options);
    }

    [Benchmark]
    public void RedisOneElementWithoutConversion()
    {
        RedisValue redisValue = database.StringGet($"Reseller:{resellerIds[0]}");
    }

    [Benchmark]
    public void SQLOneElement()
    {
        Reseller reseller = SQLHelper.GetReseller(resellerIds[0]);
    }

    #endregion

    #region All Each Item

    [Benchmark]
    public void RedisAllEachItem()
    {
        foreach (int resellerId in resellerIds)
        {
            RedisValue redisValue = database.StringGet($"Reseller:{resellerId}".ToString());
            ReadOnlySpan<byte> byteArray = (byte[])redisValue;


            Reseller reseller = JsonSerializer.Deserialize<Reseller>(byteArray, options);
        }
    }

    [Benchmark]
    public void RedisAllEachItemWithCompression()
    {
        foreach (int resellerId in resellerIds)
        {
            RedisValue redisValue = database.StringGet($"ResellerCompress:{resellerId}".ToString());
            byte[] byteArray = (byte[])redisValue;
            byte[] decompressData = CompressHelper.Decompress(byteArray);


            Reseller reseller = JsonSerializer.Deserialize<Reseller>(decompressData, options);
        }
    }

    [Benchmark]
    public void RedisAllEachItemWithoutConversion()
    {
        foreach (int resellerId in resellerIds)
        {
            RedisValue redisValue = database.StringGet($"Reseller:{resellerId}".ToString());
        }
    }

    [Benchmark]
    public void SQLAllEachItem()
    {
        foreach (int resellerId in resellerIds)
        {
            Reseller reseller = SQLHelper.GetReseller(resellerId);
        }
    }

    #endregion

    #region All

    [Benchmark]
    public void RedisAll()
    {
        RedisValue redisValue = database.StringGet($"Reseller:All".ToString());
        ReadOnlySpan<byte> byteArray = (byte[])redisValue;

        List<Reseller> resellers = JsonSerializer.Deserialize<List<Reseller>>(byteArray, options);

    }

    [Benchmark]
    public void RedisAllWithCompression()
    {
        RedisValue redisValue = database.StringGet($"ResellerCompress:All".ToString());
        byte[] byteArray = (byte[])redisValue;
        byte[] decompressData = CompressHelper.Decompress(byteArray);


        List<Reseller> resellers = JsonSerializer.Deserialize<List<Reseller>>(decompressData, options);

    }

    [Benchmark]
    public void RedisAllWithoutConversion()
    {
        RedisValue redisValue = database.StringGet($"Reseller:All".ToString());
    }

    [Benchmark]
    public void SQLAll()
    {
        List<Reseller> reseller = SQLHelper.GetResellers();
    }

    #endregion

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
}