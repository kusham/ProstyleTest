using System.ComponentModel.DataAnnotations;

namespace ABC.studentManagement.API.Models
{
    public class StaffMember
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Full name is required")]
        public required string FullName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public required string Email { get; set; }
        [Required(ErrorMessage = "Phone number is required")]
        public required string Phone { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public required string Password { get; set; }
    }
}
