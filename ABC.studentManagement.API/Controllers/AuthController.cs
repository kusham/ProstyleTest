using ABC.studentManagement.API.IServices;
using ABC.studentManagement.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ABC.studentManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody] StaffMember staffmember)
        {
            try
            {
                await _authService.SignUp(staffmember);
                return Ok("Signed up successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("signin")]
        public async Task<IActionResult> SignIn([FromBody] LoginUser credintials)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(credintials.Email) || 
                    string.IsNullOrWhiteSpace(credintials.Password))
                {
                    return BadRequest("Username or password cannot be empty.");
                }
                var token = await _authService.SignIn(credintials);
                if (token is null)
                    return Unauthorized("Invalid email or password.");

                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
