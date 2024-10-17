using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Security.Cryptography;
using snowMarks.Benchmarks;
using Benchmarks.Benchmarks;

namespace snowMarks
{
    public static class Runner
    {
        public static void Main(string[] args)
        {
            //BenchmarkRunner.Run<Md5VsSha256>();
            BenchmarkRunner.Run<PasswordBenchmarks>();
        }
    }
}
