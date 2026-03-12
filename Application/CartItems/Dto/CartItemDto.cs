namespace Application.CartItems.Dto;

public class CartItemDto
{
    public int Id { get; set; }
    public int Quantity { get; set; }
    public int? GymProductId { get; set; }
}