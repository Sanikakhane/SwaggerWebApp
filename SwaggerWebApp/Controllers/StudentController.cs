using SwaggerWebApp.Service;
using System.Collections.Generic;
using SwaggerWebApp.IService;
using SwaggerWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace SwaggerWebApp.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController()
        {
            _studentService = new StudentService();
        }

        /// <summary>
        /// Gets all students.
        /// </summary>
        /// <returns>List of students</returns>
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet] 
        public List<Student> GetStudents()
        {
            return _studentService.GetStudents();
        }

        /// <summary>
        /// Gets a single student by ID.
        /// </summary>
        /// <param name="id">Student ID</param>
        /// <returns>Student object</returns>
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet("{id}")]
        public Student GetStudent(string id)
        {
            return _studentService.GetStudent(id);
        }

        /// <summary>
        /// Saves or updates a student.
        /// </summary>
        /// <param name="student">Student object</param>
        /// <returns>Success message</returns>
        [HttpPost]
        public IActionResult SaveOrUpdate([FromBody] Student student)
        {
            _studentService.SaveOrUpdate(student);
            return Ok("Student saved or updated successfully.");
        }

        /// <summary>
        /// Deletes a student by ID.
        /// </summary>
        /// <param name="id">Student ID</param>
        /// <returns>Success message</returns>
        
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            _studentService.Delete(id);
            return Ok("Student deleted successfully.");
        }

        /// <summary>
        /// Updates a student by ID.
        /// </summary>
        /// <param name="id">Student ID</param>
        /// <param name="student">Student object</param>
        /// <returns>Success message</returns>
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] Student student)
        {
            student.Id = id;
            _studentService.SaveOrUpdate(student);
            return Ok("Student updated successfully.");
        }
    }
}
