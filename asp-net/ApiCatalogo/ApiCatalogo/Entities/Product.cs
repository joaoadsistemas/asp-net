namespace ApiCatalogo.Entities;

public class Product
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public string? ImgUrl { get; set; }
    public double Stock { get; set; }
    public DateTime RegisterData { get; set; }
    
    // lado muitos
    public long CategoryId { get; set; }
    public Category? Category { get; set; }

}