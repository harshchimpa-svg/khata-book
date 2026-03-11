namespace Application.ShopSettings.Dto;

public class CreateShopSettingDto
{
    public string ShopeName { get; set; }
    public string OnerName { get; set; }
    public string PhoneNo { get; set; }
    public string Email { get; set; }
    public int GstNumber  { get; set; }
    public int? EmployeeId { get; set; }
    public string? UserId { get; set; }
}