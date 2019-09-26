using BenchmarkDotNet.Attributes;
using System.IO;

namespace Heroes.Icons.Benchmarks
{
    [MemoryDiagnoser]
    public class HeroDataBenchmarks
    {
        //private readonly string _heroDataFile = Path.Combine("JsonData", "herodata_76003_enus.json");
        //private HeroDataReader? _heroDataReader;

        //[Params("Zuljin")]
        //public string HeroIds { get; set; } = string.Empty;

        //[Params("Zul'jin")]
        //public string HeroNames { get; set; } = string.Empty;

        //[GlobalSetup]
        ////[Benchmark]
        //public void LoadJsonFile()
        //{
        //  //  _heroDataReader = HeroDataReader.Parse(_heroDataFile, "");
        //}

        //[GlobalCleanup]
        //public void Cleanup()
        //{
        //    _heroDataReader?.Dispose();
        //}

        ////[Benchmark]
        ////public void LoadGamestringFile()
        ////{
        ////    GamestringReader gamestringReader = new GamestringReader(@"F:\heroes\heroes_76003\gamestrings-76003\gamestrings_76003_enus.txt");
        ////}


        //[Benchmark]
        //public void GetHeroById()
        //{
        //    _heroDataReader?.GetHeroById(HeroIds);
        //}

        //[Benchmark]
        //public void GetHeroByIdWithAbilities()
        //{
        //    _heroDataReader?.GetHeroById(HeroIds, abilities: true);
        //}

        //[Benchmark]
        //public void GetHeroByIdWithTalents()
        //{
        //    _heroDataReader?.GetHeroById(HeroIds, talents: true);
        //}

        //[Benchmark]
        //public void GetHeroByIdWithAbilitiesTalents()
        //{
        //    _heroDataReader?.GetHeroById(HeroIds, abilities: true, talents: true);
        //}

        //[Benchmark]
        //public void GetHeroByName()
        //{
        //    _heroDataReader?.GetHeroByName(HeroNames);
        //}
    }
}
