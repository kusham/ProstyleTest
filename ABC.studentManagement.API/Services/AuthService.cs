using ABC.studentManagement.API.IRepositories;
using ABC.studentManagement.API.IServices;
using ABC.studentManagement.API.Models;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Net;

namespace ABC.studentManagement.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IPasswordHasher<StaffMember> _passwordHasher;

        public AuthService(IAuthRepository authRepository, IPasswordHasher<StaffMember> passwordHasher) 
        {
            this._authRepository = authRepository;
            this._passwordHasher = passwordHasher;
        }
        public async Task<string?> SignIn(LoginUser credintials)
        {
            StaffMember? staffMember = await _authRepository.GetStaffMemberByEmail(credintials.Email);
            PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(
                staffMember, staffMember.Password, credintials.Password);

            if (staffMember is not null && result == PasswordVerificationResult.Success)
            {
                // Generate and return authentication token
                return "your-authentication-token";
            }

            return null; // Authentication failed
        }

        public async Task SignUp(StaffMember staffMember)
        {
            StaffMember? exisstingstaffMember = await _authRepository.GetStaffMemberByEmailorPhone(
                staffMember.Email, staffMember.Phone);
            if (exisstingstaffMember is not null)
                throw new Exception("Email or Phone already exists.");

            var newStaffMember = new StaffMember
            {
                FullName = staffMember.FullName,
                Email = staffMember.Email,
                Phone = staffMember.Phone,
                Password = _passwordHasher.HashPassword(staffMember, staffMember.Password)
        };

            await _authRepository.AddStaffMember(newStaffMember);
        }
    }
}
