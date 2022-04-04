// See https://aka.ms/new-console-template for more information

using System.Buffers;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<ListAndArrayBenchmark>();

[MemoryDiagnoser, HtmlExporter, CsvExporter]
public class ListAndArrayBenchmark
{
    private const int ArraySize = 1000;
    private IEnumerable<int> createdNumbers;

    public ListAndArrayBenchmark()
    {
        createdNumbers = Enumerable.Range(0, ArraySize);
    }

    [Benchmark]
    public void ListAdd()
    {
        List<int> list = new();
        for (int i = 0; i < ArraySize; i++)
        {
            list.Add(i);
        }
    }

    [Benchmark]
    public void ListAddRange()
    {
        List<int> list = new();
        list.AddRange(createdNumbers);

    }

    [Benchmark]
    public void ListWithCapacityAdd()
    {
        List<int> list = new(ArraySize);
        for (int i = 0; i < ArraySize; i++)
        {
            list.Add(i);
        }
    }

    [Benchmark]
    public void ListWithCapacityAddRange()
    {
        List<int> list = new(ArraySize);
        list.AddRange(createdNumbers);

    }

    [Benchmark]
    // Only for short-lived arrays and it's size bigger 100
    public void SharedArrayAdd()
    {
        ArrayPool<int> arrayPool = ArrayPool<int>.Shared;
        
        int[] array = arrayPool.Rent(ArraySize);
        
        for (int i = 0; i < ArraySize; i++)
        {
            array[i] = i;
        }

        arrayPool.Return(array);
    }

    [Benchmark]
    public void ArrayWithCapacityAdd()
    {
        int[] array = new int[ArraySize];
        for (int i = 0; i < ArraySize; i++)
        {
            array[i] = i;
        }
    }

    [Benchmark]
    public void ArrayWithoutCapacityIncreaseByOneAdd()
    {
        int[] array = new int[4];
        for (int i = 0; i < ArraySize; i++)
        {
            if (i >= array.Length)
            {
                Array.Resize(ref array, array.Length +1);
            }

            array[i] = i;
        }
    }

    [Benchmark]
    public void ArrayWithoutCapacityAdd()
    {
        int[] array = new int[4];
        for (int i = 0; i < ArraySize; i++)
        {
            if (i >= array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }

            array[i] = i;
        }
    }

}