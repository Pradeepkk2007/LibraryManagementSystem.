using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.API.Models;

public class Student
{
    [Key]
    public int StudentId { get; set; }

    public string RollNumber { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Department { get; set; } = string.Empty;

    public int Semester { get; set; }

    public string Email { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;
}