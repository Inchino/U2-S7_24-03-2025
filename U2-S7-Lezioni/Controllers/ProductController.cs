using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using U2_S7_Lezioni.Models;
using U2_S7_Lezioni.Servicies;

namespace U2_S7_Lezioni.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _service;

        public StudentController(StudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            var students = await _service.GetAllAsync();
            return Ok(students);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> Post([FromBody] Student student)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdStudent = await _service.AddAsync(student);
            return CreatedAtAction(nameof(Get), new { id = createdStudent.Id }, createdStudent);
        }
    }
}
