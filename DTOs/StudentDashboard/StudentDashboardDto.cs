using LibraryManagementSystem.API.DTOs.StudentHistory;

namespace LibraryManagementSystem.API.DTOs.StudentDashboard
{
    public class StudentDashboardDto
    {
        // Student Information
        public int StudentId { get; set; }

        public string RollNumber { get; set; } = string.Empty;

        public string StudentName { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public int Semester { get; set; }

        // Dashboard Summary
        public int CurrentlyIssuedBooks { get; set; }

        public int TotalBorrowedBooks { get; set; }

        public int OverdueBooks { get; set; }

        public decimal CurrentFine { get; set; }

        public DateTime? NextDueDate { get; set; }

        // Recent Borrow History
        public List<StudentHistoryDto> RecentHistory { get; set; } = new();
    }
}