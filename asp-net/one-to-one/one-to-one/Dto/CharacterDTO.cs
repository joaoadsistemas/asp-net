using one_to_many.Entities;
using one_to_one.Dto;
using one_to_one.Entities;

namespace one_to_many.Dto
{
    public class CharacterDTO
    {
        public CharacterDTO()
        {

        }

        public CharacterDTO(int Id, string Name, string PublishedBy, WeaponDTO weapon)
        {
            this.Id = Id;
            this.Name = Name;
            this.PublishedBy = PublishedBy;
            this.Weapon = weapon;
        }

        public CharacterDTO(Character entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.PublishedBy = entity.PublishedBy;
            this.Weapon = new WeaponDTO(entity.Weapon);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PublishedBy { get; set; }
        public WeaponDTO Weapon { get; set; }
    }
}
