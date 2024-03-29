using ABC.studentManagement.API.Models;

namespace ABC.studentManagement.API.IServices
{
    public interface IAuthService
    {
        Task SignUp(StaffMember staffmember);
        Task<string?> SignIn(LoginUser credintials);
    }
}
