// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using EF7;
using EF7.Models;
using Microsoft.EntityFrameworkCore;

using System.Linq;

BenchmarkRunner.Run<EF7Benchamrk>();
Console.ReadKey();

namespace EF7
{
    [MemoryDiagnoser, HtmlExporter, CsvExporter]
    public class EF7Benchamrk
    {
        private readonly int seed = 100;
        private int index = 1000;


        [Benchmark]
        public void FirstOrDefault()
        {
            AdventureWorksDW2017Context context = new AdventureWorksDW2017Context();
            for (int i = 0; i < seed; i++)
            {
                _ = context.DimCustomers.FirstOrDefault(); 
            }

        }

        [Benchmark]
        public void FirstOrDefaultAsNoTracking()
        {
            AdventureWorksDW2017Context context = new AdventureWorksDW2017Context();
            for (int i = 0; i < seed; i++)
            {
                _ = context.DimCustomers.AsNoTracking().FirstOrDefault(); 
            }

        }


        [Benchmark]
        public void List()
        {
            AdventureWorksDW2017Context context = new AdventureWorksDW2017Context();
            _ = context.DimCustomers.Take(10000).ToList();

        }


        [Benchmark]
        public void ListAsNoTracking()
        {
            AdventureWorksDW2017Context context = new AdventureWorksDW2017Context();
            _ = context.DimCustomers.Take(10000).AsNoTracking().ToList();

        }


        [Benchmark]
        public void Update()
        {
            AdventureWorksDW2017Context context = new AdventureWorksDW2017Context();
            _ = context.DimCustomers.Where(c=> c.FirstName.StartsWith("A")).ExecuteUpdate(e => e.SetProperty(c => c.YearlyIncome, c=> c.YearlyIncome +1000));
        }

        [Benchmark]
        public void Insert()
        {
            AdventureWorksDW2017Context context = new AdventureWorksDW2017Context();
            for (int i = 0; i < seed; i++)
            {
                _ = context.DimCustomers.Add(new DimCustomer() { FirstName = "Test", LastName = "Test", CustomerAlternateKey = "AW3009" + index++ });
                context.SaveChanges();
            }
        }


        [Benchmark]
        public void BulkInsert()
        {
            AdventureWorksDW2017Context context = new AdventureWorksDW2017Context();
            for (int i = 0; i < seed; i++)
            {
                _ = context.DimCustomers.Add(new DimCustomer() { FirstName = "Test", LastName = "Test", CustomerAlternateKey = "AW1000" + index++ });
            }
            context.SaveChanges();
        }

        [Benchmark]
        public void Delete()
        {
            DeleteSetup();
            AdventureWorksDW2017Context context = new AdventureWorksDW2017Context();
            _ = context.DimCustomers.Where(c => c.FirstName == "Test").ExecuteDelete();
        }

        
        public void DeleteSetup()
        {
            AdventureWorksDW2017Context context = new AdventureWorksDW2017Context();
            for (int i = 0; i < seed; i++)
            {
                _ = context.DimCustomers.Add(new DimCustomer() { FirstName = "Test", LastName = "Test", CustomerAlternateKey = "AW2000" + index++ });
            }
            context.SaveChanges();
        }
    }
}