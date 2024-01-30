using eCommerce.Entities;

namespace eCommerce.API.Dtos;

public class DeliverAddressDTO
{
    public int Id { get; set; }
    public string AddressName { get; set; }
    public string ZipCode { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string Number { get; set; }
    public string Complement { get; set; }
    
    public int UserId { get; set; }

    public DeliverAddressDTO()
    {
        
    }

    public DeliverAddressDTO(DeliverAddress entity)
    {
        this.Id = entity.Id;
        this.AddressName = entity.AddressName;
        this.ZipCode = entity.ZipCode;
        this.State = entity.State;
        this.City = entity.City;
        this.Address = entity.Address;
        this.Number = entity.Number;
        this.Complement = entity.Complement;
        this.UserId = entity.UserId;
    }
}