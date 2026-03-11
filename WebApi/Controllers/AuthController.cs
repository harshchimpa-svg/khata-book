using Application;
using Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace ManjeetFigma.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDto request)
        {
            try
            {
                await _auth.RegisterAsync(request);
                return Ok(new { message = "Admin registered. OTP sent to email." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("register-employee")]
        public async Task<IActionResult> RegisterEmployee([FromBody] CreateUserDto request)
        {
            try
            {
                await _auth.RegisterEmployeeAsync(request);
                return Ok(new { message = "Employee registered. OTP sent to email." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] CreateUserDto request)
        {
            try
            {
                var token = await _auth.LoginAsync(request);
                return Ok(new { token });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] CreateUserDto request)
        {
            try
            {
                var token = await _auth.VerifyOtpAsync(request);
                return Ok(new
                {
                    message = "Email verified successfully",
                    token
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] CreateUserDto request)
        {
            try
            {
                await _auth.ForgotPasswordAsync(request);
                return Ok(new { message = "OTP sent to your email" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] CreateUserDto request)
        {
            try
            {
                await _auth.ResetPasswordAsync(request);
                return Ok(new { message = "Password reset successful" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }
    }
}