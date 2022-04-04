// See https://aka.ms/new-console-template for more information


using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;



BenchmarkRunner.Run<ClassVsStructBenchmark>();




[MemoryDiagnoser, HtmlExporter, CsvExporter]
public class ClassVsStructBenchmark
{
    private const int ItemSize = 10;

    [Benchmark]
    public void RunArrayWithClass()
    {
        PointClass[] points = new PointClass[ItemSize];
        for (int i = 0; i < ItemSize; i++)
        {
            points[i] = new()
            {
                X = i,
                Y = i+1
            };
        }   

    }


    [Benchmark]
    public void RunArrayWithStruct()
    {
        PointStruct[] points = new PointStruct[ItemSize];
        for (int i = 0; i < ItemSize; i++)
        {
            points[i].X = i;
            points[i].Y = i + 1;
        }

    }


    [Benchmark]
    public void RunWithClass()
    {
        for (int i = 0; i < ItemSize; i++)
        {
            PointClass point = new()
            {
                X = i,
                Y = i + 1
            };
        }

    }


    [Benchmark]
    public void RunWithStruct()
    {
        for (int i = 0; i < ItemSize; i++)
        {
            PointStruct point = default;
            point.X = i;
            point.Y = i + 1;
        }

    }
}

class PointClass
{
    public int X { get; set; }
    public int Y { get; set; }
}


// Recomended using the following code when size does not exceed 16 byte which equals to 4 ints
struct PointStruct
{
    public int X { get; set; }
    public int Y { get; set; }
}