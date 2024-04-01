using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABC.studentManagement.API.Models
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Full name is required")]
        public required string FullName { get; set; }

        public string? Title { get; set; }
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Index number is required")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "Index number must be 7 characters")]
        public required string IndexNumber { get; set; }

        [Required(ErrorMessage = "Department is required")]
        public required string Department { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public required string Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number")]
        public string? Phone { get; set; }

        public string? Address { get; set; }
    }
}
