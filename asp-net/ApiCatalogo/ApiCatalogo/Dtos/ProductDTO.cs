using ApiCatalogo.Entities;

namespace ApiCatalogo.Dtos;

public class ProductDTO
{
    
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public string? ImgUrl { get; set; }
    public double Stock { get; set; }
    public DateTime RegisterData { get; set; }
    
    public long CategoryId { get; set; }


    public ProductDTO()
    {
        
    }

    public ProductDTO(Product entity)
    {
        this.Id = entity.Id;
        this.Name = entity.Name;
        this.Description = entity.Description;
        this.Price = entity.Price;
        this.ImgUrl = entity.ImgUrl;
        this.Stock = entity.Stock;
        this.RegisterData = entity.RegisterData;
        this.CategoryId = entity.CategoryId;
    }
}