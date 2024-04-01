using ABC.studentManagement.API.Models;

namespace ABC.studentManagement.API.IRepositories
{
    public interface IStudentRepository 
    {
        public Task<IEnumerable<Student>> GetAll();
        public Task<Student?> Get(Guid id);
        public Task<int> Add(Student student);
        public Task<int> Update(Student student);
        public Task<int> Delete(Student student);
        public Task<Student?> GetByEmail(string email);
        public Task<Student?> GetByIndexNumber(string indexNumber);

    }
}
