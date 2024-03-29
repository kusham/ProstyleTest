using ABC.studentManagement.API.Models;

namespace ABC.studentManagement.API.IServices
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudents();
        Task<Student> GetStudent(Guid id);
        Task<int> AddStudent(Student student);
        Task UpdateStudent(Student student);
        Task DeleteStudent(Guid id);
    }
}
