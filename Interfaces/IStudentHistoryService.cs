using LibraryManagementSystem.API.DTOs.StudentHistory;

namespace LibraryManagementSystem.API.Interfaces
{
    public interface IStudentHistoryService
    {
        List<StudentHistoryDto> GetStudentHistory(int studentId);
    }
}