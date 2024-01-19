using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using one_to_many.Entities;

namespace one_to_one.Entities
{
    public class Weapon
    {

        [Key()]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Demage { get; set; }

        // fazendo o relacionamento e adicionando a chave estrangeira em um dos lados ONE
        [JsonIgnore] // tirar o ciclo infinito de um chamar o outro
        public Character Character { get; set; }
        public int CharacterId { get; set; }



        public Weapon()
        {
            
        }

    }
}
