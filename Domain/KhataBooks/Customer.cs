using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Customer
{
    public  int Id { get; set; }
    
    [ForeignKey("User")]
    public string? UserId { get; set; }
    // public User? User { get; set; }
    
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Notes { get; set; }
    public decimal? Balance { get; set; }
    public string? Profile { get; set; }
    public bool IsActive { get; set; }
}