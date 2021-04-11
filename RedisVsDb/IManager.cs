namespace RedisVsDb
{
    internal interface IManager
    {
        public void CreateStudent(Student student);

        public Student? GetStudent();
    }
}
