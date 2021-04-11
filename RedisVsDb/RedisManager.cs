using Newtonsoft.Json;
using StackExchange.Redis;

namespace RedisVsDb
{
    internal class RedisManager : IManager
    {
        void IManager.CreateStudent(Student student)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(
                "[redis connection string]");
            IDatabase db = redis.GetDatabase();
            string existingData = db.StringGet("Student");
            if (existingData == null)
            {
                string serializedStudent = JsonConvert.SerializeObject(student);
                db.StringSet("Student", serializedStudent);
            }
        }

        Student? IManager.GetStudent()
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(
                "[redis connection string]");
            IDatabase db = redis.GetDatabase();
            string serializedStudent = db.StringGet("Student");
            Student? student = JsonConvert.DeserializeObject<Student>(serializedStudent);
            return student;
        }
    }
}
