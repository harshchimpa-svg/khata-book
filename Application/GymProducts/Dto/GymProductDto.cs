namespace Application.GymProducts.Dto;

public class GymProductDto
{
    public int Id { get; set; }
    public int Tax {  get; set; }
    public decimal Price { get; set; }
    public int? CategoryId { get; set; }
}