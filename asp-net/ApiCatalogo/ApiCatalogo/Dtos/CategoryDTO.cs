using ApiCatalogo.Entities;

namespace ApiCatalogo.Dtos;

public class CategoryDTO
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? ImgUrl { get; set; }
    
    public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();


    public CategoryDTO()
    {
        
    }


    public CategoryDTO(Category entity)
    {
        this.Id = entity.Id;
        this.Name = entity.Name;
        this.ImgUrl = entity.ImgUrl;

        foreach (Product product in entity.Products)
        {
            this.Products.Add(new ProductDTO(product));
        }
    }
}