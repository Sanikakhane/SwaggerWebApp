using MongoDB.Driver;
using System.Collections.Generic;
using System;
using System.Linq;
using SwaggerWebApp.IService;
using SwaggerWebApp.Models;

namespace SwaggerWebApp.Service
{
    public class StudentService : IStudentService
    {
        private MongoClient _mongoClient;
        private IMongoDatabase _database;
        private IMongoCollection<Student> _studentTable;
        public int count = 0;
        public StudentService()
        {
            _mongoClient = new MongoClient("mongodb://localhost:30114/");
            _database = _mongoClient.GetDatabase("SchoolDB");
            _studentTable = _database.GetCollection<Student>("Students");
        }
        public string Delete(string studentId)
        {
            _studentTable.DeleteOne(st => st.Id == studentId);
            return "Deleted";
        }

        public Student GetStudent(string studentId)
        {
            return _studentTable.Find(st => st.Id == studentId).FirstOrDefault();
        }

        public List<Student> GetStudents()
        {
            //count = (int)_studentTable.CountDocuments(FilterDefinition<Student>.Empty);
            //Console.WriteLine(count);

            return _studentTable.Find(FilterDefinition<Student>.Empty).Sort(Builders<Student>.Sort.Ascending(s => s.Roll)).ToList();

        }

        public void SaveOrUpdate(Student student)
        {

            var studentObj = _studentTable.Find(x => x.Id == student.Id).FirstOrDefault();
            if (studentObj == null)
            {
                _studentTable.InsertOne(student);
            }
            else
            {
                _studentTable.ReplaceOne(x => x.Id == student.Id, student);
            }
        }

        public Dictionary<int, List<Student>> GetStudentsGroupedbyAge()
        {

            Dictionary<int, List<Student>> GroupedStudents = new Dictionary<int, List<Student>>();


            var groups = _studentTable.Aggregate()
                .Group(
                    s => s.Age,
                    g => new
                    {
                        Age = g.Key,
                        Students = g.ToList()
                    })
                .ToList();


            GroupedStudents = groups
                .OrderBy(group => group.Age)
                .ToDictionary(group => group.Age, group => group.Students);

            return GroupedStudents;
        }


    }
}
