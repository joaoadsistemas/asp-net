using Microsoft.EntityFrameworkCore;
using one_to_many.Dto;
using one_to_many.Entities;
using one_to_many.Repositories;
using one_to_many.Repositories.db;
using one_to_one.Entities;

namespace one_to_many.Services
{
    public class CharacterService : CharacterRepository
    {

        private readonly SystemDbContext _context;

        public CharacterService(SystemDbContext context)
        {
            _context = context;
        }

        public async Task<List<CharacterDTO>> FindAll()
        {
            List<Character> result = _context.Characters.Include(character => character.Weapon).ToList();
            return result.AsEnumerable().Select(c => new CharacterDTO(c)).ToList();
        }

        public async Task<CharacterDTO> FindById(int id)
        {
            Character result = _context.Characters.Include(character => character.Weapon).FirstOrDefault(c => c.Id == id) ??
                               throw new Exception("Resource not found");
            return new CharacterDTO(result);
        }

        public async Task<CharacterDTO> Insert(CharacterDTO dto)
        {
            Character entity = new Character();
            copyDTOToEntity(dto, entity);
            _context.Characters.Add(entity);
            _context.SaveChanges();
            return new CharacterDTO(entity);
        }


        public async Task<CharacterDTO> Update(CharacterDTO dto, int id)
        {
            Character entity = _context.Characters.FirstOrDefault(c => c.Id == id) ??
                               throw new Exception("Resource not found");
            copyDTOToEntity(dto, entity);
            _context.SaveChanges();
            return new CharacterDTO(entity);
        }

        public async Task<bool> DeleteById(int id)
        {
            Character entity = _context.Characters.FirstOrDefault(character => character.Id == id) ?? throw new Exception("Resource not found");
            _context.Characters.Remove(entity);
            _context.SaveChanges();
            return true;
        }


        private void copyDTOToEntity(CharacterDTO dto, Character entity)
        {
            entity.Name = dto.Name;
            entity.PublishedBy = dto.PublishedBy;

            Weapon weapon = new Weapon();
            weapon.Name = dto.Weapon.Name;
            weapon.Demage = dto.Weapon.Demage;
            weapon.CharacterId = dto.Id;

            entity.Weapon = weapon;

        }
    }
}
