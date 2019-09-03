using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;

namespace Heroes.Icons.Benchmarks
{
    public class Test
    {
        [Benchmark]
        public void Tests()
        {
            using HeroDataReader heroDataReader = HeroDataReader.Parse(@"F:\heroes\heroes_76003\data\json\herodata_76003_enus.json");
            heroDataReader.GetHero("Alexstrasza");
            
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
           //new Test().Tests();

           var summary = BenchmarkRunner.Run<Test>();
        }
    }
}
