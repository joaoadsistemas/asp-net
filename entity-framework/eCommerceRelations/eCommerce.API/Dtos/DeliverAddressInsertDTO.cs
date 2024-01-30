using eCommerce.Entities;

namespace eCommerce.API.Dtos;

public class DeliverAddressInsertDTO
{

    public string AddressName { get; set; }
    public string ZipCode { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string Number { get; set; }
    public string Complement { get; set; }
    
    
    public DeliverAddressInsertDTO()
    {
        
    }

    public DeliverAddressInsertDTO(DeliverAddress entity)
    {

        this.AddressName = entity.AddressName;
        this.ZipCode = entity.ZipCode;
        this.State = entity.State;
        this.City = entity.City;
        this.Address = entity.Address;
        this.Number = entity.Number;
        this.Complement = entity.Complement;

    }
}