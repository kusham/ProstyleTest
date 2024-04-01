using ABC.studentManagement.API.IServices;
using ABC.studentManagement.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABC.studentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            this._studentService = studentService;
        }

        [HttpPost("add")]
        [Authorize]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            try
            {
                await _studentService.AddStudent(student);
                return CreatedAtAction("GetStudent", new { id = student.Id }, student);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getAll")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
        {
            try
            {
                var students = await _studentService.GetAllStudents();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Student>> GetStudent(Guid id)
        {
            try
            {
                var student = await _studentService.GetStudent(id);
                if (student is null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

   

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateStudent(Guid id, Student student)
        {
            try
            {
                if (id != student.Id)
                {
                    return BadRequest();
                }
                await _studentService.UpdateStudent(student);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            try
            {
                await _studentService.DeleteStudent(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }
    }
}
