namespace LibraryManagementSystem.API.DTOs;

public class StudentDto
{
    public int StudentId { get; set; }
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;
}