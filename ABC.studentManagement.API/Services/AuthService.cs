using ABC.studentManagement.API.IRepositories;
using ABC.studentManagement.API.IServices;
using ABC.studentManagement.API.Models;
using ABC.studentManagement.API.Utils;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Net;

namespace ABC.studentManagement.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;
        private readonly IPasswordHasher<StaffMember> _passwordHasher;
        private readonly JWT _jwt;

        public AuthService(IAuthRepository authRepository, IPasswordHasher<StaffMember> passwordHasher, JWT jwt) 
        {
            this._authRepository = authRepository;
            this._passwordHasher = passwordHasher;
            this._jwt = jwt;
        }
        public async Task<LoggedUser?> SignIn(LoginUser credintials)
        {
            StaffMember? staffMember = await _authRepository.GetStaffMemberByEmail(credintials.Email);

            if (staffMember is not null)
            {
            PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(
                staffMember, staffMember.Password, credintials.Password);
                if(result == PasswordVerificationResult.Success)
                {
                    var token = _jwt.GenerateToken(staffMember);
                    var loggedUser = new LoggedUser
                    {
                        Id = staffMember.Id,
                        FullName = staffMember.FullName,
                        Email = staffMember.Email,
                        Phone = staffMember.Phone,
                        token = token
                    };
                    return loggedUser;
                }
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
