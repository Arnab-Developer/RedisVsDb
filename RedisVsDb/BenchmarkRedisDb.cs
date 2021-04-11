using BenchmarkDotNet.Attributes;

namespace RedisVsDb
{
    public class BenchmarkRedisDb
    {
        [Benchmark]
        public void TestDbPerf()
        {
            IManager manager = new DbManager();
            for (int i = 0; i < 100; i++)
            {
                manager.GetStudent();
            }
        }

        [Benchmark]
        public void TestRedisPerf()
        {
            IManager manager = new RedisManager();
            for (int i = 0; i < 100; i++)
            {
                manager.GetStudent();
            }
        }
    }
}
