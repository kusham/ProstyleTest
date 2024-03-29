using ABC.studentManagement.API.Models;

namespace ABC.studentManagement.API.IRepositories
{
    public interface IAuthRepository
    {
        Task AddStaffMember(StaffMember staffMember);
        Task<StaffMember?> GetStaffMemberByEmail(string email);
        Task<StaffMember?> GetStaffMemberByEmailorPhone(string email, string phone);
    }
}
