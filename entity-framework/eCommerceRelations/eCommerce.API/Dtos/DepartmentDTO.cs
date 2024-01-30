using eCommerce.Entities;

namespace eCommerce.API.Dtos;

public class DepartmentDTO
{
    public int Id { get; set; }
    public string Name { get; set; }

    public DepartmentDTO()
    {
        
    }

    public DepartmentDTO(Department entity)
    {
        this.Id = entity.Id;
        this.Name = entity.Name;
    }
}