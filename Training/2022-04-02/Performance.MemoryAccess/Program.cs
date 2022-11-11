using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Performance.MemoryAccess;

BenchmarkRunner.Run<MemoryBenchmark>();

namespace Performance.MemoryAccess
{
    [MemoryDiagnoser, HtmlExporter, CsvExporter]
    public class MemoryBenchmark
    {
        private const int RepeatCount = 1000;
        private int[][] mapping;

        public MemoryBenchmark()
        {
            mapping = new int[RepeatCount][];
            for (int i = 0; i < RepeatCount; i++)
            {
                mapping[i] = Enumerable.Range(0, RepeatCount).ToArray();
            }
        }
    
        [Benchmark]
        public void WithNew()
        {
            VectorStruct[] vectors = new VectorStruct[RepeatCount];
            for (int i = 0; i < RepeatCount; i++)
            {
                vectors[i].X = 5;
                vectors[i].Y = 10;
            }
        }
    
        [Benchmark]
        public unsafe void WithStackAlloc() 
        {
            VectorStruct* vectors = stackalloc VectorStruct[RepeatCount];
            for (int i = 0; i < RepeatCount; i++)
            {
                vectors[i].X = 5;
                vectors[i].Y = 10;
            }
        }
    
        [Benchmark]
        public void WithStackAllocSpan()
        {
            Span<VectorStruct> vectors = stackalloc VectorStruct[RepeatCount];
            for (int i = 0; i < RepeatCount; i++)
            {
                vectors[i].X = 5;
                vectors[i].Y = 10;
            }
        }

        [Benchmark]
        public void RunColumnFirst()
        {
            int result = 0;
            for (int i = 0; i < mapping.Length; i++)
            {
                for (int n = 0; n < mapping.Length; n++)
                {
                    if (mapping[n][i] > 0)
                    {
                        result++;
                    }
                }
            }   
        }

        [Benchmark]
        public void RunRowFirst()
        {
            int result = 0;
            for (int i = 0; i < mapping.Length; i++)
            {
                for (int n = 0; n < mapping.Length; n++)
                {
                    if (mapping[i][ n] > 0)
                    {
                        result++;
                    }
                }
            }
        }

    }

    struct VectorStruct
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}