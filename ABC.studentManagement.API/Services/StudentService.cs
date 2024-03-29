using ABC.studentManagement.API.IRepositories;
using ABC.studentManagement.API.IServices;
using ABC.studentManagement.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ABC.studentManagement.API.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;
        public StudentService(IStudentRepository repository) 
        {
            this._repository = repository;
        }
        public async Task<int> AddStudent(Student student)
        {
            var existingStudentWithEmail = await _repository.GetByEmail(student.Email);
            if (existingStudentWithEmail is not null)
            {
                throw new InvalidOperationException($"A student with the email '{student.Email}' already exists.");
            }
            var existingStudentWithIndexNumber = await _repository.GetByIndexNumber(student.IndexNumber);
            if (existingStudentWithIndexNumber is not null)
            {
                throw new InvalidOperationException($"A student with the index number '{student.IndexNumber}' already exists.");
            }
            return await _repository.Add(student);
        }


        public Task<IEnumerable<Student>> GetAllStudents()
        {
            return _repository.GetAll();
        }

        public Task<Student> GetStudent(Guid id)
        {
            return _repository.Get(id);
        }

        public Task UpdateStudent(Student student)
        {
            return _repository.Update(student);
        }
        public Task DeleteStudent(Guid id)
        {
            var student = _repository.Get(id).Result;
            if (student is null)
            {
                throw new System.Exception("Student not found");
            }
            return _repository.Delete(student);
        }
    }
}
