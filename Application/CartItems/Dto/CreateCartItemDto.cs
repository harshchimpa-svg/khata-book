namespace Application.CartItems.Dto;

public class CreateCartItemDto
{
    public int Quantity { get; set; }
    public int? GymProductId { get; set; }
}