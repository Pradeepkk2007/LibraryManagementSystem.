namespace LibraryManagementSystem.API.DTOs.Dashboard
{
    public class DashboardDto
    {
        public int TotalBooks { get; set; }

        public int TotalBookCopies { get; set; }

        public int AvailableCopies { get; set; }

        public int IssuedCopies { get; set; }

        public int DamagedCopies { get; set; }

        public int TotalStudents { get; set; }

        public int BooksIssuedToday { get; set; }

        public int BooksReturnedToday { get; set; }

        public decimal TotalFineCollected { get; set; }
    }
}