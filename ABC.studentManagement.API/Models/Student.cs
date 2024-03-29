namespace ABC.studentManagement.API.Models
{
    public class Student
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string IndexNumber { get; set; }
        public required string Department { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }
    }
}
