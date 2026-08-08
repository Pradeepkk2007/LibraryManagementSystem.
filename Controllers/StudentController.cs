using LibraryManagementSystem.API.DTOs;
using LibraryManagementSystem.API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [Authorize]
    [HttpGet("GetAllStudents")]
    public IActionResult GetAllStudents()
    {
        var students = _studentService.GetAllStudents();
        return Ok(students);
    }

    [Authorize]
    [HttpGet("GetStudentById/{studentId}")]
    public IActionResult GetStudentById(int studentId)
    {
        var student = _studentService.GetStudentById(studentId);

        if (student == null)
        {
            return NotFound("Student not found.");
        }

        return Ok(student);
    }

    [Authorize(Roles = "Admin,Librarian")]
    [HttpPost("CreateStudent")]
    public IActionResult CreateStudent([FromBody] CreateStudentDto createStudentDto)
    {
        var createdStudent = _studentService.CreateStudent(createStudentDto);
        return CreatedAtAction(
            nameof(GetStudentById),
            new { studentId = createdStudent.StudentId },
            createdStudent);
    }

    [Authorize(Roles = "Admin,Librarian")]
    [HttpPut("UpdateStudent{studentId}")]
    public IActionResult UpdateStudent(int studentId, [FromBody] UpdateStudentDto updateStudentDto)
    {
        var student = _studentService.UpdateStudent(studentId, updateStudentDto);

        if (student == null)
        {
            return NotFound("Student not found.");
        }

        return Ok(student);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("DeleteStudent{studentId}")]
    public IActionResult DeleteStudent(int studentId)
    {
        var student = _studentService.DeleteStudent(studentId);

        if (student == null)
        {
            return NotFound("Student not found.");
        }

        return Ok(student);
    }
}