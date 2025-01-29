using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwaggerWebApp.Models;
using SwaggerWebApp.Service;

namespace SwaggerWebApp.v1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private StudentService _studentService;

        public CourseController()
        {
            _studentService = new StudentService();
        }

        /// <summary>
        /// Gets the list of courses for a specific student.
        /// </summary>
        /// <param name="studentId">Student ID</param>
        /// <returns>List of courses</returns>
        [HttpGet("{studentId}/courses")]
        public IActionResult GetCourses(string studentId)
        {
            var student = _studentService.GetStudent(studentId);
            if (student == null)
            {
                return NotFound("Student not found.");
            }
            return Ok(student.Courses);
        }

        /// <summary>
        /// Removes a course from a student's record.
        /// </summary>
        /// <param name="studentId">Student ID</param>
        /// <param name="courseId">Course ID</param>
        /// <returns>Success message</returns>
        [HttpDelete("{studentId}/courses/{courseId}")]
        public IActionResult RemoveCourse(string studentId, string courseId)
        {
            var student = _studentService.GetStudent(studentId);
            if (student == null)
            {
                return NotFound("Student not found.");
            }

            var course = student.Courses.Find(c => c.Id == courseId);
            if (course == null)
            {
                return NotFound("Course not found.");
            }

            student.Courses.Remove(course);
            _studentService.SaveOrUpdate(student);
            return Ok("Course removed successfully.");
        }

        /// <summary>
        /// Adds a course to a student's record.
        /// </summary>
        /// <param name="studentId">Student ID</param>
        /// <param name="course">Course object</param>
        /// <returns>Success message</returns>
        [HttpPost("{studentId}/courses")]
        public IActionResult AddCourse(string studentId, [FromBody] Course course)
        {
            var student = _studentService.GetStudent(studentId);
            if (student == null)
            {
                return NotFound("Student not found.");
            }

            student.Courses.Add(course);
            _studentService.SaveOrUpdate(student);
            return Ok("Course added successfully.");
        }
    }
}
