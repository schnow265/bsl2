using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Benchmarks.Benchmarks;

namespace Benchmarks
{
    public static class Runner
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<RegexHell>();
            BenchmarkRunner.Run<Md5VsSha256>();
            //BenchmarkRunner.Run<PasswordBenchmarks>();
        }
    }
}
