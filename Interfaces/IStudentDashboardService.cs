using LibraryManagementSystem.API.DTOs.StudentDashboard;

namespace LibraryManagementSystem.API.Interfaces
{
    public interface IStudentDashboardService
    {
        StudentDashboardDto GetStudentDashboard(int studentId);
    }
}