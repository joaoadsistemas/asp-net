using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using many_to_many.Entities;

namespace one_to_many.Entities
{
    public class Character
    {

        public Character()
        {
            
        }

        public Character(int Id, string Name, string PublishedBy)
        {
            this.Id = Id;
            this.Name = Name;
            this.PublishedBy = PublishedBy;
        }

        [Key()]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PublishedBy { get; set; }


        // configurando o outro lado MUITOS
        public List<Skill> Skills { get; set; } = new List<Skill>();


    }
}
