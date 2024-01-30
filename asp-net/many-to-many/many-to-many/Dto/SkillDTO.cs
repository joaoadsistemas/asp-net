
using many_to_many.Entities;
using one_to_many.Dto;
using one_to_many.Entities;

namespace many_to_many.Dto
{
    public class SkillDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public int Damage { get; set; }

        public SkillDTO()
        {
            
        }

        public SkillDTO(int id, string name, int damage)
        {
            this.Id = id;
            this.Name = name;
            this.Damage = damage;
        }

        public SkillDTO(Skill entity)
        {
            
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.Damage = entity.Damage;


        }

    }
}
