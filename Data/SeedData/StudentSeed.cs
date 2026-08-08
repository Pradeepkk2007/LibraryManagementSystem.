using LibraryManagementSystem.API.Models;

namespace LibraryManagementSystem.API.Data.SeedData
{
    public static class StudentSeed
    {
        public static void Seed(ApplicationDbContext context)
        {
            if (context.Students.Any())
                return;

            var students = new List<Student>
            {
                new Student
                {
                    RollNumber = "CSE2026001",
                    FirstName = "Aarav",
                    LastName = "Sharma",
                    Email = "aarav.sharma@example.com",
                    Phone = "9876543210",
                    Department = "Computer Science",
                    Semester = 5
                },

                new Student
                {
                    RollNumber = "CSE2026002",
                    FirstName = "Priya",
                    LastName = "Patel",
                    Email = "priya.patel@example.com",
                    Phone = "9876543211",
                    Department = "Computer Science",
                    Semester = 5
                },

                new Student
                {
                    RollNumber = "ECE2026001",
                    FirstName = "Rahul",
                    LastName = "Verma",
                    Email = "rahul.verma@example.com",
                    Phone = "9876543212",
                    Department = "Electronics",
                    Semester = 3
                },

                new Student
                {
                    RollNumber = "ECE2026002",
                    FirstName = "Ananya",
                    LastName = "Gupta",
                    Email = "ananya.gupta@example.com",
                    Phone = "9876543213",
                    Department = "Electronics",
                    Semester = 3
                },

                new Student
                {
                    RollNumber = "ME2026001",
                    FirstName = "Rohit",
                    LastName = "Singh",
                    Email = "rohit.singh@example.com",
                    Phone = "9876543214",
                    Department = "Mechanical",
                    Semester = 7
                },

                new Student
                {
                    RollNumber = "ME2026002",
                    FirstName = "Sneha",
                    LastName = "Joshi",
                    Email = "sneha.joshi@example.com",
                    Phone = "9876543215",
                    Department = "Mechanical",
                    Semester = 7
                },

                new Student
                {
                    RollNumber = "IT2026001",
                    FirstName = "Vikram",
                    LastName = "Yadav",
                    Email = "vikram.yadav@example.com",
                    Phone = "9876543216",
                    Department = "Information Technology",
                    Semester = 5
                },

                new Student
                {
                    RollNumber = "IT2026002",
                    FirstName = "Neha",
                    LastName = "Mehta",
                    Email = "neha.mehta@example.com",
                    Phone = "9876543217",
                    Department = "Information Technology",
                    Semester = 5
                },

                new Student
                {
                    RollNumber = "CE2026001",
                    FirstName = "Aditya",
                    LastName = "Chauhan",
                    Email = "aditya.chauhan@example.com",
                    Phone = "9876543218",
                    Department = "Civil",
                    Semester = 6
                },

                new Student
                {
                    RollNumber = "CE2026002",
                    FirstName = "Pooja",
                    LastName = "Kumari",
                    Email = "pooja.kumari@example.com",
                    Phone = "9876543219",
                    Department = "Civil",
                    Semester = 6
                }
            };

            context.Students.AddRange(students);
            context.SaveChanges();
        }
    }
}