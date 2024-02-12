using ApiCatalogo.Dtos;
using ApiCatalogo.Pagination;
using AutoMapper;
using DSLearn.Dtos;
using DSLearn.Entities;
using DSLearn.Interfaces;
using DSLearn.Repositories.db;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DSLearn.Services
{
    public class UserService : IUserRepository
    {

        private readonly SystemDbContext _dbContext;
        private readonly UserManager<User> _userManager;


        public UserService(SystemDbContext dbContext, UserManager<User> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }



        public async Task<IEnumerable<UserDTO>> FindAllAsync(PageQueryParams pageQueryParams)
        {
            List<User> result = await _dbContext.Users.Where(p => p.UserName.Contains(pageQueryParams.Name))
           .OrderBy(p => p.UserName)
           .Skip((pageQueryParams.PageNumber - 1) * pageQueryParams.PageSize)
           .Take(pageQueryParams.PageSize)
           .AsNoTracking().ToListAsync();

            return result.AsEnumerable().Select(u => new UserDTO(u)).ToList(); ;
        }

        public async Task<UserDTO> FindByIdAsync(string id)
        {
            User entity = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id)
                ?? throw new ArgumentException("Resource not found");

            return new UserDTO(entity);
        }

        public UserDTO Update(RegisterUserDTO registerUserDTO, string id)
        {
            User entity = _dbContext.Users.Find(id)
                ?? throw new ArgumentException("Resource not found");

            copyDtoToEntity(registerUserDTO, entity);

            if (!string.IsNullOrEmpty(registerUserDTO.Password))
            {
                var newPasswordHash = _userManager.PasswordHasher.HashPassword(entity, registerUserDTO.Password);
                entity.PasswordHash = newPasswordHash;
            }

           

            return new UserDTO(entity);
        }



        public bool Delete(string id)
        {
            User entity =  _dbContext.Users.Find(id)
                ?? throw new ArgumentException("Resource not found");
            _dbContext.Users.Remove(entity);
            return true;
        }


        private void copyDtoToEntity(RegisterUserDTO registerUserDTO, User entity)
        {
            entity.Email = registerUserDTO.Email;
            entity.UserName = registerUserDTO.Username;
            entity.PhoneNumber = registerUserDTO.PhoneNumber;
            entity.PhoneNumberConfirmed = registerUserDTO.PhoneNumberIsConfirmed;
            entity.PasswordHash = registerUserDTO.Password;

        }
    }
}
