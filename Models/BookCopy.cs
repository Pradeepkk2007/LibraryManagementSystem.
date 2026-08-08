using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LibraryManagementSystem.API.Models
{
    public class BookCopy
    {
        [Key]
        public int CopyId { get; set; }
        public int BookId { get; set; }
        public string Barcode { get; set; } = String.Empty;
        public string ShelfLocation{ get; set; } = String.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime PurchaseDate { get; set; }
        public decimal Price { get; set; }

        //Navigation Property
        public Book Book { get; set; } = null!;

    }
}
