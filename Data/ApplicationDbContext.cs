using LibraryManagementSystem.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Book> Books { get; set; }

    public DbSet<BookCopy> BookCopies { get; set; }
    public DbSet<IssueRecord> IssueRecords { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Author> Authors { get; set; }

    public DbSet<Publisher> Publishers { get; set; }

    public DbSet<Category> Categories { get; set; }

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>().ToTable("Student");

        modelBuilder.Entity<Book>().ToTable("Book");

        // Primary Key
        modelBuilder.Entity<BookCopy>()
            .HasKey(bc => bc.CopyId);

        // Relationship
        modelBuilder.Entity<BookCopy>()
            .HasOne(bc => bc.Book)
            .WithMany()
            .HasForeignKey(bc => bc.BookId);

        modelBuilder.Entity<IssueRecord>()
            .HasOne(ir => ir.Student)
            .WithMany()
            .HasForeignKey(ir => ir.StudentId);

        modelBuilder.Entity<IssueRecord>()
            .HasOne(ir => ir.BookCopy)
            .WithMany()
            .HasForeignKey(ir => ir.CopyId);
    }
}