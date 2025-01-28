using SwaggerWebApp.Models;
using System.Collections.Generic;

namespace SwaggerWebApp.IService
{
    public interface IStudentService
    {
        void SaveOrUpdate(Student student);
        Student GetStudent(string studentId);

        // string SaveStudentWithImage(Student student);

        List<Student> GetStudents();
        List<Student> GetStudentsInSortedOrder();
        string Delete(string studentId);
        Dictionary<int, List<Student>> GetStudentsGroupedbyAge();
    }
}
