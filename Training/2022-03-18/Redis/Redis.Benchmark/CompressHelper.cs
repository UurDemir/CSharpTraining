using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redis.Benchmark
{
    public static class CompressHelper
    {
        public static byte[] Compress(byte[] data)
        {
            using MemoryStream output = new();

            using DeflateStream deflateStream = new(output, CompressionLevel.SmallestSize);
            
            deflateStream.Write(data, 0, data.Length);

            return output.ToArray();
        }

        public static byte[] Decompress(byte[] data)
        {
            using MemoryStream input = new(data);
            using MemoryStream output = new();

            using DeflateStream deflateStream = new(input, CompressionMode.Decompress);
            
            deflateStream.CopyTo(output);

            return output.ToArray();
        }
    }
}
