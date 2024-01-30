using eCommerce.Entities;

namespace eCommerce.API.Dtos;

public class UserInsertDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
    public char Genre { get; set; }
    public string Rg { get; set; }
    public string Cpf { get; set; }
    public string MotherName { get; set; }
    public char RegisterSituation { get; set; }
    public DateTimeOffset RegisterTime { get; set; }
        
    public ContactDTO Contact { get; set; }
        
    public List<int> DeliverAddressesId { get; set; } = new List<int>();

    public List<int> DepartmentsId { get; set; } = new List<int>();

    public UserInsertDTO()
    {
        
    }

    public UserInsertDTO(User entity)
    {
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
            this.DeliverAddressesId.Add(deliverAddress.Id);
        }

        foreach (Department department in entity.Departments)
        {
            this.DepartmentsId.Add(department.Id);
        }
        
    }
}