using ABC.studentManagement.API.Data;
using ABC.studentManagement.API.IRepositories;
using ABC.studentManagement.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ABC.studentManagement.API.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public AuthRepository(ApplicationDbContext context)
        {
            this._dbContext = context;
        }
        public async Task AddStaffMember(StaffMember staffMember)
        {
            await _dbContext.StaffMembers.AddAsync(staffMember);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<StaffMember?> GetStaffMemberByEmail(string email)
        {
            return await _dbContext.StaffMembers.FirstOrDefaultAsync(s => s.Email == email);
        }

        public async Task<StaffMember?> GetStaffMemberByEmailorPhone(string email, string phone)
        {
            Expression<Func<StaffMember, bool>> FilterByKey(string key1, string key2)
            {
                return x => x.Email.ToLower() == key1.ToLower() || x.Phone == key2;
            }
            var member = await _dbContext.StaffMembers.Where(FilterByKey(email, phone)).ToListAsync();
            return member.FirstOrDefault();
        }
    }
}
