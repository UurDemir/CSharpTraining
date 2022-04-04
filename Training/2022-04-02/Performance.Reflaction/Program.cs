// Author       : Nick Chapsas
// Youtube      : https://www.youtube.com/watch?v=er9nD-usM1A&ab_channel=NickChapsas


using System.Reflection;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<ReflectionBenchmark>();

public class ReflectionBenchmark
{
    [Benchmark]
    public void PropertyCalling()
    {
        ReflectionExample.PropertyCalling();
    }

    [Benchmark]
    public void TraditionalReflection()
    {
        ReflectionExample.TraditionalReflection();
    }


    [Benchmark]
    public void OptimizedTraditionalReflection()
    {
        ReflectionExample.OptimizedTraditionalReflection();
    }


    [Benchmark]
    public void CompiledGetterReflection()
    {
        ReflectionExample.CompiledGetterReflection();
    }
}

public class ReflectionExample
{
    public static string PropertyCalling()
    {
        var container = new SecretsContainer();

        return container.RevealedTruth;
    }

    public static string TraditionalReflection()
    {
        var container = new SecretsContainer();

        var propertyInfo = container.GetType()
            .GetProperty("Secret", BindingFlags.Instance | BindingFlags.NonPublic);

        var value = propertyInfo!.GetValue(container);

        return value!.ToString() ?? string.Empty;
    }

    private static readonly PropertyInfo SecretPropertyInfo = typeof(SecretsContainer)
        .GetProperty("Secret", BindingFlags.Instance | BindingFlags.NonPublic)!;

    public static string OptimizedTraditionalReflection()
    {
        var container = new SecretsContainer();

        var value = SecretPropertyInfo.GetValue(container);

        return value!.ToString() ?? string.Empty;
    }

    private static readonly Func<SecretsContainer, string> SecretPropertyGetter =
        (Func<SecretsContainer, string>)
            typeof(SecretsContainer)
                .GetMethod("get_Secret", BindingFlags.Instance | BindingFlags.NonPublic)!
                .CreateDelegate(typeof(Func<SecretsContainer, string>));


    public static string CompiledGetterReflection()
    {
        var container = new SecretsContainer();

        var value = SecretPropertyGetter(container);

        return value;
    }
}


public class SecretsContainer
{
    private string Secret { get; set; } = "Earth is flat!";

    public string RevealedTruth => Secret;
}

