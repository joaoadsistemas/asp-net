using ApiCatalogo.Entities;

namespace ApiCatalogo.Dtos;

public class ProductInsertDTO
{
    
    public string? Name { get; set; }
    public string? Description { get; set; }
    public double Price { get; set; }
    public string? ImgUrl { get; set; }
    public double Stock { get; set; }
    public DateTimeOffset RegisterData { get; set; } = DateTimeOffset.Now;
    
    public long CategoryId { get; set; }


    public ProductInsertDTO()
    {
        
    }

    public ProductInsertDTO(Product entity)
    {
        this.Name = entity.Name;
        this.Description = entity.Description;
        this.Price = entity.Price;
        this.ImgUrl = entity.ImgUrl;
        this.Stock = entity.Stock;
        this.CategoryId = entity.CategoryId;
    }
}