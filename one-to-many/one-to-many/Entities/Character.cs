using System.ComponentModel.DataAnnotations;
using relation_one_to_many.Entities;

namespace one_to_many.Entities
{
    public class Character
    {

        public Character()
        {
            
        }

        public Character(int Id, string Name, string PublishedBy, int UserId)
        {
            this.Id = Id;
            this.Name = Name;
            this.PublishedBy = PublishedBy;
            this.UserId = UserId;
        }

        [Key()]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PublishedBy { get; set; }
        
        // fazendo a foreign key no lado MUITOS
        public User User { get; set; }
        public int UserId { get; set; }

    }
}
