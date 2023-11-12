using Microsoft.AspNetCore.Mvc;

using Serilog;

using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration
    .Enrich.FromLogContext()
    .WriteTo.Elasticsearch(new Serilog.Sinks.Elasticsearch.ElasticsearchSinkOptions(new Uri("http://host.docker.internal:9200"))
    {
        AutoRegisterTemplate = true,
        IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower()}-{DateTime.UtcNow:yyyy-MM}"
    })
    .ReadFrom.Configuration(builder.Configuration);
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", ([FromServices] ILogger<WeatherForecast> logger) =>
{
    logger.LogInformation("Getting weatherforecasts Date : {FetchDate}", DateTime.Now);
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapGet("/givemeerror", ([FromServices] ILogger<Program> logger) =>
{
    throw new Exception("This is your error", new Exception("This is your inner self"));
})
    .WithName("GiveMeError")
    .WithOpenApi();

app.MapGet("/validate", ([FromServices] ILogger<Program> logger, string userName, string password) =>
{
    if (userName == "log" && password == "ging")
    {
        logger.LogInformation("Authentication is valid");
    }
    else
    {
        logger.LogError("Authentication is invalid");
    }
})
    .WithName("Validate")
    .WithOpenApi();


app.MapGet("/havecontext", ([FromServices] ILogger<Program> logger, string userName, int age, string name, string surname) =>
{
    var scope = logger.BeginScope("Processing the user {UserName}", userName);
    logger.LogInformation("Age calculation {Age}", age);
    logger.LogInformation("Changing name {Name}", name);
    logger.LogInformation("Getting married {Surname}", surname);

})
    .WithName("HaveContext")
    .WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
