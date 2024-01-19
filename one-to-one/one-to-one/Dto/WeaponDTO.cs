using one_to_one.Entities;

namespace one_to_one.Dto
{
    public class WeaponDTO
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Demage { get; set; }

        public int CharacterId { get; set; }


        public WeaponDTO()
        {
            
        }

        public WeaponDTO(int id, string name, int demage, int characterId)
        {
            this.Id = id;
            this.Name = name;
            this.Demage = demage;
            this.CharacterId = characterId;
        }

        public WeaponDTO(Weapon entity)
        {
            
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.Demage = entity.Demage;
            this.CharacterId = entity.CharacterId;

        }


    }
}
