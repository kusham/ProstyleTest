using ABC.studentManagement.API.Data;
using ABC.studentManagement.API.IRepositories;
using ABC.studentManagement.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ABC.studentManagement.API.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public StudentRepository(ApplicationDbContext context) 
        {
            this._dbContext = context;
        }

        public async Task<int> Add(Student student)
        {
            await _dbContext.Students.AddAsync(student);
            return await _dbContext.SaveChangesAsync();
        }


        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _dbContext.Students.ToListAsync();
        }

        public async Task<Student?> Get(Guid id)
        {
           return await _dbContext.Students.FindAsync(id);
        }

        public async Task<int> Update(Student student)
        {
            _dbContext.Update(student);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<int> Delete(Student student)
        {
            _dbContext.Students.Remove(student);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Student?> GetByEmail(string email)
        {
            Expression<Func<Student, bool>> FilterByKey(string key)
            {
                return x => x.Email.ToLower() == key.ToLower();
            }
            var student = await _dbContext.Students.Where(FilterByKey(email)).ToListAsync();
            return student.FirstOrDefault();
        }

        public async Task<Student?> GetByIndexNumber(string indexNumber)
        {
            Expression<Func<Student, bool>> FilterByKey(string key)
            {
                return x => x.IndexNumber.ToLower() == key.ToLower();
            }
            var student = await _dbContext.Students.Where(FilterByKey(indexNumber)).ToListAsync();
            return student.FirstOrDefault();
        }
    }
}
