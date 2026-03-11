namespace Application.Customers.Dto;

public class CustomerDto
{
    public int? Id { get; set; }
    public string? UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Notes { get; set; }
    public decimal? Balance { get; set; }
    public string? Profile { get; set; }
}