using ApiCatalogo.Entities;

namespace ApiCatalogo.Dtos;

public class CategoryInsertDTO
{

    public string? Name { get; set; }
    public string? ImgUrl { get; set; }
    
    public List<int> Products { get; set; } = new List<int>();


    public CategoryInsertDTO()
    {
        
    }


    public CategoryInsertDTO(Category entity)
    {
     
        this.Name = entity.Name;
        this.ImgUrl = entity.ImgUrl;

        foreach (Product product in entity.Products)
        {
            this.Products.Add((int)product.Id);
        }
    }
}