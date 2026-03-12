using Application.Dto;

namespace Application
{
    public interface IAuthService
    {
        Task RegisterAsync(CreateUserDto request);
        Task<string> VerifyOtpAsync(CreateUserDto request);
        Task<string> LoginAsync(CreateUserDto request);
        Task ResetPasswordAsync(CreateUserDto request);
        Task ForgotPasswordAsync(CreateUserDto request);
        Task RegisterEmployeeAsync(CreateUserDto request);
        Task RegisterTrainerAsync(CreateUserDto request);

    }
}