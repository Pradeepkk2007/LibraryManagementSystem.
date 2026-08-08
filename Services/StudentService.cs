using LibraryManagementSystem.API.Data;
using LibraryManagementSystem.API.DTOs;
using LibraryManagementSystem.API.Interfaces;
using LibraryManagementSystem.API.Models;

namespace LibraryManagementSystem.API.Services;

public class StudentService : IStudentService
{
    private readonly ApplicationDbContext _context;

    public StudentService(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<StudentDto> GetAllStudents()
    {
        var students = _context.Students.ToList();

        var studentDtos = new List<StudentDto>();

        foreach (var student in students)
        {
            studentDtos.Add(new StudentDto
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName
            });
        }

        return studentDtos;
    }

    public StudentDto CreateStudent(CreateStudentDto createStudentDto)
    {
        var student = new Student
        {
            RollNumber = createStudentDto.RollNumber,
            FirstName = createStudentDto.FirstName,
            LastName = createStudentDto.LastName,
            Department = createStudentDto.Department,
            Semester = createStudentDto.Semester,
            Email = createStudentDto.Email,
            Phone = createStudentDto.Phone
        };

        _context.Students.Add(student);

        _context.SaveChanges();

        return new StudentDto
        {

            FirstName = student.FirstName,
            LastName = student.LastName
        };
    }

    public StudentDto? GetStudentById(int studentId)
    {
        var student = _context.Students.Find(studentId);

        if (student == null)
        {
            return null;
        }
        else
        {
            return new StudentDto
            {
                FirstName = student.FirstName,
                LastName = student.LastName
            };
        }
        ;

    }

    public StudentDto UpdateStudent(int studentId, UpdateStudentDto updateStudentDto)
    {
        var student = _context.Students.Find(studentId);
        if (student == null)
        {
            return new StudentDto()
            {

            };
        }

        student.RollNumber = updateStudentDto.RollNumber;
        student.FirstName = updateStudentDto.FirstName;
        student.LastName = updateStudentDto.LastName;
        student.Department = updateStudentDto.Department;
        student.Semester = updateStudentDto.Semester;
        student.Email = updateStudentDto.Email;
        student.Phone = updateStudentDto.Phone;

        _context.SaveChanges();

        return new StudentDto
        {
            FirstName = student.FirstName,
            LastName = student.LastName
        };
    }

    public StudentDto? DeleteStudent(int studentId)
    {
        var student = _context.Students.Find(studentId);

        if (student == null)
        {
            return null;
        }

        var studentDto = new StudentDto
        {
            FirstName = student.FirstName,
            LastName = student.LastName
        };

        _context.Students.Remove(student);

        _context.SaveChanges();

        return studentDto;

    }

}