using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.API.DTOs
{
    public class UpdateBookCopyDto
    {
        [Range(1, int.MaxValue,
            ErrorMessage = "Please select a valid Book.")]
        public int BookId { get; set; }

        [Required(ErrorMessage = "Barcode is required.")]
        [StringLength(50, MinimumLength = 3,
            ErrorMessage = "Barcode must be between 3 and 50 characters.")]
        public string Barcode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Shelf Location is required.")]
        [StringLength(50, MinimumLength = 2,
            ErrorMessage = "Shelf Location must be between 2 and 50 characters.")]
        public string ShelfLocation { get; set; } = string.Empty;

        [Required(ErrorMessage = "Purchase Date is required.")]
        public DateTime PurchaseDate { get; set; }

        [Range(0.01, 1000000,
            ErrorMessage = "Price must be greater than 0.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public string Status { get; set; } = string.Empty;
    }
}