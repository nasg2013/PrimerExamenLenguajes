using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebApiLab.Models;

namespace WebApiLab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IF4101_A95777_2020Context _context;

        public StudentController(IF4101_A95777_2020Context context)
        {
            _context = context;
        }

        // GET: All Students from SP
        [Route("[action]")]
        [HttpGet]
        public IActionResult GetAllStudentsSP()
        {
            try
            {
                var students = _context.Student
                     .FromSqlRaw($"SelectStudentAPI")
                     .AsEnumerable();
                return Ok(students);
            }
            catch { throw; }

        }
        
        // GET: A student by id from SP
        [Route("[action]/{id}")]
        [HttpGet("{id}")]
        public ActionResult GetStudentById(int id)
        {
            var studentId = new SqlParameter("@StudentId", id);
            var student = _context.Student
                            .FromSqlRaw($"SelectStudentByIdAPI @StudentId", studentId)
                            .AsEnumerable().Single();

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        //GET: All students by name
        [Route("[action]/{Id}")]
        [HttpGet("{Id}")]
        public IActionResult GetStudentByName(string id)
        {
            using (var context = new IF4101_A95777_2020Context())
            {
                try
                {
                    var students = _context.Student
                                    .FromSqlRaw("SelectStudentByNameApi {0}", id)
                                    .AsEnumerable();
                    if (students.Equals("[]"))
                    {
                        return NotFound();
                    }
                    return Ok(students);
                }
                catch { throw; }
            }
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.StudentId == id);
        }
    }
}
