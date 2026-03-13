using Application.Dto;

namespace Application
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterRequestDto request);
        Task<string> VerifyOtpAsync(VerifyOtpRequest request);
        Task<string> LoginAsync(LoginRequestDto request);
        Task ResetPasswordAsync(ResetPasswordDto request);
        Task ForgotPasswordAsync(ForgotPasswordDto request);
        Task RegisterEmployeeAsync(RegisterRequestDto request);
        Task RegisterTrainerAsync(RegisterRequestDto request);

    }
}