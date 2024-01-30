using System.ComponentModel.DataAnnotations;
using one_to_many.Entities;

namespace relation_one_to_many.Entities
{
    public class User
    {

        public User()
        {
            
        }

        public User(int Id, string Username)
        {
            this.Id = Id;
            this.Username = Username;
        }

        [Key()]
        public int Id { get; set; }
        public string Username { get; set; }


        // fazendo o relacionamento para muitos no lado UM
        public List<Character> Characters { get; set; } = new List<Character>();
    }
}
