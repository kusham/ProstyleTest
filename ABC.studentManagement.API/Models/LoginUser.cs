using System.ComponentModel.DataAnnotations;

namespace ABC.studentManagement.API.Models
{
    public class LoginUser
    {
        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }

    public class LoggedUser
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string token { get; set; }
    }
}
