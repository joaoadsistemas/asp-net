using Microsoft.EntityFrameworkCore;
using one_to_many.Dto;
using one_to_many.Entities;
using one_to_many.Repositories;
using one_to_many.Repositories.db;
using User = relation_one_to_many.Entities.User;

namespace one_to_many.Services
{
    public class UserService : UserRepository
    {

        private readonly SystemDbContext _context;

        public UserService(SystemDbContext context)
        {
            _context = context;
        }



        public async Task<List<UserDTO>> FindAll()
        {
            List<User> result = _context.Users.Include(user => user.Characters).ToList();
            return result.AsEnumerable().Select(user => new UserDTO(user)).ToList();
        }

        public async Task<UserDTO> FindById(int id)
        {
            User user = _context.Users.Include(user => user.Characters).FirstOrDefault(u => u.Id == id) ?? throw new Exception("Resource not found");
            return new UserDTO(user);
        }

        public async Task<UserDTO> Insert(UserDTO dto)
        {
            User entity = new User();
            copyDTOToEntity(dto, entity);
            _context.Users.Add(entity);
            _context.SaveChanges();
            return new UserDTO(entity);
        }

        

        public async Task<UserDTO> Update(UserDTO dto, int id)
        {
            User user = _context.Users.FirstOrDefault(user => user.Id == id) ?? throw new Exception("Resource not found");
            copyDTOToEntity(dto, user);
            _context.SaveChanges();
            return new UserDTO(user);
        }

        public async Task<bool> DeleteById(int id)
        {
            User user = _context.Users.FirstOrDefault(user => user.Id == id) ?? throw new Exception("Resource not found");
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }


        private void copyDTOToEntity(UserDTO dto, User entity)
        {
            entity.Username = dto.Username;

            foreach (CharacterDTO characterDto in dto.Characters)
            {
                Character character = new Character();
                character.Name = characterDto.Name;
                character.PublishedBy = characterDto.PublishedBy;
                character.UserId = dto.Id;
                // talvez precise falvar no db o character aqui;
                entity.Characters.Add(character);
            }
        }
    }
}
