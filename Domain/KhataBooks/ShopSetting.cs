using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class ShopSetting
{
    public int Id { get; set; }
    public string ShopName { get; set; }
    public string OwnerName { get; set; }
    public string PhoneNo { get; set; }
    public string Email { get; set; }
    public int GstNumber  { get; set; }
    
    [ForeignKey("Employee")]
    public int? EmployeeId { get; set; }
    // public Employee Employee { get; set; }
    
    public string? UserId { get; set; }
}