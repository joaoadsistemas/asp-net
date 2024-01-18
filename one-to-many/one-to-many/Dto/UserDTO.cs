using one_to_many.Entities;
using relation_one_to_many.Entities;

namespace one_to_many.Dto
{
    public class UserDTO
    {

        public UserDTO()
        {
            
        }

        public UserDTO(int Id, string Username)
        {
            this.Id = Id;
            this.Username = Username;
        }

        public UserDTO(User entity)
        {
            this.Id = entity.Id;
            this.Username = entity.Username;

            foreach (Character character in entity.Characters)
            {
                Characters.Add(new CharacterDTO(character));
            }
        }

        public int Id { get; set; }
        public string Username { get; set; }

        public List<CharacterDTO> Characters { get; set; } = new List<CharacterDTO>();

    }
}
