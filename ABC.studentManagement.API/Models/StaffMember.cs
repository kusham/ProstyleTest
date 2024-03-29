using System.ComponentModel.DataAnnotations;

namespace ABC.studentManagement.API.Models
{
    public class StaffMember
    {
        public int Id { get; set; }
        [Required]
        public required string FullName { get; set; }
        //public string Designation { get; set; }
        public string? Department { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
    }
}
