using ApiCatalogo.Entities;

namespace ApiCatalogo.Dtos;

public class CategoryInsertDTO
{

    public string Name { get; set; }
    public string ImgUrl { get; set; }
    


    public CategoryInsertDTO()
    {
        
    }


    public CategoryInsertDTO(Category entity)
    {
     
        this.Name = entity.Name;
        this.ImgUrl = entity.ImgUrl;
        
    }
}