using Application.Dto;
using Data.Repositorys;
using Data.Services;
using Data.Services.JwtToken;
using Domain;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace Application;

public class AuthService : IAuthService
{
    private readonly IUserRepository _users;
    private readonly IOtpRepository _otps;
    private readonly PasswordHasher<User> _hasher;
    private readonly IEmailService _email;
    private readonly IJwtService _jwt;

    public AuthService(
        IUserRepository users,
        IOtpRepository otps,
        IEmailService email,
        IJwtService jwt)
    {
        _users = users;
        _otps = otps;
        _email = email;
        _jwt = jwt;
        _hasher = new PasswordHasher<User>();
    }

    public async Task RegisterAsync(RegisterRequestDto request)
    {
        var existing = await _users.GetByEmail(request.Email);
        if (existing != null) throw new Exception("User already exists");

        var user = new User
        {
            UserName = request.UserName,
            Email = request.Email,
            RoleType = RoleType.Admin
        };

        user.PasswordHash = _hasher.HashPassword(user, request.Password);

        await _users.AddAsync(user);

        await SendOtpToEmailAsync(user);
    }

    public async Task RegisterEmployeeAsync(RegisterRequestDto request)
    {
        var existing = await _users.GetByEmail(request.Email);
        if (existing != null) throw new Exception("Employee already exists");

        var user = new User
        {
            UserName = request.UserName,
            Email = request.Email,
            RoleType = RoleType.Employee 
        };

        user.PasswordHash = _hasher.HashPassword(user, request.Password);

        await _users.AddAsync(user);

        await SendOtpToEmailAsync(user);
    }

    public async Task RegisterTrainerAsync(RegisterRequestDto request)
    {
        var existing = await _users.GetByEmail(request.Email);
        if (existing != null) throw new Exception("Trainer already exists");

        var user = new User
        {
            UserName = request.UserName,
            Email = request.Email,
            RoleType = RoleType.Trainer 
        };

        user.PasswordHash = _hasher.HashPassword(user, request.Password);

        await _users.AddAsync(user);

        await SendOtpToEmailAsync(user);
    }
    
    public async Task<string> LoginAsync(LoginRequestDto request)
    {
        var user = await _users.GetByEmail(request.Email)
            ?? throw new Exception("User not found");

        var res = _hasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);

        if (res == PasswordVerificationResult.Failed)
            throw new Exception("Invalid credentials");

        if (!user.IsEmailVerified)
            throw new Exception("Email not verified");

        return _jwt.GenerateToken(user); 
    }

    public async Task<string> VerifyOtpAsync(VerifyOtpRequest request)
    {
        var user = await _users.GetByEmail(request.Email)
            ?? throw new Exception("User not found");

        var otp = await _otps.GetValidOtpAsync(user.Id, request.Code)
            ?? throw new Exception("Invalid/expired OTP");

        await _otps.MakeUsedAsync(otp);

        user.IsEmailVerified = true;

        await _users.UpdateAsync(user);

        return _jwt.GenerateToken(user);
    }

    public async Task ForgotPasswordAsync(ForgotPasswordDto request)
    {
        var user = await _users.GetByEmail(request.Email)
            ?? throw new Exception("User not found");

        var otpCode = new Random().Next(1000, 9999).ToString();

        var otp = new Otp
        {
            UserId = user.Id,
            Code = otpCode,
            ExpiresAt = DateTime.UtcNow.AddMinutes(5)
        };

        await _otps.AddAsync(otp);

        await _email.SendEmail(
            user.Email,
            "Reset Password OTP",
            $"<h3>Your Password Reset OTP is <b>{otpCode}</b></h3>");
    }

    public async Task ResetPasswordAsync(ResetPasswordDto request)
    {
        var user = await _users.GetByEmail(request.Email)
            ?? throw new Exception("User not found");

        var otp = await _otps.GetValidOtpAsync(user.Id, request.Code)
            ?? throw new Exception("Invalid OTP");

        await _otps.MakeUsedAsync(otp);

        user.PasswordHash = _hasher.HashPassword(user, request.NewPassword);

        await _users.UpdateAsync(user);
    }

    private async Task SendOtpToEmailAsync(User user)
    {
        var otpCode = new Random().Next(1000, 9999).ToString();

        var otp = new Otp
        {
            UserId = user.Id,
            Code = otpCode,
            ExpiresAt = DateTime.UtcNow.AddMinutes(15)
        };

        await _otps.AddAsync(otp);

        await _email.SendEmail(
            user.Email,
            "Your OTP Code",
            $"<h3>Your OTP is <b>{otpCode}</b></h3>");
    }
}