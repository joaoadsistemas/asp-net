namespace ApiCatalogo.Entities;

public class Category
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? ImgUrl { get; set; }

    // lado um
    public List<Product>? Products { get; set; } = new List<Product>();
}