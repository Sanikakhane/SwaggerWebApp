using SwaggerWebApp.Service;
using System.Collections.Generic;
using SwaggerWebApp.IService;
using SwaggerWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Asp.Versioning;

namespace SwaggerWebApp.v2.Controllers
{


    [Produces("application/json", "application/xml")] // Content negotiation
    [Route("api/students")]
    [ApiController]
    [ApiVersion("2.0")]
    [ApiConventionType(typeof(DefaultApiConventions))]
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

        //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        [HttpGet]
  
        public List<Student> Get()
        {
            return _studentService.GetStudentsInSortedOrder();
        }

       

        
    }
}
