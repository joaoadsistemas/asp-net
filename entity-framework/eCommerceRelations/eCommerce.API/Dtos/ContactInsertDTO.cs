using eCommerce.Entities;

namespace eCommerce.API.Dtos;

public class ContactInsertDTO
{
    public string Phone { get; set; }
    public string CellPhone { get; set; }

    public ContactInsertDTO()
    {
        
    }

    public ContactInsertDTO(Contact entity)
    {
        this.Phone = entity.Phone;
        this.CellPhone = entity.CellPhone;
    }
}