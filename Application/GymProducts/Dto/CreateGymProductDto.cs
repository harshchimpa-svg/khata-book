namespace Application.GymProducts.Dto;

public class CreateGymProductDto
{
    public int Tax {  get; set; }
    public decimal Price { get; set; }
    public int? CategoryId { get; set; }
}