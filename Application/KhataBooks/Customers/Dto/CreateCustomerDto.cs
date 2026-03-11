using Data.Services;
using Microsoft.AspNetCore.Http;

namespace Application.Customers.Dto;

public class CreateCustomerDto
{
    public string? UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Notes { get; set; }
    public decimal? Balance { get; set; }
    public IFormFile? Profile { get; set; }
}