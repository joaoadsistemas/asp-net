using eCommerce.API.Database;
using eCommerce.API.Dtos;
using eCommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.API.Repositories;

public class UserRepository : IUserRepository
{

    private readonly SystemDbContext _dbContext;

    public UserRepository(SystemDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<List<UserDTO>> GetAll()
    {
        List<User> users = _dbContext.Users
            .Include(u => u.Contact)
            .Include(u => u.Departments)
            .Include(u => u.DeliverAddresses)
            .ToList();
        return users.AsEnumerable().Select(u => new UserDTO(u)).ToList();
    }

    public async Task<UserDTO> GetById(int id)
    {
        User entity = _dbContext.Users
            .Include(u => u.Contact)
            .Include(u => u.Departments)
            .Include(u => u.DeliverAddresses)
            .FirstOrDefault(u => u.Id == id) ?? throw new Exception("Resource not found");
        return new UserDTO(entity);

    }

    public void Insert(UserInsertDTO dto)
    {
        User entity = new User();
        copyDtoToEntity(dto, entity);
        _dbContext.Add(entity);
        _dbContext.SaveChanges();

    }

    public void Update(UserInsertDTO dto, int id)
    {
        User entity = _dbContext.Users
            .Include(u => u.Contact)
            .Include(u => u.Departments)
            .Include(u => u.DeliverAddresses)
            .FirstOrDefault(u => u.Id == id) ?? throw new Exception("Resource not found");
        copyDtoToEntity(dto, entity);
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        User entity = _dbContext.Users
            .Include(u => u.Contact)
            .Include(u => u.Departments)
            .Include(u => u.DeliverAddresses)
            .FirstOrDefault(u => u.Id == id) ?? throw new Exception("Resource not found");
        _dbContext.Remove(entity);
        _dbContext.SaveChanges();
    }
    
    private void copyDtoToEntity(UserInsertDTO dto, User entity)
    {
        entity.Name = dto.Name;
        entity.Email = dto.Email;
        entity.Genre = dto.Genre;
        entity.Rg = dto.Rg;
        entity.Cpf = dto.Cpf;
        entity.MotherName = dto.MotherName;
        entity.RegisterTime = dto.RegisterTime;
        entity.RegisterSituation = dto.RegisterSituation;

        Contact contact = new Contact();
        contact.Phone = dto.Contact.Phone;
        contact.CellPhone = dto.Contact.CellPhone;

        
        entity.Contact = contact;

        foreach (DeliverAddressInsertDTO deliverAddressInsertDto in dto.DeliverAddress)
        {

            DeliverAddress deliverAddress = new DeliverAddress();
            deliverAddress.AddressName = deliverAddressInsertDto.AddressName;
            deliverAddress.ZipCode = deliverAddressInsertDto.ZipCode;
            deliverAddress.State = deliverAddressInsertDto.State;
            deliverAddress.City = deliverAddressInsertDto.City;
            deliverAddress.Address = deliverAddressInsertDto.Address;
            deliverAddress.Number = deliverAddressInsertDto.Number;
            deliverAddress.Complement = deliverAddressInsertDto.Complement;

       
            entity.DeliverAddresses.Add(deliverAddress);
        }
        
        foreach (int deparmentId in dto.DepartmentsId)
        {
            entity.Departments.Add(_dbContext.Departments.Find(deparmentId) ?? null);
        }

    }
}