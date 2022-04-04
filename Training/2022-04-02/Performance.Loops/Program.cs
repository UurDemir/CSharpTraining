using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<ForeachVsForBenchmark>();

[MemoryDiagnoser, HtmlExporter, CsvExporter]
public class ForeachVsForBenchmark
{
    [Benchmark]
    public void ForInt()
    {
        for (int i = 0; i < Utilities.ArrayNumber; i++)
        {
            _ = Utilities.NumberList[i];
        }
    }

    [Benchmark]
    public void ForeachInt()
    {
        foreach (var listItem in Utilities.NumberList)
        {
            _ = listItem;
        }
    }

    [Benchmark]
    public void ForPoint()
    {
        for (int i = 0; i < Utilities.ArrayNumber; i++)
        {
            _ = Utilities.PointList[i];
        }
    }

    [Benchmark]
    public void ForeachPoint()
    {
        foreach (var listItem in Utilities.PointList)
        {
            _ = listItem;
        }
    }

    [Benchmark]
    public void ForPerson()
    {
        for (int i = 0; i < Utilities.ArrayNumber; i++)
        {
            _ = Utilities.PersonList[i];
        }
    }

    [Benchmark]
    public void ForeachPerson()
    {
        foreach (var listItem in Utilities.PersonList)
        {
            _ = listItem;
        }
    }


    [Benchmark]
    public void ForIntAdd()
    {
        var list = new List<int>(Utilities.ArrayNumber);
        for (int i = 0; i < Utilities.ArrayNumber; i++)
        {
            list.Add(Utilities.NumberList[i]);
        }
    }

    [Benchmark]
    public void ForeachIntAdd()
    {
        var list = new List<int>(Utilities.ArrayNumber);
        foreach (var listItem in Utilities.NumberList)
        {
            list.Add(listItem);
        }
    }

    [Benchmark]
    public void ForPointAdd()
    {
        var list = new List<Point>(Utilities.ArrayNumber);
        for (int i = 0; i < Utilities.ArrayNumber; i++)
        {
            list.Add(Utilities.PointList[i]);
        }
    }

    [Benchmark]
    public void ForeachPointAdd()
    {
        var list = new List<Point>(Utilities.ArrayNumber);
        foreach (var listItem in Utilities.PointList)
        {
            list.Add(listItem);
        }
    }

    [Benchmark]
    public void ForPersonAdd()
    {
        var list = new List<Person>(Utilities.ArrayNumber);
        for (int i = 0; i < Utilities.ArrayNumber; i++)
        {
            list.Add(Utilities.PersonList[i]);
        }
    }

    [Benchmark]
    public void ForeachPersonAdd()
    {
        var list = new List<Person>(Utilities.ArrayNumber);
        foreach (var listItem in Utilities.PersonList)
        {
            list.Add(listItem);
        }
    }


}

public struct Point
{
    public int X { get; set; }
    public int Y { get; set; }
}

public class Person
{
    public string Name { get; set; }
    public DateTime Birthdate { get; set; }
    public int Age { get; set; }
}

public class Utilities
{
    public const int ArrayNumber = 1000;

    public static List<int> NumberList = Enumerable.Range(1, ArrayNumber).ToList();
    public static List<Point> PointList = new List<Point>(ArrayNumber);
    public static List<Person> PersonList = new List<Person>(ArrayNumber);

    static Utilities()
    {
        for (int i = 0; i < ArrayNumber; i++)
        {
            PointList.Add(new Point { X = i, Y = i });
            PersonList.Add(new Person { Name = "Person" + i, Age = i, Birthdate = DateTime.Now });
        }
    }
}