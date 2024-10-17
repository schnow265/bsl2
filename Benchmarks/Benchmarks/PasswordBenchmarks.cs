using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Guesser;

namespace Benchmarks.Benchmarks
{
    public class PasswordBenchmarks
    {
        private Runner runner;

        [Params(1, 2, 5, 10)]
        public int threads;

        [Params(2, 5, 10, 20)]
        public int lengths;

        public PasswordBenchmarks() {
            string password = "0000";
            runner = new Runner(password, password.Length);
        }

        [IterationSetup]
        public void Setup() {
            string password = RNG.PasswordGenerator(lengths);
            runner = new Runner(password, password.Length);
        }

        [Benchmark]
        public TimeSpan GuesserCracker() => runner.Guesser(threads);
    }
}
