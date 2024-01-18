using one_to_many.Entities;
using relation_one_to_many.Entities;

namespace one_to_many.Dto
{
    public class CharacterDTO
    {
        public CharacterDTO()
        {

        }

        public CharacterDTO(int Id, string Name, string PublishedBy, int UserId)
        {
            this.Id = Id;
            this.Name = Name;
            this.PublishedBy = PublishedBy;
            this.UserId = UserId;
        }

        public CharacterDTO(Character entity)
        {
            this.Id = entity.Id;
            this.Name = entity.Name;
            this.PublishedBy = entity.PublishedBy;
            this.UserId = entity.UserId;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PublishedBy { get; set; }
        public int UserId { get; set; }
    }
}
