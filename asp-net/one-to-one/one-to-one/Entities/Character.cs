using System.ComponentModel.DataAnnotations;
using one_to_one.Entities;

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


        // adicionando o relacionamento no outro lado UM
        public Weapon Weapon { get; set; }
        
        

    }
}
