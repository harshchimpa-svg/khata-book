namespace Domain;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public int? ParentId { get; set; }
    public Category Parent { get; set; }
}