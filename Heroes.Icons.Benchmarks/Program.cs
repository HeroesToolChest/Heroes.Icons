using BenchmarkDotNet.Running;

namespace Heroes.Icons.Benchmarks
{
    public class Program
    {
        public static void Main()
        {
            _ = BenchmarkRunner.Run<HeroDataBenchmarks>();
        }
    }
}
