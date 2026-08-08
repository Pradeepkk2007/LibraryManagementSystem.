namespace LibraryManagementSystem.API.DTOs.Reports
{
    public class MonthlyStatisticsDto
    {
        public int Year { get; set; }

        public int MonthNumber { get; set; }

        public string Month { get; set; } = string.Empty;

        public int TotalBooksIssued { get; set; }
    }
}