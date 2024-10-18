using BenchmarkDotNet.Attributes;
using Microsoft.Diagnostics.Tracing.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Benchmarks.Benchmarks
{
    [RPlotExporter]
    [MemoryDiagnoser]
    public partial class RegexHell
    {
        private readonly string regexMatcher = @".*(?:.*=.*)";

        private readonly string toMatch = "x=xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"; // regex101 says this takes 1036 spets to match

        public RegexHell() {
        
        }

        private Match staticbenchmark() {
            return Regex.Match(toMatch, regexMatcher);
        }

        private Match generatedMatcher()
        {
            Regex reg = genEx();
            return reg.Match(toMatch);
        }

        private Match newRegexInstance()
        {
            Regex reg = new Regex(@".*(?:.*=.*)");
            return reg.Match(toMatch);
        }

        [Benchmark(Description = "Static Regex.Match Method")]
        public Match StaticReference() => staticbenchmark();

        [Benchmark(Description = ".Net GeneratedRegex Annotation")]
        public Match GenMark() => generatedMatcher();

        [Benchmark(Description = "new Regex Object")]
        public Match newInstance() => newRegexInstance();

        [GeneratedRegex(@".*(?:.*=.*)")]
        private static partial Regex genEx();
    }
}
