using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementSystem.API.Models
{
    public class BookCopy
    {
        [Key]
        public int CopyId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public string Barcode { get; set; } = string.Empty;

        public string ShelfLocation { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime PurchaseDate { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        // Navigation Property
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; } = null!;
    }
}