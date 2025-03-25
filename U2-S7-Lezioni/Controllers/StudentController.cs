using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using U2_S7_Lezioni.Models;
using U2_S7_Lezioni.Servicies;
using U2_S7_Lezioni.DTOs;

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

        [HttpPut("{id}")]
        public async Task<ActionResult<StudentResponseDTO>> Put(Guid id, [FromBody] StudentUpdateDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = await _service.UpdateAsync(id, dto);
            if (updated == null) return NotFound();

            return Ok(new StudentResponseDTO
            {
                Id = updated.Id,
                Nome = updated.Nome,
                Cognome = updated.Cognome,
                Email = updated.Email
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _service.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
