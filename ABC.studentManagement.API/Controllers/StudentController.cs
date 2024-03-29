﻿using ABC.studentManagement.API.IServices;
using ABC.studentManagement.API.Models;
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
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            await _studentService.AddStudent(student);
            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents()
        {
            var students = await _studentService.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(Guid id)
        {
            var student = await _studentService.GetStudent(id);
            if (student is null)
            {
                return NotFound();
            }
            return Ok(student);
        }

   

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(Guid id, Student student)
        {
            if (id != student.Id)
            {
                return BadRequest();
            }
            await _studentService.UpdateStudent(student);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            await _studentService.DeleteStudent(id);
            return NoContent();
        }
    }
}
