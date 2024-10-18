using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Guesser;

namespace Benchmarks.Benchmarks
{
    [RPlotExporter]
    [SimpleJob(RunStrategy.ColdStart, launchCount: 1, iterationCount: 5)]
    [MemoryDiagnoser]
    [ThreadingDiagnoser]
    public class PasswordBenchmarks
    {
        private Guesser.Runner? runner;

        [Params(10)]
        public int threads;

        [Params(2, 5, 10, 20)]
        public int lengths;

        [IterationSetup]
        public void Setup() {
            string password = RNG.PasswordGenerator(lengths);
            runner = new Guesser.Runner(password, password.Length);
        }

        [Benchmark]
        public TimeSpan GuesserCracker() => runner.Guesser(threads);
    }
}
