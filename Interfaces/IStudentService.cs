using LibraryManagementSystem.API.DTOs;
using LibraryManagementSystem.API.Models;

namespace LibraryManagementSystem.API.Interfaces;

public interface IStudentService
{
    List<StudentDto> GetAllStudents();

    StudentDto CreateStudent(CreateStudentDto createStudentDto);

    StudentDto? GetStudentById(int studentId);

    StudentDto? UpdateStudent(int studentId, UpdateStudentDto updateStudentDto);

    StudentDto? DeleteStudent(int studentId);

    
}