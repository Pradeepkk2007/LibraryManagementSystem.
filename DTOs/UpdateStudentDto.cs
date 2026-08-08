using System.ComponentModel.DataAnnotations;
namespace LibraryManagementSystem.API.DTOs
{
    public class UpdateStudentDto
    {
        [Required(ErrorMessage ="Roll Number is requireed.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage ="Roll Number must be exactly 10 characters." )]
        public string RollNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, MinimumLength =2)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50,MinimumLength =2)]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Department is required")]
        [StringLength(50)]
        public string Department { get; set; } = string.Empty;


        [Range(1,8, ErrorMessage ="Semester must be between 1 and 8.")]
        public int Semester { get; set; }

        [Required(ErrorMessage ="Email is required.")]
        [EmailAddress(ErrorMessage ="Invalid Email Address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage ="Phone Number is required.")]
        [Phone(ErrorMessage ="Invalid Phone Number.")]
        public string Phone { get; set; } = string.Empty;
    }
}
