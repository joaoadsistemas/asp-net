using eCommerce.Entities;

namespace eCommerce.API.Dtos;

public class UserDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public char Genre { get; set; }
    public string Rg { get; set; }
    public string Cpf { get; set; }
    public string MotherName { get; set; }
    public char RegisterSituation { get; set; }
    public DateTimeOffset RegisterTime { get; set; }
        
    public ContactDTO Contact { get; set; }
        
    public List<DeliverAddressDTO> DeliverAddresses { get; set; } = new List<DeliverAddressDTO>();

    public List<DepartmentDTO> Departments { get; set; } = new List<DepartmentDTO>();

    public UserDTO()
    {
        
    }

    public UserDTO(User entity)
    {
        Id = entity.Id;
        Name = entity.Name;
        Email = entity.Email;
        Genre = entity.Genre;
        Rg = entity.Rg;
        Cpf = entity.Cpf;
        MotherName = entity.MotherName;
        RegisterSituation = entity.RegisterSituation;
        RegisterTime = entity.RegisterTime;
        Contact = new ContactDTO(entity.Contact);

        foreach (DeliverAddress deliverAddress in entity.DeliverAddresses)
        {
            this.DeliverAddresses.Add(new DeliverAddressDTO(deliverAddress));
        }

        foreach (Department department in entity.Departments)
        {
            this.Departments.Add(new DepartmentDTO(department));
        }
        
    }
}