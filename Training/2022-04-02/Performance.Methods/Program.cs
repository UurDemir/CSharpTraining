// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

BenchmarkRunner.Run<MethodBenchmark>();



[MemoryDiagnoser, HtmlExporter, CsvExporter]
public class MethodBenchmark
{
    private const string Drive = "Z:";
    
    [Benchmark]
    public void MethodWithParameters()
    {
        MethodExamples.MethodWithParameters("John", "Doe", DateTime.Now, "Programmer", "Green", 146.1, "Happy");
    }

    [Benchmark]
    public void MethodWithClass()
    {
        Person person = new Person("John", "Doe", DateTime.Now, "Programmer", "Green", 146.1, "Happy");

        MethodExamples.MethodWithClass(person);
    }
    [Benchmark]
    public void MethodWithNothing()
    {
        MethodExamples.MethodWithNothing(Drive);
    }

    [Benchmark]
    public void MethodWithAggressiveInlining()
    {
        MethodExamples.MethodWithAggressiveInlining(Drive);
    }
    [Benchmark]
    public void MethodWithAggressiveOptimization()
    {
        MethodExamples.MethodWithAggressiveOptimization(Drive);
    }

    [Benchmark]
    public void MethodWithAggressiveOptimizationAndAggressiveInlining()
    {
        MethodExamples.MethodWithAggressiveOptimizationAndAggressiveInlining(Drive);
    }

}


public static class MethodExamples
{
    private const string SelectedDrive = "Z:";
    public static void MethodWithParameters(string name, string surname, DateTime birthDate, string job, string eyeColor, double weight, string mood)
    {
        // string message = $"{name} {surname} was born on {birthDate} and is a {job} with {eyeColor} eyes and {weight} weight and {mood} mood.";
    }
    public static void MethodWithClass(Person person)
    {
        // string message = $"{person.Name} {person.Surname} was born on {person.BirthDate} and is a {person.Job} with {person.EyeColor} eyes and {person.Weight} weight and {person.Mood} mood.";
    }
    
    public static bool MethodWithNothing(string driveWithColon)
    {
        if (SelectedDrive.Length == 2 && SelectedDrive[1] == ':')
        {
            driveWithColon = driveWithColon.ToUpper();
            // this is surprisingly faster than the equivalent if statement
            switch (driveWithColon[0])
            {
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                case 'G':
                case 'H':
                case 'I':
                case 'J':
                case 'K':
                case 'L':
                case 'M':
                case 'N':
                case 'O':
                case 'P':
                case 'Q':
                case 'R':
                case 'S':
                case 'T':
                case 'U':
                case 'V':
                case 'W':
                case 'X':
                case 'Y':
                case 'Z':
                    return true;
                default:
                    return false;
            }
        }
        else
            return false;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool MethodWithAggressiveInlining(string driveWithColon)
    {
        if (SelectedDrive.Length == 2 && SelectedDrive[1] == ':')
        {
            driveWithColon = driveWithColon.ToUpper();
            // this is surprisingly faster than the equivalent if statement
            switch (driveWithColon[0])
            {
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                case 'G':
                case 'H':
                case 'I':
                case 'J':
                case 'K':
                case 'L':
                case 'M':
                case 'N':
                case 'O':
                case 'P':
                case 'Q':
                case 'R':
                case 'S':
                case 'T':
                case 'U':
                case 'V':
                case 'W':
                case 'X':
                case 'Y':
                case 'Z':
                    return true;
                default:
                    return false;
            }
        }
        else
            return false;
    }

    [MethodImpl(MethodImplOptions.AggressiveOptimization)]
    public static bool MethodWithAggressiveOptimization(string driveWithColon)
    {
        if (SelectedDrive.Length == 2 && SelectedDrive[1] == ':')
        {
            driveWithColon = driveWithColon.ToUpper();
            // this is surprisingly faster than the equivalent if statement
            switch (driveWithColon[0])
            {
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                case 'G':
                case 'H':
                case 'I':
                case 'J':
                case 'K':
                case 'L':
                case 'M':
                case 'N':
                case 'O':
                case 'P':
                case 'Q':
                case 'R':
                case 'S':
                case 'T':
                case 'U':
                case 'V':
                case 'W':
                case 'X':
                case 'Y':
                case 'Z':
                    return true;
                default:
                    return false;
            }
        }
        else
            return false;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static bool MethodWithAggressiveOptimizationAndAggressiveInlining(string driveWithColon)
    {
        if (SelectedDrive.Length == 2 && SelectedDrive[1] == ':')
        {
            driveWithColon = driveWithColon.ToUpper();
            // this is surprisingly faster than the equivalent if statement
            switch (driveWithColon[0])
            {
                case 'A':
                case 'B':
                case 'C':
                case 'D':
                case 'E':
                case 'F':
                case 'G':
                case 'H':
                case 'I':
                case 'J':
                case 'K':
                case 'L':
                case 'M':
                case 'N':
                case 'O':
                case 'P':
                case 'Q':
                case 'R':
                case 'S':
                case 'T':
                case 'U':
                case 'V':
                case 'W':
                case 'X':
                case 'Y':
                case 'Z':
                    return true;
                default:
                    return false;
            }
        }
        else
            return false;
    }
}

public struct Person
{
    public Person(string name, string surname, DateTime birthDate, string job, string eyeColor, double weight, string mood)
    {
        Name = name;
        Surname = surname;
        BirthDate = birthDate;
        Job = job;
        EyeColor = eyeColor;
        Weight = weight;
        Mood = mood;
    }

    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime BirthDate { get; set; }
    public string Job { get; set; }
    public string EyeColor { get; set; }
    public double Weight { get; set; }
    public string Mood { get; set; }
}