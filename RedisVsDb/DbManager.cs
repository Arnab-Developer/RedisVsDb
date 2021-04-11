using Dapper;
using System.Data.SqlClient;
using System.Linq;

namespace RedisVsDb
{
    internal class DbManager : IManager
    {
        void IManager.CreateStudent(Student student)
        {
            string conStr = "[db connection string]";
            using SqlConnection connection = new(conStr);
            Student? existingStudent = connection
                .Query<Student>("SELECT Id, FirstName, LastName FROM Students WHERE Id = @id", new { Id = 1 })
                .FirstOrDefault();
            if (existingStudent == null)
            {
                connection.Execute("INSERT INTO Students VALUES(@Id, @FirstName, @LastName)",
                    new { student.Id, student.FirstName, student.LastName });
            }
        }

        Student? IManager.GetStudent()
        {
            string conStr = "[db connection string]";
            using SqlConnection connection = new(conStr);
            Student? students = connection
                .Query<Student>("SELECT Id, FirstName, LastName FROM Students WHERE Id = @id", new { Id = 1 })
                .FirstOrDefault();
            return students;
        }
    }
}
