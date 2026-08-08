using LibraryManagementSystem.API.DTOs.Reports;

namespace LibraryManagementSystem.API.Interfaces
{
    public interface IReportService
    {
        List<OverdueBookDto> GetOverdueBooks();
        List<MostBorrowedBookDto> GetMostBorrowedBooks();
        List<TopReaderDto> GetTopReaders();
        List<NeverBorrowedBookDto> GetNeverBorrowedBooks();
        List<MonthlyStatisticsDto> GetMonthlyStatistics();
    }
}