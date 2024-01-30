using eCommerce.Entities;

namespace eCommerce.API.Dtos;

public class ContactDTO
{
    public int Id { get; set; }
    public string Phone { get; set; }
    public string CellPhone { get; set; }
    public int UserId { get; set; }

    public ContactDTO()
    {
        
    }

    public ContactDTO(Contact entity)
    {
        this.Id = entity.Id;
        this.Phone = entity.Phone;
        this.CellPhone = entity.CellPhone;
        this.UserId = entity.UserId;
    }
    
}