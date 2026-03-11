using System.ComponentModel.DataAnnotations;

namespace Application.Dto;

public class CreateUserDto
{
    [EmailAddress(ErrorMessage = "Invalid Email format")]
    public string Email { get; set; }
    public string Password { get; set; }
    public string NewPassword { get; set; }
    public string Code { get; set; }
    public string UserName { get; set; }
    public string Role { get; set; }
}