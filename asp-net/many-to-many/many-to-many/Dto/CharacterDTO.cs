using many_to_many.Dto;
using many_to_many.Entities;
using one_to_many.Entities;

namespace one_to_many.Dto
{
    public class CharacterDTO
    {
        public CharacterDTO()
        {

        }

        public CharacterDTO(int Id, string Name, string PublishedBy)
        {
            this.Id = Id;
            this.Name = Name;
            this.PublishedBy = PublishedBy;
        }

        public CharacterDTO(Character entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.PublishedBy = entity.PublishedBy;

            foreach (Skill skill in entity.Skills)
            {
                Skills.Add(new SkillDTO(skill));
            }

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PublishedBy { get; set; }
        public List<SkillDTO> Skills { get; set; } = new List<SkillDTO>();
    }
}
