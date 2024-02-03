using ApiCatalogo.Entities;
using System.ComponentModel.DataAnnotations;


namespace ApiCatalogo.Dtos;

public class CategoryInsertDTO
{

    [Required(ErrorMessage = "O campo 'Name' é obrigatório.")]
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