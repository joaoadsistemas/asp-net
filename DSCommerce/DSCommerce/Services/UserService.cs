using DSCommerce.Dto;
using DSCommerce.Entities;
using DSCommerce.Repositories;
using DSCommerce.Repositories.db;
using Microsoft.EntityFrameworkCore;

namespace DSCommerce.Services
{
    public class UserService(SystemDbContext dbContext) : UserRepository
    {


        private readonly SystemDbContext _dbContext = dbContext;

        public async Task<List<UserDTO>> FindAll()
        {
            List<User> entity = dbContext.Users
                .Include(u => u.Orders)
                .ThenInclude(o => o.Payment)
                .Include(u => u.Orders)
                .ThenInclude(o => o.Items)
                .ThenInclude(i => i.Product)
                .ToList();

            return entity.Select(u => new UserDTO(u)).ToList();
        }



        public async Task<UserDTO> FindById(long id)
        {
            User entity = _dbContext.Users
                              .Include(u => u.Orders)
                              .ThenInclude(o => o.Payment)
                              .Include(u => u.Orders)
                              .ThenInclude(o => o.Items)
                              .ThenInclude(i => i.Product)
                              .SingleOrDefault(u => u.Id == id) 
                          ?? throw new Exception("Resource not found");

            return new UserDTO(entity);
        }

        public async Task<UserSimpleDTO> Insert(UserSimpleDTO dto)
        {
            User entity = new User();
            copyDtoToEntity(dto, entity);
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            return new UserSimpleDTO(entity);

        }


        public async Task<UserSimpleDTO> Update(UserSimpleDTO dto, long id)
        {
            User entity = _dbContext.Users.Include(u => u.Orders).SingleOrDefault(u => u.Id == id)
                          ?? throw new Exception("Resource not found");
            copyDtoToEntity(dto, entity);
            _dbContext.SaveChanges();
            return new UserSimpleDTO(entity);
        }

        public async Task<bool> DeleteById(long id)
        {
            User entity = _dbContext.Users.Include(u => u.Orders).SingleOrDefault(u => u.Id == id)
                          ?? throw new Exception("Resource not found");
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
            return true;
        }

        private void copyDtoToEntity(UserSimpleDTO dto, User entity)
        {
            entity.Name = dto.Name;
            entity.Email = dto.Email;
            entity.Phone = dto.Phone;
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);
            entity.Password = hashedPassword;

        }

    }
}
