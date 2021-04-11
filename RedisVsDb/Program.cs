using BenchmarkDotNet.Running;
using RedisVsDb;

Student student = new()
{
    Id = 1,
    FirstName = "Jon",
    LastName = "Doe"
};

Setup(new DbManager(), student);
Setup(new RedisManager(), student);

BenchmarkRedisDb benchmarkRedisDb = new();
benchmarkRedisDb.TestDbPerf();
benchmarkRedisDb.TestRedisPerf();

BenchmarkRunner.Run<BenchmarkRedisDb>();

static void Setup(IManager manager, Student student)
{
    manager.CreateStudent(student);
}