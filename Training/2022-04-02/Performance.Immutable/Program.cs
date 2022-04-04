// See https://aka.ms/new-console-template for more information

using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run(typeof(StringWithLessTextBenchmark).Assembly);

[MemoryDiagnoser, HtmlExporter, CsvExporter]
public class StringWithLessTextBenchmark
{
    private const int Repetitions = 10;
    private const string Name = "Shepard";
    private const string Age = "36";

    [Benchmark]
    public void StringWithClassic()
    {
        for (int i = 0; i < Repetitions; i++)
        {
            string text = "Happy Birthday Mr. " + Name + " you're now " + Age; 
        }
    }
    
    [Benchmark]
    public void StringWithFormat()
    {
        for (int i = 0; i < Repetitions; i++)
        {
            string text = string.Format("Happy Birthday Mr. {0} you're now {1}", Name, Age); 
        }
    }

    [Benchmark]
    public void StringWithInterpolation()
    {
        for (int i = 0; i < Repetitions; i++)
        {
            string text = $"Happy Birthday Mr. {Name} you're now {Age}"; 
        }
    }

    [Benchmark]
    public void StringWithBuilder()
    {
        for (int i = 0; i < Repetitions; i++)
        {
            StringBuilder sb = new();
            sb.Append("Happy Birthday Mr. ");
            sb.Append(Name);
            sb.Append(" you're now ");
            sb.Append(Age);
            string text = sb.ToString();
        }
    }

    [Benchmark]
    public void StringWithBuilderSingleInstance()
    {
        StringBuilder sb = new();
        for (int i = 0; i < Repetitions; i++)
        {
            sb.Append("Happy Birthday Mr. ");
            sb.Append(Name);
            sb.Append(" you're now ");
            sb.Append(Age);
            string text = sb.ToString();
            sb.Clear();
        }
    }

    [Benchmark]
    public void StringWithBuilderCapacity()
    {
        for (int i = 0; i < Repetitions; i++)
        {
            StringBuilder sb = new(45);
            sb.Append("Happy Birthday Mr. ");
            sb.Append(Name);
            sb.Append(" you're now ");
            sb.Append(Age);
            string text = sb.ToString();
        }
    }

    [Benchmark]
    public void StringWithBuilderSingleInstanceCapacity()
    {
        StringBuilder sb = new(45);
        for (int i = 0; i < Repetitions; i++)
        {
            sb.Append("Happy Birthday Mr. ");
            sb.Append(Name);
            sb.Append(" you're now ");
            sb.Append(Age);
            string text = sb.ToString();
            sb.Clear();
        }
    }
}

[MemoryDiagnoser, HtmlExporter, CsvExporter]
public class StringWithMoreTextBenchmark
{
    private const int Repetitions = 10;
    private const string Name = "Shepard";

    [Benchmark]
    public void StringWithClassic()
    {
        string text = string.Empty;
        for (int i = 0; i < Repetitions; i++)
        {
            text += "My Name is "+Name;
        }
    }

    [Benchmark]
    public void StringWithFormat()
    {
        string text = string.Empty;
        for (int i = 0; i < Repetitions; i++)
        {
            text += string.Format("My Name is {0}", Name);
        }
    }

    [Benchmark]
    public void StringWithInterpolation()
    {
        string text = string.Empty;
        for (int i = 0; i < Repetitions; i++)
        {
             text += $"My Name is {Name}";
        }
    }

    [Benchmark]
    public void StringWithBuilder()
    {
        StringBuilder sb = new();
        for (int i = 0; i < Repetitions; i++)
        {
            sb.Append("My Name is ");
            sb.Append(Name);
        }
        string text = sb.ToString();
    }
    

    [Benchmark]
    public void StringWithBuilderCapacity()
    {
        StringBuilder sb = new(45* Repetitions);
        for (int i = 0; i < Repetitions; i++)
        {
            sb.Append("My Name is ");
            sb.Append(Name);
        }
        string text = sb.ToString();
    }
}

[MemoryDiagnoser, HtmlExporter, CsvExporter]
public class StringWithLessTextMoreRepeatBenchmark
{
    private const int Repetitions = 10_000;
    private const string Name = "Shepard";
    private const string Age = "36";

    [Benchmark]
    public void StringWithClassic()
    {
        for (int i = 0; i < Repetitions; i++)
        {
            string text = "Happy Birthday Mr. " + Name + " you're now " + Age;
        }
    }

    [Benchmark]
    public void StringWithFormat()
    {
        for (int i = 0; i < Repetitions; i++)
        {
            string text = string.Format("Happy Birthday Mr. {0} you're now {1}", Name, Age);
        }
    }

    [Benchmark]
    public void StringWithInterpolation()
    {
        for (int i = 0; i < Repetitions; i++)
        {
            string text = $"Happy Birthday Mr. {Name} you're now {Age}";
        }
    }

    [Benchmark]
    public void StringWithBuilder()
    {
        for (int i = 0; i < Repetitions; i++)
        {
            StringBuilder sb = new();
            sb.Append("Happy Birthday Mr. ");
            sb.Append(Name);
            sb.Append(" you're now ");
            sb.Append(Age);
            string text = sb.ToString();
        }
    }

    [Benchmark]
    public void StringWithBuilderSingleInstance()
    {
        StringBuilder sb = new();
        for (int i = 0; i < Repetitions; i++)
        {
            sb.Append("Happy Birthday Mr. ");
            sb.Append(Name);
            sb.Append(" you're now ");
            sb.Append(Age);
            string text = sb.ToString();
            sb.Clear();
        }
    }

    [Benchmark]
    public void StringWithBuilderCapacity()
    {
        for (int i = 0; i < Repetitions; i++)
        {
            StringBuilder sb = new(45);
            sb.Append("Happy Birthday Mr. ");
            sb.Append(Name);
            sb.Append(" you're now ");
            sb.Append(Age);
            string text = sb.ToString();
        }
    }

    [Benchmark]
    public void StringWithBuilderSingleInstanceCapacity()
    {
        StringBuilder sb = new(45);
        for (int i = 0; i < Repetitions; i++)
        {
            sb.Append("Happy Birthday Mr. ");
            sb.Append(Name);
            sb.Append(" you're now ");
            sb.Append(Age);
            string text = sb.ToString();
            sb.Clear();
        }
    }
}

[MemoryDiagnoser, HtmlExporter, CsvExporter]
public class StringWithMoreTextMoreRepeatBenchmark
{
    private const int Repetitions = 10_000;
    private const string Name = "Shepard";

    [Benchmark]
    public void StringWithClassic()
    {
        string text = string.Empty;
        for (int i = 0; i < Repetitions; i++)
        {
            text += "My Name is " + Name;
        }
    }

    [Benchmark]
    public void StringWithFormat()
    {
        string text = string.Empty;
        for (int i = 0; i < Repetitions; i++)
        {
            text += string.Format("My Name is {0}", Name);
        }
    }

    [Benchmark]
    public void StringWithInterpolation()
    {
        string text = string.Empty;
        for (int i = 0; i < Repetitions; i++)
        {
            text += $"My Name is {Name}";
        }
    }

    [Benchmark]
    public void StringWithBuilder()
    {
        StringBuilder sb = new();
        for (int i = 0; i < Repetitions; i++)
        {
            sb.Append("My Name is ");
            sb.Append(Name);
        }
        string text = sb.ToString();
    }


    [Benchmark]
    public void StringWithBuilderCapacity()
    {
        StringBuilder sb = new(45 * Repetitions);
        for (int i = 0; i < Repetitions; i++)
        {
            sb.Append("My Name is ");
            sb.Append(Name);
        }
        string text = sb.ToString();
    }
}

[MemoryDiagnoser, HtmlExporter, CsvExporter]
public class StringSubstringBenchmark
{
    private const int Repetitions = 1_000;

    [Benchmark]
    public void StringSubstringWithClassic()
    {
        string text = "Hi! My Name is Dom Thompson and instead of letter 'O' I'm using Donuts!";
        for (int i = 0; i < Repetitions; i++)
        {
            string newText = text.Substring(0, 10);
        }
    }

    [Benchmark]
    public void StringSubstringWithSpan()
    {
        Span<char> text = "Hi! My Name is Dom Thompson and instead of letter 'O' I'm using Donuts!".ToCharArray();
        for (int i = 0; i < Repetitions; i++)
        {
            Span<char> newText = text.Slice(0, 10);
        }
    }
    
}